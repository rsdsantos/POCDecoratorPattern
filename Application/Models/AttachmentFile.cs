namespace Communication.API.Application.Models
{
    public class AttachmentFile
    {
        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string Base64 { get; set; }

        public string FileId { get; set; }

        public int ArchiveType { get; set; }
    }
}
