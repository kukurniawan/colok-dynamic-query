namespace Colok.DynamicQuery
{
    public static class TermBoolean
    {
        internal static string GetTerm(ITerm control, int index)
        {
            return $"({string.Empty}{control.ColumnName} {GetOperator(control.Operator, index)}) ";
        }

        private static string GetOperator(SqlOperator sqlOperator, int index)
        {
            return sqlOperator switch
            {
                SqlOperator.NotEqual => $"!= @{index}",
                SqlOperator.IsNull => "== NULL",
                _ => $"= @{index}"
            };
        }
    }
}