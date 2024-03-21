namespace AUA.ProjectName.Common.Tools.Security
{
    public static class TokenHelper
    {

        public static bool IsValidationExpirationDate(DateTime? expirationDate) => expirationDate is not null &&
                                                                                    DateTime.UtcNow <= expirationDate;


    }
}
