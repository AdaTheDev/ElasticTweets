using System.Linq;
using ElasticTweets.Library.Data;
using Nest;

namespace ElasticTweets.Library.Queries
{
    public class TweetsContainingLinksQuery : IElasticQuery
    {        
        /*
         * { 
         *      "query" : {
         *          "constant_score" : {
         *              "filter" : {
         *                  "exists" : { "field" : "entities.urls.url"}
         *               }
         *          }
         *      }
         * }
         */ 
        private const string RawQuery = 
            "{ \"query\" : {\"constant_score\" : {\"filter\" : {\"exists\" : { \"field\" : \"entities.urls.url\"}}}}}";        

     
        public string Description 
        {
            get { return "Tweets that contain links"; }
        }

        public string RawQueryText { get { return RawQuery; } }

        public QueryDescriptor<Tweet> Query
        {
            get
            {
                var query = new QueryDescriptor<Tweet>();
                query.ConstantScore(cs => cs.Filter(fd => fd.Exists(t =>t.entities.urls.First().url)));
                return query;
            }
        }
    }
}
