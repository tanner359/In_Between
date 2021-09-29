using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryEditor : Editor
{
    [MenuItem("GameObject/Inventory/Default Inventory", false, 10)]
    static void CreateInventory(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject go = Instantiate(Resources.Load<InventorySystemDefaults>("Data/InventorySystemDefaults").defaultInventory);
        go.name = "Inventory";
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }

    [MenuItem("GameObject/Inventory/Slot", false, 10)]
    static void CreateSlot(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject go = Instantiate(Resources.Load<InventorySystemDefaults>("Data/InventorySystemDefaults").defaultSlot);
        go.name = "Slot";
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }

    [MenuItem("GameObject/Inventory/Tooltip", false, 10)]
    static void CreateTooltip(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject go = Instantiate(Resources.Load<InventorySystemDefaults>("Data/InventorySystemDefaults").defaultToolTip);
        go.name = "Tooltip";
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }

    [MenuItem("GameObject/Inventory/Item Icon", false, 10)]
    static void CreateIcon(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject go = Instantiate(Resources.Load<InventorySystemDefaults>("Data/InventorySystemDefaults").defaultIcon);
        go.name = "Item Icon";
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }

    [MenuItem("GameObject/Inventory/Interact Text", false, 10)]
    static void CreateInteractText(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject go = Instantiate(Resources.Load<InventorySystemDefaults>("Data/InventorySystemDefaults").defaultInteractText);
        go.name = "Interact Text";
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }

}
