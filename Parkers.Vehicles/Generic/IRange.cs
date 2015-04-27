// <copyright file="IRange.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Defines range
    /// </summary>
    public interface IRange : IKeyValueMappable
    {
        /// <summary>
        /// Gets or sets the discontinued year.
        /// </summary>
        /// <value>
        /// The discontinued year.
        /// </value>
        int DiscontinuedYear
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the introduced year.
        /// </summary>
        /// <value>
        /// The introduced year.
        /// </value>
        int IntroducedYear
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is discontinued.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is discontinued; otherwise, <c>false</c>.
        /// </value>
        bool IsDiscontinued
        {
            get;
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        IManufacturer Manufacturer
        {
            get;
        }

        /// <summary>
        /// Gets the max price new.
        /// </summary>
        int MaxPriceNew
        {
            get;
        }

        /// <summary>
        /// Gets the min price new.
        /// </summary>
        int MinPriceNew
        {
            get;
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
        /// Gets or sets the name with years.
        /// </summary>
        /// <value>
        /// The name with years.
        /// </value>
        string NameWithYears
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
        /// Gets or sets the popularity.
        /// </summary>
        /// <value>
        /// The popularity.
        /// </value>
        double Popularity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the production years.
        /// </summary>
        string ProductionYears
        {
            get;
        }
    }
}
