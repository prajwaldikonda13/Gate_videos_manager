﻿using Microsoft.WindowsAPICodePack.Shell;
        public Form1()
                dbRootFoldersList.AddRange(dBConnection.rootFolders);

        private void getAndSetAllListsFromDatabase()
        {

        }

        private void Create_Root_Folder_Button_Click(object sender, EventArgs e)
                //if (Directory.Exists(Path.Combine(destinationFullPath,validName)))
                //{
                //    MessageBox.Show("Root Folder with given name already Exists.");
                //    return;
                //}
                string path = Path.Combine(destinationFullPath, validName);
                using (DBConnection dBConnection = new DBConnection())
                {

                    dBConnection.rootFolders.Add(new RootFolder { FolderName = validName, Path = path });
                    dBConnection.SaveChanges();
                    textBox1.Text = "";
                    MessageBox.Show("New Root Folder created successfully.");
                    dbRootFoldersList = dBConnection.rootFolders.ToList();
                }
                textBox1.Text = textBox1.Text.Trim();
                //folderNames.RemoveAll(m => m.ToLower() == "guest access");
                DialogResult res = MessageBox.Show("Is last entry a Description?", "Select Description or not", MessageBoxButtons.YesNo);

                int i = 0;
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
                }
                textBox1.Text = textBox1.Text.Trim();
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

                DialogResult res = MessageBox.Show("Is last entry a Description?", "Select Description or not", MessageBoxButtons.YesNo);
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
                }
                //if ((topicFolder = )) == null)
                //{
                //    MessageBox.Show("Database entries folders can't be created here.Please select the topic folder.");
                //    return;
                //}
                string validString = getValidString(textBox1.Text);
                textBox1.Text = textBox1.Text.Trim();

                DialogResult res = MessageBox.Show("Is last entry a Description?", "Select Description or not", MessageBoxButtons.YesNo);
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
                }
                //MessageBox.Show(i + " Folders are created in the selected folder.");
                MessageBox.Show(i + " Entries are created in the selected folder.");
            //cmbTopic.DataSource = topicFoldersList;
            if (cmbSubject.SelectedIndex > 0)
            cmbTopic.SelectedIndex = 0;
            {
                string topicName = dbTopicFoldersList[cmbTopic.SelectedIndex - 1].FolderName.Trim();
                string contentName = dbContentsList[0].VideoName.Trim();
                //if(topicName==contentName)
                //dbContentsList.RemoveAt(0);
            }
            cmbContent.Items.Clear();
            //contentsList.Insert(0, new Video { ID = 0, VideoName = "Select content", });
            cmbContent.Items.Insert(0, new Video { ID = 0, VideoName = "Select content", });
            //if (cmbTopic.SelectedIndex > 0)
            {
            {
                cmbSubject.Items.Add(new SubjectFolder { ID = subject.ID, FolderName = i++ + ". " + subject.FolderName + " (" + subject.ID + ")" });
            cmbSubject.SelectedIndex = 0;
                cmbRoot.Items.Add(new RootFolder { ID = rootFolder.ID, FolderName = i++ + ". " + rootFolder.FolderName + " (" + rootFolder.ID + ")", Path = rootFolder.Path });
                    dbSubjectFoldersList.AddRange(dBConnection.subjectFolders.Where(m => m.RootParentID == id));
                    dbTopicFoldersList.AddRange(dBConnection.topicFolders.Where(m => m.SubjectFolderParentID == subjectId));
                    dbContentsList.AddRange(dBConnection.videos.Where(m => m.TopicParentID == topicId));
                //string topicPath = Path.Combine(rootFoldersList[cmbRoot.SelectedIndex].Path, cmbSubject.Text, cmbTopic.Text);
                string topicPath = Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, dbSubjectFoldersList[cmbSubject.SelectedIndex - 1].FolderName, dbTopicFoldersList[cmbTopic.SelectedIndex - 1].FolderName);
            //return;//please remove this line
            if (!((long)cmbContent.SelectedIndex == 0 || (long)cmbTopic.SelectedIndex == 0 || (long)cmbSubject.SelectedIndex == 0 || (long)cmbRoot.SelectedIndex == 0))
                    if (dbContentsList[cmbContent.SelectedIndex - 1].Description != "")
                    //textBox1.Text += Environment.NewLine + Environment.NewLine + contentsList[cmbContent.SelectedIndex].Description;
                    lblCompleteDuration.Text = getTimeSpanForContents(cmbContent.SelectedIndex, false);
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process.StartInfo.Arguments = string.Format("\"{0}\"", contentPath);// + " --new-window";
            process.Start();
        }


        private string getValidString(string str)
            str = Regex.Replace(str.Trim(), @"\s+", " ");

            try
                FileNames.GetValidFileNames(topicFolderPath, dbTopicFoldersList[cmbTopic.SelectedIndex - 1].ID);
                dbContentsList = new List<Video>();
                long topicId = dbTopicFoldersList[cmbTopic.SelectedIndex - 1].ID;
                    dbContentsList.AddRange(dBConnection.videos.Where(m => m.TopicParentID == topicId));
                MessageBox.Show("Operation completed successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Font = new Font("Arial", 12, FontStyle.Bold);
        }
        {
            return getTwoDigitTime(ts.Hours)+":" + getTwoDigitTime(ts.Minutes)+":" + getTwoDigitTime(ts.Seconds);
            int totalHours = 0;
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
            return "Complete duration after '" + dbContentsList[cmbContent.SelectedIndex - 1].VideoName + "' content will be :" + getTwoDigitTime(totalHours) + ":" + getTwoDigitTime(totalMinutes) + ":" + getTwoDigitTime(totalSeconds);
                    //if (i >= 1)
                    {
                            //string contentPath = Path.Combine(rootFoldersList[cmbRoot.SelectedIndex].Path, cmbSubject.Text, cmbTopic.Text, contentsList[i].FileName);
                            //TimeSpan ts = TimeSpan.FromTicks(contentsList[i].Duration);
                            string ext = Path.GetExtension(contentPath);

                        cmbContent.Items.Add(new Video { ID = dbContentsList[i].ID, VideoName = (i + 1) + ". " + dbContentsList[i].VideoName + " (" +getTimeStringFromTimeSpan(ts)+ ")" });

                {
                    entireTopicTimespan = totalTime;
                    return dbContentsList.Count + " contents are there in " + dbTopicFoldersList[cmbTopic.SelectedIndex - 1].FolderName + "(" + getTimeStringFromTimeSpan(totalTime) + ")";

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
    }