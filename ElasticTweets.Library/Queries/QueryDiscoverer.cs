using System;
using System.Linq;
using System.Reflection;

namespace ElasticTweets.Library.Queries
{
    public class QueryDiscoverer
    {
        public IElasticQuery[] FindAll()
        {            
            return
                Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => typeof(IElasticQuery).IsAssignableFrom(t) && t.IsClass)
                    .Select(query => (IElasticQuery) Activator.CreateInstance(query)).ToArray();
        }
    }    
}
