using System.Collections.Generic;

namespace FASTrack.ViewModel
{
    public sealed class ViewPhoto
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }

    public class ViewPhotoViewModel
    {
        public List<ViewPhoto> Photos { get; set; }
        public string Default { get; set; }
    }
}