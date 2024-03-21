
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
namespace AUA.ProjectName.Models.GeneralModels.LoginModels
{
    public class SwaggerLoginResponse : ResultModel<LoginResultDto>
    {
        public string? Access_token => Result.AccessToken;
    }
}
