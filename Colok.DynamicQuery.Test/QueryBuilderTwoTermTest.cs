using System;
using Shouldly;
using Xunit;

namespace Colok.DynamicQuery.Test
{
    public class QueryBuilderTwoTermTest
    {
        [Fact]
        public void WhereTermStringTest()
        {
            var query = QueryBuilder.Create();
            
            query.Add(Q.P("value", "column"))
                .Add(Q.P("value2", "foo"))
                .Build();
            query.GetQuery().ShouldBe($"column = @0 AND foo = @1 ");
            query.GetValues().ShouldContain("value");
            query.GetValues().ShouldContain("value2");
        }
        
        [Fact]
        public void WhereTermStringNumberTest()
        {
            var query = QueryBuilder.Create();
            
            query.Add(Q.P("value", "column"))
                .Add(Q.P(100, "foo"))
                .Build();
            query.GetQuery().ShouldBe($"column = @0 AND foo = @1 ");
            query.GetValues().ShouldContain("value");
            query.GetValues().ShouldContain(100);
        }
        
        [Fact]
        public void WhereTermStringNumberWithOrOperatorTest()
        {
            var query = QueryBuilder.Create();
            
            query.Add(Q.P("value", "column", SqlOperator.Equals, LogicalOperator.OR))
                .Add(Q.P(100, "foo"))
                .Build();
            query.GetQuery().ShouldBe($"column = @0 OR foo = @1 ");
            query.GetValues().ShouldContain("value");
            query.GetValues().ShouldContain(100);
        }
        
        [Fact]
        public void WhereTermStringNumberWithOrOperatorTest2()
        {
            var query = QueryBuilder.Create();
            
            query.Add(Q.P("value", "column", SqlOperator.Equals, LogicalOperator.OR))
                .Add(Q.P(100, "foo", SqlOperator.GreatThan))
                .Build();
            query.GetQuery().ShouldBe($"column = @0 OR foo > @1 ");
            query.GetValues().ShouldContain("value");
            query.GetValues().ShouldContain(100);
        }
        
        [Fact]
        public void WhereTermStringNumberDateTime()
        {
            var query = QueryBuilder.Create();
            var now = DateTime.Now;
            query.Add(Q.P(100, "column", SqlOperator.GreatThanEqual))
                .Add(Q.P("value", "foo", SqlOperator.NotEqual, LogicalOperator.OR))
                .Add(Q.P(now, "date", SqlOperator.LessThan))
                .Build();
            query.GetQuery().ShouldBe($"column >= @0 AND foo <> @1 OR date < @2 ");
            query.GetValues().ShouldContain("value");
            query.GetValues().ShouldContain(100);
            query.GetValues().ShouldContain(now);
        }
    }
}