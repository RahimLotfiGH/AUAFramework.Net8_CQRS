namespace AUA.ProjectName.Infrastructure.PipelineBehaviors.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class FullAuditLogAttribute : Attribute
    {
        public FullAuditLogAttribute()
        {

        }

    }
}