using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;


using Parkers.Data;
using StructureMap;

namespace Parkers.Vehicles
{
    public class VanReviewProvider : IVanReviewProvider
    {
        private static string _database = "ParkersVAN";
        private static IVanProvider vanProvider = ObjectFactory.GetInstance<IVanProvider>();

        public IVanReview GetReviewFromId(int id)
        {
            Sproc sp = new Sproc("Mod_Select_ById", _database);
            sp.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr.HasRows && dr.Read())
                {
                    if ((bool)dr["Review"])
                    {
                        return GetReviewFromDataReader(dr);
                    }
                }
            }
            return null;
        }

        internal static IVanReview GetReviewFromDataReader(SqlDataReader dataReader)
        {
            VanReview review = new VanReview();

            review.Id = (int)dataReader["VANModId"];
            review.For = (string)dataReader["TextFor"];
            review.Against = (string)dataReader["TextAgainst"];
            review.Summary = (string)dataReader["TextSummary"];
            review.SummaryRating = (int)dataReader["RatingSummary"];
            review.Cargo = (string)dataReader["TextCargo"];
            review.CargoRating = (int)dataReader["RatingCargo"];
            review.Road = (string)dataReader["TextRoad"];
            review.RoadRating = (int)dataReader["RatingRoad"];
            review.Wheel = (string)dataReader["TextWheel"];
            review.WheelRating = (int)dataReader["RatingWheel"];
            review.Safety = (string)dataReader["TextSafety"];
            review.SafetyRating = (int)dataReader["RatingSafety"];
            review.Cost = (string)dataReader["TextCost"];
            review.CostRating = (int)dataReader["RatingCost"];
            review.Reliability = (string)dataReader["TextReliability"];
            review.ReliabilityRating = (int)dataReader["RatingReliability"];
            review.MinPriceNew = DataUtil.GetInt32(dataReader, "NewMin");
            review.MaxPriceNew = DataUtil.GetInt32(dataReader, "NewMax");
            review.MinPriceUsed = DataUtil.GetInt32(dataReader, "UsedMin");
            review.MaxPriceUsed = DataUtil.GetInt32(dataReader, "UsedMax");
            review.MinIG = DataUtil.GetInt32(dataReader, "IGMin");
            review.MaxIG = DataUtil.GetInt32(dataReader, "IGMax");
            review.ModelIntroduced = dataReader["ModelIntroduced"] == null ? String.Empty : Convert.ToString(dataReader["ModelIntroduced"]);
            review.ModelDiscontinued = dataReader["ModelDiscontinued"] == null ? String.Empty : Convert.ToString(dataReader["ModelDiscontinued"]);
            review.AlternativeIds.Add(DataUtil.GetInt32(dataReader, "AlternativeId1"));
            review.AlternativeIds.Add(DataUtil.GetInt32(dataReader, "AlternativeId2"));
            review.AlternativeIds.Add(DataUtil.GetInt32(dataReader, "AlternativeId3"));

            review.FirstPublished = DataUtil.GetDateTime(dataReader, "FirstPublished");
            review.LastUpdated = DataUtil.GetDateTime(dataReader, "LastUpdated");
            review.OriginalAuthor = DataUtil.GetString(dataReader, "OriginalAuthor");
            review.Video = DataUtil.GetString(dataReader, "YouTubeVideoId");

            return review;
        }

        public List<IVanDerivative> GetDerivativesFromId(int modelId)
        {
            Sproc sp = new Sproc("Review_Select_DerivativesByModel", _database);
            sp.Parameters.Add("@VanModId", SqlDbType.Int).Value = modelId;
            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr != null && dr.HasRows)
                {
                    List<IVanDerivative> result = new List<IVanDerivative>();
                    while (dr.Read())
                    {
                        result.Add(vanProvider.GetDerivativeFromId((int)dr["VanDerId"]));
                    }
                    return result;
                }
            }
            return null;
        }
    }
}

