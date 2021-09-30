using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(Stats))]
public class StatsEditor : Editor
{
    SerializedProperty stats;

    ReorderableList list;

    /*
     * This script functions to modify the editor of type(Stats) to display
     * the list of stats as a re-orderable list with no dropdown foldouts.
     * 
     * Credit: Terresquall(Youtube) - "Creating Reorderable Lists in the Unity Inspector" Link: https://www.youtube.com/watch?v=Pba1x7D8pMQ&t=938s
     */

    private void OnEnable()
    {
        GUI.enabled = false;
        stats = serializedObject.FindProperty("stats");

        list = new ReorderableList(serializedObject, stats, true, true, true, true);

        list.drawElementCallback = DrawListItems;
        list.drawHeaderCallback = DrawHeader;
    }

    void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
    {
        SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index); // The element in the list

        EditorGUI.LabelField(new Rect(rect.x + 10, rect.y, 200, EditorGUIUtility.singleLineHeight),element.FindPropertyRelative("Name").stringValue);

        EditorGUI.IntField(new Rect(rect.x + 200, rect.y, 100, EditorGUIUtility.singleLineHeight),element.FindPropertyRelative("value").intValue);
    }

    void DrawHeader(Rect rect)
    {
        EditorGUI.LabelField(rect, "Stats");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update(); // Update the array property's representation in the inspector

        list.DoLayoutList(); // Have the ReorderableList do its work

        // We need to call this so that changes on the Inspector are saved by Unity.
        serializedObject.ApplyModifiedProperties();
    }
}
