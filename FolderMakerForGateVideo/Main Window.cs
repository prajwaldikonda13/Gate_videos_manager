using Microsoft.WindowsAPICodePack.Shell;using Microsoft.WindowsAPICodePack.Shell.PropertySystem;using System;using System.Collections.Generic;using System.Diagnostics;using System.IO;using System.Linq;using System.Text.RegularExpressions;using System.Windows.Forms;namespace FolderMakerForGateVideo{    public partial class Form1 : Form    {        public static List<SubjectFolder> dbSubjectFoldersList;        public static List<RootFolder> dbRootFoldersList;        public static List<TopicFolder> dbTopicFoldersList;        public static List<Video> dbContentsList;
        public Form1()        {            InitializeComponent();            getAndSetAllListsFromDatabase();            dbRootFoldersList = new List<RootFolder>();            using (DBConnection dBConnection = new DBConnection())
                dbRootFoldersList.AddRange(dBConnection.rootFolders);            dbSubjectFoldersList = new List<SubjectFolder>();            dbTopicFoldersList = new List<TopicFolder>();            dbContentsList = new List<Video>();            setCmbRootValues();            setCmbSubjectValues();            setCmbTopicValues();            setCmbContentValues();        }

        private void getAndSetAllListsFromDatabase()
        {

        }

        private void Create_Root_Folder_Button_Click(object sender, EventArgs e)        {            try            {                if (folderBrowserDialog1.ShowDialog().ToString() != "OK")                    return;                string destinationFullPath = folderBrowserDialog1.SelectedPath;                string destinationFolderName = new DirectoryInfo(folderBrowserDialog1.SelectedPath).Name;                string newFolderName = getValidString(textBox1.Text);                if (string.IsNullOrEmpty(newFolderName) || string.IsNullOrWhiteSpace(newFolderName))                {                    MessageBox.Show("Please enter the nonempty input.");                    return;                }                if (dbRootFoldersList.SingleOrDefault(m => m.FolderName == destinationFolderName) != null)                {                    MessageBox.Show("Root Folder can't be created in existing root folder.");                    return;                }                string validName = getValidFolderName(Regex.Replace(newFolderName, @"\s+", " "));                if (string.IsNullOrEmpty(validName) || string.IsNullOrWhiteSpace(validName))                {                    MessageBox.Show("Please enter a nonempty string");                    return;                }                if (dbRootFoldersList.SingleOrDefault(m => m.FolderName == validName) != null)                {                    MessageBox.Show("The root folder with given name is already in database.Please enter another name.");                    return;                }
                //if (Directory.Exists(Path.Combine(destinationFullPath,validName)))
                //{
                //    MessageBox.Show("Root Folder with given name already Exists.");
                //    return;
                //}
                string path = Path.Combine(destinationFullPath, validName);                Directory.CreateDirectory(path);
                using (DBConnection dBConnection = new DBConnection())
                {

                    dBConnection.rootFolders.Add(new RootFolder { FolderName = validName, Path = path });
                    dBConnection.SaveChanges();
                    textBox1.Text = "";
                    MessageBox.Show("New Root Folder created successfully.");
                    dbRootFoldersList = dBConnection.rootFolders.ToList();
                }                setCmbRootValues();            }            catch (Exception ex)            {                MessageBox.Show("Exception:" + ex.Message);            }        }        private void Create_Subject_Folders_Click(object sender, EventArgs e)        {            int j;            List<string> memListFolderNames;            try            {                if ((long)cmbRoot.SelectedIndex < 1)                {                    MessageBox.Show("Please select the root folder to proceed.");                    return;                }                if (dbSubjectFoldersList.Count > 1)                {                    MessageBox.Show("Selected subject  folder is not empty.Please select another folder which is empty to proceed.");                    return;                }                string validString = getValidString(textBox1.Text);                if (string.IsNullOrEmpty(validString) || string.IsNullOrWhiteSpace(validString))                {                    MessageBox.Show("Please enter the nonempty input.");                    return;                }
                textBox1.Text = textBox1.Text.Trim();                memListFolderNames = textBox1.Lines.ToList();
                //folderNames.RemoveAll(m => m.ToLower() == "guest access");
                DialogResult res = MessageBox.Show("Is last entry a Description?", "Select Description or not", MessageBoxButtons.YesNo);                if (res == DialogResult.Yes && memListFolderNames.Count >= 2)                    memListFolderNames.Add("");

                int i = 0;                using (DBConnection dBConnection = new DBConnection())
                {
                    for (j = 0; j < memListFolderNames.Count;)
                    {

                        string validFolderName = getValidFolderName(memListFolderNames[j]);
                        if (string.IsNullOrEmpty(validFolderName) || string.IsNullOrWhiteSpace(validFolderName))
                        {
                            j++;
                            continue;
                        }
                        string path = Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, validFolderName);
                        string description = "";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            i++;
                        }
                        else
                        {
                            bool isExists = true;
                            int temp = 1;
                            while (isExists)
                            {
                                validFolderName += "_" + temp;
                                path = Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, validFolderName);
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                    i++;
                                    isExists = false;
                                }
                                else
                                {
                                    validFolderName = validFolderName.Substring(0, validFolderName.LastIndexOf("_"));
                                    temp++;
                                }
                            }
                        }
                        if (j + 2 < memListFolderNames.Count && memListFolderNames[j + 2] == "")
                        {
                            description = memListFolderNames[j + 1];
                            j += 3;
                        }
                        else
                        {
                            j++;
                        }
                        dBConnection.subjectFolders.Add(new SubjectFolder { FolderName = validFolderName, Description = description, RootParentID = dbRootFoldersList[(int)cmbRoot.SelectedIndex - 1].ID });
                    }

                    dBConnection.SaveChanges();
                    textBox1.Text = "";
                    MessageBox.Show(i + " Folders are created in the selected folder.");
                    long id = dbRootFoldersList[cmbRoot.SelectedIndex - 1].ID;
                    dbSubjectFoldersList = dBConnection.subjectFolders.Where(m => m.RootParentID == id).ToList();
                }                setCmbSubjectValues();            }            catch (Exception ex)            {                MessageBox.Show("Exception:" + ex.Message);            }        }        private void Create_Topic_Folders_Click(object sender, EventArgs e)        {            int j;            List<string> folderNames;            try            {                if ((long)cmbRoot.SelectedIndex == 0 || (long)cmbSubject.SelectedIndex == 0)                {                    MessageBox.Show("Please select the root folder and subject folder to proceed.");                    return;                }                if (dbTopicFoldersList.Count > 1)                {                    MessageBox.Show("Selected topic  folder is not empty.Please select another folder which is empty to proceed.");                    return;                }                RootFolder rootFolder = dbRootFoldersList[cmbRoot.SelectedIndex - 1];                SubjectFolder subjectFolder = dbSubjectFoldersList[cmbSubject.SelectedIndex - 1];                if (rootFolder == null || subjectFolder == null)                {                    MessageBox.Show("Some error has occured.Operation is not completed.");                    return;                }                string validString = getValidString(textBox1.Text);                if (string.IsNullOrEmpty(validString) || string.IsNullOrWhiteSpace(validString))                {                    MessageBox.Show("Please enter the nonempty input.");                    return;                }
                textBox1.Text = textBox1.Text.Trim();                folderNames = textBox1.Lines.ToList();
                //Regex regEx = new Regex(@"page\s*s*:\s*\d");
                //Regex regEx1 = new Regex(@"file\s*s*:\s*\d");
                //Regex regEx2 = new Regex(@"url\s*s*:\s*\d");
                //for (j = 0; j < folderNames.Count; j++)
                //{
                //    //if(folderNames[j].ToLower().Contains("pages:")|| folderNames[j].ToLower().Contains("files:"))
                //    if (regEx.IsMatch(folderNames[j].ToLower()) || regEx1.IsMatch(folderNames[j].ToLower()) || regEx2.IsMatch(folderNames[j].ToLower()))
                //    {
                //        folderNames.RemoveAt(j);
                //    }
                //}

                DialogResult res = MessageBox.Show("Is last entry a Description?", "Select Description or not", MessageBoxButtons.YesNo);                if (res == DialogResult.Yes && folderNames.Count >= 2)                    folderNames.Add("");                int i = 0;
                using (DBConnection dBConnection = new DBConnection())
                {
                    for (j = 0; j < folderNames.Count;)
                    {

                        string validFolderName = getValidFolderName(folderNames[j]);
                        if (string.IsNullOrEmpty(validFolderName) || string.IsNullOrWhiteSpace(validFolderName))
                        {
                            j++;
                            continue;
                        }
                        string path = Path.Combine(rootFolder.Path, subjectFolder.FolderName, validFolderName);
                        string description = "";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            i++;
                        }
                        else
                        {
                            bool isExists = true;
                            int temp = 1;
                            while (isExists)
                            {
                                validFolderName += "_" + temp;
                                path = Path.Combine(rootFolder.Path, subjectFolder.FolderName, validFolderName);
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                    i++;
                                    isExists = false;
                                }
                                else
                                {
                                    validFolderName = validFolderName.Substring(0, validFolderName.LastIndexOf("_"));
                                    temp++;
                                }
                            }
                        }
                        if (j + 2 < folderNames.Count && folderNames[j + 2] == "")
                        {
                            description = folderNames[j + 1];
                            j += 3;
                        }
                        else
                        {
                            j++;
                        }
                        dBConnection.topicFolders.Add(new TopicFolder { FolderName = validFolderName, Description = description, SubjectFolderParentID = subjectFolder.ID });
                    }

                    dBConnection.SaveChanges();
                    long id = dbSubjectFoldersList[cmbSubject.SelectedIndex - 1].ID;
                    dbTopicFoldersList = dBConnection.topicFolders.Where(m => m.SubjectFolderParentID == id).ToList();
                }                setCmbTopicValues();                textBox1.Text = "";                MessageBox.Show(i + " Folders are created in the selected folder.");            }            catch (Exception ex)            {                MessageBox.Show("Exception:" + ex.Message);            }        }        private void Create_Files_data_Click(object sender, EventArgs e)        {            int j;            List<string> topicNames;            try            {                if ((long)cmbTopic.SelectedIndex == 0 || ((long)cmbRoot.SelectedIndex == 0 || (long)cmbSubject.SelectedIndex == 0))                {                    MessageBox.Show("Please select Root,Subject and Topic folders to preceed.");                    return;                }                if (dbContentsList.Count > 1)                {                    MessageBox.Show("Selected contents  list is not empty.Please select another list which is empty to proceed.");                    return;                }                RootFolder rootFolder = dbRootFoldersList[cmbRoot.SelectedIndex - 1];                SubjectFolder subjectFolder = dbSubjectFoldersList[cmbSubject.SelectedIndex - 1];                TopicFolder topicFolder = dbTopicFoldersList[cmbTopic.SelectedIndex - 1];
                //if ((topicFolder = )) == null)
                //{
                //    MessageBox.Show("Database entries folders can't be created here.Please select the topic folder.");
                //    return;
                //}
                string validString = getValidString(textBox1.Text);                if (string.IsNullOrEmpty(validString) || string.IsNullOrWhiteSpace(validString))                {                    MessageBox.Show("Please enter the nonempty input.");                    return;                }
                textBox1.Text = textBox1.Text.Trim();                topicNames = textBox1.Lines.ToList();

                DialogResult res = MessageBox.Show("Is last entry a Description?", "Select Description or not", MessageBoxButtons.YesNo);                if (res == DialogResult.Yes && topicNames.Count >= 2)                    topicNames.Add("");                int i = 0;
                using (DBConnection dBConnection = new DBConnection())
                {
                    for (j = 0; j < topicNames.Count;)
                    {

                        string validFileName = getValidFolderName(topicNames[j]);
                        if (string.IsNullOrEmpty(validFileName) || string.IsNullOrWhiteSpace(validFileName))
                        {
                            j++;
                            continue;
                        }
                        string description = "";

                        if (j + 2 < topicNames.Count && topicNames[j + 2] == "")
                        {
                            description = topicNames[j + 1];
                            j += 3;
                        }
                        else
                        {
                            j++;
                        }
                        dBConnection.videos.Add(new Video { VideoName = validFileName, Description = description, TopicParentID = topicFolder.ID });
                        i++;
                    }

                    dBConnection.SaveChanges();
                    textBox1.Text = "";
                    long topicParentId = (long)((TopicFolder)cmbTopic.Items[cmbTopic.SelectedIndex - 1]).ID;
                    dbContentsList = dBConnection.videos.Where(m => m.TopicParentID == topicParentId).ToList();
                }                setCmbContentValues();
                //MessageBox.Show(i + " Folders are created in the selected folder.");
                MessageBox.Show(i + " Entries are created in the selected folder.");            }            catch (Exception ex)            {                MessageBox.Show("Exception:" + ex.Message);            }        }        private void setCmbTopicValues()        {            cmbTopic.Items.Clear();            cmbTopic.Items.Insert(0, new TopicFolder { ID = 0, FolderName = "Select topic folder" });            cmbTopic.DisplayMember = "FolderName";            cmbTopic.ValueMember = "ID";            int i = 1;            foreach (TopicFolder topic in dbTopicFoldersList)                cmbTopic.Items.Add(new TopicFolder { ID = topic.ID, FolderName = i++ + ". " + topic.FolderName + " (" + topic.ID + ")" });
            //cmbTopic.DataSource = topicFoldersList;
            if (cmbSubject.SelectedIndex > 0)                lblNoOfTopics.Text = dbTopicFoldersList.Count + " Topics in " + dbSubjectFoldersList[cmbSubject.SelectedIndex - 1].FolderName;
            cmbTopic.SelectedIndex = 0;        }        private void setCmbContentValues()        {            if (dbContentsList.Count > 0)
            {
                string topicName = dbTopicFoldersList[cmbTopic.SelectedIndex - 1].FolderName.Trim();
                string contentName = dbContentsList[0].VideoName.Trim();
                //if(topicName==contentName)
                //dbContentsList.RemoveAt(0);
            }
            cmbContent.Items.Clear();
            //contentsList.Insert(0, new Video { ID = 0, VideoName = "Select content", });
            cmbContent.Items.Insert(0, new Video { ID = 0, VideoName = "Select content", });            cmbContent.DisplayMember = "VideoName";            cmbContent.ValueMember = "ID";
            //if (cmbTopic.SelectedIndex > 0)
            {                lblNoOfContents.Text = getTimeSpanForContents(dbContentsList.Count, true);                cmbContent.SelectedIndex = 0;            }        }        private void setCmbSubjectValues()        {            cmbSubject.Items.Clear();            cmbSubject.Items.Insert(0, new SubjectFolder { ID = 0, FolderName = "Select subject folder" });            cmbSubject.DisplayMember = "FolderName";            cmbSubject.ValueMember = "ID";            int i = 1;            foreach (SubjectFolder subject in dbSubjectFoldersList)
            {
                cmbSubject.Items.Add(new SubjectFolder { ID = subject.ID, FolderName = i++ + ". " + subject.FolderName + " (" + subject.ID + ")" });            }            if (cmbRoot.SelectedIndex > 0)                lblNoOfSubjectFolders.Text = dbSubjectFoldersList.Count + " Subjects in " + dbRootFoldersList[cmbRoot.SelectedIndex - 1].FolderName;
            cmbSubject.SelectedIndex = 0;        }        private void setCmbRootValues()        {            cmbRoot.Items.Insert(0, new RootFolder { ID = 0, FolderName = "Select root folder" });            cmbRoot.SelectedIndex = 0;            cmbRoot.DisplayMember = "FolderName";            cmbRoot.ValueMember = "ID";            int i = 1;            foreach (RootFolder rootFolder in dbRootFoldersList)
                cmbRoot.Items.Add(new RootFolder { ID = rootFolder.ID, FolderName = i++ + ". " + rootFolder.FolderName + " (" + rootFolder.ID + ")", Path = rootFolder.Path });            lblNoOfRootFolders.Text = dbRootFoldersList.Count + " Root folders in database";            cmbRoot.SelectedIndex = 0;        }        private void cmbRoot_SelectedIndexChanged(object sender, EventArgs e)        {            if (!((sender as ComboBox).Focused && (sender as ComboBox).SelectedIndex > 0))                return;            lblCompleteDuration.Text = "";            lblNoOfContents.Text = "";            dbSubjectFoldersList = new List<SubjectFolder>();            dbTopicFoldersList = new List<TopicFolder>();            dbContentsList = new List<Video>();            if (!((long)cmbRoot.SelectedIndex == 0))            {                long id = dbRootFoldersList[cmbRoot.SelectedIndex - 1].ID;                using (DBConnection dBConnection = new DBConnection())
                    dbSubjectFoldersList.AddRange(dBConnection.subjectFolders.Where(m => m.RootParentID == id));            }            int diskFolderCount = Directory.EnumerateFileSystemEntries(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path).Count();            int listFolderCount = dbSubjectFoldersList.Count;            if (diskFolderCount != listFolderCount)            {                List<string> missingFolders = new List<string>();                string missing = "Following folders are missing:-" + Environment.NewLine;                MessageBox.Show("The number of records in selected database root folder does not match with number of records on disk." + Environment.NewLine + (listFolderCount - diskFolderCount) + " Records are missing.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);                foreach (SubjectFolder s in dbSubjectFoldersList)                {                    if (!Directory.Exists(Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, s.FolderName)))                    {                        missingFolders.Add(s.FolderName);                        missing += s.FolderName + Environment.NewLine;                    }                }                missing += "Do you want to create all missing folders?";                if (MessageBox.Show(missing, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString().ToLower() == "yes")                {                    foreach (string s in missingFolders)                        Directory.CreateDirectory(Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, s));                }            }            setCmbSubjectValues();            setCmbTopicValues();            setCmbContentValues();        }        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)        {            if (!((sender as ComboBox).Focused && (sender as ComboBox).SelectedIndex > 0))                return;            lblCompleteDuration.Text = "";            lblNoOfContents.Text = "";            dbTopicFoldersList = new List<TopicFolder>();            dbContentsList = new List<Video>();            if (!((long)cmbSubject.SelectedIndex == 0 || (long)cmbRoot.SelectedIndex == 0))            {                long subjectId = ((SubjectFolder)dbSubjectFoldersList[cmbSubject.SelectedIndex - 1]).ID;                using (DBConnection dBConnection = new DBConnection())
                    dbTopicFoldersList.AddRange(dBConnection.topicFolders.Where(m => m.SubjectFolderParentID == subjectId));            }            int diskFolderCount = Directory.EnumerateFileSystemEntries(Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, dbSubjectFoldersList[cmbSubject.SelectedIndex - 1].FolderName)).Count();            int listFolderCount = dbTopicFoldersList.Count;            if (diskFolderCount < listFolderCount)            {                List<string> missingFolders = new List<string>();                string missing = "Following folders are missing:-" + Environment.NewLine;                MessageBox.Show("The number of records in selected database subject folder does not match with number of records on disk." + Environment.NewLine + (listFolderCount - diskFolderCount) + " Records are missing.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);                foreach (TopicFolder s in dbTopicFoldersList)                {                    if (!Directory.Exists(Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, dbSubjectFoldersList[cmbSubject.SelectedIndex - 1].FolderName, s.FolderName)))                    {                        missingFolders.Add(s.FolderName);                        missing += s.FolderName + Environment.NewLine;                    }                }                missing += "Do you want to create all missing folders?";                if (MessageBox.Show(missing, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString().ToLower() == "yes")                {                    foreach (string s in missingFolders)                        Directory.CreateDirectory(Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, dbSubjectFoldersList[cmbSubject.SelectedIndex - 1].FolderName, s));                }            }            setCmbTopicValues();            setCmbContentValues();        }        private void cmbTopic_SelectedIndexChanged(object sender, EventArgs e)        {            if (!((sender as ComboBox).Focused && (sender as ComboBox).SelectedIndex > 0))                return;            lblCompleteDuration.Text = "";            dbContentsList = new List<Video>();            if (!((long)cmbTopic.SelectedIndex == 0 || (long)cmbSubject.SelectedIndex == 0 || (long)cmbRoot.SelectedIndex == 0))            {                long topicId = dbTopicFoldersList[cmbTopic.SelectedIndex - 1].ID;                using (DBConnection dBConnection = new DBConnection())
                    dbContentsList.AddRange(dBConnection.videos.Where(m => m.TopicParentID == topicId));
                //string topicPath = Path.Combine(rootFoldersList[cmbRoot.SelectedIndex].Path, cmbSubject.Text, cmbTopic.Text);
                string topicPath = Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, dbSubjectFoldersList[cmbSubject.SelectedIndex - 1].FolderName, dbTopicFoldersList[cmbTopic.SelectedIndex - 1].FolderName);                Clipboard.SetText(topicPath);            }            setCmbContentValues();            for (int i = 0; i < dbContentsList.Count; i++)            {                if (dbContentsList[i].FileName == null)                {                    MessageBox.Show("Some file names are null.Please click on Get Valid File Names button to stop this message from appearing next time." + Environment.NewLine, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);                    return;                }            }            int missingCount = 0;            string str = "";            for (int i = 0; i < dbContentsList.Count; i++)            {                if (dbContentsList[i].FileName == "")                {                    missingCount++;                    str += missingCount + ")" + dbContentsList[i].VideoName + Environment.NewLine;                }            }            if (missingCount > 0)                MessageBox.Show(missingCount + " contents are missing." + Environment.NewLine + "Probabily missing contents are:-" + Environment.NewLine + str);        }        private void cmbContent_SelectedIndexChanged(object sender, EventArgs e)        {
            //return;//please remove this line
            if (!((long)cmbContent.SelectedIndex == 0 || (long)cmbTopic.SelectedIndex == 0 || (long)cmbSubject.SelectedIndex == 0 || (long)cmbRoot.SelectedIndex == 0))            {                if (dbContentsList[cmbContent.SelectedIndex - 1].FileName != null)                {                    string contentPath = Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, dbSubjectFoldersList[cmbSubject.SelectedIndex - 1].FolderName, dbTopicFoldersList[cmbTopic.SelectedIndex - 1].FolderName.Trim(), dbContentsList[cmbContent.SelectedIndex - 1].FileName);                    Clipboard.SetText(contentPath);                    openFileInChrome(contentPath);//uncomment this line
                    if (dbContentsList[cmbContent.SelectedIndex - 1].Description != "")                        MessageBox.Show(dbContentsList[cmbContent.SelectedIndex - 1].Description, "This video has description associated with it.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //textBox1.Text += Environment.NewLine + Environment.NewLine + contentsList[cmbContent.SelectedIndex].Description;
                    lblCompleteDuration.Text = getTimeSpanForContents(cmbContent.SelectedIndex, false);                }                else                {                    MessageBox.Show("File Name not found.Please click get valid file names buttton", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);                }            }        }        private void openFileInChrome(string contentPath)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process.StartInfo.Arguments = string.Format("\"{0}\"", contentPath);// + " --new-window";
            process.Start();
        }


        private string getValidString(string str)        {
            str = Regex.Replace(str.Trim(), @"\s+", " ");            return str;        }        public string getValidFolderName(string str)        {            str = str.Trim();            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());            foreach (char c in invalid)            {                str = str.Replace(c.ToString(), "_");            }            return str;        }        private void GetValidFileNames_Click(object sender, EventArgs e)        {

            try            {                if ((long)cmbTopic.SelectedIndex == 0 || (long)cmbSubject.SelectedIndex == 0 || (long)cmbRoot.SelectedIndex == 0)                {                    MessageBox.Show("Please select Root,Subject and Topic folders to preceed");                    return;                }                string topicFolderPath = Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, dbSubjectFoldersList[cmbSubject.SelectedIndex - 1].FolderName, dbTopicFoldersList[cmbTopic.SelectedIndex - 1].FolderName);
                FileNames.GetValidFileNames(topicFolderPath, dbTopicFoldersList[cmbTopic.SelectedIndex - 1].ID);
                dbContentsList = new List<Video>();
                long topicId = dbTopicFoldersList[cmbTopic.SelectedIndex - 1].ID;                using (DBConnection dBConnection = new DBConnection())
                    dbContentsList.AddRange(dBConnection.videos.Where(m => m.TopicParentID == topicId));                setCmbContentValues();
                MessageBox.Show("Operation completed successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            catch (Exception ex)            {                MessageBox.Show(ex.Message);            }        }        private static TimeSpan GetVideoDuration(string filePath)        {            if (!File.Exists(filePath))                return TimeSpan.FromTicks(0);            using (var shell = ShellObject.FromParsingName(filePath))            {                IShellProperty prop = shell.Properties.System.Media.Duration;                var t = (ulong)prop.ValueAsObject;                return TimeSpan.FromTicks((long)t);            }        }        private void Form1_Load(object sender, EventArgs e)        {
            // Font = new Font("Arial", 12, FontStyle.Bold);
        }        private string getTwoDigitTime(int time)        {            if (time < 10)                return "0" + time;            return time + "";        }        private string getTimeStringFromTimeSpan(TimeSpan ts)
        {
            return getTwoDigitTime(ts.Hours)+":" + getTwoDigitTime(ts.Minutes)+":" + getTwoDigitTime(ts.Seconds);
            int totalHours = 0;            int totalMinutes = 0;            int totalSeconds = 0;
            if (totalSeconds > 59)
            {
                totalMinutes += totalSeconds / 60;
                totalSeconds = totalSeconds % 60;
            }
            if (totalMinutes > 59)
            {
                totalHours += totalMinutes / 60;
                totalMinutes = totalMinutes % 60;
            }
            return "Complete duration after '" + dbContentsList[cmbContent.SelectedIndex - 1].VideoName + "' content will be :" + getTwoDigitTime(totalHours) + ":" + getTwoDigitTime(totalMinutes) + ":" + getTwoDigitTime(totalSeconds);        }        TimeSpan entireTopicTimespan= TimeSpan.FromTicks(0);        private string getTimeSpanForContents(int lastIndex, bool addItemsToList)        {            if ((long)cmbTopic.SelectedIndex > 0 && (long)cmbSubject.SelectedIndex > 0 && (long)cmbRoot.SelectedIndex > 0)            {                TimeSpan totalTime = TimeSpan.FromTicks(0);                for (int i = 0; i < lastIndex; i++)                {                    TimeSpan ts = TimeSpan.FromTicks(0);
                    //if (i >= 1)
                    {                        if (dbContentsList[i].FileName != null)                        {                            string contentPath = Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, dbSubjectFoldersList[cmbSubject.SelectedIndex - 1].FolderName, dbTopicFoldersList[cmbTopic.SelectedIndex - 1].FolderName, dbContentsList[i].FileName);
                            //string contentPath = Path.Combine(rootFoldersList[cmbRoot.SelectedIndex].Path, cmbSubject.Text, cmbTopic.Text, contentsList[i].FileName);
                            //TimeSpan ts = TimeSpan.FromTicks(contentsList[i].Duration);
                            string ext = Path.GetExtension(contentPath);                            if (ext.ToLower() == ".mp4")                            {                                ts = GetVideoDuration(contentPath);                            }                            totalTime = totalTime.Add(ts);                        }                    }
                    if (addItemsToList)
                        cmbContent.Items.Add(new Video { ID = dbContentsList[i].ID, VideoName = (i + 1) + ". " + dbContentsList[i].VideoName + " (" +getTimeStringFromTimeSpan(ts)+ ")" });                }
                             if (addItemsToList)
                {
                    entireTopicTimespan = totalTime;
                    return dbContentsList.Count + " contents are there in " + dbTopicFoldersList[cmbTopic.SelectedIndex - 1].FolderName + "(" + getTimeStringFromTimeSpan(totalTime) + ")";                }                else                {                    return "Complete duration after '" + dbContentsList[cmbContent.SelectedIndex - 1].VideoName + "' content will be :" + "(" + getTimeStringFromTimeSpan(totalTime) + ") Remaining:("+getTimeStringFromTimeSpan(entireTopicTimespan-totalTime)+")";                }            }            return "";        }        private void button1_Click(object sender, EventArgs e)        {            new Time_Calculator().Show();        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString().ToLower() == "p")
            {
                openFileInChrome(Clipboard.GetText());//uncomment this line
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetFilenamesOfAllFiles.getAll();
            MessageBox.Show("Operation completed successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }}