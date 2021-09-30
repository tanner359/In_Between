using UnityEngine;
using UnityEditor;

[System.Serializable]
public class InventoryEditorWindow : EditorWindow
{
    private static InventorySystemSettings data;

    [InitializeOnLoadMethod]
    private static void OnLoad()
    {
        // if no data exists yet create and reference a new instance
        if (!data)
        {
            // as first option check if maybe there is an instance already
            // and only the reference got lost
            // won't work ofcourse if you moved it elsewhere ...
            data = AssetDatabase.LoadAssetAtPath<InventorySystemSettings>("Assets/JumboShell/Inventory System/Resources/Data/InventorySystemSettings.asset");
            
            // if that was successful we are done
            if (data) return;

            // otherwise create and reference a new instance
            data = CreateInstance<InventorySystemSettings>();

            AssetDatabase.CreateAsset(data, "Assets/JumboShell/Inventory System/Resources/Data/InventorySystemSettings.asset");
            AssetDatabase.Refresh();
        }
    }

    // Add menu named "My Window" to the Window menu
    [MenuItem("Inventory/Inventory Settings")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        InventoryEditorWindow window = (InventoryEditorWindow)GetWindow(typeof(InventoryEditorWindow));
        window.titleContent.text = "Inventory System";
        window.Show();
    }

    void OnGUI()
    {       
        GUILayout.Label("Inventory Settings", EditorStyles.boldLabel);

        if (data)
        {
            var InventorySystemData = new SerializedObject(data);
            InventorySystemData.Update();

            var IP = InventorySystemData.FindProperty("inventoryProfile");
            var ID = InventorySystemData.FindProperty("itemDatabase");
            var autoSave = InventorySystemData.FindProperty("autoSave");

            IP.objectReferenceValue = (InventoryProfile)EditorGUILayout.ObjectField("Inventory Profile", IP.objectReferenceValue, typeof(InventoryProfile), true);
            ID.objectReferenceValue = (ItemDatabase)EditorGUILayout.ObjectField("Item Database", ID.objectReferenceValue, typeof(ItemDatabase), true);

            autoSave.boolValue = EditorGUILayout.Toggle("Auto-Saving", autoSave.boolValue);

            if(GUILayout.Button("Clear Save Data"))
            {
                InventorySystem.DeleteInventorySave();
            }
          
            InventorySystemData.ApplyModifiedProperties();
        }
    }
}
