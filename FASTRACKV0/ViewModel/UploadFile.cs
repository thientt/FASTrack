using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace FASTrack.ViewModel
{
    public class UploadFile
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Select File to Upload")]
        public HttpPostedFileBase File { get; set; }
    }

    public class FileUploadDBModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }
    }

    public class UploadFilesResult
    {
        public string Name { get; set; }
        public decimal Length { get; set; }
        public string Type { get; set; }
    }
}