using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace CI.Utilities
{
	public class SceneManager
	{
		public static void LoadScene(SerializedScene scene)
		{
#if UNITY_EDITOR
			if (UnityEditor.EditorApplication.isPlaying == false)
			{
				Debug.LogWarning("Activate Playmode first.");
				return;
			}
			Debug.Log("Scene switched");
#endif
			UnitySceneManager.LoadScene(scene.BuildIndex);
		}
	}
}
