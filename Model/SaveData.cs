namespace Rain_save_manager.Model
{
    public class SaveData : IFileData
    {
        public int Id { get; set; }
        public string VisualName { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        //public IFileData TypeFileData { get; set; }

        public SaveData(string VisualName, int Id, string Content, string FileName)
        {
            this.Id = Id;
            this.VisualName = VisualName;
            this.FileName = FileName;
            this.Content = Content;
        }
        public SaveData() { }
    }
}
