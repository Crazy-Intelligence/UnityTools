using System.Collections.Generic;
using UnityEngine;

namespace CI.Utilities
{
	[System.Serializable]
	public class WeightedList<T> 
	{
		public List<ObjectWithWeight<T>> List = new List<ObjectWithWeight<T>>();

		public T GetRandom()
		{
			var objects = new List<T>();

			foreach (var obj in List)
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
