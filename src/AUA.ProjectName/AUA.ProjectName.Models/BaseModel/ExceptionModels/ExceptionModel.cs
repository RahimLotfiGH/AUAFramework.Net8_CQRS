namespace AUA.ProjectName.Models.BaseModel.ExceptionModels
{
    public class ExceptionModel
    {
        public string Message { get; set; }

        public string Source { get; set; }

        public int HResult { get; set; }

        public string SourceName { get; set; }

        public string StackTrace { get; set; }

    }
}
