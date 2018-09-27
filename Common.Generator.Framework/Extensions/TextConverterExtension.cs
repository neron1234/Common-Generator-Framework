using System;
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
            string result = "";

            if (word == null)
                return result;

            word = word.Trim();

            if (word.Length > 0)
            {
                char[] separators = new char[] {' ', '-', '_', '/'};
                string[] splittedString = word.Split(separators);

                foreach (string s in splittedString.Where(s => !string.IsNullOrEmpty(s)))
                {
                    string newS = s;
                    newS = Regex.Replace(
                                    newS,
                                    "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
                                    " $1",
                                    RegexOptions.Compiled)
                                .Trim();

                    newS = newS.Replace(" ", string.Empty);
                    newS = newS.Substring(0, 1).ToUpper() + newS.Substring(1);
                    result += newS;
                }
            }

            return result;
        }

        /// <summary>
        /// Convert any string to CamelCase.
        /// </summary>
        /// <param name="word">Any string.</param>
        /// <returns>A string converted to CamelCase.</returns>
        public static string ToCamelCase(this string word)
        {
            string result = "";

            if (word == null)
                return result;

            word = word.Trim();

            if (word.Length > 0)
            {
                char[] separators = new char[] {' ', '-', '_', '/'};
                string[] splittedString = word.Split(separators);
                int i = 0;

                foreach (string s in splittedString.Where(s => !string.IsNullOrEmpty(s)))
                {
                    string newS = s;
                    newS = Regex.Replace(
                                    newS,
                                    "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
                                    " $1",
                                    RegexOptions.Compiled)
                                .Trim();

                    newS = newS.Replace(" ", string.Empty);

                    if (i == 0)
                        newS = newS.Substring(0, 1).ToLower() + newS.Substring(1);
                    else
                        newS = newS.Substring(0, 1).ToUpper() + newS.Substring(1);

                    i++;
                    result += newS;
                }
            }

            return result;
        }

        /// <summary>
        /// Transform Mobioos types to C# types.
        /// </summary>
        /// <param name="type">A Mobioos type in string.</param>
        /// <returns>A C# type in string.</returns>
        public static string CSharpType(this string type)
        {
            string result = "";

            if (type == null)
                return result;

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
            string result = "";

            if (type == null)
                return result;

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
            string result = "";

            if (actionType == null)
                return result;

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
            bool result = false;

            if (type == null)
                return result;

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
                    return true;
                default:
                    return result;
            }
        }

        /// <summary>
        /// Check if the action given type is a data action or not.
        /// </summary>
        /// <param name="actionType">An action type in string.</param>
        /// <returns>A boolean.</returns>
        public static bool IsDataAction(this string actionType)
        {
            bool result = false;

            if (actionType == null)
                return result;

            switch (actionType.ToLower())
            {
                case "dataget":
                case "datalist":
                case "datacreate":
                case "dataupdate":
                case "datadelete":
                    return true;
                default:
                    return result;
            }
        }
    }
}

