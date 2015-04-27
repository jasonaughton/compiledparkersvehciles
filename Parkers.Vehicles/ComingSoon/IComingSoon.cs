// <copyright file="IComingSoon.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines coming soon
    /// </summary>
    public interface IComingSoon
    {
        /// <summary>
        /// Gets or sets the car search term.
        /// </summary>
        /// <value>
        /// The car search term.
        /// </value>
        string CarSearchTerm
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the first image.
        /// </summary>
        string FirstImage
        {
            get;
        }

        /// <summary>
        /// Gets or sets the heading.
        /// </summary>
        /// <value>
        /// The heading.
        /// </value>
        string Heading
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>
        /// The images.
        /// </value>
        List<IComingSoonImage> Images
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the on sale.
        /// </summary>
        /// <value>
        /// The on sale.
        /// </value>
        string OnSale
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the page id.
        /// </summary>
        /// <value>
        /// The page id.
        /// </value>
        int PageId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the prices.
        /// </summary>
        /// <value>
        /// The prices.
        /// </value>
        string Prices
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the secondary heading.
        /// </summary>
        /// <value>
        /// The secondary heading.
        /// </value>
        string SecondaryHeading
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the secondary image.
        /// </summary>
        /// <value>
        /// The secondary image.
        /// </value>
        string SecondaryImage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the secondary model.
        /// </summary>
        ICarModel SecondaryModel
        {
            get;
        }

        /// <summary>
        /// Gets or sets the secondary model id.
        /// </summary>
        /// <value>
        /// The secondary model id.
        /// </value>
        int SecondaryModelId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the secondary text.
        /// </summary>
        /// <value>
        /// The secondary text.
        /// </value>
        string SecondaryText
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the strapline.
        /// </summary>
        /// <value>
        /// The strapline.
        /// </value>
        string Strapline
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [sub home].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [sub home]; otherwise, <c>false</c>.
        /// </value>
        bool SubHome
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
        /// Gets or sets a value indicating whether this <see cref="IComingSoon"/> is visible.
        /// </summary>
        /// <value>
        ///     <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        bool Visible
        {
            get;
            set;
        }

        /// <summary>
        /// Firsts the image URL.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>first image url</returns>
        string FirstImageUrl(int width, int height);
    }
}
