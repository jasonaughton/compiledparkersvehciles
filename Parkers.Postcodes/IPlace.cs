using System;
using System.Collections.Generic;
using System.Text;

namespace Parkers.Postcodes
{
	public interface IPlace
	{
		GridRef GetGridRef();
		string GetDisplayName();
	}
}
