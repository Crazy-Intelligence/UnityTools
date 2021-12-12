using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

namespace CI.EditorExtensions
{
	public class PositionHandleAttributeEditor : IVirtualMonoBehaviourEditor
	{
		private List<VectorField> _vectorFields = new List<VectorField>();

		public void OnSceneGUI(Object target, SerializedObject serializedObject)
		{
			foreach (var field in _vectorFields)
			{
				var position = field.GetValue();
				var offset = new Vector3(-0.5f, -0.25f, -1f);

				Handles.color = new Color(1f, 1f, 1f, 1f);

				Handles.Label(position + offset, field.Vector.name);

				if (Handles.Button(field.GetValue(), Quaternion.identity, 0.5f, 1f, Handles.SphereHandleCap))
				{
					field.ShowHandle = !field.ShowHandle;
				}
				
				if (!field.ShowHandle) continue;

				field.SetValue(EditorTools.PositionHandle(target, position));
			}

			serializedObject.ApplyModifiedProperties();
		}

		public void OnEnable(Object target, SerializedObject serializedObject)
		{
			var monoBehaviour = (MonoBehaviour)target;
			if (monoBehaviour is null) return;

			var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

			var fields = monoBehaviour.GetFieldsWith<PositionHandleAttribute>(flags, IsVector);

			foreach (var field in fields)
			{
				var vector = serializedObject.FindProperty(field.Name);
				_vectorFields.Add(new VectorField(vector));
			}
		}

		private bool IsVector(FieldInfo fieldInfo)
		{
			return fieldInfo.FieldType == typeof(Vector3) || fieldInfo.FieldType == typeof(Vector2);
		}

		private class VectorField
		{
			public bool ShowHandle { get; set; }
			
			public SerializedProperty Vector { get; private set; }

			public VectorField(SerializedProperty vector)
			{
				Vector = vector;
				ShowHandle = false;
			}

			public Vector3 GetValue()
			{
				if (IsVector3())
				{
					return Vector.vector3Value;
				}
				return Vector.vector2Value;
			}

			public void SetValue(Vector3 value)
			{
				if (IsVector3())
				{
					Vector.vector3Value = value;
				}
				else
				{
					Vector.vector2Value = value;
				}
			}

			private bool IsVector3()
			{
				return Vector.propertyType == SerializedPropertyType.Vector3;
			}
		}
	}
}
