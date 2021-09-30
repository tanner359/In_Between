using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;



[CreateAssetMenu(fileName = "New Item", menuName = "Item System/Create Item")]
public class Item : ScriptableObject, ISerializationCallbackReceiver
{
    [Space(10)]
    [Header("Item Info")]
    public string itemName;
    [Multiline]
    public string description;
    public int levelRequirement;
    [Space(10)]

    public static List<string> raritiesTemp;
    public static List<string> rarities;
    [ListToPopup(typeof(Item), "raritiesTemp")]
    public string Rarity;

    public static List<string> equipSlotsTemp;
    public static List<string> equipSlots;
    [ListToPopup(typeof(Item), "equipSlotsTemp")]
    public string EquipSlot;

    public static List<string> itemTypesTemp;
    public static List<string> itemTypes;
    [ListToPopup(typeof(Item), "itemTypesTemp")]
    public string ItemType;

    [Space(10)]
    public Mesh mesh;
    public Material material;
    public Sprite inventoryIcon;

    [Space(10)]
    [Header("Item Stacking")]
    public bool isStackable;
    public int stackLimit;

    [Space(10)]   
    [Header("Item Stats")]

    
    public List<Stat> stats = new List<Stat>();
    

    public void OnBeforeSerialize()
    {
        if (InventorySystem.profileData.Invoke() != null)
        {     
            rarities = InventorySystem.profileData.Invoke().GetRarityNames();
            raritiesTemp = rarities;

            equipSlots = InventorySystem.profileData.Invoke().equipSlots;
            equipSlotsTemp = equipSlots;

            itemTypes = InventorySystem.profileData.Invoke().itemTypes;
            itemTypesTemp = itemTypes;
        }
        else
        {
            rarities = new List<string> { "<None>" };
            raritiesTemp = rarities;

            equipSlots = new List<string> { "<None>" };
            equipSlotsTemp = equipSlots;

            itemTypes = new List<string> { "<None>" };
            itemTypesTemp = itemTypes;
        }
    }

    public void OnAfterDeserialize() {}
}
