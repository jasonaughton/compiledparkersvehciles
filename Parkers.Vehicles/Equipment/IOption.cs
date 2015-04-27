// <copyright file="IOption.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines option
    /// </summary>
    public interface IOption
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
        /// Gets or sets the category id.
        /// </summary>
        /// <value>
        /// The category id.
        /// </value>
        int CategoryId
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
        /// Gets the cost description.
        /// </summary>
        string CostDescription
        {
            get;
        }

        /// <summary>
        /// Gets or sets the date from.
        /// </summary>
        /// <value>
        /// The date from.
        /// </value>
        string DateFrom
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date to.
        /// </summary>
        /// <value>
        /// The date to.
        /// </value>
        string DateTo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text value.
        /// </value>
        string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type value.
        /// </value>
        string Type
        {
            get;
            set;
        }
    }
}
