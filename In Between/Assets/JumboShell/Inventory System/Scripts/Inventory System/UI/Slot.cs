using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

[AddComponentMenu("Inventory/Slot")]
public class Slot : MonoBehaviour, ISerializationCallbackReceiver
{
    public enum SlotType { InventorySlot, EquipSlot }

    public SlotType slotType;
    public static List<string> equipSlotsTemp;
    public static List<string> equipSlots;
    [ListToPopup(typeof(Slot), "equipSlotsTemp")]
    public string EquipSlot;

    [Header("Slotted Item")]
    public Item item;
    public int stackSize;

    [Header("References")]
    public Image image;
    public RawImage slotImage;
    public TMP_Text label;
    public TMP_Text stackText;

    public void OnBeforeSerialize()
    {
        if (InventorySystem.profileData.Invoke() != null)
        {
            equipSlots = InventorySystem.profileData.Invoke().equipSlots;
            equipSlotsTemp = equipSlots;
        }
        else
        {
            equipSlots = new List<string> { "<None>" };
            equipSlotsTemp = equipSlots;
        }
    }

    public void OnAfterDeserialize()
    {}
}
