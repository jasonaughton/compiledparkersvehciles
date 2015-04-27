// <copyright file="IManufacturer.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Defines manufacturer
    /// </summary>
    public interface IManufacturer : IKeyValueMappable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance has review.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has review; otherwise, <c>false</c>.
        /// </value>
        bool HasReview
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has tech data.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has tech data; otherwise, <c>false</c>.
        /// </value>
        bool HasTechData
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is discontinued.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is discontinued; otherwise, <c>false</c>.
        /// </value>
        bool IsDiscontinued
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the models.
        /// </summary>
        List<IModel> Models
        {
            get;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name value.
        /// </value>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the popularity rank.
        /// </summary>
        /// <value>
        /// The popularity rank.
        /// </value>
        int PopularityRank
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL value.
        /// </value>
        string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the logo filename.
        /// </summary>
        string LogoFileName
        {
            get;
        }

        /// <summary>
        /// Finds the models.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>list of models</returns>
        ListOfModel FindModels(Predicate<IModel> filter);

        /// <summary>
        /// Determines whether the specified filter has model.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        ///     <c>true</c> if the specified filter has model; otherwise, <c>false</c>.
        /// </returns>
        bool HasModel(Predicate<IModel> filter);
    }
}
