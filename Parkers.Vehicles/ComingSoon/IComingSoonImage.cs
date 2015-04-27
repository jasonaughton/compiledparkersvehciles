// <copyright file="IComingSoonImage.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System.Collections.Generic;

    #endregion

    public interface IComingSoonImage
    {
        /// <summary>
        /// Gets or sets the captions.
        /// </summary>
        /// <value>
        /// The captions.
        /// </value>
        List<IComingSoonCaption> Captions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>
        /// The file.
        /// </value>
        string File
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        int Id
        {
            get;
            set;
        }
    }
}
