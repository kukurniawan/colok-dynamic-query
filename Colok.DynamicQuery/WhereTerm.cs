using System.Text.Json.Serialization;

namespace Colok.DynamicQuery
{
    public class WhereTerm : ITerm
    {
        [JsonPropertyName("d")]
        public ParameterDataType DataType { get; set; }
        [JsonPropertyName("t")]
        public string TableName { get; set; }
        [JsonPropertyName("c")]
        public string ColumnName { get; set; }
        [JsonPropertyName("o")]
        public SqlOperator Operator { get; set; }
        [JsonPropertyName("v")]
        public object Value { get; set; }
        [JsonPropertyName("l")]
        public LogicalOperator Logical { get; set; } = LogicalOperator.AND;
        [JsonPropertyName("n")]
        public bool Nullable { get; set; } = false;

    }
}