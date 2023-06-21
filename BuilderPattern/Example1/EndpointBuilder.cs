using System;
using System.Text;

namespace BuilderPattern.Example1
{
    public class EndpointBuilder
    {
        private string BaseUrl = "";
        private readonly StringBuilder sbBaseUrl = new();
        private readonly StringBuilder sbParams = new();
        private const string defaultDelimiter = "/";

        public EndpointBuilder(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
          
        public EndpointBuilder Append(string value)
        {
            sbBaseUrl.Append(value);
            sbBaseUrl.Append(defaultDelimiter);
            return this;
        }

        public EndpointBuilder AppendParam(string key, string value)
        {
            sbParams.AppendFormat("{0}={1}",key,value);
            return this;
        }

        public EndpointBuilder Build()
        {
            if (BaseUrl.EndsWith(defaultDelimiter))
            {
                BaseUrl += sbBaseUrl.ToString();
                BaseUrl += sbParams.ToString();
            }
            return this;
        }

        public void PrintUrl()
        {
            Console.WriteLine(this.BaseUrl);
        }

        
     }
}

