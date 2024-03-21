namespace AUA.ProjectName.Models.BaseModel.BaseViewModels
{
    public class BaseSearchFilter
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalSize { get; set; }

        public int Skip => (PageNumber - 1) * PageSize;

    }
}
