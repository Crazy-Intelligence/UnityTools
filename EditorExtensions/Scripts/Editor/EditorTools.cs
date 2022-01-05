#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using CI.Utilities;

namespace CI.EditorExtensions
{
	public class EditorTools
	{
		private const string _EditIconPath = "Assets/_Project/Graphics/Icons/EditIcon.png";
		private const string _CopyIconPath = "Assets/_Project/Graphics/Icons/CopyIcon.png";
		private const string _DeleteIconPath = "Assets/_Project/Graphics/Icons/DeleteIcon.png";

		public static Vector3 ScaleHandle(Object @object, Vector3 scale, Vector3 center)
		{
			if (scale == Vector3.zero)
			{
				scale = new Vector3(1f, 1f, 0f);
			}

			EditorGUI.BeginChangeCheck();

			Vector3 newSize = Handles.DoScaleHandle(scale, center, Quaternion.identity, 2f);

			newSize = newSize.Round();

			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(@object, $"Changed Scale for {@object.name}");
				EditorUtility.SetDirty(@object);
				return newSize;
			}

			return scale;
		}
		public static Vector3 PositionHandle(Object @object, Vector3 position)
		{
			EditorGUI.BeginChangeCheck();

			Vector3 newPosition = Handles.DoPositionHandle(position, Quaternion.identity);

			newPosition = newPosition.Round();

			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(@object, $"Changed Position for {@object.name}");
				EditorUtility.SetDirty(@object);
				return newPosition;
			}

			return position;
		}

		public static void DrawWireSphere(Vector3 center, float radius)
		{
			Handles.DrawWireDisc(center, Vector3.up, radius);
			Handles.DrawWireDisc(center, Vector3.right, radius);
			Handles.DrawWireDisc(center, Vector3.forward, radius);
		}

		public static Texture GetEditIcon()
		{
			return AssetDatabase.LoadAssetAtPath<Texture>(_EditIconPath);
		}
		public static Texture GetCopyIcon()
		{
			return AssetDatabase.LoadAssetAtPath<Texture>(_CopyIconPath);
		}
		public static Texture GetDeleteIcon()
		{
			return AssetDatabase.LoadAssetAtPath<Texture>(_DeleteIconPath);
		}

		public static GUIStyle ColorStyle(Color color)
		{
			var colorStyle = new GUIStyle();
			colorStyle.normal.textColor = color;
			return colorStyle;
		}
	}
}

#endif