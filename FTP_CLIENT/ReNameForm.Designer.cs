namespace FTP_CLIENT
{
    partial class ReNameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox_newName = new TextBox();
            button_Ok = new Button();
            button_Сancel = new Button();
            SuspendLayout();
            // 
            // textBox_newName
            // 
            textBox_newName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_newName.Location = new Point(12, 12);
            textBox_newName.Name = "textBox_newName";
            textBox_newName.Size = new Size(312, 29);
            textBox_newName.TabIndex = 0;
            // 
            // button_Ok
            // 
            button_Ok.BackColor = Color.LawnGreen;
            button_Ok.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button_Ok.ForeColor = SystemColors.ControlText;
            button_Ok.Location = new Point(12, 57);
            button_Ok.Name = "button_Ok";
            button_Ok.Size = new Size(135, 46);
            button_Ok.TabIndex = 1;
            button_Ok.Text = "Да";
            button_Ok.UseVisualStyleBackColor = false;
            button_Ok.Click += button_Ok_Click;
            // 
            // button_Сancel
            // 
            button_Сancel.BackColor = Color.Red;
            button_Сancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button_Сancel.Location = new Point(189, 57);
            button_Сancel.Name = "button_Сancel";
            button_Сancel.Size = new Size(135, 46);
            button_Сancel.TabIndex = 2;
            button_Сancel.Text = "НЕТ";
            button_Сancel.UseVisualStyleBackColor = false;
            button_Сancel.Click += button_Сancel_Click;
            // 
            // ReNameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 118);
            Controls.Add(button_Сancel);
            Controls.Add(button_Ok);
            Controls.Add(textBox_newName);
            FormBorderStyle = FormBorderStyle.None;
            MinimizeBox = false;
            Name = "ReNameForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReNameForm";
            Load += ReNameForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_newName;
        private Button button_Ok;
        private Button button_Сancel;
    }
}