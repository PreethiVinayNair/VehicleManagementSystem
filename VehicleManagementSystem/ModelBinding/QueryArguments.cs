using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace VMS.ModelBinding
{
  public class QueryArguments
  {
    public QueryArguments(IQueryCollection query)
    {
      Query = query;
    }

    public IQueryCollection Query { get; }

    public string GetString(string name)
    {
      if (name == null)
      {
        return null;
      }

      return Query[name];
    }

    public string[] GetValues(string name)
    {
      if (name == null)
      {
        return null;
      }

      return Query[name];
    }

    public IDictionary<string, StringValues> Data {
      get {
        return Query.Keys.ToDictionary(
            key => key,
            key =>
            {
              var values = GetValues(key);
              if (values == null || values.Length == 0)
              {
                return StringValues.Empty;
              }

              return values.Length == 1 ? (StringValues)values[0] : (StringValues)values;
            }, StringComparer.OrdinalIgnoreCase);
      }
    }

    public override string ToString()
    {
      return string.Join("&", GetKeyValuePairs().Select(
          kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));
    }

    private IEnumerable<KeyValuePair<string, string>> GetKeyValuePairs()
    {
      foreach (var key in Query.Keys)
      {
        foreach (var value in Query[key])
        {
          yield return new KeyValuePair<string, string>(key, value);
        }
      }
    }
  }
}