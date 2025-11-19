using UnityEngine;
using UnityEditor;
using System.IO;

public class PrefabIconSaver : EditorWindow
{
    // Adjustable contrast multiplier (1.0 = normal, >1.0 = higher contrast)
    private const float contrastAmount = 0.75f;

    [MenuItem("Tools/Save Prefab Icons (16x9 + Contrast)")]
    public static void SavePrefabIcons()
    {
        string savePath = "Assets/Cars/CarData/CarIcons/";
        Directory.CreateDirectory(savePath);

        GameObject[] carPrefabs = Selection.gameObjects;

        foreach (var prefab in carPrefabs)
        {
            Texture2D preview = AssetPreview.GetAssetPreview(prefab);
            if (preview != null)
            {
                // Convert to 16:9 centered crop
                Texture2D icon16x9 = ConvertTo16x9Centered(preview);

                // Boost contrast
                ApplyContrast(icon16x9, contrastAmount);

                // Save as PNG
                byte[] png = icon16x9.EncodeToPNG();
                string filePath = Path.Combine(savePath, prefab.name + ".png");
                File.WriteAllBytes(filePath, png);

                Object.DestroyImmediate(icon16x9);
                Debug.Log($"Saved 16:9 icon with contrast: {filePath}");
            }
            else
            {
                Debug.LogWarning("No preview available for " + prefab.name);
            }
        }

        AssetDatabase.Refresh();
    }

    private static Texture2D ConvertTo16x9Centered(Texture2D original)
    {
        int newWidth = original.width;
        int targetHeight = Mathf.RoundToInt(newWidth * 10f / 16f);

        if (targetHeight >= original.height)
        {
            // Pad vertically if original is too small
            Texture2D padded = new Texture2D(newWidth, targetHeight, TextureFormat.RGBA32, false);
            Color[] fill = new Color[newWidth * targetHeight];
            for (int i = 0; i < fill.Length; i++) fill[i] = new Color(0, 0, 0, 0);
            padded.SetPixels(fill);

            int offsetY = (targetHeight - original.height) / 2;
            padded.SetPixels(0, offsetY, original.width, original.height, original.GetPixels());
            padded.Apply();
            return padded;
        }
        else
        {
            // Crop equally from top and bottom
            int startY = (original.height - targetHeight) / 2;
            Texture2D cropped = new Texture2D(newWidth, targetHeight, TextureFormat.RGBA32, false);
            Color[] pixels = original.GetPixels(0, startY, newWidth, targetHeight);
            cropped.SetPixels(pixels);
            cropped.Apply();
            return cropped;
        }
    }

    private static void ApplyContrast(Texture2D tex, float contrast)
    {
        Color[] pixels = tex.GetPixels();
        float midpoint = 0.5f;

        for (int i = 0; i < pixels.Length; i++)
        {
            Color c = pixels[i];
            c.r = Mathf.Clamp01((c.r - midpoint) * contrast + midpoint);
            c.g = Mathf.Clamp01((c.g - midpoint) * contrast + midpoint);
            c.b = Mathf.Clamp01((c.b - midpoint) * contrast + midpoint);
            pixels[i] = c;
        }

        tex.SetPixels(pixels);
        tex.Apply();
    }
}
