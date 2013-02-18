using Nest.FactoryDsl;
using Nest.FactoryDsl.Filter;
using Nest.FactoryDsl.Query;

namespace ElasticTweets.Library.Queries
{
    public class TweetsContainingLinksQuery : IElasticQuery
    {        
        /*
         * { 
         *      "query" : {
         *          "constant_score" : {
         *              "filter" : {
         *                  "exists" : { "field" : "url"}
         *               }
         *          }
         *      }
         * }
         */ 
        private const string RawQuery = 
            "{ \"query\" : {\"constant_score\" : {\"filter\" : {\"exists\" : { \"field\" : \"url\"}}}}}";        

     
        public string Description 
        {
            get { return "Finds tweets that contain links"; }
        }

        public string RawQueryText { get { return RawQuery; } }

        public SearchBuilder Builder
        {
            get
            {
                var searchBuilder = new SearchBuilder();
                searchBuilder.Query(new ConstantScoreQueryBuilder(new ExistsFilterBuilder("url")));
                return searchBuilder;
            }
        }
    }
}
