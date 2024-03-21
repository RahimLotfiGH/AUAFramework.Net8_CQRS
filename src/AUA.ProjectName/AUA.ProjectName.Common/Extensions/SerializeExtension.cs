using AUA.ProjectName.Common.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AUA.ProjectName.Common.Extensions
{
    public static class SerializeExtension
    {
        public static string ObjectSerialize<T>(this T toSerialize)
        {

            var resultSerializeObject = JsonConvert.SerializeObject(toSerialize);

            return resultSerializeObject;
        }

        public static T ObjectDeserialize<T>(this string toDeserialize)
        {
            if (toDeserialize.IsNullOrEmpty())
                throw new ClientException("EX", "Invalid json format ");

            try
            {
                return JsonConvert.DeserializeObject<T>(toDeserialize);

            }
            catch
            {
                throw new ClientException("EX", "Invalid Json Format");
            }


        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static T DeepClone<T>(this T sourceObject) where T : new()
        {
            var objData = sourceObject.ObjectSerialize();

            return ObjectDeserialize<T>(objData);
        }

        public static Dictionary<string, object> ToDictionary(this object model)
        {
            return model is null ?
                new Dictionary<string, object>() :
                JObject.FromObject(model).ToObject<Dictionary<string, object>>();
        }

    }
}
