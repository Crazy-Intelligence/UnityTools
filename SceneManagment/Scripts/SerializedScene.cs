using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
namespace CI.Utilities
{
    [System.Serializable]
    public class SerializedScene
    {
#if UNITY_EDITOR
		[SerializeField] private SceneAsset _sceneAsset;
		public SceneAsset SceneAsset 
		{
			get 
			{
				return _sceneAsset;
			}
			set
			{
				if (value != _sceneAsset)
				{
					_sceneAsset = value;
					SetDirty();
				}
			}
		}

		[SerializeField] private Object _sceneSwitcher;
#endif

		[SerializeField] private string _path;
		public string Path
		{
			get
			{
#if UNITY_EDITOR
				if (_sceneAsset is null) { return _path; }

				string path = GetPathFromAssetPath();
				if (path != _path)
				{
					_path = path;
					SetDirty();
				}
#endif
				return _path;
			}
		}

		[SerializeField] private int _buildIndex;
		public int BuildIndex 
		{ 
			get
			{
#if UNITY_EDITOR
				if (_sceneAsset is null) { return _buildIndex; }

				int buildIndex = GetBuildIndexFromEditorBuildSettings();
				if (buildIndex != _buildIndex)
				{
					_buildIndex = buildIndex;
					SetDirty();
				}
#endif
				return _buildIndex;
			}
		}

		public void SetSceneSwitcher(Object sceneSwitcher)
		{
			if (sceneSwitcher == _sceneSwitcher) { return; }
			_sceneSwitcher = sceneSwitcher;
			SetDirty();
		}

		private void SetDirty() => EditorUtility.SetDirty(_sceneSwitcher);
		
		private string GetPathFromAssetPath()
		{
			string assetPath = AssetDatabase.GetAssetPath(SceneAsset);
			
			if (_path != assetPath) { return assetPath; }

			return _path;
		}
		private int GetBuildIndexFromEditorBuildSettings()
		{
			for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
			{
				EditorBuildSettingsScene sceneInBuild = EditorBuildSettings.scenes[i];

				if (sceneInBuild.path == _path) { return i; }
			}

			return -1;
		}
	}
}
