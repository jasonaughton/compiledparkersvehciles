// <copyright file="VanProvider.cs" company="Bauer Consumer Media Limited">
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
    /// Van provider class
    /// </summary>
    public class VanProvider : IVanProvider
    {
        #region Constants

        /// <summary>
        /// Instance key for named instance
        /// </summary>
        public const string ComparerInstanceKey = "van-model-facet-item-comparer";

        /// <summary>
        ///  The value of PS for PS BHP conversion
        /// </summary>
        private const double PsValue = 1000;

        /// <summary>
        /// The value of BHP for PS to BHP converstion
        /// </summary>
        private const double BhpValue = 986.4;

        /// <summary>
        /// The name of the database to query
        /// </summary>
        private const string DatabaseName = "ParkersVAN";

        #endregion

        #region Methods

        /// <summary>
        /// Calls GetModelFromId to return an IModel
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>IModel of the id</returns>
        public IModel GetSortModelFromId(int id)
        {
            return this.GetModelFromId(id);
        }

        /// <summary>
        /// Gets the manufacturer from id.
        /// </summary>
        /// <param name="id">The manufacturer id.</param>
        /// <returns>Van manufacturer</returns>
        public IVanManufacturer GetManufacturerFromId(int id)
        {
            Sproc sp = new Sproc("Man_Select_ById", DatabaseName);
            sp.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr.HasRows && dr.Read())
                {
                    return this.GetManufacturerFromDataReader(dr);
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the range from id.
        /// </summary>
        /// <param name="id">The range id.</param>
        /// <returns>The Van range</returns>
        public IVanRange GetRangeFromId(int id)
        {
            Sproc sp = new Sproc("Ran_Select_ById", DatabaseName);
            sp.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr.HasRows && dr.Read())
                {
                    return this.GetRangeFromDataReader(dr);
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the model from id.
        /// </summary>
        /// <param name="id">The model id.</param>
        /// <returns>The Van model</returns>
        public IVanModel GetModelFromId(int id)
        {
            Sproc sp = new Sproc("Mod_Select_ById", DatabaseName);
            sp.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr.HasRows && dr.Read())
                {
                    return this.GetModelFromDataReader(dr);
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the derivative from id.
        /// </summary>
        /// <param name="id">The derivative id.</param>
        /// <returns>Van derivative</returns>
        public IVanDerivative GetDerivativeFromId(int id)
        {
            Sproc sp = new Sproc("Der_Select_ById", DatabaseName);
            sp.Parameters.Add("@Id", SqlDbType.Int).Value = id;
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
        /// Gets the derivative from cap code.
        /// </summary>
        /// <param name="capCode">The cap code.</param>
        /// <returns>Van derivative</returns>
        public IVanDerivative GetDerivativeFromCapCode(string capCode)
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
        /// Gets the derivatives from id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>list of van derivatives</returns>
        public List<IVanDerivative> GetDerivativesFromId(int modelId)
        {
            Sproc sp = new Sproc("Review_Select_DerivativesByModel", DatabaseName);
            sp.Parameters.Add("@VANModId", SqlDbType.Int).Value = modelId;
            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr != null && dr.HasRows)
                {
                    List<IVanDerivative> result = new List<IVanDerivative>();

                    IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();

                    while (dr.Read())
                    {
                        result.Add(vanProvider.GetDerivativeFromId((int)dr["VANDerId"]));
                    }

                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the manufacturers.
        /// </summary>
        /// <returns>List of van manufacturers</returns>
        public List<IVanManufacturer> GetManufacturers()
        {
            Sproc sp = new Sproc("Man_List_S", DatabaseName);
            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr != null && dr.HasRows)
                {
                    List<IVanManufacturer> result = new List<IVanManufacturer>();
                    while (dr.Read())
                    {
                        IVanManufacturer m = this.GetManufacturerFromId((int)dr["VANManId"]);
                        result.Add(m);
                    }

                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the models by manufacturer id.
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id.</param>
        /// <returns>List of van models</returns>
        public List<IVanModel> GetModelsByManufacturerId(int manufacturerId)
        {
            Sproc sp = new Sproc("Mod_List_S", DatabaseName);
            sp.Parameters.Add("@VANManId", SqlDbType.Int).Value = manufacturerId;
            sp.Parameters.Add("@VANRanId", SqlDbType.Int).Value = DBNull.Value;

            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr != null && dr.HasRows)
                {
                    List<IVanModel> result = new List<IVanModel>();
                    while (dr.Read())
                    {
                        result.Add(this.GetModelFromId((int)dr["VANModId"]));
                    }

                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the models by range name and manufacturer identifier.
        /// </summary>
        /// <param name="rangeName">The range name.</param>
        /// <param name="manufacturerId">The manufacturer identifier.</param>
        /// <returns>the models by range and manufacturer</returns>
        public List<IVanModel> GetModelsByRangeNameAndManufacturerId(string rangeName, int manufacturerId)
        {
            List<IVanModel> result = new List<IVanModel>();
            
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
                        if (Int32.TryParse(reader["VANModId"].ToString(), out id))
                        {
                            result.Add(this.GetModelFromId(id));
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the ranges by manufacturer id.
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id.</param>
        /// <returns>List of van ranges</returns>
        public List<IVanRange> GetRangesByManufacturerId(int manufacturerId)
        {
            Sproc sp = new Sproc("Ran_List_S", DatabaseName);
            sp.Parameters.Add("@VANManId", SqlDbType.Int).Value = manufacturerId;

            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr != null && dr.HasRows)
                {
                    List<IVanRange> result = new List<IVanRange>();
                    while (dr.Read())
                    {
                        result.Add(this.GetRangeFromId((int)dr["VANRanId"]));
                    }

                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the tech data derivatives from id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>List of van derivatives</returns>
        public List<IVanDerivative> GetTechDataDerivativesFromId(int modelId)
        {
            Sproc sp = new Sproc("Review_Select_DerivativesByModel", DatabaseName);
            sp.Parameters.Add("@VANModId", SqlDbType.Int).Value = modelId;
            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr != null && dr.HasRows)
                {
                    List<IVanDerivative> result = new List<IVanDerivative>();

                    IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();

                    while (dr.Read())
                    {
                        IVanDerivative d = vanProvider.GetDerivativeFromId((int)dr["VANDerId"]);
                        if (d.HasTechData)
                        {
                            result.Add(d);
                        }
                    }

                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the images by model id.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>Collection of review images</returns>
        public ReviewImageCollection GetImagesByModelId(int modelId)
        {
            ReviewImageCollection result = new ReviewImageCollection();

            Sproc sp = new Sproc("ImgArchive_Select_ByModel", DatabaseName);
            sp.Parameters.Add("@VanModId", SqlDbType.Int).Value = modelId;
            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        result.Add(this.GetReviewImageFromDataReader(dr));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets a van manufacturer from a data reader
        /// </summary>
        /// <param name="dataReader">The data reader</param>
        /// <returns>Van range representation of the data</returns>
        private IVanManufacturer GetManufacturerFromDataReader(SqlDataReader dataReader)
        {
            VanManufacturer manufacturer = new VanManufacturer();
            manufacturer.Id = (int)dataReader["VANManId"];
            manufacturer.Name = (string)dataReader["Manufacturer"];
            manufacturer.LogoFileName = this.PrefixLogoFileName(DataUtil.GetString(dataReader, "Logo"));
            manufacturer.HasReview = DataUtil.GetBoolean(dataReader, "Review");

            return manufacturer;
        }

        /// <summary>
        /// Gets a van range from a data reader
        /// </summary>
        /// <param name="dataReader">The data reader</param>
        /// <returns>Van range representation of the data</returns>
        private IVanRange GetRangeFromDataReader(SqlDataReader dataReader)
        {
            VanRange range = new VanRange();
            range.Id = (int)dataReader["VANRanId"];
            range.Name = (string)dataReader["Range"];
            range.NameWithYears = (string)dataReader["RangeYear"];
            range.IntroducedYear = (int)dataReader["RangeIntroduced"];
            if (!dataReader.IsDBNull(dataReader.GetOrdinal("RangeDiscontinued")))
            {
                range.DiscontinuedYear = (int)dataReader["RangeDiscontinued"];
            }
            else
            {
                range.DiscontinuedYear = Int32.MaxValue;
            }

            range._manufacturerId = (int)dataReader["VANManId"];

            return range;
        }

        /// <summary>
        /// Gets a van model from a data reader
        /// </summary>
        /// <param name="dataReader">The data reader</param>
        /// <returns>Van model representation of the data</returns>
        private IVanModel GetModelFromDataReader(SqlDataReader dataReader)
        {
            VanModel model = new VanModel();
            model.Id = (int)dataReader["VANModId"];
            if (!dataReader.IsDBNull(dataReader.GetOrdinal("Model")))
            {
                model.BodyStyle = (string)dataReader["Model"];
            }
            else
            {
                model.BodyStyle = String.Empty;
            }

            model.Name = (string)dataReader["RangeModel"];
            model.NameWithYears = (string)dataReader["RangeModelYear"];
            model.IntroducedYear = (int)dataReader["ModelIntroduced"];
            if (!dataReader.IsDBNull(dataReader.GetOrdinal("ModelDiscontinued")))
            {
                model.DiscontinuedYear = (int)dataReader["ModelDiscontinued"];
            }
            else
            {
                model.DiscontinuedYear = Int32.MaxValue;
            }

            model.RangeId = (int)dataReader["VANRanId"];

            IYearPlateProvider yearPlateProvider = ObjectFactory.GetInstance<IYearPlateProvider>();

            model.FromYearPlate = yearPlateProvider.FromId(DataUtil.GetInt32(dataReader, "FromYearPlateId"));
            model.ToYearPlate = yearPlateProvider.FromId(DataUtil.GetInt32(dataReader, "ToYearPlateId"));

            IVanClassificationProvider classificationProvider = ObjectFactory.GetInstance<IVanClassificationProvider>();
            model.Classification = classificationProvider.GetClassification(DataUtil.GetInt32(dataReader, "ClassificationId"));

            model.HasReview = DataUtil.GetBoolean(dataReader, "Review");

            model.HasTechData = DataUtil.GetBoolean(dataReader, "Tech");

            if (dataReader.IsDBNull(dataReader.GetOrdinal("CAPBodyStyleId")))
            {
                model.CAPBodyStyleId = String.Empty;
            }
            else
            {
                model.CAPBodyStyleId = Convert.ToString(dataReader["CAPBodyStyleId"]);
            }

            if (dataReader.IsDBNull(dataReader.GetOrdinal("CAPRanId")))
            {
                model.CAPRanId = String.Empty;
            }
            else
            {
                model.CAPRanId = Convert.ToString(dataReader["CAPRanId"]);
            }

            model.UrlVariantIndex = 0;

            return model;
        }

        /// <summary>
        /// Builds a van derivative representation from the data
        /// </summary>
        /// <param name="dataReader">The data reader</param>
        /// <returns>The van derivative</returns>
        private VanDerivative GetDerivativeFromDataReader(SqlDataReader dataReader)
        {
            VanDerivative deriv = new VanDerivative();
            deriv.Id = (int)dataReader["VANDerId"];
            deriv.Name = (string)dataReader["Derivative"];
            deriv._modelId = (int)dataReader["VANModId"];
            deriv.FuelType = (string)dataReader["FuelType"];

            deriv.HasCO2Emissions = DataUtil.GetNullableInt(dataReader, "CO2").HasValue;
            deriv.HasEnginePower = DataUtil.GetNullableInt(dataReader, "BHP").HasValue;
            deriv.HasPayload = DataUtil.GetNullableInt(dataReader, "Payload").HasValue;
            deriv.HasTorque = DataUtil.GetNullableInt(dataReader, "TorqueNm").HasValue;
            deriv.HasBrakedTowing = DataUtil.GetNullableInt(dataReader, "BrakedTowing").HasValue;
            deriv.HasSeats = DataUtil.GetNullableInt(dataReader, "Seats").HasValue;
            deriv.HasEngineSize = DataUtil.GetNullableInt(dataReader, "CC").HasValue;
            deriv.HasMpg = DataUtil.GetNullableInt(dataReader, "MPG").HasValue;

            deriv.ListPrice = DataUtil.GetInt32(dataReader, "ListPrice");
            deriv.InsuranceGroup = DataUtil.GetInt32(dataReader, "IG");

            deriv.CC = DataUtil.GetInt32(dataReader, "CC");
            deriv.Cylinders = DataUtil.GetInt32(dataReader, "Cylinders");
            deriv.Bhp = DataUtil.GetInt32(dataReader, "BHP");

            if (!(deriv.Bhp > 0))
            {
                int ps = DataUtil.GetInt32(dataReader, "PS");
                double calculatedBhp = ps / PsValue * BhpValue;
                deriv.Bhp = Convert.ToInt32(Math.Round(calculatedBhp));
            }

            deriv.Wheelbase = DataUtil.GetInt32(dataReader, "wheelbase");
            deriv.TurningCircle = DataUtil.GetInt32(dataReader, "TurningCircle");
            deriv.BrakedTowing = DataUtil.GetInt32(dataReader, "BrakedTowing");

            deriv.Width = DataUtil.GetInt32(dataReader, "Width");
            deriv.Height = DataUtil.GetInt32(dataReader, "Height");
            deriv.Weight = DataUtil.GetInt32(dataReader, "Weight");
            deriv.Payload = DataUtil.GetInt32(dataReader, "Payload");

            deriv.CO2Emissions = DataUtil.GetInt32(dataReader, "CO2");
            deriv.MilesPerGallon = DataUtil.GetInt32(dataReader, "MPG");
            deriv.Seats = DataUtil.GetInt32(dataReader, "Seats");
            deriv.TorqueLbFt = DataUtil.GetInt32(dataReader, "TorqueLbFt");
            deriv.TorqueNm = DataUtil.GetInt32(dataReader, "TorqueNm");
            deriv.Transmission = DataUtil.GetString(dataReader, "Transmission", "-");
            deriv.FuelDelivery = DataUtil.GetString(dataReader, "FuelDelivery", "-");
            deriv.FuelCapacity = DataUtil.GetInt32(dataReader, "FuelCapacity");
            deriv.Gears = DataUtil.GetString(dataReader, "Gears", "-");
            deriv.FrontOverhang = DataUtil.GetInt32(dataReader, "OverhangFront");
            deriv.RearOverhang = DataUtil.GetInt32(dataReader, "OverhangRear");
            deriv.EuroEmissions = DataUtil.GetInt32(dataReader, "EuroEmissions");
            deriv.Valves = DataUtil.GetInt32(dataReader, "Valves");

            deriv.HasTechData = DataUtil.GetBoolean(dataReader, "Tech");

            if (!dataReader.IsDBNull(dataReader.GetOrdinal("Introduced")))
            {
                deriv.Introduced = (DateTime)dataReader["Introduced"];
            }
            else
            {
                deriv.Introduced = DateTime.MaxValue;
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal("Discontinued")))
            {
                deriv.Discontinued = (DateTime)dataReader["Discontinued"];
            }
            else
            {
                deriv.Discontinued = DateTime.MaxValue;
            }

            IYearPlateProvider yearPlateProvider = ObjectFactory.GetInstance<IYearPlateProvider>();

            deriv.FromYearPlate = yearPlateProvider.FromId(DataUtil.GetInt32(dataReader, "FromYearPlateId"));
            deriv.ToYearPlate = yearPlateProvider.FromId(DataUtil.GetInt32(dataReader, "ToYearPlateId"));

            return deriv;
        }

        /// <summary>
        /// Prefix the logo name
        /// </summary>
        /// <param name="logoFileName">The logo name</param>
        /// <returns>The prefixed logo name</returns>
        private string PrefixLogoFileName(string logoFileName)
        {
            if (!String.IsNullOrEmpty(logoFileName))
            {
                return String.Concat("LCV\\", logoFileName);
            }

            return String.Empty;
        }

        /// <summary>
        /// Gets a review image from a data reader
        /// </summary>
        /// <param name="dataReader">The datareader</param>
        /// <returns>ReviewImage representation of the data</returns>
        private ReviewImage GetReviewImageFromDataReader(SqlDataReader dataReader)
        {
            try
            {
                ReviewImage reviewImage = new ReviewImage();
                reviewImage.Category = (int)dataReader["CategoryId"];
                reviewImage.File = "LCV/" + (string)dataReader["Image"];

                return reviewImage;
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentException("A required column was not found", "dataReader", e);
            }
            catch (InvalidCastException e)
            {
                throw new ArgumentException("A column value was invalid", "dataReader", e);
            }
        }

        #endregion
    }
}