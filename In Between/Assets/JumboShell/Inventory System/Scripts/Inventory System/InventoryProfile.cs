using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "New Inventory Profile", menuName = "Inventory/Inventory Profile")]
public class InventoryProfile : ScriptableObject
{
    public List<Rarity> rarities = new List<Rarity>();
    public List<string> statTypes = new List<string>(); 
    public List<string> equipSlots = new List<string>();
    public List<string> itemTypes = new List<string>();
    public List<string> GetRarityNames()
    {
        List<string> names = new List<string>();
        for (int i = 0; i < rarities.Count; i++)
        {
            names.Add(rarities[i].name);
        }
        return names;
    }

    public Color GetRarityColor(string rarityName)
    {
        for(int i = 0; i < rarities.Count; i++)
        {
            if(rarities[i].name == rarityName)
            {
                return rarities[i].color;
            }
        }
        return Color.white;
    }
}

[System.Serializable]
public struct Rarity
{   
    public string name;
    public Color color;
}

[System.Serializable]
public struct Stat : ISerializationCallbackReceiver
{
    public static List<string> namesTemp;
    public static List<string> names;
    [ListToPopup(typeof(Stat), "namesTemp")]
    public string Name;
    public int value;

    public Stat(string name, int value)
    {
        this.Name = name;
        this.value = value;
    }

    public void OnBeforeSerialize()
    {
        if (InventorySystem.profileData.Invoke() != null)
        {
            names = InventorySystem.profileData.Invoke().statTypes;
            namesTemp = names;
        }
        else
        {
            names = new List<string> { "<None>" };
            namesTemp = names;
        }
    }
    public void OnAfterDeserialize()
    { }  
}
