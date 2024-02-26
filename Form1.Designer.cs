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
            splitter1 = new Splitter();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Left;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(190, 450);
            treeView1.TabIndex = 0;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(190, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(610, 450);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Filename";
            columnHeader1.Width = 200;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(190, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(8, 450);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitter1);
            Controls.Add(listView1);
            Controls.Add(treeView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private ListView listView1;
        private Splitter splitter1;
        private ColumnHeader columnHeader1;
    }
}
