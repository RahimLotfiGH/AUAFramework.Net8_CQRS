namespace AUA.ProjectName.Common.Consts
{
    public class RegexConsts
    {
        public const string PhoneValidation = "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$";

        public const string PasswordRegexSpecial = @"([!_^#*@~$&=%?\\])+";

        public const string Numeric = @"[\d]";

        public const string LowerCaseChar = "[a-z]";

        public const string UpperCase = "[A-Z]";

    }


}
