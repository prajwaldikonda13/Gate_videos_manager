using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FolderMakerForGateVideo
{
    public class SubjectFolder
    {
        [Key]
        public long ID { get; set; }
        public string FolderName { get; set; }
        public string Description { get; set; }
        //[ForeignKey("RootFolder")]
        public long RootParentID { get; set; }
    }
}
