using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Parkers.Data;

namespace Parkers.Vehicles
{
    [DataObject]
    public class ComingSoonProvider : IComingSoonProvider
    {
        private static string _database = "ParkersMeta";

        public List<IComingSoon> GetActiveComingSoons()
        {
            Sproc sp = new Sproc("ComingSoon_Select_Active", _database);
            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr != null && dr.HasRows)
                {
                    List<IComingSoon> results = new List<IComingSoon>();
                    while (dr.Read())
                    {
                        results.Add(GetComingSoonFromId((int)dr["PageId"]));
                    }
                    return results;
                }
            }
            return null;
        }

        public IComingSoon GetComingSoonFromId(int id)
        {
            Sproc sp = new Sproc("ComingSoon_Select", _database);
            sp.Parameters.Add("@PageId", SqlDbType.Int).Value = id;

            using (SqlDataReader dr = sp.ExecuteReader())
            {
                if (dr != null && dr.Read())
                {
                    return GetComingSoonFromDataReader(dr);
                }
            }
            return null;
        }

        private IComingSoon GetComingSoonFromDataReader(SqlDataReader dr)
        {
            ComingSoon cs = new ComingSoon();
            cs.PageId = (int)dr["PageId"];
            cs.Heading = (string)dr["Heading"];
            cs.Strapline = (string)dr["StrapLine"];
            cs.Prices = (string)dr["Prices"];
            cs.OnSale = (string)dr["OnSale"];
            cs.Text = (string)dr["Text"];
            cs.SecondaryHeading = (string)dr["SecondaryHeading"];
            cs.SecondaryText = (string)dr["SecondaryText"];
            cs.SecondaryModelId = (int)dr["SecondaryParModId"];
            //cs.SecondaryImage = (string) dr["SecondaryImage"];
            cs.Visible = (bool)dr["Visible"];
            cs.SubHome = (bool)dr["SubHome"];
            cs.CarSearchTerm = DataUtil.GetString(dr, "CarSearchTerm");

            dr.NextResult();

            // Populate images
            while (dr.Read())
            {
                ComingSoonImage i = new ComingSoonImage();
                i.File = (string)dr["Image"];
                i.File = i.File.Replace("/images/", "");
                i.Id = (int)dr["ImageId"];
                cs.Images.Add(i);
            }

            dr.NextResult();

            // Populate captions
            List<IComingSoonCaption> allCaptions = new List<IComingSoonCaption>();
            while (dr.Read())
            {
                ComingSoonCaption cap = new ComingSoonCaption();
                cap.Text = (string)dr["Text"];
                cap.Left = (int)dr["Left"];
                cap.Top = (int)dr["Top"];
                cap.ImageId = (int)dr["ImageId"];
                cap.Id = (int)dr["CaptionId"];
                allCaptions.Add(cap);
            }

            // Link captions to the right images
            int imageIndex = 0;
            int captionIndex = 0;
            while (imageIndex < cs.Images.Count && captionIndex < allCaptions.Count)
            {
                if (cs.Images[imageIndex].Id < allCaptions[captionIndex].ImageId)
                {
                    // Advance in images
                    imageIndex++;
                }
                else if (cs.Images[imageIndex].Id > allCaptions[captionIndex].ImageId)
                {
                    // Advance in captions
                    captionIndex++;
                }
                else
                {
                    cs.Images[imageIndex].Captions.Add(allCaptions[captionIndex]);
                    captionIndex++;
                }
            }

            return cs;
        }
    }

}
