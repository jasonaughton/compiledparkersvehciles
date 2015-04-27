// <copyright file="IVanClassification.cs" company="Bauer Consumer Media Limited">
//    Copyright 2014 Bauer Consumer Media Limited
// </copyright>
namespace Parkers.Vehicles
{
    #region Usings

    using System.Collections.Generic;
    
    #endregion
    /// <summary>
    /// The van classificatation interface
    /// </summary>
    public interface IVanClassification
    {
        #region Properties

        /// <summary>
        /// Gets the id
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// Gets the name
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Gets the description
        /// </summary>
        string Description
        {
            get;
        }

        /// <summary>
        /// Gets the long description
        /// </summary>
        string LongDescription
        { 
            get;
        }

        /// <summary>
        /// Gets the average mileage.
        /// </summary>
        Dictionary<int, int> AverageMileage
        {
            get;
        } 

        #endregion
    }
}
