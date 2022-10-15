using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FolderMakerForGateVideo
{
    public class RootFolder
    {
        [Key]
        public long ID { get; set; }
        public string FolderName { get; set; }
        public string Path { get; set; }
    }
}
