using System;

namespace CI.Utilities
{
	public class Timer
	{
		public float RemainingSeconds { get; private set; }
		public float ElapsedSeconds { get; private set; }

		public event Action OnTimerEnd;

		private float _duration;
		private bool _loop;

		public Timer(float duration, bool loop) => Initialize(duration, loop);
		public Timer(float duration) => Initialize(duration, false);

		public void Tick(float deltaTime)
		{
			ElapsedSeconds += deltaTime;

			RemainingSeconds -= deltaTime;

			CheckTimerEnd();
		}

		public void Reset(float newDuration)
		{
			_duration = newDuration;

			RemainingSeconds = _duration;
			ElapsedSeconds = 0f;
		}
		public void Reset() => Reset(_duration);

		private void Initialize(float duration, bool loop)
		{
			Reset(duration);
			_loop = loop;
		}

		private void CheckTimerEnd()
		{
			if (RemainingSeconds > 0f) return;

			RemainingSeconds = 0f;

			OnTimerEnd?.Invoke();

			if (_loop) Reset();
		}
	}
}
