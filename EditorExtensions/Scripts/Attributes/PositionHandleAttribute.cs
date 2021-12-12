using UnityEngine;
using System;

namespace CI.EditorExtensions
{
	[AttributeUsage(AttributeTargets.Field)]
	public class PositionHandleAttribute : PropertyAttribute
	{
		public PositionHandleAttribute()
		{

		}
	}
}
