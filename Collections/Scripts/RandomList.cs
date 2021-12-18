using System.Collections.Generic;
using UnityEngine;

namespace CI.Collections
{
    [System.Serializable]
    public class RandomList<T>
    {
        [SerializeField] private List<T> list = new List<T>();

        public void Add(T item) => list.Add(item);
        public void Remove(T item) => list.Remove(item);

        public T GetRandom()
		{
            var randomIndex = Random.Range(0, list.Count - 1);

            return list[randomIndex];
        }
    }
}
