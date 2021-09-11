using Newtonsoft.Json;

namespace Colok.DynamicQuery
{
    public class WhereTerm : ITerm
    {
        [JsonProperty("d")]
        public ParameterDataType DataType { get; set; }
        [JsonProperty("t")]
        public string TableName { get; set; }
        [JsonProperty("c")]
        public string ColumnName { get; set; }
        [JsonProperty("o")]
        public SqlOperator Operator { get; set; }
        [JsonProperty("v")]
        public object Value { get; set; }
        [JsonProperty("l")]
        public LogicalOperator Logical { get; set; } = LogicalOperator.AND;
        [JsonProperty("n")]
        public bool Nullable { get; set; } = false;

    }
}