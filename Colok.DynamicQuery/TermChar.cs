namespace Colok.DynamicQuery
{
    public static class TermChar
    {
        private static string GetOperator(SqlOperator @operator, int param)
        {
            return @operator switch
            {
                SqlOperator.NotEqual => $"<> @{param}",
                SqlOperator.GreatThan => $"> @{param}",
                SqlOperator.GreatThanEqual => $">= @{param}",
                SqlOperator.LessThan => $"< @{param}",
                SqlOperator.LesThanEqual => $"<= @{param}",
                SqlOperator.BeginWith => $".StartsWith(@{param})",
                SqlOperator.EndWith => $".EndsWith(@{param})",
                SqlOperator.Like => $".Contains(@{param})",
                _ => $"= @{param}"
            };
        }
        
        internal static string GetTerm(ITerm param, int index)
        {
            return
                $"{(string.IsNullOrEmpty(param.TableName) ? string.Empty : param.TableName + ".")}{param.ColumnName} {GetOperator(param.Operator, index)} ";
        }

                
    }
}