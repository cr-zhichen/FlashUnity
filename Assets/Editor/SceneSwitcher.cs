using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SceneSwitcherWindow : EditorWindow
{
    private Dictionary<string, string> scenesInBuild;
    private bool closeWindowAfterSwitch = true;
    private Vector2 scrollPosition;

    [MenuItem("Tools/场景切换器 &q")]
    private static void ShowWindow()
    {
        GetWindow<SceneSwitcherWindow>("场景切换器");
    }

    private void OnEnable()
    {
        RefreshSceneList();
    }

    private void RefreshSceneList()
    {
        scenesInBuild = new Dictionary<string, string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                string sceneName = Path.GetFileNameWithoutExtension(scene.path);
                scenesInBuild[sceneName] = scene.path;
            }
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("选择一个场景进行切换:", EditorStyles.boldLabel);

        closeWindowAfterSwitch = EditorGUILayout.Toggle("切换后关闭窗口", closeWindowAfterSwitch);

        if (GUILayout.Button("刷新"))
        {
            RefreshSceneList();
        }

        GUILayout.BeginVertical("box");
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(150));
        foreach (var scene in scenesInBuild)
        {
            if (GUILayout.Button(scene.Key))
            {
                SwitchScene(scene.Value);
            }
        }

        GUILayout.EndScrollView();
        GUILayout.EndVertical();
    }

    private void SwitchScene(string scenePath)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(scenePath);
            if (closeWindowAfterSwitch)
            {
                Close();
            }
        }
    }
}