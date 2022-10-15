using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FolderMakerForGateVideo
{
    public static class FileNames
    {
        public static void GetValidFileNames(string topicFolderPath, long topicID)
        {

            int unmatchedCount = 0;
            //string topicFolderPath = Path.Combine(dbRootFoldersList[cmbRoot.SelectedIndex - 1].Path, dbSubjectFoldersList[cmbSubject.SelectedIndex - 1].FolderName, dbTopicFoldersList[cmbTopic.SelectedIndex - 1].FolderName);
            if (!Directory.Exists(topicFolderPath)) return;
            List<string> physicalContentFilesList = Directory.EnumerateFiles(topicFolderPath).ToList();
            //if (dbContentsList.Count != physicalContentFilesList.Count())
            //{
            //    MessageBox.Show("There is mismatch in number of database entries and number of files in the folder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    // return;
            //}
            for (int i = 0; i < physicalContentFilesList.Count; i++)
            {
                physicalContentFilesList[i] = Path.GetFileName(physicalContentFilesList[i]);
            }
            List<Video> tempContentlist = new List<Video>();
            List<Video> tempList = new List<Video>();
            List<Video> dbContentsList = new List<Video>();
            using (DBConnection dBConnection = new DBConnection())
            {
                dbContentsList.AddRange(dBConnection.videos.Where(m => m.TopicParentID == topicID));
                tempContentlist.AddRange(dbContentsList);
                double percentage = 100;


                while (tempContentlist.Count() != 0 && percentage >= 50)
                {
                    for (int i = 0; i < tempContentlist.Count; i++)
                    {
                        string match = Match.FindBestMatch(tempContentlist[i].VideoName, physicalContentFilesList, percentage);
                        if (match == "")
                            unmatchedCount++;
                        //string contentPath = Path.Combine(rootFoldersList[cmbRoot.SelectedIndex].Path,subjectFoldersList[cmbSubject.SelectedIndex+1].FolderName,/* cmbSubject.Text,*/topicFoldersList[cmbTopic.SelectedIndex + 1].FolderName/* cmbTopic.Text*/, match);
                        var ele = tempContentlist[i];
                        var entry = dBConnection.Entry(ele);
                        ele.FileName = match;
                        //ele.Duration = GetVideoDuration(contentPath);
                        physicalContentFilesList.Remove(match);
                    }
                    tempList.Clear();
                    for (int i = 0; i < tempContentlist.Count(); i++)
                    {
                        if (tempContentlist[i].FileName == "")
                            tempList.Add(tempContentlist[i]);
                    }
                    tempContentlist.Clear();
                    tempContentlist.AddRange(tempList);
                    percentage -= 1;
                }

                //if (tempContentlist.Count > 0)
                //MessageBox.Show("Unable to find names of " + (tempContentlist.Count) + " files.", "Information", MessageBoxButtons.OK);
                dBConnection.SaveChanges();
            }

            //if(unmatchedCount>0)
        }
    }
}