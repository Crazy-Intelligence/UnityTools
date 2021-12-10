using UnityEngine;

namespace CI.Audio
{
	public abstract class ConfiguredAudioClip : ScriptableObject
	{
		public abstract void Play(AudioSource source);
	}
}
