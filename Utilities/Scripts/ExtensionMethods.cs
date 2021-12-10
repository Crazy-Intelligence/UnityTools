using UnityEngine;

namespace CI.Utilities
{
	public static class ExtensionMethods
	{
		public static Vector3 Round(this Vector3 vector, int places = 3)
		{
			var rounded = vector;
			rounded.x = rounded.x.Round(places);
			rounded.y = rounded.y.Round(places);
			rounded.z = rounded.z.Round(places);
			return rounded;
		}
		public static Vector2 Round(this Vector2 vector, int places = 3)
		{
			var rounded = vector;
			rounded.x = rounded.x.Round(places);
			rounded.y = rounded.y.Round(places);
			return rounded;
		}
		public static float Round(this float x, int places = 3)
		{
			float factor = 1f;

			for (int i = 1; i <= places; i++)
			{
				factor *= 10f;
			}

			x = Mathf.Round(x * factor) / factor;

			return x;
		}

		public static Vector2 ToVector2(this Vector3 vector) => new Vector2(vector.x, vector.y);
		public static Vector3 ToVector3(this Vector2 vector) => new Vector3(vector.x, vector.y, 0f);
		public static Vector3 ToVector3(this Vector2 vector, float z) => new Vector3(vector.x, vector.y, z);

		public static Vector3 RelativeTo(this Vector3 vector, MonoBehaviour monoBehaviour)
		{
			return monoBehaviour.transform.position + vector;
		}
		public static Vector2 RelativeTo(this Vector2 vector, Component component)
		{
			return component.transform.position + vector.ToVector3();
		}

		public static Vector3 Rotate(this Vector3 vector, float angel)
		{
			var q = Quaternion.Euler(0f, 0f, angel);

			var vectorPartOfQ = new Vector3(q.x, q.y, q.z);
			var scalerPartOfQ = q.w;

			var newVector = 2f * Vector3.Dot(vectorPartOfQ, vector) * vectorPartOfQ
							+ ((scalerPartOfQ * scalerPartOfQ) - Vector3.Dot(vectorPartOfQ, vectorPartOfQ)) * vector
							+ 2f * scalerPartOfQ * Vector3.Cross(vectorPartOfQ, vector);

			return newVector;
		}
	}
}


