using UnityEngine;
using CI.Utilities;

namespace CI.Audio
{
	[CreateAssetMenu(fileName = "SimpleAudioClips", menuName = "TooManyBits/Audio/RandomSimple")]
	public class RandomizedSimpleAudioClip : ConfiguredAudioClip
	{
		[SerializeField] private WeightedList<SimpleAudioClip> clips;

		public override void Play(AudioSource source)
		{
			clips.GetRandom().Play(source);
		}
	}
}
