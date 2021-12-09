using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

namespace CI.Utilities
{
    public class EditorSceneManager
    {
		[MenuItem("Tools/Snowden/Scenes/Add all Scenes to Build")]
		public static void AddAllScenesToBuild()
		{
			List<string> scenePathsInAssets = ConvertGUIDsToPaths(new List<string>(AssetDatabase.FindAssets("t: Scene")));
			List<string> scenePathsInBuild = ConvertEditorScenesToPaths(GetEditorScenesInBuild());
			var scenesInBuild = GetEditorScenesInBuild();
			
			foreach (var scene in scenePathsInAssets)
			{
				if (scenePathsInBuild.Contains(scene) == false)
				{
					scenesInBuild.Add(new EditorBuildSettingsScene(scene, true));
				}
			}

			EditorBuildSettings.scenes = scenesInBuild.ToArray();

			Debug.LogWarning("All Scenes are now included in Build");
		}
		[MenuItem("Tools/Snowden/Scenes/Enable all Scenes in Build")]
		public static void EnableAllScenesInBuild()
		{
			var scenesInBuild = EditorBuildSettings.scenes;
			foreach (var sceneInBuild in scenesInBuild)
			{
				sceneInBuild.enabled = true;
			}
			EditorBuildSettings.scenes = scenesInBuild;

			Debug.LogWarning("Every Scene in Build was enabled");
		}
		[MenuItem("Tools/Snowden/Scenes/Disable DEV Scenes in Build")]
		public static void DisableDevScenesInBuild()
		{
			var scenesInBuild = EditorBuildSettings.scenes;
			foreach (var sceneInBuild in scenesInBuild)
			{
				if (IsDevScene(sceneInBuild.path))
				{
					sceneInBuild.enabled = false;
				}
			}
			EditorBuildSettings.scenes = scenesInBuild;

			Debug.Log("DEV Scenes were disabled in Build");
		}

		public static void AddSceneToBuild(SerializedScene scene)
		{
			var scenesInBuild = GetEditorScenesInBuild();
			scenesInBuild.Add(new EditorBuildSettingsScene(scene.Path, true));
			EditorBuildSettings.scenes = scenesInBuild.ToArray();

			Debug.Log($"{GetSceneName(scene.Path)} added to Build");
		}
		public static void EnableSceneInBuild(SerializedScene scene)
		{
			var scenesInBuild = EditorBuildSettings.scenes;
			foreach (var sceneInBuild in scenesInBuild)
			{
				if (sceneInBuild.path == scene.Path)
				{
					sceneInBuild.enabled = true;
				}
			}
			EditorBuildSettings.scenes = scenesInBuild;

			Debug.Log($"{GetSceneName(scene.Path)} enabled in Build");
		}

		public static bool IsEnabledInBuild(SerializedScene scene)
		{
			var sceneInBuild = GetBuildSettingsScene(scene);
			if (sceneInBuild != null)
			{
				return sceneInBuild.enabled;
			}
			return false;
		}
		public static bool IsDevScene(string path)
		{
			string name = GetSceneName(path);

			if (name.Length <= 3) { return false; }

			name = name.Remove(3);
			if (name == "DEV")
			{
				return true;
			}
			return false;
		}
		
		public static EditorBuildSettingsScene GetBuildSettingsScene(SerializedScene scene)
		{
			for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
			{
				EditorBuildSettingsScene sceneInBuild = EditorBuildSettings.scenes[i];

				if (sceneInBuild.path == scene.Path)
				{ return sceneInBuild; }
			}

			return null;
		}
		
		private static List<EditorBuildSettingsScene> GetEditorScenesInBuild()
		{
			return new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);
		}
		
		private static List<string> ConvertGUIDsToPaths(List<string> guids)
		{
			List<string> paths = new List<string>();
			foreach (var guid in guids)
			{
				paths.Add(AssetDatabase.GUIDToAssetPath(guid));
			}
			return paths;
		}
		private static List<string> ConvertEditorScenesToPaths(List<EditorBuildSettingsScene> scenes)
		{
			List<string> paths = new List<string>();
			foreach (var scene in scenes)
			{
				paths.Add(scene.path);
			}
			return paths;
		}
		
		private static string GetSceneName(string scenePath)
		{
			string[] path = scenePath.Split('/');
			string name = path[path.Length - 1];

			name = name.Remove(name.Length - 6);

			return name;
		}
	}
}
