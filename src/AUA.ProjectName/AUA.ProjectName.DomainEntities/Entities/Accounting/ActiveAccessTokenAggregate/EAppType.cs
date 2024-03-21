using System.ComponentModel;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting.AccessTokenAggregate
{
    public enum EAppType
    {
        [Description("Web")]
        WebSite = 1,

        [Description("AndroidApp")]
        AndroidApp = 2,

        [Description("IosApp")]
        IosApp = 3,

    }
}