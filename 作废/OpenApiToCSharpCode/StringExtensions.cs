using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

namespace System.Linq
{
    /// <summary>
    /// 字符串<see cref="String"/>类型的扩展辅助操作类
    /// </summary>
    public static class StringExtensions
    {
        public static string 小驼峰命名(this string camel)
        {
            return 驼峰命名(camel, true);
        }
        public static string 大驼峰命名(this string camel)
        {
            return 驼峰命名(camel, false);
        }
        /// <summary>
        /// 下划线转驼峰法(默认小驼峰)
        /// </summary>
        /// <param name="camel">源字符串</param>
        /// <param name="smallCamel">大小驼峰,是否为小驼峰(驼峰，第一个字符是大写还是小写)</param>
        /// <returns>转换后的字符串</returns>
        public static string 驼峰命名(this string camel, bool smallCamel = true)
        {
            if (String.IsNullOrWhiteSpace(camel))
                return "";
            var sb = new StringBuilder();
            //匹配正则表达式
            var matcher = Regex.Matches(camel.Replace("-", "_"), "(?<name>[A-Za-z\\d]+)(_)?");
            foreach (Match item in matcher)
            {
                var word = item.Groups["name"].Value;
                //当是true 或则是空的情况
                if (smallCamel && item.Index == 0)
                {
                    sb.Append(char.ToLower(word[0]));
                }
                else
                {
                    sb.Append(char.ToUpper(word[0]));
                }
                int index = word.LastIndexOf('_');
                if (index > 0)
                {
                    sb.Append(word.Substring(1, index)/*.ToLower()*/);
                }
                else
                {
                    sb.Append(word.Substring(1)/*.ToLower()*/);
                }
            }
            return sb.ToString();
        }

        //      /**
        //* 驼峰法转下划线
        //*
        //* @param line
        //*            源字符串
        //* @return 转换后的字符串
        //*/
        //      public static String camel2Underline(String line)
        //      {
        //          if (string.IsNullOrWhiteSpace(line))
        //          {
        //              return "";
        //          }
        //          line = String.valueOf(line.charAt(0)).toUpperCase()
        //                  .concat(line.substring(1));
        //          StringBuffer sb = new StringBuffer();
        //          Pattern pattern = Pattern.compile("[A-Z]([a-z\\d]+)?");
        //          Matcher matcher = pattern.matcher(line);
        //          while (matcher.find())
        //          {
        //              String word = matcher.group();
        //              sb.append(word.toUpperCase());
        //              sb.append(matcher.end() == line.length() ? "" : "_");
        //          }
        //          return sb.toString();
        //      }


        //#region 命名方法
        ///// <summary>
        ///// 骆驼拼写法(CamelCase),除了第一个单词外的其他单词的开头字母大写. 如. testCounter.
        ///// </summary>
        ///// <param name="camel"></param>
        ///// <returns></returns>
        //public static string CamelFriendly(this string camel)
        //{
        //    if (String.IsNullOrWhiteSpace(camel))
        //        return "";

        //    var sb = new StringBuilder(camel);

        //    for (int i = camel.Length - 1; i > 0; i--)
        //    {
        //        if (char.IsUpper(sb[i]))
        //        {
        //            sb.Insert(i, ' ');
        //        }
        //    }

        //    return sb.ToString();
        //}
        //public static string HtmlClassify(this string text)
        //{
        //    if (String.IsNullOrWhiteSpace(text))
        //        return "";

        //    var friendlier = text.CamelFriendly();

        //    var result = new char[friendlier.Length];

        //    var cursor = 0;
        //    var previousIsNotLetter = false;
        //    for (var i = 0; i < friendlier.Length; i++)
        //    {
        //        char current = friendlier[i];
        //        if (IsLetter(current) || (Char.IsDigit(current) && cursor > 0))
        //        {
        //            if (previousIsNotLetter && i != 0 && cursor > 0)
        //            {
        //                result[cursor++] = '-';
        //            }

        //            result[cursor++] = Char.ToLowerInvariant(current);
        //            previousIsNotLetter = false;
        //        }
        //        else
        //        {
        //            previousIsNotLetter = true;
        //        }
        //    }

        //    return new string(result, 0, cursor);
        //}
        ///// <summary>
        ///// Generates a valid technical name.
        ///// </summary>
        ///// <remarks>
        ///// Uses a white list set of chars.
        ///// </remarks>
        //public static string ToSafeName(this string name)
        //{
        //    if (String.IsNullOrWhiteSpace(name))
        //        return String.Empty;

        //    name = RemoveDiacritics(name);
        //    name = name.Strip(c =>
        //        !c.IsLetter()
        //        && !Char.IsDigit(c)
        //        );

        //    name = name.Trim();

        //    // don't allow non A-Z chars as first letter, as they are not allowed in prefixes
        //    while (name.Length > 0 && !IsLetter(name[0]))
        //    {
        //        name = name.Substring(1);
        //    }

        //    if (name.Length > 128)
        //        name = name.Substring(0, 128);

        //    return name;
        //}
        ////public static string ToHtmlId(this string name)
        ////{
        ////    return name.Replace('.', '_');//.ToHtmlName();
        ////}
        ///// <summary>
        ///// Generates a valid Html name.
        ///// </summary>
        ///// <remarks>
        ///// Uses a white list set of chars.
        ///// </remarks>
        //public static string ToHtmlName(this string name)
        //{
        //    if (String.IsNullOrWhiteSpace(name))
        //        return String.Empty;

        //    name = RemoveDiacritics(name);
        //    name = name.Strip(c =>
        //        c != '-'
        //        && c != '_'
        //        && !c.IsLetter()
        //        && !Char.IsDigit(c)
        //        );

        //    name = name.Trim();

        //    // don't allow non A-Z chars as first letter, as they are not allowed in prefixes
        //    while (name.Length > 0 && !IsLetter(name[0]))
        //    {
        //        name = name.Substring(1);
        //    }

        //    return name;
        //}

        ///// <summary>
        ///// Whether the char is a letter between A and Z or not
        ///// </summary>
        //public static bool IsLetter(this char c)
        //{
        //    return ('A' <= c && c <= 'Z') || ('a' <= c && c <= 'z');
        //}

        ////public static bool IsSpace(this char c)
        ////{
        ////    return (c == '\r' || c == '\n' || c == '\t' || c == '\f' || c == ' ');
        ////}
        //public static string RemoveDiacritics(this string name)
        //{
        //    string stFormD = name.Normalize(NormalizationForm.FormD);
        //    var sb = new StringBuilder();

        //    foreach (char t in stFormD)
        //    {
        //        UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(t);
        //        if (uc != UnicodeCategory.NonSpacingMark)
        //        {
        //            sb.Append(t);
        //        }
        //    }

        //    return (sb.ToString().Normalize(NormalizationForm.FormC));
        //}
        ////public static string Strip(this string subject, params char[] stripped)
        ////{
        ////    if (stripped == null || stripped.Length == 0 || String.IsNullOrEmpty(subject))
        ////    {
        ////        return subject;
        ////    }

        ////    var result = new char[subject.Length];

        ////    var cursor = 0;
        ////    for (var i = 0; i < subject.Length; i++)
        ////    {
        ////        char current = subject[i];
        ////        if (Array.IndexOf(stripped, current) < 0)
        ////        {
        ////            result[cursor++] = current;
        ////        }
        ////    }

        ////    return new string(result, 0, cursor);
        ////}

        //public static string Strip(this string subject, Func<char, bool> predicate)
        //{

        //    var result = new char[subject.Length];

        //    var cursor = 0;
        //    for (var i = 0; i < subject.Length; i++)
        //    {
        //        char current = subject[i];
        //        if (!predicate(current))
        //        {
        //            result[cursor++] = current;
        //        }
        //    }

        //    return new string(result, 0, cursor);
        //}
        //#endregion 命名方法
    }
}
