using UnityEngine;
using UnityEditor;

public class EnableReadWriteOnModels : Editor
{
    [MenuItem("Tools/Enable Read/Write on Selected Models")]
    static void EnableReadWrite()
    {
        // Get all selected assets in the Project window
        var selectedObjects = Selection.objects;

        // Loop through each selected object
        foreach (Object obj in selectedObjects)
        {
            // Get the path of the asset
            string assetPath = AssetDatabase.GetAssetPath(obj);

            // Try to load the asset as a model
            ModelImporter modelImporter = AssetImporter.GetAtPath(assetPath) as ModelImporter;

            // If the asset is a model
            if (modelImporter != null)
            {
                // Enable Read/Write flag
                modelImporter.isReadable = true;

                // Apply the changes
                AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
                Debug.Log("Enabled Read/Write for: " + assetPath);
            }
        }
    }
}
