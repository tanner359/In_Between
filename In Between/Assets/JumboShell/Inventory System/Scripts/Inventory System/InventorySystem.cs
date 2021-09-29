using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class InventorySystem
{
    public delegate InventoryProfile ProfileData();

    public static ProfileData profileData = RetrieveProfileData;

    public static InventoryProfile RetrieveProfileData()
    {
        InventoryProfile profile = Resources.Load<InventorySystemSettings>("Data/InventorySystemSettings").inventoryProfile;
        return profile;
    }

    #region Inventory Functions
    public static void TransferItem(Inventory inventory, Item item, Slot slot, int itemAmount) // transfers item to target slot
    {
        if (slot.slotType == Slot.SlotType.EquipSlot) // check to see if the target slot is an equip slot
        {          
            if (slot.EquipSlot == item.EquipSlot) // check to see if the equipslot matches the item equip slot
            {
                if (inventory.gameObject.TryGetComponent(out EquipmentLink link)) // get equipment link in the inventory
                {
                    link.EquipItem(item); // equip item to linked body parts
                    inventory.sharedPlayer.GetComponent<Stats>().AddStats(item); // add item stats to player stats
                    slot.label.enabled = false;
                }
                else
                {
                    // triggers if you are missing and equipment link on the inventory when trying to equip and item
                    Debug.LogError("Missing Component: <Equipment Link>. Did you add the <Equipment Link> Component to your Inventory");                 
                }
            }
            else
            {
                // triggers when you try to equip an item in a non-matching equip slot
                slot.item = null;
                slot.image.enabled = false;
                return;
            }
        }

        //change all the slot data to show the item transfered
        slot.item = item;
        slot.image.enabled = true;
        slot.image.sprite = item.inventoryIcon; 
        Color rarityColor = profileData.Invoke().GetRarityColor(item.Rarity); // get the color linked with the item rarity
        slot.slotImage.color = new Color(rarityColor.r, rarityColor.g, rarityColor.b, slot.slotImage.color.a); // change slot color to item rarity color

        if (item.isStackable) // check to see if the item we transfer is stackable then set the stack size transfered
        {
            slot.stackSize = itemAmount;
            slot.stackText.text = itemAmount.ToString();
        }
        else // if the item tranfered is not stackable set stack size of slot to 1;
        {
            slot.stackSize = 1;
            slot.stackText.text = "";
        }
    }
    public static Slot GetNextAvailableSlot(Inventory inventory) // find the next available slot in our inventory
    {
        for (int i = 0; i < inventory.inventorySlots.transform.childCount; i++) 
        {
            Slot slot = inventory.inventorySlots.transform.GetChild(i).GetComponent<Slot>();
            if (slot.item == null)
            {
                return slot;
            }
        }
        return null;
    }
    public static InventoryData GetInventoryData(Inventory inventory) // Compiles the current inventory data of the given inventory and returns it as type <InventoryData>
    {
        int numOfEquipSlots = inventory.equipSlots.transform.childCount;
        int numOfInventorySlots = inventory.inventorySlots.transform.childCount;
        int[] itemID = new int[numOfInventorySlots + numOfEquipSlots];
        int[] itemAmount = new int[numOfInventorySlots + numOfEquipSlots];


        for (int i = 0; i < inventory.inventorySlots.transform.childCount; i++)
        {
            Slot slot = inventory.inventorySlots.transform.GetChild(i).GetComponent<Slot>();
            if (slot.item != null)
            {
                itemID[i] = ItemSystem.GetItemID(slot.item);
                itemAmount[i] = slot.stackSize;
            }
            else
            {
                itemID[i] = -1;
                itemAmount[i] = 0;
            }
        }
        for (int k = 0; k < inventory.equipSlots.transform.childCount; k++)
        {
            Slot slot = inventory.equipSlots.transform.GetChild(k).GetComponent<Slot>();
            if (slot.item != null)
            {
                itemID[numOfInventorySlots + k] = ItemSystem.GetItemID(slot.item);
                itemAmount[numOfInventorySlots + k] = slot.stackSize;
            }
            else
            {
                itemID[numOfInventorySlots + k] = -1;
                itemAmount[numOfInventorySlots + k] = 0;
            }
        }

        InventoryData data = new InventoryData(itemID, itemAmount, numOfInventorySlots, numOfEquipSlots);
        return data;
    }
    public static void SwapItems(Inventory inventory, Item item, Slot newSlot, Slot returnSlot, int itemAmount) // swaps the slot positions of items
    {
        Item oldItem = newSlot.item; // get the old item of the new slot

        if(returnSlot.slotType == Slot.SlotType.EquipSlot) // if return slot is an equip slot
        {
            if(oldItem.EquipSlot != item.EquipSlot) // check to see if the old item matches the equip slot it will be put into
            {
                TransferItem(inventory, item, returnSlot, itemAmount); // if it doesn't match return the item to its slot
                return;
            }
        }

        if(newSlot.slotType == Slot.SlotType.EquipSlot) // if our new slot is an equip slot
        {
            if(item.EquipSlot != oldItem.EquipSlot) // check to see if the current item matches the equip slot it will be put into
            {
                TransferItem(inventory, item, returnSlot, itemAmount); // if it doesn't match return it to origin
                return;
            }
        }

        if(returnSlot.item != null) // check to see if the return slot still contains an item
        {
            Slot nextSlot = GetNextAvailableSlot(inventory); // if it does then find another available slot to put the item
            if (nextSlot != null)
            {
                TransferItem(inventory, oldItem, nextSlot, newSlot.stackSize); // if we find an available slot then transfer it to that slot.
            }
            else // if we can't find another available slot and return item to its origin
            {
                if (item.isStackable)
                {
                    AddToStack(returnSlot, itemAmount);
                    return;
                }
                else
                {
                    TransferItem(inventory, item, returnSlot, itemAmount);
                    return;
                }
            }
        }
        else // if return slot doesn't still contain an item
        {
            TransferItem(inventory, oldItem, returnSlot, newSlot.stackSize); // transfer old item to the return slot;
        }      

        if (item.isStackable) // is the item stackable
        {
            newSlot.stackSize = itemAmount;
            newSlot.stackText.text = itemAmount.ToString();
        }
        else // is the item not stackable
        {
            newSlot.stackSize = 0;
            newSlot.stackText.text = "";
        }
        // set new slot data
        newSlot.item = item;
        newSlot.image.enabled = true;
        newSlot.image.sprite = item.inventoryIcon;
        Color itemColor = profileData.Invoke().GetRarityColor(item.Rarity); // get color linked to the rarity
        newSlot.slotImage.color = new Color(itemColor.r, itemColor.g, itemColor.b, newSlot.slotImage.color.a); // set slot color to rarity color
    }
    public static void AddToStack(Slot slot, int amount) // adds a given amount of an item to a target slot
    {
        slot.stackSize += amount;
        slot.stackText.text = slot.stackSize.ToString();
    }
    public static Slot FindSlot(Vector3 position) // raycast from position of the mouse and returns the slot clicked on
    {
        Physics.Raycast(position + Vector3.back * 25, Vector3.forward * 50, out RaycastHit hit); // raycast from position
        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out Slot slot)) // check to see if the collider we hit contains a slot component
        {
            return slot;
        }
        else
        {
            return null;
        }
    }
    public static void DropItem(Inventory inventory, Item item, int amount, Vector3 position) // drops given item at position
    {
        GameObject GO = null;
        if (item.isStackable)
        {
            GO = ItemSystem.Spawn(item, amount, position); // spawn system spawns item
        }
        else
        {
            GO = ItemSystem.Spawn(item, position); // spawn system spawns item
        }
        GO.GetComponent<Rigidbody>().AddForce(inventory.sharedPlayer.transform.forward * 5, ForceMode.Impulse); // apply a small force to the item to simulate a throw
    }
    public static void EmptySlot(Inventory inventory, Slot slot) // empty a slot of all of its contents and un-equips any item in a equip slot
    {
        // reset all slot info
        slot.stackSize = 0;
        slot.stackText.text = "";
        slot.image.sprite = null;
        slot.image.enabled = false;
        slot.slotImage.color = new Color(1,1,1, slot.slotImage.color.a);

        if (slot.slotType == Slot.SlotType.EquipSlot) // check to see if slot is an equip slot
        {
            slot.label.enabled = true;
            slot.label.color = Color.white;
            slot.slotImage.color = new Color(1,1,1, slot.slotImage.color.a);

            if (inventory.gameObject.TryGetComponent(out EquipmentLink link)) // get the equipment link on the inventory
            {
                link.UnEquipItem(slot.item); // un-equip item from equipment link
                inventory.sharedPlayer.GetComponent<Stats>().RemoveStats(slot.item); // remove item stats from player stats
            }
            else
            {
                Debug.LogError("Missing Component: <Equipment Link>"); // you are missing an equipment link on the referenced inventory
            }
        }
        slot.item = null; // finally remove the slot item
    }
    #endregion

    #region Inventory Saving
    /*
     * Credit: Brackeys(Youtube) - "SAVE & LOAD SYSTEM in Unity" Link: https://www.youtube.com/watch?v=XOjd_qU2Ido&t=625s
     */
    public static void SaveInventory(InventoryData data) // save inventory data
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/inventory.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static InventoryData LoadInventory() // load inventory data
    {
        string path = Application.persistentDataPath + "/inventory.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            InventoryData data = formatter.Deserialize(stream) as InventoryData;
            stream.Close();

            return data;
        }
        else
        {          
            return null;
        }
    }
    public static void DeleteInventorySave() // delete inventory data
    {
        string path = Application.persistentDataPath + "/inventory.data";
        File.Delete(path);
    }
    #endregion
}
