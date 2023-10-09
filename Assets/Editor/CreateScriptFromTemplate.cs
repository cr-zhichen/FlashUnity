using UnityEditor;
using UnityEngine;
using System.IO;
using System;
using System.Text.RegularExpressions;

/// <summary>
/// 格式化脚本模板创建窗口
/// </summary>
public class CreateScriptFromTemplate : EditorWindow
{
    private const string templatePath = "Assets/ScriptTemplates/81-C# Script-NewBehaviourScript.cs.txt";
    private const string authorKey = "CreateScriptFromTemplate.author";
    private string scriptName = "";
    private string author = "";
    private string description = "";
    private string function = "";
    private string errorMessage = "";

    [MenuItem("Assets/Create/新建项目脚本", false, 80)]
    public static void ShowWindow()
    {
        var window = GetWindow<CreateScriptFromTemplate>("新建项目脚本", true);
        window.author = EditorPrefs.GetString(authorKey, "");
        window.minSize = new Vector2(250, 250);
    }

    public void OnGUI()
    {
        GUILayout.Label("创建新的脚本", EditorStyles.boldLabel);
        scriptName = EditorGUILayout.TextField("脚本名称：", scriptName);
        author = EditorGUILayout.TextField("作者：", author);
        function = EditorGUILayout.TextField("功能：", function);
        GUI.skin.textField.wordWrap = true;
        var e = Event.current;
        if (e.type == EventType.KeyDown && e.character == '\n')
            e.Use();
        description = EditorGUILayout.TextArea(description, GUILayout.Height(75)).Replace("\n", "").Replace("\r", "");
        GUI.skin.textField.wordWrap = false;

        if (!string.IsNullOrEmpty(errorMessage))
        {
            EditorGUILayout.HelpBox(errorMessage, MessageType.Error);
        }

        if (GUILayout.Button("创建"))
        {
            if (string.IsNullOrEmpty(scriptName) ||
                string.IsNullOrEmpty(author) ||
                string.IsNullOrEmpty(description) ||
                string.IsNullOrEmpty(function))
            {
                errorMessage = "所有字段都必须填写！";
            }
            else if (!Regex.IsMatch(scriptName, @"^[A-Z][a-zA-Z]*$"))
            {
                errorMessage = "脚本名称必须为英文且符合大驼峰命名规则！";
            }
            else
            {
                string newScriptPath = CreateScriptFromName(scriptName, author, description, function);
                EditorPrefs.SetString(authorKey, author);
                if (!string.IsNullOrEmpty(newScriptPath))
                {
                    var scriptAsset = AssetDatabase.LoadAssetAtPath<MonoScript>(newScriptPath);
                    AssetDatabase.OpenAsset(scriptAsset);
                }

                this.Close();
            }
        }
    }

    private string CreateScriptFromName(string scriptName, string author, string description, string function)
    {
        if (!File.Exists(templatePath))
        {
            Debug.LogError("模板文件不存在: " + templatePath);
            return null;
        }

        string templateText = File.ReadAllText(templatePath);
        templateText = templateText.Replace("#SCRIPTNAME#", scriptName);
        templateText = templateText.Replace("#AUTHOR#", author);
        templateText = templateText.Replace("#DESCRIPTION#", description);
        templateText = templateText.Replace("#FUNCTION#", function);
        templateText = templateText.Replace("#CREATETIME#", DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"));

        string selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (!Directory.Exists(selectedPath))
        {
            selectedPath = Path.GetDirectoryName(selectedPath);
        }

        string newScriptPath = Path.Combine(selectedPath, $"{scriptName}.cs");
        newScriptPath = AssetDatabase.GenerateUniqueAssetPath(newScriptPath);

        File.WriteAllText(newScriptPath, templateText);
        AssetDatabase.Refresh();
        return newScriptPath;
    }
}