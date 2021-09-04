using System;
using Shouldly;
using Xunit;

namespace Colok.DynamicQuery.Test
{
    public class QueryBuilderOneTermTest
    {
        [Fact]
        public void WhereTermStringTest()
        {
            var query = QueryBuilder.Create();
            
            query.Add(Q.P("value", "column")).Build();
            query.GetQuery().ShouldBe($"column = @0 ");
            query.GetValues().ShouldContain("value");
        }
        
        [Fact]
        public void WhereTermNumberTest()
        {
            var query = QueryBuilder.Create();
            
            query.Add(Q.P(100, "column")).Build();
            query.GetQuery().ShouldBe($"column = @0 ");
            query.GetValues().ShouldContain(100);
        }
        
        [Fact]
        public void WhereTermDateTimeTest()
        {
            var query = QueryBuilder.Create();
            var date = DateTime.Now;
            query.Add(Q.P(date, "column")).Build();
            query.GetQuery().ShouldBe($"column = @0 ");
            query.GetValues().ShouldContain(date);
        }
        
        [Fact]
        public void WhereTermBooleanTest()
        {
            var query = QueryBuilder.Create();
            query.Add(Q.P(true, "column")).Build();
            query.GetQuery().ShouldBe($"column = @0 ");
            query.GetValues().ShouldContain(true);
        }
        
        [Fact]
        public void WhereTermGuidTest()
        {
            var query = QueryBuilder.Create();
            var id = Guid.NewGuid();
            query.Add(Q.P(id, "column")).Build();
            query.GetQuery().ShouldBe($"column = @0 ");
            query.GetValues().ShouldContain(id);
        }
    }
}