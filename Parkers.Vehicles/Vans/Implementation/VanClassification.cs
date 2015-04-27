// <copyright file="VanClassification.cs" company="Bauer Consumer Media Limited">
//    Copyright 2014 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Van classification object
    /// </summary>
    public class VanClassification : IVanClassification
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the long description
        /// </summary>
        public string LongDescription
        { 
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the average mileage.
        /// </summary>
        public Dictionary<int, int> AverageMileage
        {
            get; 
            set;
        }
        #endregion
    }
}
