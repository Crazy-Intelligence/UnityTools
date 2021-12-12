using System;
using UnityEngine;

namespace CI.EditorExtensions
{
	[AttributeUsage(AttributeTargets.Field)]
	public class InspectorReadonlyAttribute : PropertyAttribute
	{
		public InspectorReadonlyAttribute()
		{

		}
	}
}