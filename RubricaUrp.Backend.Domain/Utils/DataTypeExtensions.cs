using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace RubricaUrp.Backend.Domain.Utils
{
    public static class DataTypeExtensions
    {
        public static int ToInt2(this Enum payLoad)
        {
            return (int)(object)payLoad;
        }

        public static string ToString2(this Enum payLoad)
        {
            return ((int)(object)payLoad).ToString();
        }

        public static int ToInt<T>(this T soure) where T : IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return (int)(object)soure;
        }

        public static int Count<T>() where T : IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return Enum.GetNames(typeof(T)).Length;
        }

        public static bool IsJson(this string source)
        {
            if (source == null)
            {
                return false;
            }

            try
            {
                JsonDocument.Parse(source);
                return true;
            }
            catch (JsonException)
            {
                return false;
            }
        }

        public static List<T> DataTableToList<T>(this DataTable table) where T : class
        {
            List<T> list = new();
            foreach (DataRow row in table.Rows)
            {
                T val = Activator.CreateInstance<T>();
                PropertyInfo[] array = (from x in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                        where ValidateType(Nullable.GetUnderlyingType(x.PropertyType) ?? x.PropertyType)
                                        select x).ToArray();
                foreach (PropertyInfo propertyInfo in array)
                {
                    if (row.Table.Columns.Contains(propertyInfo.Name))
                    {
                        object obj = row[propertyInfo.Name];
                        if (obj.GetType() != typeof(DBNull))
                        {
                            propertyInfo.SetValue(val, obj, null);
                        }
                    }
                }

                list.Add(val);
            }

            return list;
        }

        public static DataTable ToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new(typeof(T).Name);
            PropertyInfo[] array = (from x in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                    where ValidateType(Nullable.GetUnderlyingType(x.PropertyType) ?? x.PropertyType)
                                    select x).ToArray();
            PropertyInfo[] array2 = array;
            foreach (PropertyInfo propertyInfo in array2)
            {
                dataTable.Columns.Add(propertyInfo.Name);
                dataTable.Columns[propertyInfo.Name]!.DataType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
            }

            foreach (T item in items)
            {
                object[] array3 = new object[array.Length];
                for (int j = 0; j < array.Length; j++)
                {
                    PropertyInfo propertyInfo2 = array[j];
                    array3[j] = propertyInfo2.GetValue(item, null) ?? new object();
                }

                dataTable.Rows.Add(array3);
            }

            return dataTable;
        }

        public static string ToListString(this List<int> items)
        {
            string res = "";
            for (int i = 0; i < items.Count; i++)
            {
                res += items[i];
                if (i < items.Count - 1)
                {
                    res += ",";
                }
            }
            return res;
        }

        public static string Truncate(this string source, int maxLength, bool addEllipsis = false)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }

            string empty;
            if (source.Length > maxLength)
            {
                empty = source[..maxLength];
                if (addEllipsis)
                {
                    empty += "...";
                }
            }
            else
            {
                empty = source;
            }

            return empty;
        }

        private static bool ValidateType(Type type)
        {
            if (!type.IsEnum)
            {
                switch (Type.GetTypeCode(type))
                {
                    case TypeCode.DBNull:
                    case TypeCode.Boolean:
                    case TypeCode.Char:
                    case TypeCode.Byte:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.Double:
                    case TypeCode.Decimal:
                    case TypeCode.DateTime:
                    case TypeCode.String:
                        return true;
                }
            }

            return false;
        }
    }
}
