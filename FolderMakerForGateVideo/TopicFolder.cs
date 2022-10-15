using System.ComponentModel.DataAnnotations;

namespace FolderMakerForGateVideo
{
    public class TopicFolder
    {
        [Key]
        public long ID { get; set; }
        public string FolderName { get; set; }
        public string Description { get; set; }
        //[ForeignKey("SubjectFolder")]
        public long SubjectFolderParentID { get; set; }
    }
}
