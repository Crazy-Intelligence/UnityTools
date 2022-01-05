#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace CI.EditorExtensions
{
	public interface IVirtualMonoBehaviourEditor
	{
		public void OnSceneGUI(Object target, SerializedObject serializedObject);
		public void OnEnable(Object target, SerializedObject serializedObject);
	}
}

#endif