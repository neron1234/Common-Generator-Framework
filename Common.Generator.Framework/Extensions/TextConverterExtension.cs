using System.Linq;
using System.Text.RegularExpressions;

namespace Common.Generator.Framework.Extensions
{
    public static class TextConverterExtension
    {
        /// <summary>
        /// Convert any string to PascalCase.
        /// </summary>
        /// <param name="word">Any string.</param>
        /// <returns>A string converted to PascalCase.</returns>
        public static string ToPascalCase(this string word)
        {
            if (!word.IsValid())
            {
                return null;
            }

            word = word.Trim();

            if (word.Length > 0)
            {
                var separators = new char[]
                {
                    ' ',
                    '-',
                    '_',
                    '/'
                };

                var splittedString = word.Split(separators);

                var result = "";

                foreach (var s in splittedString.Where(s => !string.IsNullOrEmpty(s)))
                {
                    var newS = s;

                    newS = Regex.Replace(
                            newS,
                            "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
                            " $1",
                            RegexOptions.Compiled)
                        .Trim();

                    newS = newS.Replace(
                        " ",
                        string.Empty);

                    newS = $"{newS.Substring(0, 1).ToUpper()}{newS.Substring(1)}";

                    result += newS;
                }

                if (result.IsValid())
                {
                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Convert any string to CamelCase.
        /// </summary>
        /// <param name="word">Any string.</param>
        /// <returns>A string converted to CamelCase.</returns>
        public static string ToCamelCase(this string word)
        {
            if (!word.IsValid())
            {
                return null;
            }

            word = word.Trim();

            if (word.Length > 0)
            {
                var separators = new char[]
                {
                    ' ',
                    '-',
                    '_',
                    '/'
                };

                var splittedString = word.Split(separators);
                var i = 0;

                var result = "";

                foreach (var s in splittedString.Where(s => !string.IsNullOrEmpty(s)))
                {
                    var newS = s;

                    newS = Regex.Replace(
                            newS,
                            "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
                            " $1",
                            RegexOptions.Compiled)
                        .Trim();

                    newS = newS.Replace(
                        " ",
                        string.Empty);

                    if (i == 0)
                    {
                        newS = $"{newS.Substring(0, 1).ToLower()}{newS.Substring(1)}";
                    }
                    else
                    {
                        newS = $"{newS.Substring(0, 1).ToUpper()}{newS.Substring(1)}";
                    }

                    i++;

                    result += newS;
                }

                if (result.IsValid())
                {
                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Transform Mobioos types to C# types.
        /// </summary>
        /// <param name="type">A Mobioos type in string.</param>
        /// <returns>A C# type in string.</returns>
        public static string CSharpType(this string type)
        {
            if (!type.IsValid())
            {
                return null;
            }

            switch (type.ToLower())
            {
                case "date":
                    return "DateTime";
                case "email":
                case "url":
                case "password":
                    return "string";
                case "number":
                    return "double";
                case "integer":
                    return "int";
                case "boolean":
                    return "bool";
                case "blob":
                    return "byte[]";
                default:
                    return type;
            }
        }

        /// <summary>
        /// Transform Mobioos types to TypeScript types.
        /// </summary>
        /// <param name="type">A Mobioos type in string.</param>
        /// <returns>A Typescript type in string.</returns>
        public static string TypeScriptType(this string type)
        {
            if (!type.IsValid())
            {
                return null;
            }

            switch (type.ToLower())
            {
                case "date":
                    return "Date";
                case "email":
                case "url":
                case "blob":
                case "password":
                    return "string";
                case "integer":
                    return "number";
                case "boolean":
                case "number":
                default:
                    return type;
            }
        }

        /// <summary>
        /// Transform Mobioos action types to TypeScript action types.
        /// </summary>
        /// <param name="actionType">An action type in string.</param>
        /// <returns>A TypeScript action type.</returns>
        public static string TypeScriptActionType(this string actionType)
        {
            if (!actionType.IsValid())
            {
                return null;
            }

            switch (actionType.ToLower())
            {
                case "dataget":
                    return "get";
                case "datalist":
                    return "get";
                case "datacreate":
                    return "post";
                case "dataupdate":
                    return "put";
                case "datadelete":
                    return "delete";
                default:
                    return actionType;
            }
        }

        /// <summary>
        /// Check if the given type is a primitive type.
        /// </summary>
        /// <param name="property">A string.</param>
        /// <returns>A boolean.</returns>
        public static bool IsPrimitiveType(this string type)
        {
            if (!type.IsValid())
            {
                return false;
            }

            switch (type.ToLower())
            {
                case "date":
                case "email":
                case "url":
                case "blob":
                case "password":
                case "integer":
                case "boolean":
                case "number":
                case "string":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Check if the action given type is a data action or not.
        /// </summary>
        /// <param name="actionType">An action type in string.</param>
        /// <returns>A boolean.</returns>
        public static bool IsDataAction(this string actionType)
        {
            if (!actionType.IsValid())
            {
                return false;
            }

            switch (actionType.ToLower())
            {
                case "dataget":
                case "datalist":
                case "datacreate":
                case "dataupdate":
                case "datadelete":
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsValid(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            return true;
        }
    }
}

