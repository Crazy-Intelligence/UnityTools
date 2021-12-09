using System;
using UnityEngine;

namespace CI.Utilities
{
	[AttributeUsage(AttributeTargets.Field)]
	public class InspectorReadonlyAttribute : PropertyAttribute
	{
		public InspectorReadonlyAttribute()
		{

		}
	}
}