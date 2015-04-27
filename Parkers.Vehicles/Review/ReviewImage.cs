using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Web;
using System.Configuration;
using Parkers.Data;

namespace Parkers.Vehicles
{
	/// <summary>
	/// Represents a review image
	/// </summary>
	public class ReviewImage
	{
		#region Properties

		public int Category
		{
			get { return _category; }
			set { _category = value; }
		}
		private int _category;

		/// <summary>
		/// Path to the image file, taken to be relative to http://www.parkers.co.uk/images
		/// </summary>
		public string File
		{
			get
			{
				return _file;
			}
			set
			{
				_file = value;
				_file = _file.Replace( "\\", "/" );
				_file = _file.Replace( "//", "/" );
			}
		}
		private string _file;

		public string Caption
		{
			get { return _caption; }
			set { _caption = value; }
		}
		private string _caption;

		#endregion
	}
}