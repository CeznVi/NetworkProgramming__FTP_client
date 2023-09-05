namespace FTP_CLIENT
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            label1 = new Label();
            textBox_login = new TextBox();
            textBox_pasw = new TextBox();
            label_pass = new Label();
            textBox_host = new TextBox();
            label2 = new Label();
            button_connect = new Button();
            treeView_server = new TreeView();
            button_Delete = new Button();
            button_rename = new Button();
            label3 = new Label();
            textBox_fname = new TextBox();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ButtonFace;
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(39, 17);
            toolStripStatusLabel.Text = "Ready";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(220, 24);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 2;
            label1.Text = "Login:";
            // 
            // textBox_login
            // 
            textBox_login.Location = new Point(266, 21);
            textBox_login.Name = "textBox_login";
            textBox_login.Size = new Size(100, 23);
            textBox_login.TabIndex = 3;
            textBox_login.Text = "ftp";
            // 
            // textBox_pasw
            // 
            textBox_pasw.Location = new Point(411, 21);
            textBox_pasw.Name = "textBox_pasw";
            textBox_pasw.Size = new Size(100, 23);
            textBox_pasw.TabIndex = 5;
            textBox_pasw.Text = "ftp";
            // 
            // label_pass
            // 
            label_pass.AutoSize = true;
            label_pass.Location = new Point(372, 24);
            label_pass.Name = "label_pass";
            label_pass.Size = new Size(33, 15);
            label_pass.TabIndex = 4;
            label_pass.Text = "Pass:";
            // 
            // textBox_host
            // 
            textBox_host.Location = new Point(48, 21);
            textBox_host.Name = "textBox_host";
            textBox_host.Size = new Size(166, 23);
            textBox_host.TabIndex = 7;
            textBox_host.Text = "ftp://127.0.0.1/";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 24);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 6;
            label2.Text = "Host:";
            // 
            // button_connect
            // 
            button_connect.Location = new Point(607, 20);
            button_connect.Name = "button_connect";
            button_connect.Size = new Size(181, 23);
            button_connect.TabIndex = 8;
            button_connect.Text = "Connect/Update";
            button_connect.UseVisualStyleBackColor = true;
            button_connect.Click += button_connect_Click;
            // 
            // treeView_server
            // 
            treeView_server.Location = new Point(5, 50);
            treeView_server.Name = "treeView_server";
            treeView_server.Size = new Size(588, 362);
            treeView_server.TabIndex = 9;
            // 
            // button_Delete
            // 
            button_Delete.Location = new Point(607, 62);
            button_Delete.Name = "button_Delete";
            button_Delete.Size = new Size(181, 23);
            button_Delete.TabIndex = 10;
            button_Delete.Text = "Delete";
            button_Delete.UseVisualStyleBackColor = true;
            button_Delete.Click += button_Delete_Click;
            // 
            // button_rename
            // 
            button_rename.Location = new Point(607, 155);
            button_rename.Name = "button_rename";
            button_rename.Size = new Size(181, 23);
            button_rename.TabIndex = 11;
            button_rename.Text = "Rename";
            button_rename.UseVisualStyleBackColor = true;
            button_rename.Click += button_rename_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(623, 108);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 12;
            label3.Text = "New File Name";
            // 
            // textBox_fname
            // 
            textBox_fname.Location = new Point(607, 126);
            textBox_fname.Name = "textBox_fname";
            textBox_fname.Size = new Size(116, 23);
            textBox_fname.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox_fname);
            Controls.Add(label3);
            Controls.Add(button_rename);
            Controls.Add(button_Delete);
            Controls.Add(treeView_server);
            Controls.Add(button_connect);
            Controls.Add(textBox_host);
            Controls.Add(label2);
            Controls.Add(textBox_pasw);
            Controls.Add(label_pass);
            Controls.Add(textBox_login);
            Controls.Add(label1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "FTP3000";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private Label label1;
        private TextBox textBox_login;
        private TextBox textBox_pasw;
        private Label label_pass;
        private TextBox textBox_host;
        private Label label2;
        private Button button_connect;
        private TreeView treeView_server;
        private Button button_Delete;
        private Button button_rename;
        private Label label3;
        private TextBox textBox_fname;
    }
}