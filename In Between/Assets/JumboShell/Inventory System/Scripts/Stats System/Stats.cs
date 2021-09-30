using UnityEngine;
using System.Collections.Generic;

[AddComponentMenu("Inventory/Stats")]
public class Stats : MonoBehaviour, ISerializationCallbackReceiver
{
    [NonReorderable]
    public List<Stat> stats;
    
    public void AddStats(Item item)
    {
        for(int i = 0; i < stats.Count; i++)
        {
            for(int k = 0; k < item.stats.Count; k++)
            {
                if (stats[i].Name == item.stats[k].Name)
                {
                    stats[i] = new Stat(stats[i].Name, stats[i].value + item.stats[k].value);
                }
            }
        }
    }

    public void RemoveStats(Item item)
    {
        for (int i = 0; i < stats.Count; i++)
        {
            for (int k = 0; k < item.stats.Count; k++)
            {
                if (stats[i].Name == item.stats[k].Name)
                {
                    stats[i] = new Stat(stats[i].Name, stats[i].value - item.stats[k].value);
                }
            }
        }
    }

    public void OnAfterDeserialize()
    {}

    public void OnBeforeSerialize()
    {
        if (InventorySystem.profileData.Invoke() != null)
        {
            for (int i = 0; i < InventorySystem.profileData.Invoke().statTypes.Count; i++)
            {
                if (i >= stats.Count || (i == 0 && stats.Count == 0))
                {
                    stats.Add(new Stat(InventorySystem.profileData.Invoke().statTypes[i], 0));
                }
                else
                {
                    stats[i] = new Stat(InventorySystem.profileData.Invoke().statTypes[i], stats[i].value);
                }
            }
        }
    }
}


