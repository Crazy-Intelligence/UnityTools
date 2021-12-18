using System.Collections.Generic;
using UnityEngine;

namespace CI.Collections
{
    [System.Serializable]
    public class RandomList<T>
    {
        public List<T> List = new List<T>();

        public void Add(T item) => List.Add(item);
        public void Remove(T item) => List.Remove(item);

        public T GetRandom()
		{
            var randomIndex = Random.Range(0, List.Count - 1);

            return List[randomIndex];
        }
    }
}
