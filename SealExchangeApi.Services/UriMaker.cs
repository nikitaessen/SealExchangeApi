using System;
using System.Linq;
using System.Text;
using SealExchangeApi.Services.Extensions;

namespace SealExchangeApi.Services
{
    public class UriMaker
    {
        public const string SLASH = "/";
        public const string AMPERSAND = "&";
        public const string QUESTION_SIGN = "?";

        //TODO Unit Tests
        public string Combine(string baseUrl, params string[] pathFragments)
        {
            if (pathFragments.Length == 0)
            {
                throw new ArgumentException("Uri fragments is not defined", nameof(pathFragments));
            }

            var uriStrBuilder = new StringBuilder();

            uriStrBuilder.Append(baseUrl.EnsureNotEndsWith(SLASH));

            pathFragments.Aggregate(
                uriStrBuilder,
                (url, fragment) =>
                    url.Append(fragment.EnsureStartsWith(SLASH).EnsureNotEndsWith(SLASH)));

            return uriStrBuilder.ToString();
        }

        public string CombineQuery(string baseUrl, params string[] queryParams)
        {
            if (queryParams.Length == 0)
            {
                throw new ArgumentException("Uri fragments is not defined", nameof(queryParams));
            }

            var uriStrBuilder = new StringBuilder(baseUrl);

            uriStrBuilder.Append(
                queryParams.First()
                    .EnsureNotStartsWith(AMPERSAND)
                    .EnsureStartsWith(QUESTION_SIGN)
                    .EnsureNotEndsWith(AMPERSAND));

            var j = 0;
            var remainingParams = new string[queryParams.Length - 1];
            for (var i = 1; i < queryParams.Length; i++)
            {
                remainingParams[j] = queryParams[i];
                j++;
            }

            remainingParams.Aggregate(
                uriStrBuilder,
                (uri, fragment) =>
                    uri.Append(fragment.EnsureStartsWith(AMPERSAND).EnsureNotEndsWith(AMPERSAND)));

            return uriStrBuilder.ToString();
        }
    }
}