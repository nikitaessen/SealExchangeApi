using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SealExchangeApi.Services.Extensions
{
    public static class StringExtensions
    {
        private const string IS_FORMATTED_REGEX_STRING = @"{\d+}";
        private const string HEX_STRING_FORMAT = @"{0:x2}";
        public const string LETTERS_AND_NUMBERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";


        public static string EnsureStartsWith(this string targetStr, string startsWith)
        {
            if (targetStr == null)
            {
                return targetStr;
            }

            return targetStr.StartsWith(startsWith) ? targetStr : $"{startsWith}{targetStr}";
        }

        public static string EnsureNotStartsWith(this string targetStr, string startsWith)
        {
            if (targetStr == null)
            {
                return targetStr;
            }

            return targetStr.StartsWith(startsWith)
                ? targetStr.Substring(startsWith.Length, targetStr.Length - startsWith.Length)
                : targetStr;
        }

        public static bool IsFormattedString(this string targetStr)
        {
            var regex = new Regex(IS_FORMATTED_REGEX_STRING);
            return regex.IsMatch(targetStr);
        }

        public static string EnsureNotEndsWith(this string targetStr, string endsWith)
        {
            if(targetStr == null)
            {
                return targetStr;
            }

            return targetStr.EndsWith(endsWith)
                ? targetStr.Substring(0, targetStr.Length - endsWith.Length)
                : targetStr;
        }

        public static string DecodeFromBase64AsUtf8(this string target)
        {
            var base64EncodedBytes = Convert.FromBase64String(target);

            return Encoding.UTF8.GetString(base64EncodedBytes, 0, base64EncodedBytes.Length);
        }

        public static string RandomString(this string targetStr, int length)
        {
            var random = new Random();
            return new string(
                Enumerable.Repeat(LETTERS_AND_NUMBERS, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string JoinSkippingNullOrEmpty(string separator, IEnumerable<string> values)
        {
            return string.Join(separator, values.Where(s => !string.IsNullOrEmpty(s)));
        }

        public static string ToTitleCase(this string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                return null;
            }

            if (target.Length == 0)
            {
                return target;
            }

            var result = new StringBuilder(target.ToLowerInvariant());
            result[0] = char.ToUpper(result[0]);

            return result.ToString();
        }

        public static Stream GetStreamForRead(this string target)
        {
            var stream = new MemoryStream();

            var writer = new StreamWriter(stream);
            writer.Write(target);
            writer.Flush();

            stream.Position = 0;

            return stream;
        }

        public static string HtmlDecode(this string target)
        {
            return System.Net.WebUtility.HtmlDecode(target);
        }

        public static string AsHexString(this byte[] sourceBytes)
        {
            var hex = new StringBuilder(sourceBytes.Length * 2);

            foreach (var chr in sourceBytes)
            {
                hex.AppendFormat(HEX_STRING_FORMAT, chr);
            }

            return hex.ToString();
        }


        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        public static string ToLowercaseWithFirstLetterUppercase(this string target)
        {
            var lowercaseString = target.ToLower();

            if (string.IsNullOrEmpty(lowercaseString))
            {
                return lowercaseString;
            }

            var firstLetterUppercase = lowercaseString.Substring(0, 1).ToUpper();

            return firstLetterUppercase + lowercaseString.Remove(0, 1);
        }
    }
}