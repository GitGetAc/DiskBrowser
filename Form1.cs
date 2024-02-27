using System.Diagnostics;
using System.IO.Compression;

namespace DiskBrowser
{
    public partial class Form1 : Form
    {
        ImageList? imageList1; //ImageList

        public Form1()
        {
            InitializeComponent();
        }

        private void ShowDrives()
        {
            //Begin 
            treeView1.BeginUpdate();

            //Array with Drivenames
            string[] drives = Directory.GetLogicalDrives();

            //Fill out nodes with drivenames
            foreach (var drive in drives)
            {
                TreeNode treeNode = new TreeNode(drive);
                treeView1.Nodes.Add(treeNode);

                //Calling AddDirs in ShowDrives()
                AddDirs(treeNode);
            }

            //End
            treeView1.EndUpdate();
        }

        private void ShowFileNames()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(treeView1.SelectedNode.FullPath);
            FileInfo[] filesArray = { };
            ListViewItem listViewItem;

            imageList1 = new ImageList();
            listView1.Items.Clear();
            listView1.SmallImageList = imageList1;

            if (directoryInfo.Exists)
            {
                filesArray = directoryInfo.GetFiles(); //Todo 1.: Exception handling
            }

            listView1.BeginUpdate();

            foreach (FileInfo fileInfo in filesArray)
            {
                Icon? iconForFile;

                listViewItem = new ListViewItem(fileInfo.Name);
                listView1.Items.Add(listViewItem);

                iconForFile = SystemIcons.WinLogo;

                //Checking if the image collection contains an image for this extension, using the extension as a key
                if (!imageList1.Images.ContainsKey(fileInfo.Extension))
                {
                    //If not, add the image to the image list.
                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName);
                    imageList1.Images.Add(fileInfo.Extension, iconForFile);
                }

                listViewItem.ImageKey = fileInfo.Extension;
                listViewItem.SubItems.Add(fileInfo.Length.ToString() + " bytes");
                listViewItem.SubItems.Add(fileInfo.LastWriteTime.ToString());
                listViewItem.SubItems.Add(GetAttributes(fileInfo));
            }

            listView1.EndUpdate();
        }

        private void AddDirs(TreeNode treeNode)
        {
            string fullPath = treeNode.FullPath;
            DirectoryInfo directoryPath = new DirectoryInfo(fullPath);
            DirectoryInfo[] directoryArray = { };

            try
            {
                if (directoryPath.Exists)
                {
                    directoryArray = directoryPath.GetDirectories();
                }
            }
            catch (Exception)
            {
                return;
            }

            foreach (DirectoryInfo directory in directoryArray)
            {
                TreeNode treeNodeDir = new TreeNode(directory.Name);
                treeNode.Nodes.Add(treeNodeDir);
            }
        }

        private String GetAttributes(FileInfo fileInfo)
        {
            string attributes = "";

            if ((fileInfo.Attributes & FileAttributes.Archive) != 0) attributes += "A";
            if ((fileInfo.Attributes & FileAttributes.Hidden) != 0) attributes += "H";
            if ((fileInfo.Attributes & FileAttributes.ReadOnly) != 0) attributes += "R";
            if ((fileInfo.Attributes & FileAttributes.System) != 0) attributes += "S";

            return attributes;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowDrives();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowFileNames();
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeView1.BeginUpdate();

            foreach (TreeNode treeNodeItem in e.Node.Nodes)
            {
                AddDirs(treeNodeItem);          //Todo 3.: Prevent directory duplication
            }

            treeView1.EndUpdate();
        }

        private string SelectedFilePath()
        {
            string diskFile = treeView1.SelectedNode.FullPath;

            if (!diskFile.EndsWith("\\")) diskFile += "\\";

            diskFile += listView1.FocusedItem.Text;

            return diskFile;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string diskFile = SelectedFilePath();

            if (File.Exists(diskFile)) Process.Start(new ProcessStartInfo { FileName = diskFile, UseShellExecute = true });
        }

        private void ZipFolder(string path)
        {
            string zFile;

            if (Directory.GetDirectoryRoot(path) == path)
            {
                MessageBox.Show($"Sorry! I will not allow you to zip the entire {path} disk!");
            }
            else
            {
                zFile = $"{path}.zip";
                MessageBox.Show($"About to zip {path} to {zFile} -- That can take some time...");
                ZipFile.CreateFromDirectory(path, zFile);   //Todo 2.: Set compression level

                MessageBox.Show(Path.GetFileName(path) + ".zip has been created!");
            }
        }

        private void UnZip(string dir, string zipfile)
        {
            string zipdir;

            zipdir = dir + "\\extractdir";
            MessageBox.Show($"About to unzip {zipfile} to {zipdir}");
            ZipFile.ExtractToDirectory(zipfile, zipdir, true);
        }

        private void ziptoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TreeNode treeNode;
            string path;

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            treeNode = treeView1.SelectedNode;
            if (treeNode == null)
            {
                MessageBox.Show("No directory selected!");
            }
            else
            {
                path = treeNode.FullPath;
                result = MessageBox.Show($"Zip {path}?", "Zip this directory", buttons);

                //Test result of the button press
                if(result == System.Windows.Forms.DialogResult.Yes) 
                {
                    ZipFolder(path);
                }
                else
                {
                    MessageBox.Show("Cancelled!");
                }
            }

        }

        private void unziptoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string diskFile;
            string fileExtension;
            string dir;
            TreeNode treeNode;

            MessageBoxButtons buttons;
            DialogResult result;

            buttons = MessageBoxButtons.YesNo;
            diskFile = SelectedFilePath();
            dir = treeView1.SelectedNode.FullPath;
            fileExtension = Path.GetExtension(diskFile).ToLower();

            treeNode = treeView1.SelectedNode;

            if(diskFile == "")
            {
                MessageBox.Show("No file selected!");
            }
            else if (fileExtension != ".zip")
            {
                MessageBox.Show("File is not a zip archive!");
            }
            else
            {
                result = MessageBox.Show($"Unzip {diskFile}?", "Unzip this ZipFile", buttons);

                if(result == DialogResult.Yes)
                {
                    UnZip(dir, diskFile);
                    AddDirs(treeNode);  //Updates subdirectories under treenode
                    MessageBox.Show($"{diskFile} has been unzipped!");
                }
                else
                {
                    MessageBox.Show("Cancelled!");
                }
            }
            
        }
    }
}

/*
 Todo 1.: Exception handling
 Todo 2.: Set compression level
 Todo 3.: Prevent directory duplication
*/
