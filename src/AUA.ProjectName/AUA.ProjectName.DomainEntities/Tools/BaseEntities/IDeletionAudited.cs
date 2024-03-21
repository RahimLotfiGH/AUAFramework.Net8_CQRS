using System;

namespace AUA.ProjectName.DomainEntities.Tools.BaseEntities
{
    public interface IDeletionAudited : ISoftDelete
    {
        long? DeleterUserId { get; set; }

        DateTime? DeletionDate { get; set; }

    }
}
