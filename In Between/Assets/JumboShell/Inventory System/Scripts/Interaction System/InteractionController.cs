using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[AddComponentMenu("Interactions/InteractionController")]
public class InteractionController : MonoBehaviour
{
    Inventory_Inputs inputs;

    #region REFERENCES
    public Inventory inventory;
    #endregion

    #region INTERACTIONS
    private GameObject closestItem;
    [Header("Interaction Settings")]
    public int interactionRange;
    public bool showRange = false;
    #endregion
    
    public GameObject interactText;

    private void OnEnable()
    {
        if (inputs == null)
        {
            inputs = new Inventory_Inputs();
        }
        inputs.Interaction.Interact.performed += Interact;
        inputs.Interaction.Enable();
    }

    private void Update()
    {
        ScanInteractArea();
    }

    #region Inputs
    public void Interact(InputAction.CallbackContext context) // if user clicks pickup button
    {
        if (closestItem != null) // do we have an item to interact with
        {
            InteractionID id = closestItem.GetComponent<InteractionID>(); // get the interaction ID

            if (id.interactType == InteractionID.InteractType.stationary) //check the interaction type to prevent pickup of static objects Ex.(door or light switch)
            {
                id.GetComponent<Interact>().TriggerEvent(); // trigger the event on the item
                return;
            }
            else // if interact type is a pickup
            {
                Item item = closestItem.GetComponent<ItemID>().item; // get <ItemID> data from the game object
                int amount = closestItem.GetComponent<ItemID>().amount;
                Slot NextAvailableSlot = InventorySystem.GetNextAvailableSlot(inventory);

                if (item.isStackable) // check to see if the item is stackable
                {
                    for (int i = 0; i < inventory.inventorySlots.transform.childCount; i++) // go through inventory slots
                    {
                        Slot slot = inventory.inventorySlots.transform.GetChild(i).GetComponent<Slot>();
                        if (slot.item == item && slot.stackSize < slot.item.stackLimit) // check to see if we have another item to stack with
                        {
                            InventorySystem.AddToStack(slot, amount); // add item to existing stack
                            Destroy(closestItem);
                            inventory.SaveInventory();
                            return;
                        }
                    }
                    for (int i = 0; i < inventory.equipSlots.transform.childCount; i++) // go through equip slots
                    {
                        Slot slot = inventory.equipSlots.transform.GetChild(i).GetComponent<Slot>();
                        if (slot.item == item && slot.stackSize < slot.item.stackLimit) // check to see if we have another item to stack with
                        {
                            InventorySystem.AddToStack(slot, amount); // add item to existing stack
                            Destroy(closestItem);
                            inventory.SaveInventory();
                            return;
                        }
                    }
                    if (NextAvailableSlot != null) // if we find an available slot and there is no existing stack of the item
                    {
                        InventorySystem.TransferItem(inventory, item, NextAvailableSlot, amount); // transfer that item to that slot
                        //InventorySystem.AddToStack(NextAvailableSlot, 1); // this will create a new stack of the item
                        Destroy(closestItem);
                        inventory.SaveInventory();
                        return;
                    }                    
                }
                else if (NextAvailableSlot != null) // if item is not stackable
                {
                    InventorySystem.TransferItem(inventory, item, NextAvailableSlot, amount); // transfer item to next available slot
                    Destroy(closestItem);
                    inventory.SaveInventory();
                }
            }
        }
    }
    #endregion

    #region Functions
    public void ScanInteractArea() // searching for items to interact with
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, interactionRange);
        if (objects.Length > 0)
        {
            List<GameObject> interactables = new List<GameObject>(); // objects that the system found that have ID's

            for (int i = 0; i < objects.Length; i++) //filter out the objects that contain an interaction ID
            {
                if (objects[i].GetComponent<InteractionID>()) // does it have ID
                {
                    interactables.Add(objects[i].gameObject); // if it does add to list of interactable items
                }
            }
            if (interactables.Count > 0) // if the system found any interactable items
            {
                closestItem = GetClosestItem(transform.position, interactables); // find the closest item to the player
                InteractionID id = closestItem.GetComponent<InteractionID>(); //get the ID
                DisplayInteractText(id.textPosition, id.InteractText); //display the interaction prompt on that item
            }
            else { HideText(); } // if the system found no interactable items disable text
        }
    }
    public GameObject GetClosestItem(Vector3 playerPos, List<GameObject> items) // iterates through our interactable items that we found in ScanInteractArea() and returns the closest one
    {
        GameObject closestItem = items[0].gameObject;
        float minDistance = Vector3.Distance(playerPos, items[0].transform.position);
        for (int i = 0; i < items.Count; i++)
        {
            if (minDistance > Vector3.Distance(playerPos, items[i].transform.position))
            {
                minDistance = Vector3.Distance(playerPos, items[i].transform.position);
                closestItem = items[i];
            }
        }
        return closestItem;
    }

    #region UI Functions
    public void DisplayInteractText(Vector3 textPos, string text)
    {
        interactText.SetActive(true);
        interactText.GetComponent<TMPro.TextMeshPro>().text = "[" + inputs.Interaction.Interact.GetBindingDisplayString() + "]" + text;
        interactText.transform.position = textPos;
    }
    public void HideText()
    {
        interactText.SetActive(false);
    }
    #endregion
    #endregion

    #region Gizmos
    private void OnDrawGizmos()
    {
        //displays the interact radius
        if (showRange)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, interactionRange);
        }
    }
    #endregion
}
