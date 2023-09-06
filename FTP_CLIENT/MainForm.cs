using Microsoft.VisualBasic.FileIO;
using System.Net;

namespace FTP_CLIENT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            treeView_server.ContextMenuStrip = contextMenuStrip_forTree;
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            UpdateView();
        }


        ///Оновить древо
        private void UpdateView()
        {
            treeView_server.Nodes.Clear();
            TreeNode rootNode = new TreeNode(textBox_host.Text);
            treeView_server.Nodes.Add(rootNode);

            UpdTreeView(textBox_host.Text, textBox_login.Text, textBox_pasw.Text, "", rootNode);
        }

        /// <summary>
        /// Рекурсионный метод для обновление дерева и данных вложености
        /// </summary>
        private void UpdTreeView(string ftpServer, string ftpUsername, string ftpPassword, string ftpPath, TreeNode parentNode)
        {
            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(ftpServer + ftpPath);
            ftpWebRequest.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            try
            {
                FtpWebResponse ftpResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
                Stream streamReaderResponse = ftpResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(streamReaderResponse);

                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 9)
                    {

                        string itemName = string.Empty;

                        for (int i = 8; i < parts.Length; i++)
                        {
                            if (parts.Length - 8 == 0)
                                itemName += parts[i];
                            else
                            {
                                if (i < parts.Length - 1)
                                    itemName += parts[i] + " ";
                                else
                                    itemName += parts[i];
                            }
                        }

                        TreeNode itemNode = new TreeNode(itemName);

                        if (line.StartsWith("d"))
                        {
                            itemNode.Tag = "Directory";
                            UpdTreeView(ftpServer, ftpUsername, ftpPassword, ftpPath + "/" + itemName, itemNode);
                        }
                        else
                        {
                            string fileExtension = Path.GetExtension(itemName);

                            if (!string.IsNullOrEmpty(fileExtension))
                            {
                                itemNode.Tag = "File";
                            }
                        }
                        parentNode.Nodes.Add(itemNode);
                    }
                }
            }
            catch (WebException webx)
            {
                MessageBox.Show("Ошибка при подключении к FTP-серверу: \n" + webx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ///--------------------------------------------------------Контектсное меню вызов cобытий

        // удалить
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckSelectedItemTree())
                DeleteSelectedItem();

        }
        // скачать
        private void скачатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckSelectedItemTree())
                DownloadSelectedItem();
        }
        /// Переименовать
        private void переименоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckSelectedItemTree())
                RenameSelectedItem();
        }
        //Загрузить на сервер

        private void загрузитьНаСерверToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadSelectedItem();
        }
        ///////--------------------------------------------------------------------END

        ///--------------------------------------------------------Кнопки вызов cобытий

        //УДАЛИТЬ
        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (CheckSelectedItemTree())
                DeleteSelectedItem();
        }
        //СКАЧАТЬ
        private void button_download_Click(object sender, EventArgs e)
        {
            if (CheckSelectedItemTree())
                DownloadSelectedItem();
        }
        ///Переименовать
        private void button_rename_Click(object sender, EventArgs e)
        {
            if (CheckSelectedItemTree())
                RenameSelectedItem();
        }
        //Загрузить на сервер
        private void button_uploadFile_Click(object sender, EventArgs e)
        {
            UploadSelectedItem();
        }

        ///////--------------------------------------------------------------------END

        ///--------------------------------------------------------МЕТОДЫ реализации действий

        //******************        УДАЛЕНИЕ //
        private void DeleteSelectedItem()
        {
            if (isSelectedItemDirectory())
            {
                DeleteDirectory();
            }
            else if (isSelectedItemFile())
            {
                DeleteFile();
            }
            else
                return;
        }
        private void DeleteDirectory()
        {
            string deletePath = treeView_server.SelectedNode.FullPath;

            try
            {
                foreach (TreeNode item in treeView_server.SelectedNode.Nodes)
                {
                    DeleteFileFromLink(item.FullPath);
                }

                Uri uriDeleteFile = new Uri(deletePath);

                if (uriDeleteFile.Scheme != Uri.UriSchemeFtp)
                {
                    MessageBox.Show("Некоректный адресс");
                    return;
                }

                FtpWebRequest ftpWebRequestDeleteFile = (FtpWebRequest)WebRequest.Create(uriDeleteFile);
                ftpWebRequestDeleteFile.Credentials = new NetworkCredential(textBox_login.Text, textBox_pasw.Text);
                ftpWebRequestDeleteFile.Method = WebRequestMethods.Ftp.RemoveDirectory;

                FtpWebResponse ftpWebResponseDeleteFile = (FtpWebResponse)ftpWebRequestDeleteFile.GetResponse();

                toolStripStatusLabel.Text = ftpWebResponseDeleteFile.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            UpdateView();
        }
        private void DeleteFile()
        {
            string deletePath = treeView_server.SelectedNode.FullPath;

            try
            {
                Uri uriDeleteFile = new Uri(deletePath);

                if (uriDeleteFile.Scheme != Uri.UriSchemeFtp)
                {
                    MessageBox.Show("Некоректный адресс");
                    return;
                }

                FtpWebRequest ftpWebRequestDeleteFile = (FtpWebRequest)WebRequest.Create(uriDeleteFile);
                ftpWebRequestDeleteFile.Credentials = new NetworkCredential(textBox_login.Text, textBox_pasw.Text);
                ftpWebRequestDeleteFile.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse ftpWebResponseDeleteFile = (FtpWebResponse)ftpWebRequestDeleteFile.GetResponse();

                toolStripStatusLabel.Text = ftpWebResponseDeleteFile.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            UpdateView();
        }
        private void DeleteFileFromLink(string link)
        {
            try
            {
                Uri uriDeleteFile = new Uri(link);

                if (uriDeleteFile.Scheme != Uri.UriSchemeFtp)
                {
                    MessageBox.Show("Некоректный адресс");
                    return;
                }

                FtpWebRequest ftpWebRequestDeleteFile = (FtpWebRequest)WebRequest.Create(uriDeleteFile);
                ftpWebRequestDeleteFile.Credentials = new NetworkCredential(textBox_login.Text, textBox_pasw.Text);
                ftpWebRequestDeleteFile.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse ftpWebResponseDeleteFile = (FtpWebResponse)ftpWebRequestDeleteFile.GetResponse();

                toolStripStatusLabel.Text = ftpWebResponseDeleteFile.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //******************        СКАЧАТЬ //
        private void DownloadSelectedItem()
        {
            if (isSelectedItemFile())
            {
                DownloadFile();
            }
            else
                return;
        }
        private void DownloadFile()
        {
            string downloadPath = treeView_server.SelectedNode.FullPath;

            try
            {

                Uri uriDownloadFile = new Uri(downloadPath);

                if (uriDownloadFile.Scheme != Uri.UriSchemeFtp)
                {
                    MessageBox.Show("Некоректный адресс");
                    return;
                }

                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.UseDescriptionForTitle = true;
                folderBrowserDialog.Description = "Выбирите папку в которую необходимо скачать файл";
                string pathToSaveFile;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    pathToSaveFile = folderBrowserDialog.SelectedPath;
                    pathToSaveFile += "\\" + treeView_server.SelectedNode.Text;
                }
                else
                    return;

                FtpWebRequest ftpWebRequestDownloadFile = (FtpWebRequest)WebRequest.Create(uriDownloadFile);
                ftpWebRequestDownloadFile.Credentials = new NetworkCredential(textBox_login.Text, textBox_pasw.Text);
                ftpWebRequestDownloadFile.Method = WebRequestMethods.Ftp.DownloadFile;

                FtpWebResponse ftpWebResponseDownloadFile = (FtpWebResponse)ftpWebRequestDownloadFile.GetResponse();


                Stream streamDownloadFile = ftpWebResponseDownloadFile.GetResponseStream();

                List<byte> downloadFileList = new List<byte>();

                int data = 0;
                while ((data = streamDownloadFile.ReadByte()) != -1)
                {
                    downloadFileList.Add((byte)data);
                }

                File.WriteAllBytes(pathToSaveFile, downloadFileList.ToArray());


                toolStripStatusLabel.Text = ftpWebResponseDownloadFile.StatusDescription;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            UpdateView();
        }

        //******************        Переименовать //

        private void RenameSelectedItem()
        {
            ReNameForm reNameForm = new ReNameForm(treeView_server.SelectedNode.Text);

            if (reNameForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Uri uriReNameObj = new Uri(treeView_server.SelectedNode.FullPath);

                    if (uriReNameObj.Scheme != Uri.UriSchemeFtp)
                    {
                        MessageBox.Show("Некоректный адресс");
                        return;
                    }

                    FtpWebRequest ftpWebRequestReNameObj = (FtpWebRequest)WebRequest.Create(uriReNameObj);
                    ftpWebRequestReNameObj.Credentials = new NetworkCredential(textBox_login.Text, textBox_pasw.Text);
                    ftpWebRequestReNameObj.Method = WebRequestMethods.Ftp.Rename;
                    ftpWebRequestReNameObj.RenameTo = reNameForm.NewName;

                    FtpWebResponse ftpWebResponseReNameObj = (FtpWebResponse)ftpWebRequestReNameObj.GetResponse();

                    toolStripStatusLabel.Text = ftpWebResponseReNameObj.StatusDescription;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                UpdateView();
            }
            else
            {
                return;
            }

        }

        //******************        Загрузка на ФТП //
        private void UploadSelectedItem()
        {

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Выбирите файл который необходимо загрузить";


            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream fsUpload = new FileStream(fileDialog.FileName, FileMode.Open);
                    
                    byte[] fileUploadByte = new byte[fsUpload.Length];
                    fsUpload.Read(fileUploadByte, 0, fileUploadByte.Length);

                    Uri uriUploadFile = new Uri(GetCurrentPath() + "/" + Path.GetFileName(fileDialog.FileName));
                    //MessageBox.Show(uriUploadFile.ToString());

                    if (uriUploadFile.Scheme != Uri.UriSchemeFtp)
                    {
                        MessageBox.Show("Некоректный адресс");
                        return;
                    }

                    FtpWebRequest ftpWebRequestUpload = (FtpWebRequest)WebRequest.Create(uriUploadFile);
                    ftpWebRequestUpload.Credentials = new NetworkCredential("ftp", "ftp");
                    ftpWebRequestUpload.Method = WebRequestMethods.Ftp.UploadFile;
                    ftpWebRequestUpload.ContentLength = fileDialog.FileName.Length;

                    Stream reaquestStrem = ftpWebRequestUpload.GetRequestStream();
                    reaquestStrem.Write(fileUploadByte, 0, fileUploadByte.Length);
                    reaquestStrem.Close();
                    FtpWebResponse ftpWebResponseIploadFile = (FtpWebResponse)ftpWebRequestUpload.GetResponse();

                    toolStripStatusLabel.Text = ftpWebResponseIploadFile.StatusDescription;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                UpdateView();


            }
            else
                return;
        }

        ///////--------------------------------------------------------------------END

        ///--------------------------------------------------------МЕТОДЫ различных проверок

        ///Проверить выделенный елемент ( не является ли он пустым, и есть ли он папкой либо файлом)
        private bool CheckSelectedItemTree()
        {
            if (treeView_server.SelectedNode != null)
            {
                if (treeView_server.SelectedNode.Tag != null)
                {
                    if ((treeView_server.SelectedNode.Tag.ToString() == "File" || treeView_server.SelectedNode.Tag.ToString() == "Directory"))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private bool isSelectedItemDirectory()
        {
            if (treeView_server.SelectedNode.Tag.ToString() == "Directory")
                return true;
            else
                return false;
        }
        private bool isSelectedItemFile()
        {
            if (treeView_server.SelectedNode.Tag.ToString() == "File")
                return true;
            else
                return false;
        }

        private string GetCurrentPath()
        {
            if (treeView_server.SelectedNode == null)
                return textBox_host.Text;
            else
            {
                if (treeView_server.SelectedNode.FullPath == textBox_host.Text)
                    return textBox_host.Text;
                else
                {
                    if (treeView_server.SelectedNode.Tag.ToString() == "File")
                    {
                        return treeView_server.SelectedNode.Parent.FullPath;
                    }
                    else
                        return treeView_server.SelectedNode.FullPath;
                }
            }
        }

        ///////--------------------------------------------------------------------END


    }
}