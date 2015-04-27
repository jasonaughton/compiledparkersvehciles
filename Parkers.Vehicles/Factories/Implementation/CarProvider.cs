// <copyright file="CarProvider.cs" company="Bauer Consumer Media Limited">
//    Copyright 2012 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings
    
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Parkers.Data;
    using StructureMap;

    #endregion

    /// <summary>
    /// Data layer for CarManufacturer, CarRange, CarModel, CarDerivative
    /// </summary>
    public class CarProvider : ICarProvider
    {
        #region Constants

        /// <summary>
        /// Instance key for named instance
        /// </summary>
        public const string ComparerInstanceKey = "car-model-facet-item-comparer";

        /// <summary>
        /// The database name
        /// </summary>
        private const string DatabaseName = "ParkersCAR";

        #endregion

        #region Methods

        /// <summary>
        /// Sets the data version poll.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="server">The server.</param>
        public void SetDataVersionPoll(int version, string server)
        {
            Sproc procedure = new Sproc("InsertDataVersionPoll", DatabaseName);
            procedure.Parameters.Add("@version", SqlDbType.Int).Value = version;
            procedure.Parameters.Add("@server", SqlDbType.Char).Value = server;
            procedure.ExecuteNonQuery();
        }

        /// <summary>
        /// Gets the data version info.
        /// </summary>
        /// <returns>The latest data version and timestamp</returns>
        public KeyValuePair<int, DateTime> GetDataVersionInfo()
        {
            string versionParameter = "@version";
            string timestampParameter = "@timestamp";
            
            Sproc procedure = new Sproc("SelectDataVersion", DatabaseName);
            procedure.Parameters.Add(versionParameter, SqlDbType.Int).Direction = ParameterDirection.Output;
            procedure.Parameters.Add(timestampParameter, SqlDbType.DateTime).Direction = ParameterDirection.Output;
            
            procedure.ExecuteNonQuery();

            int versionId = Convert.ToInt32(procedure.Parameters[versionParameter].Value);
            DateTime versionTimestamp;
            DateTime.TryParse(procedure.Parameters[timestampParameter].Value.ToString(), out versionTimestamp);

            KeyValuePair<int, DateTime> result = new KeyValuePair<int, DateTime>(versionId, versionTimestamp);

            return result;
        }

        /// <summary>
        /// Gets the server data versions.
        /// </summary>
        /// <returns>A collection of server data version info</returns>
        public IEnumerable<KeyValuePair<string, int>> GetServerDataVersions()
        {
            IEnumerable<KeyValuePair<string, int>> result = null;
            
            using (Sproc procedure = new Sproc("SelectServerDataVersion", DatabaseName))
            {
                result = procedure.ExecuteList(GetServerDataVersionsFromDataReader);
            }

            return result;
        }

        /// <summary>
        /// Get the review for a given CARModId
        /// </summary>
        /// <param name="id">The CARModiI</param>
        /// <returns>The review</returns>
        public ICarReview GetReviewFromId(int id)
        {
            ICarReview result = null;
            Sproc procedure = new Sproc("Mod_Select_ById", DatabaseName);
            procedure.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            using (SqlDataReader dataReader = procedure.ExecuteReader())
            {
                if (dataReader.HasRows && dataReader.Read())
                {
                    result = this.GetReviewFromDataReader(dataReader);
                }
            }

            return result;
        }

        /// <summary>
        /// All models having a derivative with the given insurance group
        /// </summary>
        /// <param name="group">The insurance group</param>
        /// <returns>List of models in the group</returns>
        public List<ICarModel> GetModelsByInsuranceGroup(int group)
        {
            List<ICarModel> result = new List<ICarModel>();

            Sproc procedure = new Sproc("ModIds_Select_ByIG", DatabaseName);
            procedure.Parameters.Add("@IG", SqlDbType.Int).Value = group;

            using (SqlDataReader dr = procedure.ExecuteReader())
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        result.Add(CarModel.FromId((int)dr["CARModId"]));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Find a list of all manufacturers that match a given predicate
        /// </summary>
        /// <param name="filter">The manufacturer filter</param>
        /// <returns>The car manufacturers that match</returns>
        public List<ICarManufacturer> FindAllManufacturers(Predicate<ICarManufacturer> filter)
        {
            return this.GetManufacturers().FindAll(filter);
        }

        /// <summary>
        /// Gets the manufacturer from the database
        /// </summary>
        /// <param name="id">The manufacturer id</param>
        /// <returns>A car manufacturer</returns>
        public ICarManufacturer GetManufacturerFromId(int id)
        {
            return GetManufacturerFromId(id, false);
        }

        /// <summary>
        /// Gets the range from the database
        /// </summary>
        /// <param name="id">The range id</param>
        /// <returns>A car range</returns>
        public ICarRange GetRangeFromId(int id)
        {
            return GetRangeFromId(id, false);
        }
        
        /// <summary>
        /// Gets the model from the database
        /// </summary>
        /// <param name="id">The model id</param>
        /// <returns>A car model</returns>
        public ICarModel GetModelFromId(int id)
        {
            return GetModelFromId(id, false, false, false);
        }

        /// <summary>
        /// Gets the derivative from the database
        /// </summary>
        /// <param name="id">The derivative id</param>
        /// <returns>A car derivatite</returns>
        public ICarDerivative GetDerivativeFromId(int id)
        {
            return GetDerivativeFromId(id, false);
        }

        /// <summary>
        /// Calls GetModelFromId to return an IModel
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>IModel of the id</returns>
        public IModel GetSortModelFromId(int id)
        {
            return GetModelFromId(id, false, false, false);
        }

        /// <summary>
        /// Calls Der_Select_ByCapCode to create a derivative
        /// </summary>
        /// <param name="capCode">The cap code</param>
        /// <returns>A Car Derivative</returns>
        public ICarDerivative GetDerivativeFromCapCode(string capCode)
        {
            Sproc sp = new Sproc("Der_Select_ByCapCode", DatabaseName);
            sp.Parameters.Add("@CapCode", SqlDbType.VarChar).Value = capCode;
            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr.HasRows && dr.Read())
                {
                    return this.GetDerivativeFromDataReader(dr);
                }
            }

            return null;
        }

        /// <summary>
        /// Gets a list of all manufacturers using GetManufacturerFromId and a cached list of IDs
        /// </summary>
        /// <returns>List of manufacturers</returns>
        public List<ICarManufacturer> GetManufacturers()
        {
            List<int> idList = this.GetManufacturerIds();
            List<ICarManufacturer> result = idList.ConvertAll<ICarManufacturer>(id => CarManufacturer.FromId(id));
            result.RemoveAll(m => m == null);

            return result;
        }

        /// <summary>
        /// A list of all models for a given manufacturer
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id</param>
        /// <returns>List of models</returns>
        public List<ICarModel> GetModelsByManufacturerId(int manufacturerId)
        {
            List<int> ids = this.GetModelIds(manufacturerId);
            List<ICarModel> result = ids.ConvertAll<ICarModel>(CarModel.FromId);
            result.RemoveAll(m => m == null);

            return result;
        }

        /// <summary>
        /// Gets the models by range and manufacturer identifier.
        /// </summary>
        /// <param name="rangeName">The range name.</param>
        /// <param name="manufacturerId">The manufacturer identifier.</param>
        /// <returns>the car models</returns>
        public List<ICarModel> GetModelsByRangeNameAndManufacturer(string rangeName, int manufacturerId)
        {
            List<ICarModel> result = new List<ICarModel>();

            Sproc procedure = new Sproc("ModelIds_Select_ByRangeAndManufacturer", DatabaseName);
            procedure.Parameters.Add("@manufacturerId", SqlDbType.Int).Value = manufacturerId;
            procedure.Parameters.Add("@range", SqlDbType.VarChar).Value = rangeName;

            using (SqlDataReader reader = procedure.ExecuteReader())
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id;
                        if (Int32.TryParse(reader["CARModId"].ToString(), out id))
                        {
                            result.Add(this.GetModelFromId(id));
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// A list of all ranges for a given manufacturer
        /// </summary>
        /// <param name="manufacturerId">The manufactuer id</param>
        /// <returns>The ranges</returns>
        public List<ICarRange> GetRangesByManufacturerId(int manufacturerId)
        {
            List<int> ids = this.GetRangeIds(manufacturerId);
            List<ICarRange> result = ids.ConvertAll<ICarRange>(CarRange.FromId);
            result.RemoveAll(m => m == null);
            return result;
        }

        /// <summary>
        /// Gets the generic body styles for manufacturer.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <returns>The generic body styles for a manufacturer</returns>
        public IEnumerable<string> GetGenericBodyStylesForManufacturer(ICarManufacturer manufacturer)
        {
            return manufacturer.GenericBodyStyles;
        }

        /// <summary>
        /// Alll gallery images for a given model
        /// </summary>
        /// <param name="modelId">The model id</param>
        /// <returns>Collection of review images</returns>
        public ReviewImageCollection GetImagesByModelId(int modelId)
        {
            ReviewImageCollection result = new ReviewImageCollection();

            Sproc procedure = new Sproc("ImgArchive_Select_ByModel", DatabaseName);
            procedure.Parameters.Add("@CARModId", SqlDbType.Int).Value = modelId;
            using (SqlDataReader dataReader = procedure.ExecuteReader())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        result.Add(this.GetReviewImageFromDataReader(dataReader));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// A list of all derivatives for a given model
        /// </summary>
        /// <param name="modelId">The model id</param>
        /// <returns>The derivatives</returns>
        public List<ICarDerivative> GetDerivativesByModelId(int modelId)
        {
            List<int> ids = this.GetDerivativeIds(modelId);
            List<ICarDerivative> result = ids.ConvertAll<ICarDerivative>(CarDerivative.FromId);
            result.RemoveAll(d => d == null);

            return result;
        }

        /// <summary>
        /// A list of all options and standard for the given derivative
        /// </summary>
        /// <param name="derivId">The derivative id</param>
        /// <returns>The list of options</returns>
        public List<IOption> GetOptionsByDerivativeId(int derivId)
        {
            Sproc procedure = new Sproc("DerOption_S", DatabaseName);
            procedure.Parameters.Add("@CARDerId", SqlDbType.Int).Value = derivId;

            return procedure.ExecuteList<IOption>(this.GetOptionFromDataReader);
        }

        /// <summary>
        /// The trims and equipment details for a model
        /// </summary>
        /// <param name="modelId">The model id</param>
        /// <returns>The trim list</returns>
        public TrimList GetTrimListFromModelId(int modelId)
        {
            TrimList result = new TrimList();

            Sproc procedure = new Sproc("Trim_S_ByModel", DatabaseName);
            procedure.Parameters.Add("@CARModId", SqlDbType.Int).Value = modelId;
            using (SqlDataReader datareader = procedure.ExecuteReader())
            {
                if (datareader != null && datareader.HasRows)
                {
                    this.ProcessTrims(result, datareader);
                    datareader.NextResult();
                    this.ProcessTrimEquipment(result, datareader);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the manufacturer ids with insurance infro
        /// </summary>
        /// <returns>List of manufacturer ids</returns>
        public List<int> GetManufacturerIdsWithInsuranceInfo()
        {
            Sproc procedure = new Sproc("Man_Ins_S", DatabaseName);

            List<int> result = new List<int>();

            using (SqlDataReader dataReader = procedure.ExecuteReader())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        result.Add(dataReader.GetInt32(0));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the model ids for a manufacturer with insurance info
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id</param>
        /// <returns>List of the model ids</returns>
        public List<int> GetManufacturerModelIdsWithInsuranceInfo(int manufacturerId)
        {
            Sproc procedure = new Sproc("Mod_Ins_S", DatabaseName);

            procedure.Parameters.Add("@CARManId", SqlDbType.Int).Value = manufacturerId;

            List<int> result = new List<int>();

            using (SqlDataReader dataReader = procedure.ExecuteReader())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        result.Add(dataReader.GetInt32(0));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the model trim equipment table.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>A table with rows for equipment items and a tri state flag for trim level (none - no derivatives have the equipment, some or all)</returns>
        public DataTable GetModelTrimEquipmentTable(int modelId)
        {
            Sproc procedure = new Sproc("TrimEquipmentGrid_S_ByModel", DatabaseName);

            procedure.Parameters.Add("@CARModId", SqlDbType.Int).Value = modelId;

            DataSet trimEquipmentDataSet = procedure.ExecuteDataSet();

            if (trimEquipmentDataSet.Tables.Count > 0)
            {
                return trimEquipmentDataSet.Tables[0];
            }

            return null;
        }

        /// <summary>
        /// A list of manufacturers which have at least one CarCheck
        /// </summary>
        /// <returns>The manufacturer ids with a checklist</returns>
        public List<int> GetManufacturerIdsWithChecklist()
        {
            Sproc procedure = new Sproc("CarCheck_Select_Manufacturers", "ParkersTransactionNew");

            List<int> result = new List<int>();

            using (SqlDataReader dataReader = procedure.ExecuteReader())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        result.Add(dataReader.GetInt32(0));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the range ids with checklist by manufacturer.
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id</param>
        /// <returns>A list of ids of ranges with a checklist for a given manufacturer</returns>
        public List<int> GetRangeIdsWithChecklistByManufacturer(int manufacturerId)
        {
            Sproc procedure = new Sproc("CarCheck_Select_Ranges", "ParkersTransactionNew");
            procedure.Parameters.Add("@CarManId", SqlDbType.Int).Value = manufacturerId;

            List<int> result = new List<int>();

            using (SqlDataReader dataReader = procedure.ExecuteReader())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        result.Add(dataReader.GetInt32(0));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets all derivatives.
        /// </summary>
        /// <returns>All the derivatives</returns>
        public List<ICarDerivative> GetAllDerivatives()
        {
            List<ICarDerivative> result = new List<ICarDerivative>();

            Sproc procedure = new Sproc("Der_Select", DatabaseName);

            using (SqlDataReader reader = procedure.ExecuteReader())
            {
                if (reader.HasRows && reader.Read())
                {
                    while (reader.Read())
                    {
                        result.Add(this.GetDerivativeFromDataReader(reader));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the server data versions from data reader.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <returns>The data version</returns>
        private static KeyValuePair<string, int> GetServerDataVersionsFromDataReader(IDataRecord dataRecord)
        {
            KeyValuePair<string, int> result = new KeyValuePair<string, int>(
                                                DataUtil.GetString(dataRecord, "Server"),
                                                DataUtil.GetInt32(dataRecord, "ServerVersion"));

            return result;
        }

        /// <summary>
        /// Calls Man_Select_ById or Man_S_All to create a manufacturer
        /// </summary>
        /// <param name="id">The manufacturer id</param>
        /// <param name="hintAll">Precache all manufacturers if the requested manufacturer is not already cached</param>
        /// <returns>A car manufacturer</returns>
        private ICarManufacturer GetManufacturerFromId(int id, bool hintAll)
        {
            if (id == 0)
            {
                return null;
            }

            CarManufacturer result = null;
            Sproc procedure = new Sproc("Man_S_All", DatabaseName);

            if (hintAll == false)
            {
                procedure.Name = "Man_Select_ById";
                procedure.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            }

            using (SqlDataReader dataReader = procedure.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CarManufacturer manufacturer = this.GetManufacturerFromDataReader(dataReader);
                        if (manufacturer.Id == id)
                        {
                            result = manufacturer;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Calls Ran_Select_ById or Ran_S_AllInManById to create a range
        /// </summary>
        /// <param name="id">The range id</param>
        /// <param name="hintManufacturer">Precache all ranges from this manufacturer if the requested range is not already cached</param>
        /// <returns>A car range</returns>
        private ICarRange GetRangeFromId(int id, bool hintManufacturer)
        {
            if (id == 0)
            {
                return null;
            }

            CarRange result = null;
            Sproc procedure = new Sproc("Ran_Select_ById", DatabaseName);

            if (hintManufacturer)
            {
                procedure.Name = "Ran_S_AllInManById";
                procedure.Parameters.Add("@CARRanId", SqlDbType.Int).Value = id;
            }
            else
            {
                procedure.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            }

            using (SqlDataReader dataReader = procedure.ExecuteReader())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CarRange range = this.GetRangeFromDataReader(dataReader);
                        if (range.Id == id)
                        {
                            result = range;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Calls Mod_Select_ById or Mod_S_AllInManById to create a model
        /// </summary>
        /// <param name="id">The model id</param>
        /// <param name="hintManufacturer">If true, cache all models from this manufacturer is the requested range is not already cached</param>
        /// <param name="hintReview">If true,cache the CarReview at the same time if the model is not already cached</param>
        /// <param name="hintRange">If true, cache the CarRange object at the same time if the model is not already cached</param>
        /// <returns>A car model</returns>
        private ICarModel GetModelFromId(int id, bool hintManufacturer, bool hintReview, bool hintRange)
        {
            if (id == 0)
            {
                return null;
            }

            CarModel result = null;

            Sproc procedure = new Sproc("Mod_Select_ById", DatabaseName);
            if (hintManufacturer)
            {
                procedure.Name = "Mod_S_AllInManById";
                procedure.Parameters.Add("@CARModId", SqlDbType.Int).Value = id;
            }
            else
            {
                procedure.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            }

            using (SqlDataReader dataReader = procedure.ExecuteReader())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CarModel model = this.GetModelFromDataReader(dataReader);
                        if (hintRange && hintManufacturer)
                        {
                            GetRangeFromId(model.RangeId, hintManufacturer);
                        }

                        if (model.Id == id)
                        {
                            result = model;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Calls Der_Select_ById or Der_S_AllInModelById to create a derivative
        /// </summary>
        /// <param name="id">The derivative id</param>
        /// <param name="hintModel">If true, precache all derivatives for this model if this derivative is not already cached</param>
        /// <returns>A car derivative</returns>
        private ICarDerivative GetDerivativeFromId(int id, bool hintModel)
        {
            if (id <= 0)
            {
                return null;
            }

            CarDerivative result = null;

            Sproc procedure = new Sproc("Der_Select_ById", DatabaseName);
            procedure.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            using (SqlDataReader dataReader = procedure.ExecuteReader())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CarDerivative derivative = this.GetDerivativeFromDataReader(dataReader);
                        if (derivative.Id == id)
                        {
                            result = derivative;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Creates a review image from a data reader
        /// </summary>
        /// <param name="dataReader">The data reader</param>
        /// <returns>ReviewImage representation of the data</returns>
        private ReviewImage GetReviewImageFromDataReader(SqlDataReader dataReader)
        {
            ReviewImage reviewImage = new ReviewImage();
            reviewImage.Category = (int)dataReader["CategoryId"];
            reviewImage.File = (string)dataReader["Image"];

            return reviewImage;
        }

        /// <summary>
        /// Creates a car review from a data reader
        /// </summary>
        /// <param name="dataReader">The data reader</param>
        /// <returns>CarReview representation of the data</returns>
        private ICarReview GetReviewFromDataReader(SqlDataReader dataReader)
        {
            if (DataUtil.GetBoolean(dataReader, "Review") == false)
            {
                return null;
            }

            CarReview review = new CarReview();
            review.Id = DataUtil.GetInt32(dataReader, "CARModId");
            review.For = DataUtil.GetString(dataReader, "TextFor");
            review.Against = DataUtil.GetString(dataReader, "TextAgainst");

            review.Summary = DataUtil.GetString(dataReader, "TextSummaryLong");
            review.SummaryRating = DataUtil.GetInt32(dataReader, "RatingSummary");
            review.Performance = DataUtil.GetString(dataReader, "TextPerformance");
            review.PerformanceRating = DataUtil.GetInt32(dataReader, "RatingPerformance");
            review.Handling = DataUtil.GetString(dataReader, "TextHandling");
            review.HandlingRating = DataUtil.GetInt32(dataReader, "RatingHandling");
            review.Comfort = DataUtil.GetString(dataReader, "TextComfort");
            review.ComfortRating = DataUtil.GetInt32(dataReader, "RatingComfort");
            review.Wheel = DataUtil.GetString(dataReader, "TextWheel");
            review.WheelRating = DataUtil.GetInt32(dataReader, "RatingWheel");
            review.Practicality = DataUtil.GetString(dataReader, "TextPracticality");
            review.PracticalityRating = DataUtil.GetInt32(dataReader, "RatingPracticality");
            review.Safety = DataUtil.GetString(dataReader, "TextSafety");
            review.SafetyRating = DataUtil.GetInt32(dataReader, "RatingSafety");
            review.Cost = DataUtil.GetString(dataReader, "TextCost");
            review.CostRating = DataUtil.GetInt32(dataReader, "RatingCost");
            review.Reliability = DataUtil.GetString(dataReader, "TextReliability");
            review.ReliabilityRating = DataUtil.GetInt32(dataReader, "RatingReliability");
            review.BuyingNew = DataUtil.GetString(dataReader, "TextBuyingNew");
            review.BuyingNewRating = DataUtil.GetInt32(dataReader, "RatingBuyingNew");
            review.BuyingUsed = DataUtil.GetString(dataReader, "TextBuyingUsed");
            review.BuyingUsedRating = DataUtil.GetInt32(dataReader, "RatingBuyingUsed");
            review.BuyingNew = DataUtil.GetString(dataReader, "TextBuyingNew");
            review.BuyingNewRating = DataUtil.GetInt32(dataReader, "RatingBuyingNew");
            review.Selling = DataUtil.GetString(dataReader, "TextSelling");
            review.SellingRating = DataUtil.GetInt32(dataReader, "RatingSelling");
            review.Equipment = DataUtil.GetString(dataReader, "TextEquipment");
            review.EquipmentRating = DataUtil.GetInt32(dataReader, "RatingEquipment");

            review.Green = DataUtil.GetString(dataReader, "TextGreen");
            review.GreenRating = DataUtil.GetInt32(dataReader, "RatingGreen");

            review.UpdateHeading = DataUtil.GetString(dataReader, "HeadingUpdate");
            review.UpdateBody = DataUtil.GetString(dataReader, "TextUpdate");

            review.CheckBody = DataUtil.GetString(dataReader, "TextCarCheckBody");
            review.CheckEngine = DataUtil.GetString(dataReader, "TextCarCheckEngine");
            review.CheckOther = DataUtil.GetString(dataReader, "TextCarCheckOther");

            review.Servicing = DataUtil.GetString(dataReader, "TextServicing");
            review.Warranty = DataUtil.GetString(dataReader, "TextWarranty");
            review.CompanyCarInfo = DataUtil.GetString(dataReader, "TextCompanyCarInfo");

            review.NcapAdult = DataUtil.GetInt32(dataReader, "NCAPAdult");
            review.NcapChild = DataUtil.GetInt32(dataReader, "NCAPChild");
            review.NcapPedestrian = DataUtil.GetInt32(dataReader, "NCAPPedestrian");

            review.MinPriceNew = DataUtil.GetInt32(dataReader, "NewMin");
            review.MaxPriceNew = DataUtil.GetInt32(dataReader, "NewMax");
            review.MinPriceUsed = DataUtil.GetInt32(dataReader, "UsedMin");
            review.MaxPriceUsed = DataUtil.GetInt32(dataReader, "UsedMax");

            review.MinPriceFRV12 = DataUtil.GetInt32(dataReader, "FRV12Min");
            review.MaxPriceFRV12 = DataUtil.GetInt32(dataReader, "FRV12Max");

            review.MinPriceFRV36 = DataUtil.GetInt32(dataReader, "FRV36Min");
            review.MaxPriceFRV36 = DataUtil.GetInt32(dataReader, "FRV36Max");

            review.MinIG = DataUtil.GetInt32(dataReader, "IGMin");
            review.MaxIG = DataUtil.GetInt32(dataReader, "IGMax");

            review.AlternativeIds.Add(DataUtil.GetInt32(dataReader, "AlternativeId1"));
            review.AlternativeIds.Add(DataUtil.GetInt32(dataReader, "AlternativeId2"));
            review.AlternativeIds.Add(DataUtil.GetInt32(dataReader, "AlternativeId3"));

            review.FirstPublished = DataUtil.GetDateTime(dataReader, "FirstPublished");
            review.LastUpdated = DataUtil.GetDateTime(dataReader, "LastUpdated");
            review.OriginalAuthor = DataUtil.GetString(dataReader, "OriginalAuthor");
            review.Video = DataUtil.GetString(dataReader, "YouTubeVideoId");

            return review;
        }

        /// <summary>
        /// Creates a car manufacturer from a data reader
        /// </summary>
        /// <param name="dataReader">The data reader</param>
        /// <returns>CarManufacturer representation of the data</returns>
        private CarManufacturer GetManufacturerFromDataReader(SqlDataReader dataReader)
        {
            CarManufacturer manufacturer = new CarManufacturer();
            manufacturer._id = DataUtil.GetInt32(dataReader, "CARManId");
            manufacturer._name = DataUtil.GetString(dataReader, "Manufacturer", null);
            manufacturer.LogoFileName = DataUtil.GetString(dataReader, "Logo", null);

            manufacturer._isDiscontinued = !dataReader.IsDBNull(dataReader.GetOrdinal("ManufacturerDiscontinued"));

            manufacturer.Url = DataUtil.GetString(dataReader, "URLMain");
            manufacturer.PopularityRank = DataUtil.GetInt32(dataReader, "PopularityRank");

            manufacturer.HasReview = DataUtil.GetBoolean(dataReader, "Review");
            manufacturer.HasTechData = DataUtil.GetBoolean(dataReader, "Tech");

            return manufacturer;
        }

        /// <summary>
        /// Creates a car range from a data reader
        /// </summary>
        /// <param name="dataReader">The data reader</param>
        /// <returns>CarRange representation of the data</returns>
        private CarRange GetRangeFromDataReader(SqlDataReader dataReader)
        {
            CarRange range = new CarRange();

            range.Id = DataUtil.GetInt32(dataReader, "CARRanId");
            range._manufacturerId = DataUtil.GetInt32(dataReader, "CARManId");
            range.Name = DataUtil.GetString(dataReader, "Range", null);
            range.NameWithYears = DataUtil.GetString(dataReader, "RangeYear", null);
            range.IntroducedYear = DataUtil.GetInt32(dataReader, "RangeIntroduced");
            range.DiscontinuedYear = DataUtil.GetInt32(dataReader, "RangeDiscontinued", Int32.MaxValue);
            range.CarCheckProductId = DataUtil.GetInt32(dataReader, "CarCheckProductId");
            range.CarCheckSnippet = DataUtil.GetString(dataReader, "CheckSnippet");
            range.PopularityRank = DataUtil.GetInt32(dataReader, "PopularityRank");
            range.Popularity = DataUtil.GetDouble(dataReader, "Popularity");

            return range;
        }

        /// <summary>
        /// Creates a car model from a data reader
        /// </summary>
        /// <param name="dataReader">The data reader</param>
        /// <returns>CarModel representation of the data</returns>
        private CarModel GetModelFromDataReader(SqlDataReader dataReader)
        {
            CarModel model = new CarModel();
            model.Id = DataUtil.GetInt32(dataReader, "CARModId");
            model.RangeId = DataUtil.GetInt32(dataReader, "CARRanId");
            model.GenericBodyStyle = DataUtil.GetString(dataReader, "BodyGeneric");
            model.OriginalBodyStyle = DataUtil.GetString(dataReader, "BodyOriginal");
            model.BodyStyle = DataUtil.GetString(dataReader, "Model");
            if (model.BodyStyle == String.Empty)
            {
                model.BodyStyle = model.OriginalBodyStyle;
            }

            model.PopularityRank = DataUtil.GetInt32(dataReader, "PopularityRank");
            model.Popularity = DataUtil.GetDouble(dataReader, "Popularity");

            model.Name = (string)dataReader["RangeModel"];
            model.NameWithYears = (string)dataReader["RangeModelYear"];
            model.IntroducedYear = (int)dataReader["ModelIntroduced"];
            model.DiscontinuedYear = DataUtil.GetInt32(dataReader, "ModelDiscontinued", Int32.MaxValue);

            IYearPlateProvider yearPlateProvider = new YearPlateProvider();

            model.FromYearPlate = yearPlateProvider.FromId(DataUtil.GetInt32(dataReader, "FromYearPlateId"));
            model.ToYearPlate = yearPlateProvider.FromId(DataUtil.GetInt32(dataReader, "ToYearPlateId"));

            model.OwnerReviewCount = DataUtil.GetInt32(dataReader, "UserReview") + DataUtil.GetInt32(dataReader, "UserReviewArchive");

            model.HasReview = DataUtil.GetBoolean(dataReader, "Review");
            model.HasTechData = DataUtil.GetBoolean(dataReader, "Tech");

            model.CAPBodyStyleId = Convert.ToString(dataReader["CAPBodyStyleId"]);
            model.CAPRanId = Convert.ToString(dataReader["CAPRanId"]);

            model._imageId = DataUtil.GetInt32(dataReader, "CAPImageId");

            model.MinPriceNew = DataUtil.GetInt32(dataReader, "NewMin");
            model.MaxPriceNew = DataUtil.GetInt32(dataReader, "NewMax");

            model.MinPriceUsed = DataUtil.GetInt32(dataReader, "UsedMin");
            model.MaxPriceUsed = DataUtil.GetInt32(dataReader, "UsedMax");

            model.AdultSeats = DataUtil.GetInt32(dataReader, "SuitableAdults");
            model.SeatsWithLuggage = DataUtil.GetInt32(dataReader, "SuitableAdultsWithLuggage");

            model._minPriceFRV12 = DataUtil.GetInt32(dataReader, "FRV12Min");
            model._maxPriceFRV12 = DataUtil.GetInt32(dataReader, "FRV12Max");

            model._minPriceFRV36 = DataUtil.GetInt32(dataReader, "FRV36Min");
            model._maxPriceFRV36 = DataUtil.GetInt32(dataReader, "FRV36Max");

            model._MinCo2 = DataUtil.GetInt32(dataReader, "CO2Min");
            model._MaxCo2 = DataUtil.GetInt32(dataReader, "CO2Max");

            model._maxAnnualFuelCost = DataUtil.GetInt32(dataReader, "AnnualFuelCostMax");
            model._minAnnualFuelCost = DataUtil.GetInt32(dataReader, "AnnualFuelCostMin");
            model._maxVedFull = DataUtil.GetDecimal(dataReader, "VEDFullMax");
            model._minVedFull = DataUtil.GetDecimal(dataReader, "VEDFullMin");

            model._minLuggageCapacity = DataUtil.GetInt32(dataReader, "LuggageCapacityMin");

            model._family = CarFamily.FromId(DataUtil.GetInt32(dataReader, "CARFamId"));

            model._otherModelWithSameBodyOriginal = (DataUtil.GetInt32(dataReader, "ModelsWithSameBodyOriginal") > 1);

            model._relatedModelIds.Add(DataUtil.GetInt32(dataReader, "ComputedAlternativeModelWithinRange"));
            model._relatedModelIds.Add(DataUtil.GetInt32(dataReader, "ComputedAlternativeModel1"));
            model._relatedModelIds.Add(DataUtil.GetInt32(dataReader, "ComputedAlternativeModel2"));
            model._relatedModelIds.Add(DataUtil.GetInt32(dataReader, "ComputedAlternativeModel3"));

            model.UrlVariantIndex = DataUtil.GetInt32(dataReader, "ModelVariantIndex", 0);

            model.IsLatest = DataUtil.GetBoolean(dataReader, "IsLatest");

            return model;
        }

        /// <summary>
        /// Creates a car derivative from a data reader
        /// </summary>
        /// <param name="dataReader">The data reader</param>
        /// <returns>CarDerivative representation of the data</returns>
        private CarDerivative GetDerivativeFromDataReader(SqlDataReader dataReader)
        {
            CarDerivative deriv = new CarDerivative();
            deriv.Id = (int)dataReader["CARDerId"];
            deriv._imageId = DataUtil.GetInt32(dataReader, "CapImageId");
            deriv._modelId = (int)dataReader["CARModId"];

            deriv.HasMPG = DataUtil.GetNullableInt(dataReader, "MPG").HasValue;
            deriv.HasSeats = DataUtil.GetNullableInt(dataReader, "Seats").HasValue;
            deriv.HasEngineSize = DataUtil.GetNullableInt(dataReader, "CC").HasValue;

            deriv.Name = (string)dataReader["Derivative"];
            deriv.Trim = DataUtil.GetString(dataReader, "TrimName", String.Empty).Trim();
            deriv.Engine = DataUtil.GetString(dataReader, "NameEngine", String.Empty).Trim();

            deriv.FuelType = (string)dataReader["FuelType"];

            deriv.HasTechData = DataUtil.GetBoolean(dataReader, "Tech");
            deriv.HasOptionData = DataUtil.GetBoolean(dataReader, "Option");

            deriv.OriginalBodystyle = DataUtil.GetString(dataReader, "BodyOriginal");

            deriv.P11DPrice = DataUtil.GetInt32(dataReader, "P11DPrice");
            deriv.ListPrice = DataUtil.GetInt32(dataReader, "ListPrice");
            deriv.TargetPrice = DataUtil.GetInt32(dataReader, "TargetPrice");
            deriv.ThreeYearValue = DataUtil.GetInt32(dataReader, "FRV36");
            deriv.InsuranceGroup = DataUtil.GetInt32(dataReader, "IG");

            deriv.Doors = DataUtil.GetInt32(dataReader, "Doors");
            deriv.Seats = DataUtil.GetInt32(dataReader, "Seats");
            deriv.CC = DataUtil.GetInt32(dataReader, "CC");
            deriv.Cylinders = DataUtil.GetInt32(dataReader, "Cylinders");
            deriv.Bhp = DataUtil.GetInt32(dataReader, "BHP");
            deriv.TopSpeed = DataUtil.GetInt32(dataReader, "TopSpeed");
            deriv.ZeroToSixty = DataUtil.GetDecimal(dataReader, "ZeroToSixty");
            deriv.MilesPerGallon = DataUtil.GetInt32(dataReader, "MPG");
            deriv.EuroEmissions = DataUtil.GetInt32(dataReader, "EuroEmissions");

            deriv.Length = DataUtil.GetInt32(dataReader, "Length");
            deriv.Width = DataUtil.GetInt32(dataReader, "Width");
            deriv.Height = DataUtil.GetInt32(dataReader, "Height");
            deriv.Weight = DataUtil.GetInt32(dataReader, "Weight");

            deriv.FuelDelivery = DataUtil.GetString(dataReader, "FuelDelivery", "-");
            deriv.Transmission = DataUtil.GetString(dataReader, "Transmission", "-");
            deriv.Gears = DataUtil.GetString(dataReader, "Gears", "-");

            deriv.Valves = DataUtil.GetInt32(dataReader, "Valves");
            deriv.TorqueLbFt = DataUtil.GetInt32(dataReader, "TorqueLbFt");
            deriv.TorqueNm = DataUtil.GetInt32(dataReader, "TorqueNm");
            deriv.Wheelbase = DataUtil.GetInt32(dataReader, "Wheelbase");
            deriv.LuggageCapacity = DataUtil.GetInt32(dataReader, "LuggageCapacity");
            deriv.FuelCapacity = DataUtil.GetInt32(dataReader, "FuelCapacity");

            deriv.TurningCircle = DataUtil.GetInt32(dataReader, "TurningCircle");
            deriv.UnbrakedTowing = DataUtil.GetInt32(dataReader, "UnbrakedTowing");
            deriv.BrakedTowing = DataUtil.GetInt32(dataReader, "BrakedTowing");

            deriv.CO2Emissions = DataUtil.GetInt32(dataReader, "CO2");
            deriv.VedBand = DataUtil.GetString(dataReader, "VEDBand", "-");
            deriv.VedFull = DataUtil.GetDecimal(dataReader, "VEDFull");

            deriv.Introduced = DataUtil.GetDateTime(dataReader, "Introduced", DateTime.MaxValue);
            deriv.Discontinued = DataUtil.GetDateTime(dataReader, "Discontinued", DateTime.MaxValue);

            IYearPlateProvider yearPlateProvider = ObjectFactory.GetInstance<IYearPlateProvider>();

            deriv.FromYearPlate = yearPlateProvider.FromId(DataUtil.GetInt32(dataReader, "FromYearPlateId"));
            deriv.ToYearPlate = yearPlateProvider.FromId(DataUtil.GetInt32(dataReader, "ToYearPlateId"));

            deriv.CapCode = DataUtil.GetString(dataReader, "CAPCode");

            deriv.ThisYearBasicRate = DataUtil.GetInt32(dataReader, "CompanyCarTaxThisYearBasicRate");
            deriv.ThisYearHigherRate = DataUtil.GetInt32(dataReader, "CompanyCarTaxThisYearHigherRate");
            deriv.NextYearBasicRate = DataUtil.GetInt32(dataReader, "CompanyCarTaxNextYearBasicRate");
            deriv.NextYearHigherRate = DataUtil.GetInt32(dataReader, "CompanyCarTaxNextYearHigherRate");
            deriv.CompanyCarTaxPercentage = DataUtil.GetInt32(dataReader, "CompanyCarTaxPercentage");

            return deriv;
        }

        /// <summary>
        /// Gets the list of manufacturer ids
        /// </summary>
        /// <returns>The list of manufacturer ids</returns>
        private List<int> GetManufacturerIds()
        {
            List<int> result = new List<int>();

            Sproc sp = new Sproc("Man_List_S", DatabaseName);
            result = sp.ExecuteList<int>(dr => DataUtil.GetInt32(dr, "CARManId"));

            return result;
        }

        /// <summary>
        /// Gets the list of model ids for a manufacturer
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id</param>
        /// <returns>The list of model ids</returns>
        private List<int> GetModelIds(int manufacturerId)
        {
            List<int> result = new List<int>();

            Sproc sp = new Sproc("Mod_List_S", DatabaseName);
            sp.Parameters.Add("@CARManId", SqlDbType.Int).Value = manufacturerId;
            sp.Parameters.Add("@CARRanId", SqlDbType.Int).Value = DBNull.Value;

            using (SqlDataReader dataReader = sp.ExecuteReader())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        result.Add((int)dataReader["CARModId"]);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets a list of ranges for a manufacturer
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id</param>
        /// <returns>The list of ranges</returns>
        private List<int> GetRangeIds(int manufacturerId)
        {
            List<int> result = new List<int>();

            Sproc sp = new Sproc("Ran_List_S", DatabaseName);
            sp.Parameters.Add("@CARManId", SqlDbType.Int).Value = manufacturerId;

            using (SqlDataReader dataReader = sp.ExecuteReader())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        result.Add((int)dataReader["CARRanId"]);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the list of derivative ids for a model
        /// </summary>
        /// <param name="modelId">The model id</param>
        /// <returns>The list of derivatives</returns>
        private List<int> GetDerivativeIds(int modelId)
        {
            List<int> result = new List<int>();

            Sproc sp = new Sproc("Review_Select_DerivativesByModel", DatabaseName);
            sp.Parameters.Add("@CARModId", SqlDbType.Int).Value = modelId;

            using (SqlDataReader dataReader = sp.ExecuteReader())
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        result.Add((int)dataReader["CARDerId"]);
                    }
                }
            }

            return result;
        }
        
        /// <summary>
        /// Creates an option from a data reader
        /// </summary>
        /// <param name="dataReader">The data reader</param>
        /// <returns>Option representation of the data</returns>
        private IOption GetOptionFromDataReader(IDataRecord dataReader)
        {
            Option option = new Option();

            option.CategoryId = DataUtil.GetInt32(dataReader, "CategoryId");
            option.Category = DataUtil.GetString(dataReader, "Category");
            option.Text = DataUtil.GetString(dataReader, "Text");
            option.Cost = (decimal)DataUtil.GetInt32(dataReader, "Cost");
            option.DateFrom = DataUtil.GetString(dataReader, "DateFrom");
            option.DateTo = DataUtil.GetString(dataReader, "DateTo");
            option.Type = DataUtil.GetString(dataReader, "Type");

            return option;
        }

        /// <summary>
        /// Process the trims
        /// </summary>
        /// <param name="result">The trim result</param>
        /// <param name="dataReader">The datareader</param>
        private void ProcessTrims(TrimList result, SqlDataReader dataReader)
        {
            ITrim currentTrim = null;

            while (dataReader.Read())
            {
                string trimName = DataUtil.GetString(dataReader, "TrimName", String.Empty).Trim();
                string basedOnTrimName = DataUtil.GetString(dataReader, "BasedOnTrimName", null);

                currentTrim = new Trim();
                currentTrim.Name = trimName;

                if (basedOnTrimName != null && basedOnTrimName != trimName)
                {
                    currentTrim.BasedOn = basedOnTrimName.Trim();
                }

                result.Add(currentTrim);
            }
        }

        /// <summary>
        /// Process the trim equipment
        /// </summary>
        /// <param name="result">The trim list result</param>
        /// <param name="dataReader">The datareader</param>
        private void ProcessTrimEquipment(TrimList result, SqlDataReader dataReader)
        {
            ITrim currentTrim = null;
            while (dataReader.Read())
            {
                string thisTrimName = DataUtil.GetString(dataReader, "TrimName", String.Empty).Trim();
                if (currentTrim == null || currentTrim.Name != thisTrimName)
                {
                    int trimIndex = result.IndexOf(thisTrimName);
                    if (trimIndex >= 0)
                    {
                        currentTrim = result[trimIndex];
                        if (currentTrim.Equipment == null)
                        {
                            currentTrim.Equipment = new EquipmentList();
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                EquipmentItem ei = new EquipmentItem();
                ei.Name = DataUtil.GetString(dataReader, "Generic").Replace("`", "'");
                ei.OnAll = DataUtil.GetBoolean(dataReader, "OnAllDers");
                currentTrim.Equipment.Add(ei);
            }
        }
        
        #endregion
    }
}
