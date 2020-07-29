﻿using System;
using System.Collections.Generic;

namespace Simple.Data.Access
{
    internal static class AccessTypeResolver
    {
        private static readonly Dictionary<string, Type> ClrTypes = new Dictionary<string, Type>
                                                                        {
                                                                            {"image", typeof (byte[])},
                                                                            {"text", typeof (string)},
                                                                            {"long", typeof (long)},
                                                                            {"uniqueidentifier", typeof (Guid)},
                                                                            {"date", typeof (DateTime)},
                                                                            {"time", typeof (DateTime)},
                                                                            {"datetime2", typeof (DateTime)},
                                                                            {"datetimeoffset", typeof (DateTime)},
                                                                            {"tinyint", typeof (byte)},
                                                                            {"smallint", typeof (short)},
                                                                            {"int", typeof (int)},
                                                                            {"smalldatetime", typeof (DateTime)},
                                                                            {"real", typeof (float)},
                                                                            {"money", typeof (decimal)},
                                                                            {"datetime", typeof (DateTime)},
                                                                            {"float", typeof (float)},
                                                                            {"sql_variant", typeof (object)},
                                                                            {"ntext", typeof (string)},
                                                                            {"bit", typeof (bool)},
                                                                            {"decimal", typeof (decimal)},
                                                                            {"numeric", typeof (float)},
                                                                            {"smallmoney", typeof (decimal)},
                                                                            {"bigint", typeof (long)},
                                                                            {"varbinary", typeof (byte[])},
                                                                            {"varchar", typeof (string)},
                                                                            {"binary", typeof (byte[])},
                                                                            {"char", typeof (string)},
                                                                            {"timestamp", typeof (DateTime)},
                                                                            {"nvarchar", typeof (string)},
                                                                            {"nchar", typeof (string)},
                                                                            {"xml", typeof (string)},
                                                                            {"sysname", typeof (string)},
                                                                        };

        public static Type GetClrType(string sqlTypeName)
        {
            return ClrTypes.TryGetValue(sqlTypeName, out Type clrType) ? clrType : typeof(object);
        }
    }
}