using AUA.ProjectName.Common.Consts;

namespace AUA.ProjectName.Common.Extensions
{
    public static class AppropriateDataToLog
    {

        public static Dictionary<string, object> ClearParameters(this object paramaters)
        {
            var parameters = paramaters.ToDictionary();

            RemoveAllPasswords(parameters);

            return parameters;
        }

        private static void RemoveAllPasswords(Dictionary<string, object> dictionary)
        {
            var toDelete = dictionary.Keys
                                     .Where(k => k.ToLower().Contains(FiledNameConsts.Password))
                                     .ToList();

            toDelete.ForEach(k => dictionary.Remove(k));
        }
    }
}
