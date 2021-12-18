using UnityEngine;
using CI.Collections;

namespace CI.Audio
{
	[CreateAssetMenu(fileName = "VariatingAudioClips", menuName = "CI/Audio/RandomVariating")]
	public class RandomizedVariatingAudioClip : ConfiguredAudioClip
	{
		[SerializeField] private WeightedList<VariatingAudioClip> clips;

		public override void Play(AudioSource source)
		{
			clips.GetRandom().Play(source);
		}
	}
}
