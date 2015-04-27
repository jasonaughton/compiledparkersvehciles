// <copyright file="IValuationOption.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines valuation option
    /// </summary>
    public interface IValuationOption
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        string Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost value.
        /// </value>
        decimal Cost
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item value.
        /// </value>
        string Item
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the option code.
        /// </summary>
        /// <value>
        /// The option code.
        /// </value>
        int OptionCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        decimal Value
        {
            get;
            set;
        }
    }
}
