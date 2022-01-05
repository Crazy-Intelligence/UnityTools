#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace CI.EditorExtensions
{
	[CustomEditor(typeof(MonoBehaviour), true, isFallback = true)]
	public class MonoBehaviourEditor : Editor
	{
		private List<IVirtualMonoBehaviourEditor> _virtualEditors = new List<IVirtualMonoBehaviourEditor>();

		protected virtual void OnSceneGUI()
		{
			foreach (var editor in _virtualEditors)
			{
				editor.OnSceneGUI(target, serializedObject);
			}
		}

		private void OnEnable()
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (var assembly in assemblies)
			{
				var types = assembly.GetTypes();
				foreach (var type in types)
				{
					if (typeof(IVirtualMonoBehaviourEditor).IsAssignableFrom(type) && type.IsInterface == false && type.IsAbstract == false)
					{
						_virtualEditors.Add((IVirtualMonoBehaviourEditor)Activator.CreateInstance(type));
					}
				}
			}

			foreach (var editor in _virtualEditors)
			{
				editor.OnEnable(target, serializedObject);
			}
		}
	}
}

#endif