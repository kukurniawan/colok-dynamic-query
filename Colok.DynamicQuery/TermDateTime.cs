using System.Text;

namespace Colok.DynamicQuery
{
    public static class TermDateTime
    {
        internal static string GetTerm(ITerm param, int index)
        {
            return $"{string.Empty}{param.ColumnName} {GetOperator(param.Operator, index)} ";
        }
        
        private static object GetOperator(SqlOperator sqlOperator, int index)
        {
            return sqlOperator switch
            {
                SqlOperator.NotEqual => new StringBuilder().AppendFormat("<> @{0}", index),
                SqlOperator.GreatThan => new StringBuilder().AppendFormat("> @{0}", index),
                SqlOperator.GreatThanEqual => new StringBuilder().AppendFormat(">= @{0}", index),
                SqlOperator.LessThan => new StringBuilder().AppendFormat("< @{0}", index),
                SqlOperator.LesThanEqual => new StringBuilder().AppendFormat("<= @{0}", index),
                SqlOperator.IsNull => new StringBuilder().AppendFormat("== NULL"),
                _ => new StringBuilder().AppendFormat("= @{0}", index)
            };
        }
        
        
    }
}