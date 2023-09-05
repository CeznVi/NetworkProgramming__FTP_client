using System.Net;

namespace FTP_CLIENT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button_connect_Click(object sender, EventArgs e)
        {

            Connect();
        }


        public void Connect()
        {
            treeView_server.Nodes.Clear();

            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(textBox_host.Text);
            ftpWebRequest.Credentials = new NetworkCredential(textBox_login.Text, textBox_pasw.Text);

            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();

            Stream streamReaderResponce = ftpWebResponse.GetResponseStream();

            StreamReader streamReader = new StreamReader(streamReaderResponce);

            string tmp; string[] t;

            while (!streamReader.EndOfStream)
            {
                tmp = streamReader.ReadLine();

                t = tmp.Split(' ', StringSplitOptions.None);

                tmp = string.Empty;

                for (int i = 15; i < t.Length; i++)
                {
                    tmp += t[i];
                    tmp += " ";
                }

                if (tmp.Length > 0)
                {
                    treeView_server.Nodes.Add(tmp);
                }
            }

            treeView_server.Update();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (treeView_server.SelectedNode != null)
            {
                Uri uriDeleteFile = new Uri(textBox_host.Text + treeView_server.SelectedNode.Text);

                if (uriDeleteFile.Scheme != Uri.UriSchemeFtp)
                {
                    MessageBox.Show("Некоректный адресс");
                    return;
                }

                FtpWebRequest ftpWebRequestDeleteFile = (FtpWebRequest)WebRequest.Create(uriDeleteFile);
                ftpWebRequestDeleteFile.Credentials = new NetworkCredential(textBox_login.Text, textBox_pasw.Text);
                ftpWebRequestDeleteFile.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse ftpWebResponseDeleteFile = (FtpWebResponse)ftpWebRequestDeleteFile.GetResponse();

                MessageBox.Show($"Status description: {ftpWebResponseDeleteFile.StatusDescription}");


                Connect();
            }

        }

        private void button_rename_Click(object sender, EventArgs e)
        {
            if (treeView_server.SelectedNode != null)
            {

                Uri uriRenameFile = new Uri(textBox_host.Text + treeView_server.SelectedNode.Text);


                if (uriRenameFile.Scheme != Uri.UriSchemeFtp)
                {
                    MessageBox.Show("Некоректный адресс");
                    return;
                }

                try
                {
                    FtpWebRequest ftpWebRequestRename = (FtpWebRequest)WebRequest.Create(uriRenameFile);
                    ftpWebRequestRename.Credentials = new NetworkCredential(textBox_login.Text, textBox_pasw.Text);
                    ftpWebRequestRename.Method = WebRequestMethods.Ftp.Rename;


                    ftpWebRequestRename.RenameTo = textBox_fname.Text + treeView_server.SelectedNode.Text;


                    FtpWebResponse ftpWebResponseRenameFile = (FtpWebResponse)ftpWebRequestRename.GetResponse();

                    MessageBox.Show($"Status description: {ftpWebResponseRenameFile.StatusDescription}");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}