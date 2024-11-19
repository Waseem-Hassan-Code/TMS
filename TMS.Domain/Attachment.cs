namespace TMS.Domain
{
    public class Attachment
    {
        public Guid AttachmentId { get; set; } = Guid.NewGuid();
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public DateTime UploadedDate { get; set; }

        // Foreign Key
        public Guid TaskId { get; set; }

        public Task Task { get; set; }
    }
}