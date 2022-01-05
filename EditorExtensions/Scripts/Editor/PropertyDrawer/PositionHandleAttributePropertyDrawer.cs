#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using CI.Utilities;

namespace CI.EditorExtensions
{
	[CustomPropertyDrawer(typeof(PositionHandleAttribute))]
	public class PositionHandleAttributePropertyDrawer : PropertyDrawer
	{
		private bool _isVector3;

		private Vector3 _vectorValue;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			switch (property.propertyType)
			{
				case SerializedPropertyType.Vector2:
					_isVector3 = false;
					_vectorValue = property.vector2Value;
					break;
				case SerializedPropertyType.Vector3:
					_isVector3 = true;
					_vectorValue = property.vector3Value;
					break;
				default:
					return;
			}

			DrawInInspector(position, label);

			if (_isVector3)
			{
				property.vector3Value = _vectorValue;
			}
			else
			{
				property.vector2Value = _vectorValue;
			}
		}

		private void DrawInInspector(Rect position, GUIContent label)
		{
			float padding = 5f;
			float markerWidth = 2f;
			float vectorWidth = position.width - (2 * padding) - markerWidth;

			var rectBuilder = new HorizontalRectBuilder(position);

			rectBuilder.AddPadding(padding);
			var toggleRect = rectBuilder.Add(markerWidth);
			rectBuilder.AddPadding(padding);
			var vectorRect = rectBuilder.Add(vectorWidth);

			EditorGUI.DrawRect(toggleRect, Color.yellow);

			label.tooltip = "A Handle is displayed for this Vector in Scene.";

			if (_isVector3)
			{
				_vectorValue = EditorGUI.Vector3Field(vectorRect, label, _vectorValue);
			}
			else
			{
				_vectorValue = EditorGUI.Vector2Field(vectorRect, label, _vectorValue);
			}
			
		}
	}
}

#endif