using System;

namespace AUA.ProjectName.DomainEntities.Tools.BaseEntities
{
    public interface IModifiedAudited
    {

        long? ModifierUserId { get; set; }

        DateTime? ModifyDate { get; set; }

    }
}
