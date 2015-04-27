using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Parkers.Data
{
    /// <summary>
	/// Utility class for dealing with IDataRecords.
	/// </summary>
	public static class DataUtil
	{
		/// <summary>
		/// Gets a given column as an Int64, or 0 if the column is NULL
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public static long GetInt64( IDataRecord dr, string column )
		{
			if ( dr.IsDBNull( dr.GetOrdinal( column ) ) )
			{
				return 0;
			}
			else
			{
				return (long) dr[column];
			}
		}

		/// <summary>
		/// Gets a given column as an Int32, or 0 if the column is NULL
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public static int GetInt32( IDataRecord dr, string column )
		{
			return GetInt32( dr, column, 0 );
		}

		/// <summary>
		/// Gets a given column as an Int32, or nullValue if the column is NULL
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="column"></param>
		/// <param name="nullValue"></param>
		/// <returns></returns>
		public static int GetInt32( IDataRecord dr, string column, int nullValue )
		{
			if ( dr.IsDBNull( dr.GetOrdinal( column ) ) )
			{
				return nullValue;
			}
			else
			{
				return (int) dr[column];
			}
		}

		/// <summary>
		/// Gets a given column as an Int16, or 0 if the column is NULL
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public static short GetInt16( IDataRecord dr, string column )
		{
			if ( dr.IsDBNull( dr.GetOrdinal( column ) ) )
			{
				return 0;
			}
			else
			{
				return (short) dr[column];
			}
		}

		/// <summary>
		/// Gets a given column as a Decimal, or 0 if the column is NULL
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public static decimal GetDecimal( IDataRecord dr, string column )
		{
			if ( dr.IsDBNull( dr.GetOrdinal( column ) ) )
			{
				return 0M;
			}
			else
			{
				return (decimal) dr[column];
			}
		}

		/// <summary>
		/// Gets a given column as a Double, or 0 if the column is NULL
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public static double GetDouble( IDataRecord dr, string column )
		{
			return GetDouble( dr, column, 0.0 );
		}
		
		/// <summary>
		/// Gets a given column as a Double, or nullValue if the column is NULL
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="column"></param>
		/// <param name="nullValue"></param>
		/// <returns></returns>
		public static double GetDouble( IDataRecord dr, string column, double nullValue )
		{
			if ( dr.IsDBNull( dr.GetOrdinal( column ) ) )
			{
				return nullValue;
			}
			else
			{
				return (double) dr[column];
			}
		}

		/// <summary>
		/// Gets a given column as a Guid, or Guid.Empty if the column is NULL
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public static Guid GetGuid( IDataRecord dr, string column )
		{
			if ( dr.IsDBNull( dr.GetOrdinal( column ) ) )
			{
				return Guid.Empty;
			}
			else
			{
				return (Guid) dr[column];
			}
		}

        /// <summary>
        /// Gets the nullable date time.
        /// </summary>
        /// <param name="dr">The dr.</param>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public static DateTime? GetNullableDateTime(IDataRecord dr, string column)
        {
            if (dr.IsDBNull(dr.GetOrdinal(column)))
            {
                return null;
            }
            else
            {
                return GetDateTime(dr, column);
            }
        }

        /// <summary>
        /// Gets the nullable int.
        /// </summary>
        /// <param name="dr">The dr.</param>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public static int? GetNullableInt(IDataRecord dr, string column)
        {
            if (dr.IsDBNull(dr.GetOrdinal(column)))
            {
                return null;
            }
            else
            {
                return GetInt32(dr, column);
            }
        }

        /// <summary>
        /// Gets the nullable bool.
        /// </summary>
        /// <param name="dr">The dr.</param>
        /// <param name="column">The column.</param>
        /// <returns>the value as a nullable bool</returns>
        public static bool? GetNullableBool(IDataRecord dr, string column)
        {
            Nullable<bool> result = null;

            if (!dr.IsDBNull(dr.GetOrdinal(column)))
            {
                result = GetBoolean(dr, column);
            }

            return result;
        }

		/// <summary>
		/// Gets a given column as a DateTime, or DateTime.MinValue if the column is NULL
		/// </summary>
		public static DateTime GetDateTime( IDataRecord dr, string column )
		{
            return GetDateTime(dr, column, DateTime.MinValue);
		}

        /// <summary>
		/// Gets a given column as a DateTime, or nullValue if the column is NULL
        /// </summary>
        public static DateTime GetDateTime(IDataRecord dr, string column, DateTime nullValue)
        {
            if (dr.IsDBNull(dr.GetOrdinal(column)))
            {
                return nullValue;
            }
            else
            {
                return (DateTime)dr[column];
            }
        }

		/// <summary>
		/// Gets a given column as a Boolean, or False if the column is NULL
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public static bool GetBoolean( IDataRecord dr, string column )
		{
			if ( dr.IsDBNull( dr.GetOrdinal( column ) ) )
			{
				return false;
			}
			else
			{
				return (bool) dr[column];
			}
		}

		/// <summary>
		/// Gets a given column as a string, or an empty string if the column is NULL
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public static string GetString( IDataRecord dr, string column )
		{
			return GetString( dr, column, "" );
		}

		/// <summary>
		/// Gets a given column as a string, or nullValue if the column is NULL
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="column"></param>
		/// <param name="nullValue"></param>
		/// <returns></returns>
		public static string GetString( IDataRecord dr, string column, string nullValue )
		{
			if ( dr.IsDBNull( dr.GetOrdinal( column ) ) )
			{
				return nullValue;
			}
			else
			{
                //try
                //{
                return (string)dr[column];
                //}
                //catch
                //{
                //    return "s";
                //}
			}
		}

		/// <summary>
		/// Returns nullValue if obj is null, or obj otherwise.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="nullValue"></param>
		/// <returns></returns>
		public static object TranslateNull( object obj, object nullValue )
		{
			if ( obj == null )
			{
				return nullValue;
			}
			else
			{
				return obj;
			}
		}

		/// <summary>
		/// Returns DBNull.Value if obj is null, or obj otherwise.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static object TranslateNull( object obj )
		{
			return TranslateNull( obj, DBNull.Value );
		}

	}
}
