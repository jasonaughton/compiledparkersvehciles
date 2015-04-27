// <copyright file="DealerProvider.cs" company="Bauer Consumer Media Limited">
//    Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Parkers.Data;

    #endregion

    /// <summary>
    /// The cars for sale dealer provider
    /// </summary>
    public class DealerProvider : IDealerProvider
    {
        #region Constants

        /// <summary>
        /// The database name
        /// </summary>
        private const string DatabaseName = "ParkersCarStock";

        #endregion

        #region Methods

        /// <summary>
        /// Gets the dealer.
        /// </summary>
        /// <param name="supplierId">The supplier id.</param>
        /// <param name="dealerId">The dealer id.</param>
        /// <returns>
        /// The dealer object
        /// </returns>
        public IDealer GetDealer(int supplierId, int dealerId)
        {
            IDealer result = GetDealerFromDatabase(supplierId, dealerId);

            if (result != null)
            {
                result.SupplierId = supplierId;
                result.DealerId = dealerId;
            }

            return result;
        }

        /// <summary>
        /// Gets the dealer.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="address">The address value.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="town">The town value.</param>
        /// <returns>
        /// The dealer object
        /// </returns>
        public IDealer GetDealer(string name, string address, string phoneNumber, string postcode, string town)
        {
            IDealer result = CreateDealer(name, address, phoneNumber, postcode, town);

            return result;
        }

        /// <summary>
        /// Gets the dealer from database.
        /// </summary>
        /// <param name="supplierId">The supplier id.</param>
        /// <param name="dealerId">The dealer id.</param>
        /// <returns>The dealer object</returns>
        private static IDealer GetDealerFromDatabase(int supplierId, int dealerId)
        {
            Sproc storedProcedure = new Sproc("Dealer_S", DatabaseName);
            storedProcedure.Parameters.Add("@SupplierId", SqlDbType.Int).Value = supplierId;
            storedProcedure.Parameters.Add("@DealerId", SqlDbType.Int).Value = dealerId;

            IDealer result = null;

            using (SqlDataReader reader = storedProcedure.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        result = GetGetDealerFromRecord(reader);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the get dealer from record.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>The dealer object</returns>
        private static IDealer GetGetDealerFromRecord(SqlDataReader reader)
        {
            string name = DataUtil.GetString(reader, "Dealer", string.Empty);
            string address = DataUtil.GetString(reader, "Address", string.Empty);
            string phoneNumber = DataUtil.GetString(reader, "Telephone", string.Empty);
            string postcode = DataUtil.GetString(reader, "Postcode", string.Empty);
            string town = DataUtil.GetString(reader, "Town", string.Empty);

            IDealer result = CreateDealer(name, address, phoneNumber, postcode, town);

            return result;
        }

        /// <summary>
        /// Creates the dealer.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="address">The address.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="town">The town value.</param>
        /// <returns>The dealer object</returns>
        private static IDealer CreateDealer(string name, string address, string phoneNumber, string postcode, string town)
        {
            Dealer result = new Dealer
            {
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                Postcode = postcode,
                Town = town
            };

            if (!String.IsNullOrEmpty(address))
            {
                result.AddressElements.AddRange(address.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }

            return result;
        }

        #endregion
    }
}