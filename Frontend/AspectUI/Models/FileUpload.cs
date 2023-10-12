namespace AspectUI.Models
{
    public class FileUpload
    {
        public int Id { get; set; }
        public List<FileData> Files { get; set; }
    }

    public class FileData
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
    }
}
