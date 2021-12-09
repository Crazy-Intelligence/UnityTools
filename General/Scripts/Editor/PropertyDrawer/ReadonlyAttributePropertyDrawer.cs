using UnityEngine;
using UnityEditor;

namespace CI.Utilities
{
	[CustomPropertyDrawer(typeof(InspectorReadonlyAttribute))]
	public class ReadonlyAttributePropertyDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginDisabledGroup(true);
			
			switch (property.propertyType)
			{
				case SerializedPropertyType.Vector3:
					EditorGUI.Vector3Field(position, label, property.vector3Value);
					break;
				case SerializedPropertyType.Vector2:
					EditorGUI.Vector2Field(position, label, property.vector2Value);
					break;
				case SerializedPropertyType.Float:
					EditorGUI.FloatField(position, label, property.floatValue);
					break;
				case SerializedPropertyType.Integer:
					EditorGUI.IntField(position, label, property.intValue);
					break;
				case SerializedPropertyType.String:
					EditorGUI.TextField(position, label, property.stringValue);
					break;
				default:
					EditorGUI.ObjectField(position, property);
					break;
			}

			EditorGUI.EndDisabledGroup();
		}
	}
}
