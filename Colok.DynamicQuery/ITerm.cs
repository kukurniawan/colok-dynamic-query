namespace Colok.DynamicQuery
{
    public interface ITerm
    {
        ParameterDataType DataType { get; set; }
        string TableName { get; set; }
        string ColumnName { get; set; }
        SqlOperator Operator { get; set; }
        object Value { get; set; }
        LogicalOperator Logical { get; set; }
        bool Nullable { get; set; }
    }
}