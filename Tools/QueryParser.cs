using System.Text.RegularExpressions;

namespace TodoList.Tools
{
    public class QueryParser
    {
        public static object Parse(string QueryString)
        {
            object obj = new { };
            Regex rg = new Regex(@"(?<key>[\w\d]+)=(?<value>[\w\d]+)");
            MatchCollection collection = rg.Matches(QueryString);
            if(rg.IsMatch(QueryString))
            {
                for(var i = 0; i < collection.Count; i++) {
                    obj.GetType().GetProperty(collection[i].Groups[0].Value).SetValue(obj, collection[i].Groups[1].Value);
                }
            }
            return obj;
        }
    }
}
