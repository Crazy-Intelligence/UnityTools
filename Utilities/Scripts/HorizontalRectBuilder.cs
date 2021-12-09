using UnityEngine;
using System.Collections.Generic;

namespace CI.Utilities
{
	public class HorizontalRectBuilder 
	{
		private List<Rect> _rects = new List<Rect>();

		private List<int> _paddingFlag = new List<int>();

		private Rect _source;

		public HorizontalRectBuilder(Rect source)
		{
			_source = source;
		}

		public Rect Add(float width)
		{
			var newRect = new Rect(_source)
			{
				x = GetXAt(_rects.Count),
				width = width
			};

			_rects.Add(newRect);

			return newRect;
		}

		public void AddPadding(float width)
		{
			Add(width);
			_paddingFlag.Add(_rects.Count - 1);
		}

		public Rect GetRectAt(int index)
		{
			for (int i = 0; i < _rects.Count; i++)
			{
				if (_paddingFlag.Contains(i))
				{
					index++;
					continue;
				}

				if (i == index) return _rects[i];
			}

			return Rect.zero;
		}

		private float GetXAt(int index)
		{
			float x = 0f;

			for (int i = 0; i < index; i++)
			{
				x += _rects[i].width;
			}

			return x;
		}
	}
}
