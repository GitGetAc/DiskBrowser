namespace DiskBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ShowDrives()
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

        public void ShowFileNames()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(treeView1.SelectedNode.FullPath);
            FileInfo[] filesArray = { };
            ListViewItem listViewItem;

            listView1.Items.Clear();

            if (directoryInfo.Exists)
            {
                filesArray = directoryInfo.GetFiles(); //Todo 1.: Exception handling
            }

            listView1.BeginUpdate();

            foreach (FileInfo fileInfo in filesArray)
            {
                listViewItem = new ListViewItem(fileInfo.Name);
                listView1.Items.Add(listViewItem);
            }

            listView1.EndUpdate();
        }

        public void AddDirs(TreeNode treeNode)
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
                AddDirs(treeNodeItem);
            }

            treeView1.EndUpdate();
        }
    }
}

/*Todo:
 1. Exception handling
 
 */
