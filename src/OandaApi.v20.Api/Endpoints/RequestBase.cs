using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace OandaApi.v20.Api.Endpoints
{
    public abstract class RequestBase
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffK";
        
        public string ToQueryString()
        {
            var properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty)
                .Where(p => !Attribute.IsDefined(p, typeof(IgnoreDataMemberAttribute)));
            var queryString = new StringBuilder();
            foreach (var propertyInfo in properties)
            {
                var value = propertyInfo.GetValue(this);
                if(value == null)
                    continue;

                var valueStr = value.ToString();
                if (propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType == typeof(DateTime?))
                {
                    valueStr = ((DateTime) value).ToString(DateTimeFormat);
                }

                if (queryString.Length == 0)
                    queryString.Append("?");
                else
                    queryString.Append("&");
                
                queryString.AppendFormat("{0}={1}", HttpUtility.UrlEncode(FirstLetterToLower(propertyInfo.Name)), HttpUtility.UrlEncode(valueStr));

            }

            return queryString.ToString();
        }

        private string FirstLetterToLower(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            char firstLetter = char.ToLower(input[0]);
            if (input.Length <= 1)
            {
                return firstLetter.ToString(CultureInfo.InvariantCulture);
            }

            return firstLetter + input.Substring(1, input.Length - 1);
        }
    }
}