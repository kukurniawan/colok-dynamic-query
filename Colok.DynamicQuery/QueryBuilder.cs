using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Colok.DynamicQuery
{
    public class QueryBuilder
    {
        private readonly IList<ITerm> _listParameters;
        private IList<object> _listValue;
        private string _query;

        public QueryBuilder()
        {
            _listParameters = new List<ITerm>();
        }

        public QueryBuilder Add(ITerm term)
        {
            _listParameters.Add(term);
            return this;
        }

        public void Build()
        {
            var query = new StringBuilder();
            _listValue = new Collection<object>();
            var pass = 0;

            var total = _listParameters.Count - 1;
            var indexLogical = 0;
            foreach (var param in _listParameters)
            {
                var index = _listParameters.IndexOf(param) + pass;
                switch (param.DataType)
                {
                    case ParameterDataType.DateTime:
                        query.Append(
                            GetParameter(param, index) +
                            AddLogicalOperator(total, indexLogical, param));
                        _listValue.Add(param.Value);
                        indexLogical++;
                        break;
                    case ParameterDataType.Guid:
                        query.Append(
                            GetParameter(param, index) +
                            AddLogicalOperator(total, indexLogical, param)
                            );
                        _listValue.Add(new Guid(param.Value.ToString()));
                        indexLogical++;
                        break;
                    case ParameterDataType.Number:
                        query.Append(
                            GetParameter(param, index) +
                            AddLogicalOperator(total, indexLogical, param));
                        _listValue.Add(Convert.ToInt32(param.Value));
                        indexLogical++;
                        break;
                    default:
                        query.Append(
                            GetParameter(param, index) +
                            AddLogicalOperator(total, indexLogical, param));
                        _listValue.Add(param.Value);
                        indexLogical++;
                        break;
                }

            }
            if (query.Length != 0)
            {
                _query = ComposeLogicalBracket(query + " AND ");
            }

            _query = query.ToString();
        }
        
        private static string ComposeLogicalBracket(string val)
        {
            /*var val = "1 OR 2 OR 3 AND 4 OR 5 AND 6 OR 7 OR 8 OR 9 OR 10 AND 11 OR ";
            val = "1 OR 2 OR 3 OR 4 OR 5 OR 6 OR 7 OR 8 OR 9 OR 10 OR";
            val = "1 OR 2 AND 3 OR 4 AND 5 OR 6 AND 7 OR 8 AND 9 OR 10 AND";
            val = "1 AND 2 OR 3 AND 4 OR 5 AND 6 OR 7 AND 8 OR 9 AND 10 AND";*/
            var a = val.Split(new[] { "AND", "OR" }, StringSplitOptions.None);
            var list = a.ToList();
            if (list.Count == 1) return val;

            var result = "";
            
            var br = false;
            foreach (var item in list)
            {
                var index = list.IndexOf(item) + 1;
                if (index >= list.Count || string.IsNullOrEmpty(item.Trim()))
                    continue;
                var rr = val.Between(item.Trim(), list[index].Trim());
                if (rr.Trim().ToLower().Equals("and"))
                {
                    if (br)
                    {
                        br = false;
                        result += item + ") AND ";
                    }
                    else
                        result += item + " AND ";
                    
                }
                else
                {
                    if (!br)
                    {
                        if (index + 1 >= list.Count)
                            result += item;
                        else
                            result += "(" + item + " OR ";
                        br = true;
                        
                    }
                    else
                    {
                        if (index + 1 >= list.Count)
                        {
                            result += item + ")";
                            br = false;
                            
                        }
                        else
                        {
                            result += item + " OR ";
                        }
                    }

                }
            }
            return result;
        }

        public string GetQuery()
        {
            return _query;
        }

        public object[] GetValues()
        {
            return _listValue.ToArray();
        }
        
        private static string AddLogicalOperator(int total, int indexLogical, ITerm param)
        {
            return total - indexLogical == 0 ? "" : $"{param.Logical.ToString()} ";
        }
        
        private static string GetParameter(ITerm param, int index)
        {
            return param.DataType switch
            {
                ParameterDataType.Number => TermNumber.GetTerm(param, index),
                ParameterDataType.DateTime => TermDateTime.GetTerm(param, index),
                ParameterDataType.Bool => TermBoolean.GetTerm(param, index),
                ParameterDataType.Guid => TermGuid.GetTerm(param, index),
                _ => TermChar.GetTerm(param, index)
            };
        }

        public static QueryBuilder Create()
        {
            return new QueryBuilder();
        }
        
    }
}