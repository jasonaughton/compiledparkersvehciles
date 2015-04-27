using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Parkers.Data
{
	/// <summary>
	/// Utility class to access the ASP.NET cache.
	/// </summary>
	/// <remarks>
	/// These methods are accessible anywhere, whether or not HttpContext.Current is available.
	/// </remarks>
	public static class CacheUtil
	{
		/// <summary>
		/// Gets a given cache item as a given type.
		/// </summary>
		/// <typeparam name="T">The type that the cache item is expected to be</typeparam>
		/// <param name="key">The cache key to retrieve</param>
		/// <returns>The cache item, or default(T) if the cache item is not present or is not of type T</returns>
		public static T Get<T>( string key )
		{
            if (HttpRuntime.Cache != null)
			{
                object o = HttpRuntime.Cache[key];
				if ( o is T )
				{
					return (T) o;
				}
			}
			return default( T );
		}

		/// <summary>
		/// Inserts a cache item with a 15 minute absolute expiration and CacheItemPriority.Default
		/// </summary>
		/// <param name="item"></param>
		/// <param name="key"></param>
		public static void Put( object item, string key )
		{
			Put( item, key, new TimeSpan( 0, 15, 0 ) );
		}

		/// <summary>
		/// Inserts a cache item with a given absolute expiration and CacheItemPriority.Default
		/// </summary>
		/// <param name="item"></param>
		/// <param name="key"></param>
		/// <param name="duration"></param>
		public static void Put( object item, string key, TimeSpan duration )
		{
			Put( item, key, duration, CacheItemPriority.Default );
		}

		/// <summary>
		/// Inserts a cache item with a given absolute expiration and priority
		/// </summary>
		/// <param name="item"></param>
		/// <param name="key"></param>
		/// <param name="duration"></param>
		/// <param name="priority"></param>
		public static void Put( object item, string key, TimeSpan duration, CacheItemPriority priority )
		{
            Put(item, key, duration, priority, null);
		}

        /// <summary>
        /// Inserts a cache item with a given absolute expiration, priority and removal callback
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="key">The key.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="onRemovedCallback">The on removed callback.</param>
        public static void Put(object item, string key, TimeSpan duration, CacheItemPriority priority, CacheItemRemovedCallback onRemovedCallback)
        {
            HttpRuntime.Cache.Insert(key, item, null, DateTime.Now.Add(duration), Cache.NoSlidingExpiration, priority, onRemovedCallback);
        }


        /// <summary>
        /// Inserts a cache item with a given absolute expiration, priority and update callback
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="key">The key.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="onUpdateCallback">The on update callback.</param>
        public static void Put(object item, string key, TimeSpan duration, CacheItemUpdateCallback onUpdateCallback)
        {
            HttpRuntime.Cache.Insert(key, item, null, DateTime.Now.Add(duration), Cache.NoSlidingExpiration, onUpdateCallback);
        }

		/// <summary>
		/// Inserts a cache item with a given sliding expiration and priority
		/// </summary>
		/// <param name="item"></param>
		/// <param name="key"></param>
		/// <param name="duration"></param>
		/// <param name="priority"></param>
		public static void PutSliding( object item, string key, TimeSpan duration, CacheItemPriority priority )
		{
            PutSliding(item, key, duration, priority, null);
		}

        /// <summary>
        /// Inserts a cache item with a given sliding expiration, priority and removal callback
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="key">The key.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="onRemovedCallback">The on removed callback.</param>
        public static void PutSliding(object item, string key, TimeSpan duration, CacheItemPriority priority, CacheItemRemovedCallback onRemovedCallback)
        {
            HttpRuntime.Cache.Insert(key, item, null, Cache.NoAbsoluteExpiration, duration, priority, onRemovedCallback);
        }

        /// <summary>
        /// Inserts a cache item with a given sliding expiration, priority and update callback
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="key">The key.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="onUpdateCallback">The on update callback.</param>
        public static void PutSliding(object item, string key, TimeSpan duration, CacheItemUpdateCallback onUpdateCallback)
        {
            HttpRuntime.Cache.Insert(key, item, null, Cache.NoAbsoluteExpiration, duration, onUpdateCallback);
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public static void Remove(String key)
        {
            if (!String.IsNullOrEmpty(key))
            {
                HttpRuntime.Cache.Remove(key);
            }
        }

        /// <summary>
        /// Generates the duration of the fuzzed.
        /// </summary>
        /// <param name="duration">The initial duration.</param>
        /// <param name="variation">The variation. The percentage change allowed to the supplied duration expressed as 0 -> 1 for 0 -> 100%</param>
        /// <returns>The fuzzed duration</returns>
        public static TimeSpan GenerateFuzzyDuration(TimeSpan duration, double variation)
        {
            if (variation > 1.0 || variation < 0.0)
            {
                return duration;
            }

            double durationMinutes = duration.TotalMinutes;

            Random fuzzer = new Random();

            double fuzzyMinutes = durationMinutes + ((fuzzer.NextDouble() - 0.5) * (variation * durationMinutes));

            return TimeSpan.FromMinutes(fuzzyMinutes);
        }
	}
}
