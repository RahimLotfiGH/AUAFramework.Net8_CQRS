namespace AUA.ProjectName.Infrastructure.PipelineBehaviors.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class DatabaseRetryAttribute : Attribute
    {
        public DatabaseRetryAttribute()
        {
            
        }
        
    }
}
