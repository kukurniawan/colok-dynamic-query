namespace Colok.DynamicQuery
{
    public static class TermGuid
    {
        internal static string GetTerm(ITerm param, int index)
        {
            return $"{string.Empty}{param.ColumnName} {GetOperator(param.Operator, index)} ";
        }

        private static string GetOperator(SqlOperator @operator, int param)
        {
            return @operator switch
            {
                SqlOperator.NotEqual => $"<> @{param}",
                _ => $"= @{param}"
            };
        }
    }
}