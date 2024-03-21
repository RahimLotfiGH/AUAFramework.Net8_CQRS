namespace AUA.ProjectName.Models.BaseModel.BaseViewModels
{
    public class ListResult<TResult>
    {
        public int TotalCount { get; set; }

        public IEnumerable<TResult> Result { get; set; }

    }
}
