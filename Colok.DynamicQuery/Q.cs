using System;

namespace Colok.DynamicQuery
{
    public static class Q
    {
        public static WhereTerm P(string value, string column)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = string.Empty,
                DataType = ParameterDataType.Char,
                Operator = SqlOperator.Equals,
                ColumnName = column
            };
        }
        public static WhereTerm P(string value, string column, string tableName)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = tableName,
                DataType = ParameterDataType.Char,
                Operator = SqlOperator.Equals,
                ColumnName = column
            };
        }
        public static WhereTerm P(string value, string column, SqlOperator sqlOperator)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = string.Empty,
                DataType = ParameterDataType.Char,
                Operator = sqlOperator,
                ColumnName = column
            };
        }
        public static WhereTerm P(string value, string column, SqlOperator sqlOperator, LogicalOperator logical)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = string.Empty,
                DataType = ParameterDataType.Char,
                Operator = sqlOperator,
                ColumnName = column,
                Logical = logical
            };
        }
        public static WhereTerm P(string value, string column, SqlOperator sqlOperator, LogicalOperator logical, ParameterDataType type)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = string.Empty,
                DataType = type,
                Operator = sqlOperator,
                ColumnName = column,
                Logical = logical
            };
        }
        public static WhereTerm P(Guid value, string column)
        {
            return new WhereTerm
            {
                Value = value.ToString(),
                TableName = string.Empty,
                DataType = ParameterDataType.Guid,
                Operator = SqlOperator.Equals,
                ColumnName = column
            };
        }
        public static WhereTerm P(Guid value, string column, SqlOperator sqlOperator)
        {
            return new WhereTerm
            {
                Value = value.ToString(),
                TableName = string.Empty,
                DataType = ParameterDataType.Guid,
                Operator = sqlOperator,
                ColumnName = column
            };
        }
        public static WhereTerm P(DateTime value, string column)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = string.Empty,
                DataType = ParameterDataType.DateTime,
                Operator = SqlOperator.Equals,
                ColumnName = column
            };
        }
        public static WhereTerm P(DateTime value, string column, SqlOperator sqlOperator)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = string.Empty,
                DataType = ParameterDataType.DateTime,
                Operator = sqlOperator,
                ColumnName = column
            };
        }
        public static WhereTerm P(DateTime value, string column, SqlOperator sqlOperator, LogicalOperator logical)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = string.Empty,
                DataType = ParameterDataType.DateTime,
                Operator = sqlOperator,
                ColumnName = column,
                Logical = logical
            };
        }
        public static WhereTerm P(DateTime? value, string column)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = string.Empty,
                DataType = ParameterDataType.DateTime,
                Operator = SqlOperator.Equals,
                Nullable = true,
                ColumnName = column
            };
        }
        public static WhereTerm P(int value, string column)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = string.Empty,
                DataType = ParameterDataType.Number,
                Operator = SqlOperator.Equals,
                ColumnName = column
            };
        }
        public static WhereTerm P(int value, string column, SqlOperator sqlOperator)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = string.Empty,
                DataType = ParameterDataType.Number,
                Operator = sqlOperator,
                ColumnName = column
            };
        }
        public static WhereTerm P(decimal value, string column)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = string.Empty,
                DataType = ParameterDataType.Number,
                Operator = SqlOperator.Equals,
                ColumnName = column,
                Logical = LogicalOperator.AND
            };
        }
        public static WhereTerm P(bool value, string column)
        {
            return new WhereTerm
            {
                Value = value,
                TableName = string.Empty,
                DataType = ParameterDataType.Bool,
                Operator = SqlOperator.Equals,
                ColumnName = column
            };
        }
        
    }
}