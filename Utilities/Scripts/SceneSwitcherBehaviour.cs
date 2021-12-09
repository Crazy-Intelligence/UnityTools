using UnityEngine;

namespace CI.Utilities
{
	[AddComponentMenu("Snowden/Actions/SceneSwitcher")]
	public class SceneSwitcherBehaviour : MonoBehaviour
	{
		[field: SerializeField] public SerializedScene Scene { get; set; }

		[ContextMenu("Switch Scene")]
		public void SwitchScene() => SceneManager.LoadScene(Scene);
	}
}
