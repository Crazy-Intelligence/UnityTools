using UnityEngine;

namespace CI.Audio
{
	[CreateAssetMenu(fileName = "VariatingAudioClip", menuName = "CI/Audio/Variating")]
	public class VariatingAudioClip : ConfiguredAudioClip
	{
		[SerializeField] private AudioClip clip;
		[Space]
		[SerializeField] [Range(0f, 1f)] private float minVolume = 1f;
		[SerializeField] [Range(0f, 1f)] private float maxVolume = 1f;
		[Space]
		[SerializeField] [Range(-3f, 3f)] private float minPitch = 1f;
		[SerializeField] [Range(-3f, 3f)] private float maxPitch = 1f;
		[Space]
		[SerializeField] private bool loop;

		public override void Play(AudioSource source)
		{
			source.clip = clip;
			source.volume = GetRandomVolume();
			source.pitch = GetRandomPitch();
			source.loop = loop;
			source.Play();
		}

		private float GetRandomVolume() => Random.Range(minVolume, maxVolume);
		private float GetRandomPitch() => Random.Range(minPitch, maxPitch);
	}
}
