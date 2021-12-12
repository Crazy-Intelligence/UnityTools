using UnityEngine;
using UnityEditor;
using CI.EditorExtensions;

namespace CI.Utilities
{
    [CustomEditor(typeof(SceneSwitcherBehaviour))]
    public class SceneSwitcherEditor : Editor
    {
		private SceneSwitcherBehaviour _sceneSwitcher;

		private SerializedScene _scene;

		private bool _showSceneDebug;

		public override void OnInspectorGUI()
		{
			_sceneSwitcher = (SceneSwitcherBehaviour)target;
			_scene = _sceneSwitcher.Scene;
			_scene.SetSceneSwitcher(_sceneSwitcher);

			_scene.SceneAsset = DrawObjectField("Scene: ", _scene.SceneAsset);

			_showSceneDebug = EditorGUILayout.Foldout(_showSceneDebug, "Debug", true);
			DrawSceneDebugInfo(_scene);

			if (_scene.SceneAsset is null) { return; }
			
			ErrorCheckAndFeedback(_scene);

			Repaint();
		}

		private void DrawSceneDebugInfo(SerializedScene scene)
		{
			EditorGUI.BeginDisabledGroup(true);

			if (_showSceneDebug)
			{
				EditorGUILayout.Space();
				DrawObjectField("SceneAsset: ", _scene.SceneAsset);
				DrawObjectField("Scene Switcher: ", _sceneSwitcher);
				EditorGUILayout.TextField("Path:", scene.Path.TrimStart("Assets/".ToCharArray()));
				EditorGUILayout.IntField("BuildIndex", scene.BuildIndex);
			}

			EditorGUI.EndDisabledGroup();
			EditorGUILayout.Space();
		}

		private void ErrorCheckAndFeedback(SerializedScene scene)
		{
			if (scene.BuildIndex == -1)
			{
				EditorGUILayout.LabelField("Scene is not included in Build!", EditorTools.ColorStyle(new Color(0.75f, 0.15f, 0.15f)));

				if (GUILayout.Button("Add Scene To Build"))
				{
					EditorSceneManager.AddSceneToBuild(scene);
				}

				return;
			}

			if (EditorSceneManager.IsEnabledInBuild(scene) == false)
			{
				EditorGUILayout.LabelField("Scene is not enabled in Build!", EditorTools.ColorStyle(Color.yellow));

				if (GUILayout.Button("Enable Scene In Build"))
				{
					EditorSceneManager.EnableSceneInBuild(scene);
				}
			}

			if (EditorSceneManager.IsDevScene(scene.Path))
			{
				EditorGUILayout.LabelField("Scene is a Development Scene! Only use this for Testing and change it Later.", EditorTools.ColorStyle(Color.blue));
			}
		}
		
		private TObject DrawObjectField<TObject>(string label, TObject tObject) where TObject : Object
		{
			return (TObject)EditorGUILayout.ObjectField(label, tObject, typeof(TObject), true);
		}
	}
}
