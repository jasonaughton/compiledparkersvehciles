// <copyright file="IComingSoonCaption.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    /// <summary>
    /// Defines coming soon caption
    /// </summary>
    public interface IComingSoonCaption
    {
        /// <summary>
        /// Gets the caption id.
        /// </summary>
        string CaptionId
        {
            get;
        }

        /// <summary>
        /// Gets the caption left.
        /// </summary>
        int CaptionLeft
        {
            get;
        }

        /// <summary>
        /// Gets the caption top.
        /// </summary>
        int CaptionTop
        {
            get;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id value.
        /// </value>
        int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the image id.
        /// </summary>
        /// <value>
        /// The image id.
        /// </value>
        int ImageId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the image left.
        /// </summary>
        int ImageLeft
        {
            get;
        }

        /// <summary>
        /// Gets the image top.
        /// </summary>
        int ImageTop
        {
            get;
        }

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        /// <value>
        /// The left value.
        /// </value>
        int Left
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
        /// Gets or sets the top.
        /// </summary>
        /// <value>
        /// The top value.
        /// </value>
        int Top
        {
            get;
            set;
        }
    }
}
