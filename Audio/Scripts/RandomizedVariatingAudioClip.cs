using UnityEngine;
using CI.Utilities;

namespace CI.Audio
{
	[CreateAssetMenu(fileName = "VariatingAudioClips", menuName = "TooManyBits/Audio/RandomVariating")]
	public class RandomizedVariatingAudioClip : ConfiguredAudioClip
	{
		[SerializeField] private WeightedList<VariatingAudioClip> clips;

		public override void Play(AudioSource source)
		{
			clips.GetRandom().Play(source);
		}
	}
}
