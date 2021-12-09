using UnityEngine;
using UnityEditor;

namespace CI.Utilities
{
	public interface IVirtualMonoBehaviourEditor
	{
		public void OnSceneGUI(Object target, SerializedObject serializedObject);
		public void OnEnable(Object target, SerializedObject serializedObject);
	}
}
