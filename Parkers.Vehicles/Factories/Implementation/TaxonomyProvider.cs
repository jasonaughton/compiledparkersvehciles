
namespace Parkers.Vehicles
{
    using System.Collections.Generic;

    public class TaxonomyProvider : ITaxonomyProvider
    {
        /// <summary>
        /// Get a list containing an arbitrary Range for each range name represented in the passed list of models
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <remarks>Assumes that all models from any range are consecutive in the list. Used to group a model list by range name.</remarks>
        public ListOfRange GetUniqueRanges(ListOfModel models)
        {
            List<IModel> modList = models;
            List<IRange> result = new List<IRange>();

            string lastName = null;
            foreach (IModel m in modList)
            {
                if (lastName != m.Range.Name)
                {
                    lastName = m.Range.Name;
                    result.Add(m.Range);
                }
            }
            return result;
        }


        /// <summary>
        /// Gets a list of all the Ranges represented in the passed list of models which have the specified name. 
        /// </summary>
        /// <param name="models"></param>
        /// <param name="rangeName"></param>
        /// <returns></returns>
        /// <remarks>Assumes that all models from any range are consecutive in the list. Used to group a model list by range name.</remarks>
        public ListOfRange GetRangesWithName(ListOfModel models, string rangeName)
        {
            List<IModel> modList = models;
            List<IRange> result = new List<IRange>();

            int lastId = 0;
            foreach (IModel m in modList)
            {

                if (m.Range.Name == rangeName && m.Range.Id != lastId)
                {
                    lastId = m.Range.Id;
                    result.Add(m.Range);
                }
            }
            return result;
        }


        /// <summary>
        /// Get all Models in the passed list which are in the passed Range
        /// </summary>
        /// <param name="models"></param>
        /// <param name="ran"></param>
        /// <returns></returns>
        /// <remarks>Used to group a model list by range name.</remarks>
        public ListOfModel GetModelsInRange(ListOfModel models, IRange ran)
        {
            List<IModel> modList = models;
            List<IModel> result = new List<IModel>();
            if (modList != null)
            {
                foreach (IModel m in modList)
                {
                    if (m.Range.Id == ran.Id)
                    {
                        result.Add(m);
                    }
                }
            }

            return result;
        }
    }
}
