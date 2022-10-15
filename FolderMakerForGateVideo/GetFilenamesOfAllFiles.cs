using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FolderMakerForGateVideo
{
    public static class GetFilenamesOfAllFiles
    {
        public static void getAll()
        {
            DBConnection dB = new DBConnection();
            RootFolder root = dB.rootFolders.First();
            List<SubjectFolder> subjects = dB.subjectFolders.Where(sub => sub.RootParentID == root.ID).ToList();
            foreach(SubjectFolder subject in subjects)
            {
                List<TopicFolder> topics = dB.topicFolders.Where(top => top.SubjectFolderParentID == subject.ID).ToList() ;
                foreach(TopicFolder topic in topics)
                {
                    List<Video> contents = dB.videos.Where(con => con.TopicParentID == topic.ID).ToList() ;
                    //foreach(Video content in contents)
                    {
                        var topicFolderPath = Path.Combine(root.Path, subject.FolderName, topic.FolderName);
                        FileNames.GetValidFileNames(topicFolderPath, topic.ID);
                    }
                }
            }
        }
    }
}
