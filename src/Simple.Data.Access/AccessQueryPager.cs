﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using Simple.Data.Ado;

namespace Simple.Data.Access
{
    [Export(typeof(IQueryPager))]
    public class AccessQueryPager : IQueryPager
    {
        private static readonly Regex ColumnExtract = new Regex(@"SELECT\s*(.*)\s*(FROM.*)",
                                                                RegexOptions.Multiline | RegexOptions.IgnoreCase);

        private static readonly Regex SelectMatch = new Regex(@"^SELECT\s*", RegexOptions.IgnoreCase);

        #region IQueryPager Members

        public IEnumerable<string> ApplyLimit(string sql, int take)
        {
            yield return SelectMatch.Replace(sql, match => match.Value + " TOP " + take + " ");
        }

        public IEnumerable<string> ApplyPaging(string sql, string[] keys, int skip, int take)
        {
            if (sql.IndexOf("order by", StringComparison.InvariantCultureIgnoreCase) < 0)
            {
                Match match = ColumnExtract.Match(sql);
                string columns = match.Groups[1].Value.Trim();
                sql += " ORDER BY " + columns.Split(',').First().Trim();
            }

            yield return string.Format("{0} OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY", sql, skip, take);
        }

        #endregion
    }
}