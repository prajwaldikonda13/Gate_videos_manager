using System.ComponentModel.DataAnnotations;

namespace FolderMakerForGateVideo
{
    public class Video
    {
        [Key]
        public long ID { get; set; }
        public string VideoName { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        //[ForeignKey("SubjectFolder")]
        public long TopicParentID { get; set; }
        //public long Duration { get; set; }
    }
}