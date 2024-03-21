using System.Text.RegularExpressions;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate;

namespace AUA.ProjectName.DomainEntities.Tools.Utilities
{
    public static class PasswordSecurityRateHelper
    {
        public static EPasswordSecurityRate GetSecurityRate(string password)
        {
            var securityRate = EPasswordSecurityRate.VeryWeak;

            if (HasSpecial(password))
                securityRate++;

            if (HasNumber(password))
                securityRate++;

            if (HasLowercase(password))
                securityRate++;

            if (HasUppercase(password))
                securityRate++;

            return securityRate;
        }

        private static bool HasSpecial(string password)
        {
            return Regex.IsMatch(password, RegexConsts.PasswordRegexSpecial);
        }

        private static bool HasNumber(string password)
        {
            return Regex.IsMatch(password, RegexConsts.Numeric);
        }

        private static bool HasLowercase(string password)
        {
            return Regex.IsMatch(password, RegexConsts.LowerCaseChar);
        }

        private static bool HasUppercase(string password)
        {
            return Regex.IsMatch(password, RegexConsts.UpperCase);
        }
    }
}
