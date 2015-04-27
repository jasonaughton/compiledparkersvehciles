using System;
using System.Collections.Generic;
using System.Text;

namespace Parkers.Vehicles
{
	public class ReviewImageCollection
	{
		private List<ReviewImage> _images = new List<ReviewImage>();
		private Dictionary<int, List<ReviewImage>> _imagesByCategory = new Dictionary<int,List<ReviewImage>>();

		internal void Add( ReviewImage image )
		{
			_images.Add( image );
			
			if ( ! _imagesByCategory.ContainsKey( image.Category ) )
			{
				_imagesByCategory[image.Category] = new List<ReviewImage>();
			}
			
			_imagesByCategory[image.Category].Add( image );
		}

		public Dictionary<int, List<ReviewImage>> ByCategory
		{
			get
			{
				return _imagesByCategory;
			}
		}

		public bool ContainsCategory( int category )
		{
			return _imagesByCategory.ContainsKey( category ) && _imagesByCategory[category].Count > 0;
		}

		public ReviewImage[] Images
		{
			get
			{
				return _images.ToArray();
			}
		}


	}

}
