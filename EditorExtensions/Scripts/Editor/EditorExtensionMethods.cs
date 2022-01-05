#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace CI.EditorExtensions
{
	public static class EditorExtensionMethods
	{
		public static List<FieldInfo> GetFieldsWith<TAttribute>(this MonoBehaviour monoBehaviour, BindingFlags flags, Func<FieldInfo, bool> validateField) where TAttribute : Attribute
		{
			var fields = new List<FieldInfo>();

			foreach (var fieldInfo in monoBehaviour.GetType().GetFields(flags))
			{
				if (!validateField(fieldInfo)) continue;

				var attribute = fieldInfo.GetCustomAttribute<TAttribute>();
				if (attribute == null) continue;

				fields.Add(fieldInfo);
			}

			return fields;
		}
		public static List<FieldInfo> GetFieldsWith<TAttribute>(this MonoBehaviour monoBehaviour, BindingFlags flags) where TAttribute : Attribute
		{
			return monoBehaviour.GetFieldsWith<TAttribute>(flags, (fieldInfo) => true);
		}
	}
}

#endif