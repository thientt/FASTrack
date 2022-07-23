using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class UploadFile
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DisplayName("Select File to Upload")]
        public HttpPostedFileBase File { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FileUploadDBModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] File { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UploadFilesResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Length { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }
    }
}