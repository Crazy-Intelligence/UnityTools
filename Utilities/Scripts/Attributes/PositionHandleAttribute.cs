using UnityEngine;
using System;

namespace CI.Utilities
{
	[AttributeUsage(AttributeTargets.Field)]
	public class PositionHandleAttribute : PropertyAttribute
	{
		public PositionHandleAttribute()
		{

		}
	}
}
