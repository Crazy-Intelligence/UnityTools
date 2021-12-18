using System.Collections.Generic;
using UnityEngine;

namespace CI.Collections
{
	[System.Serializable]
	public class WeightedList<T>
	{
		[SerializeField] private List<ObjectWithWeight<T>> list = new List<ObjectWithWeight<T>>();

		public T GetRandom()
		{
			var objects = new List<T>();

			foreach (var obj in list)
			{
				for (int i = 0; i < obj.Weight; i++)
				{
					objects.Add(obj.Object);
				}
			}

			var randomIndex = Random.Range(0, objects.Count - 1);

			return objects[randomIndex];
		}
	}
}
