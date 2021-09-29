using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEditor;

public class ToolTip : MonoBehaviour
{
    public static ToolTip instance;

    public GameObject EquipPrefab;

    public GameObject NamePrefab;

    public GameObject DescriptionPrefab;

    public GameObject StatPrefab;

    public GameObject LevelPrefab;

    public Transform InfoContainer;

    [HideInInspector] public Item inspectedItem;

    private void Awake()
    {
        if(instance!= null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void UpdateToolTip(Item item)
    {
        inspectedItem = item; // set new inspected item
        foreach(Transform child in InfoContainer)  // clear old tooltip data
        {
            Destroy(child.gameObject);
        }

        GameObject GO;

        GO = Instantiate(EquipPrefab, InfoContainer);
        GO.GetComponentInChildren<Text>().text = item.EquipSlot;

        GO = Instantiate(NamePrefab, InfoContainer);
        GO.GetComponentInChildren<Text>().text = item.itemName;
        GO.GetComponentInChildren<Text>().color = InventorySystem.profileData.Invoke().GetRarityColor(item.Rarity);

        GO = Instantiate(DescriptionPrefab, InfoContainer);
        GO.GetComponentInChildren<Text>().text = '"' + item.description + '"';

        for(int i = 0; i < item.stats.Count; i++)
        {
            if (item.stats[i].value != 0)
            {
                GO = Instantiate(StatPrefab, InfoContainer);
                GO.GetComponentInChildren<Text>().text = "+" + item.stats[i].value.ToString() + " " + item.stats[i].Name;
            }
        }

        GO = Instantiate(LevelPrefab, InfoContainer);
        GO.GetComponentInChildren<Text>().text = "Level Requirement: " + item.levelRequirement;
    }
}
