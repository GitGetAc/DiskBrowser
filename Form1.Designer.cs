namespace DiskBrowser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            treeView1 = new TreeView();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            splitter1 = new Splitter();
            menuStrip1 = new MenuStrip();
            zipToolStripMenuItem = new ToolStripMenuItem();
            ziptoolStripMenuItem1 = new ToolStripMenuItem();
            unziptoolStripMenuItem2 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Left;
            treeView1.Location = new Point(0, 24);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(350, 737);
            treeView1.TabIndex = 0;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(350, 24);
            listView1.Name = "listView1";
            listView1.Size = new Size(658, 737);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Filename";
            columnHeader1.Width = 350;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Size";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Modified";
            columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Attributes";
            columnHeader4.Width = 80;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(350, 24);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(8, 737);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { zipToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1008, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // zipToolStripMenuItem
            // 
            zipToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ziptoolStripMenuItem1, unziptoolStripMenuItem2 });
            zipToolStripMenuItem.Name = "zipToolStripMenuItem";
            zipToolStripMenuItem.Size = new Size(36, 20);
            zipToolStripMenuItem.Text = "Zip";
            // 
            // ziptoolStripMenuItem1
            // 
            ziptoolStripMenuItem1.Name = "ziptoolStripMenuItem1";
            ziptoolStripMenuItem1.Size = new Size(189, 22);
            ziptoolStripMenuItem1.Text = "Zip Selected Directory";
            ziptoolStripMenuItem1.Click += ziptoolStripMenuItem1_Click;
            // 
            // unziptoolStripMenuItem2
            // 
            unziptoolStripMenuItem2.Name = "unziptoolStripMenuItem2";
            unziptoolStripMenuItem2.Size = new Size(189, 22);
            unziptoolStripMenuItem2.Text = "Unzip Archive";
            unziptoolStripMenuItem2.Click += unziptoolStripMenuItem2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 761);
            Controls.Add(splitter1);
            Controls.Add(listView1);
            Controls.Add(treeView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private ListView listView1;
        private Splitter splitter1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem zipToolStripMenuItem;
        private ToolStripMenuItem ziptoolStripMenuItem1;
        private ToolStripMenuItem unziptoolStripMenuItem2;
    }
}
