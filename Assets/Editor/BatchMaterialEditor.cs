using UnityEditor;
using UnityEngine;

public class BatchMaterialEditor : Editor
{
    [MenuItem("Tools/Batch Update Material Settings")]
    static void UpdateMaterialSettings()
    {
        // Get selected FBX models
        Object[] selectedObjects = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        foreach (Object obj in selectedObjects)
        {
            string assetPath = AssetDatabase.GetAssetPath(obj);

            // Check if the asset is a Model (FBX)
            ModelImporter modelImporter = AssetImporter.GetAtPath(assetPath) as ModelImporter;

            if (modelImporter != null)
            {
                // Set material location to External
                modelImporter.materialLocation = ModelImporterMaterialLocation.External;

                // Optionally, adjust the material search settings
                modelImporter.materialSearch = ModelImporterMaterialSearch.RecursiveUp;

                // Save changes
                modelImporter.SaveAndReimport();
            }
        }

        Debug.Log("Batch material update completed for selected models.");
    }
}
