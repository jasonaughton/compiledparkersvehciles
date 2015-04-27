using System;
using System.Collections.Generic;
using System.Text;

namespace Parkers.Postcodes
{
	public class County : IPlace
	{
		private string _name;

		internal County( string name )
		{
			_name = name;
		}

		#region IPlace Members

		public GridRef GetGridRef()
		{
			return null;
		}

		public string GetDisplayName()
		{
			return _name;
		}

		#endregion
	}
}
