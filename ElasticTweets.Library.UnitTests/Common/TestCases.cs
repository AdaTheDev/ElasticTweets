using System.Collections.Generic;

namespace ElasticTweets.Library.UnitTests.Common
{
    public static class TestCases
    {
        public static IEnumerable<string> NullOrWhiteSpaceStrings
        {
            get
            {
                yield return "";
                yield return "  ";
                yield return null;
            }
        }  
    }
}
