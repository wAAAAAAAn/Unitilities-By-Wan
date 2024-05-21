using UnityEditor;
using UnityEngine;

/*
네이밍 규칙에 따라 텍스쳐를 일괄적으로 세팅하는 에디터 윈도우
small, medium, large로 텍스쳐 해상도에 맞게 세팅합니다.
*/

public class TextureSettingsEditor : EditorWindow
{
    private TextureImporterFormat smallAndroidFormat = TextureImporterFormat.ETC2_RGBA8;
    private TextureImporterFormat smallIosFormat = TextureImporterFormat.ASTC_4x4;
    private int smallMaxSize = 128;

    private TextureImporterFormat mediumAndroidFormat = TextureImporterFormat.ETC2_RGBA8;
    private TextureImporterFormat mediumIosFormat = TextureImporterFormat.ASTC_4x4;
    private int mediumMaxSize = 512;

    private TextureImporterFormat largeAndroidFormat = TextureImporterFormat.ETC2_RGBA8;
    private TextureImporterFormat largeIosFormat = TextureImporterFormat.ASTC_4x4;
    private int largeMaxSize = 2048;

    [MenuItem("Tools/Texture Settings")]
    public static void ShowWindow()
    {
        GetWindow<TextureSettingsEditor>("Texture Settings");
    }

    private void OnGUI()
    {
        GUILayout.Label("Batch Texture Settings", EditorStyles.boldLabel);

        // Small textures settings
        GUILayout.Label("Small Textures", EditorStyles.label);
        smallAndroidFormat = (TextureImporterFormat)EditorGUILayout.EnumPopup("Android Format", smallAndroidFormat);
        smallIosFormat = (TextureImporterFormat)EditorGUILayout.EnumPopup("iOS Format", smallIosFormat);
        smallMaxSize = EditorGUILayout.IntField("Max Size", smallMaxSize);

        // Medium textures settings
        GUILayout.Label("Medium Textures", EditorStyles.label);
        mediumAndroidFormat = (TextureImporterFormat)EditorGUILayout.EnumPopup("Android Format", mediumAndroidFormat);
        mediumIosFormat = (TextureImporterFormat)EditorGUILayout.EnumPopup("iOS Format", mediumIosFormat);
        mediumMaxSize = EditorGUILayout.IntField("Max Size", mediumMaxSize);

        // Large textures settings
        GUILayout.Label("Large Textures", EditorStyles.label);
        largeAndroidFormat = (TextureImporterFormat)EditorGUILayout.EnumPopup("Android Format", largeAndroidFormat);
        largeIosFormat = (TextureImporterFormat)EditorGUILayout.EnumPopup("iOS Format", largeIosFormat);
        largeMaxSize = EditorGUILayout.IntField("Max Size", largeMaxSize);

        if (GUILayout.Button("Apply Settings"))
        {
            ApplyTextureSettings();
        }
    }

    private void ApplyTextureSettings()
    {
        string[] textureGuids = AssetDatabase.FindAssets("t:Texture2D");
        foreach (string guid in textureGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;

            if (textureImporter != null)
            {
                TextureImporterPlatformSettings androidSettings = new TextureImporterPlatformSettings();
                TextureImporterPlatformSettings iosSettings = new TextureImporterPlatformSettings();

                if (path.Contains("small_"))
                {
                    androidSettings.name = "Android";
                    androidSettings.overridden = true;
                    androidSettings.format = smallAndroidFormat;
                    androidSettings.maxTextureSize = smallMaxSize;

                    iosSettings.name = "iPhone";
                    iosSettings.overridden = true;
                    iosSettings.format = smallIosFormat;
                    iosSettings.maxTextureSize = smallMaxSize;
                }
                else if (path.Contains("medium_"))
                {
                    androidSettings.name = "Android";
                    androidSettings.overridden = true;
                    androidSettings.format = mediumAndroidFormat;
                    androidSettings.maxTextureSize = mediumMaxSize;

                    iosSettings.name = "iPhone";
                    iosSettings.overridden = true;
                    iosSettings.format = mediumIosFormat;
                    iosSettings.maxTextureSize = mediumMaxSize;
                }
                else if (path.Contains("large_"))
                {
                    androidSettings.name = "Android";
                    androidSettings.overridden = true;
                    androidSettings.format = largeAndroidFormat;
                    androidSettings.maxTextureSize = largeMaxSize;

                    iosSettings.name = "iPhone";
                    iosSettings.overridden = true;
                    iosSettings.format = largeIosFormat;
                    iosSettings.maxTextureSize = largeMaxSize;
                }
                else
                {
                    // Skip textures that do not match any category
                    continue;
                }

                textureImporter.SetPlatformTextureSettings(androidSettings);
                textureImporter.SetPlatformTextureSettings(iosSettings);

                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            }
        }

        Debug.Log("Texture settings applied to all textures.");
    }
}
