using System.Collections.Generic;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace Colok.DynamicQuery.Test
{
    public class JsTermTest
    {
        [Fact]
        public void WhereTermStringTest()
        {
            var queryString = "[{\"d\":0,\"t\":\"\",\"c\":\"column\",\"v\":\"value\",\"l\":0}]";
            var whereTerms = JsonConvert.DeserializeObject<List<WhereTerm>>(queryString);
            var query = QueryBuilder.Create();
            
            query.Add(whereTerms)
                .Build();
            query.GetQuery().ShouldBe($"column = @0 ");
            query.GetValues().ShouldContain("value");
        }
    }
}