using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP_CLIENT
{
    public partial class ReNameForm : Form
    {
        public string NewName { get; private set; }

        public ReNameForm()
        {
            InitializeComponent();
        }

        public ReNameForm(string oldName)
        {
            InitializeComponent();
            textBox_newName.Text = oldName;
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if (textBox_newName.Text.Length >= 1)
            {
                NewName = textBox_newName.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Заполните поле для ввода", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Сancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReNameForm_Load(object sender, EventArgs e)
        {

        }

    }
}
