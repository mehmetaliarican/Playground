using System;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Playground
{
   static  class Program
    {
        static void Main(string[] args)
        {
            var content = File.ReadAllText("request.txt");
            var decoded = HttpUtility.UrlDecode(content, Encoding.UTF8);

            var x = decoded.Split("?");
            var uriObject = new Uri(decoded);
            var b = HttpUtility.ParseQueryString(uriObject.Query, Encoding.UTF8);
            var dict = b.ToDictionary();
            Console.WriteLine();
        }

        public static IDictionary<string, string> ToDictionary(this NameValueCollection collection)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var key in collection.AllKeys)
            {
                dictionary.Add(key, collection[key]);
            }

            return dictionary;
        }
    }
}
