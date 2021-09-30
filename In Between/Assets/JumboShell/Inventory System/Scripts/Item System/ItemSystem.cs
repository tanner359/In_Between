using UnityEngine;
using System.Collections.Generic;

public static class ItemSystem
{
    public delegate GameObject m_BaseItem();
    public static m_BaseItem baseItem = RetrieveBaseItem;


    public delegate ItemDatabase m_ItemDatabase();
    public static m_ItemDatabase itemDatabase = RetrieveItemDatabase;

    public static ItemDatabase RetrieveItemDatabase()
    {
        ItemDatabase data = Resources.Load<InventorySystemSettings>("Data/InventorySystemSettings").itemDatabase;
        if(data != null)
        {
            return data;
        }
        Debug.LogError("An item Database has not been referenced in the Inventory Editor Window");
        return null;
    }
    public static GameObject RetrieveBaseItem()
    {
        GameObject GO = Resources.Load<InventorySystemDefaults>("Data/InventorySystemDefaults").defaultItem;
        if(GO != null)
        {
            return GO;
        }
        Debug.LogError("Default Item in the Inventory Editor Window has not been referenced");
        return null;
    }

    public static int GetItemID(Item item)
    {
        List<Item> items = itemDatabase.Invoke().allItems;
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i] == item)
            {
                return i;
            }
        }
        Debug.LogError("Retrieving item ID failed");
        return -1;
    }
    public static Item GetItem(int ID)
    {
        List<Item> items = itemDatabase.Invoke().allItems;
        Item item = items[ID];

        if(item != null)
        {
            return item;
        }
        Debug.LogError("An item with ID:" + ID + " does not exist");
        return null;
    }

    public static GameObject Spawn(Item item, Vector3 position)
    {         

        GameObject newItem = Object.Instantiate(baseItem.Invoke(), position, Quaternion.identity);       
        ItemProperties props = new ItemProperties(newItem);
        ItemID ID = newItem.GetComponent<ItemID>();

        ID.item = item;
        ID.itemID = GetItemID(item);
        ID.amount = 1;
        newItem.GetComponent<InteractionID>().InteractText = "[E] \n" + item.itemName;
        newItem.name = item.itemName;
        props.transform.position = position;
        props.meshFilter.mesh = item.mesh;
        props.collider.sharedMesh = item.mesh;
        props.meshRend.material = item.material;
        
        ParticleSystem.TrailModule settings = newItem.GetComponentInChildren<ParticleSystem>().trails;
        settings.colorOverTrail = InventorySystem.profileData.Invoke().GetRarityColor(item.Rarity);

        return newItem;
    }
    public static GameObject Spawn(Item item, int amount, Vector3 position)
    {
        if (baseItem.Invoke() != null)
        {
            GameObject newItem = Object.Instantiate(baseItem.Invoke(), position, Quaternion.identity);
            ItemProperties props = new ItemProperties(newItem);
            ItemID ID = newItem.GetComponent<ItemID>();

            ID.item = item;
            ID.itemID = GetItemID(item);
            ID.amount = amount;
            newItem.GetComponent<InteractionID>().InteractText = "[E] \n" + item.itemName + " (" + amount + ")";
            newItem.name = item.itemName;
            props.transform.position = position;
            props.meshFilter.mesh = item.mesh;
            props.collider.sharedMesh = item.mesh;
            props.meshRend.material = item.material;

            ParticleSystem.TrailModule settings = newItem.GetComponentInChildren<ParticleSystem>().trails;
            settings.colorOverTrail = InventorySystem.profileData.Invoke().GetRarityColor(item.Rarity);

            return newItem;
        }
        return null;
    }
    public static void SpawnRandom(Vector3 position)
    {
        if (itemDatabase.Invoke() != null)
        {
            Item item = itemDatabase.Invoke().allItems[Random.Range(0, itemDatabase.Invoke().allItems.Count)];
            if (item == null)
            {
                Debug.Log("No Items Available to Spawn");
                return;
            }
            Spawn(item, position);
        }
    }
    public static Item GetRandomItem()
    {
        if (itemDatabase.Invoke() != null)
        {
            return itemDatabase.Invoke().allItems[Random.Range(0, itemDatabase.Invoke().allItems.Count)];
        }
        return null;
    }
}
