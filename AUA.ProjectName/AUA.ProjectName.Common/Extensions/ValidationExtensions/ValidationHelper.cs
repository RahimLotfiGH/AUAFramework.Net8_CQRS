using System.Text.RegularExpressions;
using AUA.ProjectName.Common.Consts;
using static System.String;

namespace AUA.ProjectName.Common.Extensions.ValidationExtensions;

public static class ValidationHelper
{
    public static bool IsEmpty(this string value) => IsNullOrWhiteSpace(value);
    public static bool IsEmpty(this Guid? value) => value== Guid.Empty;
    
    public static bool IsPhoneNumber(this string phoneNumber)
    {
        return Regex.IsMatch(phoneNumber, RegexConsts.PhoneValidation);
    }

    public static bool IsDigit(this string value)
    {
        return Regex.IsMatch(value, RegexConsts.Numeric);
    }

    public static bool HasDangerCharacters(this object model)
    {

        var properties = model.GetType().GetProperties();


        return (from property in properties
                let dataType = property.PropertyType.Name
                where AppConsts.StringDataTypeName == dataType.ToLower()
                select (string)property.GetValue(model))
            .All(HasDangerCharacters);

    }

    public static bool HasDangerCharacters(this string input)
    {
        if (IsNullOrWhiteSpace(input)) return false;

        input = input.ToLower();

        string[] sqlCheckList =
        {
            "--", ";--", ";", "/*", "*/", "@@", "@", "char", "nchar", "varchar", "nvarchar", "alter", "begin",
            "cast", "create", "cursor", "declare", "delete", "drop", "end", "exec", "execute", "fetch", "insert",
            "kill", "select", "sys", "sysobjects", "syscolumns", "table", "update"
        };

        return sqlCheckList.Any(item => input.Contains(item.ToLower()));

    }


}