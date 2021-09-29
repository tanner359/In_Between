using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

[AddComponentMenu("Inventory/Inventory")]
public class Inventory : MonoBehaviour
{
    #region VARIABLES AND REFERENCES

    public GameObject sharedPlayer;

    #region INPUTS
    Inventory_Inputs inputs;
    Vector2 mousePosition;
    #endregion

    #region INVENTORY
    [Header("Inventory References")]
    public Transform inventory;
    public GameObject inventorySlots;
    public GameObject equipSlots;
    public GameObject tooltip;
    public GameObject icon;

    [HideInInspector] public bool isOpen;  
    private Item itemHolding;
    private int numItemHolding;
    private Slot returnSlot;
    #endregion

    #endregion
    private void OnEnable()
    {
        if (Resources.Load<InventorySystemSettings>("Data/InventorySystemSettings").autoSave)
        {
            LoadInventory();
        }
        isOpen = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        if (inputs == null)
        {
            inputs = new Inventory_Inputs();
        }
        
        inputs.Inventory.Enable();
    }
    private void Start()
    {       
        inputs.Inventory.LeftClick.performed += LeftClick;
        inputs.Inventory.RightClick.performed += RightClick;
        inputs.Inventory.Split.performed += SplitStack;
        inputs.Inventory.MousePosition.performed += MouseActions;
    }

    #region SAVE & LOAD
    public void LoadInventory()
    {
        InventoryData data = InventorySystem.LoadInventory();
        if (data == null) { return; }

        for(int i = 0; i < data.numOfInventorySlots; i++)
        {
            if(data.itemAmount[i] != 0)
            {
                InventorySystem.TransferItem(this, ItemSystem.GetItem(data.itemID[i]), 
                    inventorySlots.transform.GetChild(i).GetComponent<Slot>(), data.itemAmount[i]);
            }
        }
        for (int k = 0; k < data.numOfEquipSlots; k++)
        {
            if (data.itemAmount[data.numOfInventorySlots + k] != 0)
            {
                InventorySystem.TransferItem(this, ItemSystem.GetItem(data.itemID[data.numOfInventorySlots + k]), 
                    equipSlots.transform.GetChild(k).GetComponent<Slot>(), data.itemAmount[data.numOfInventorySlots + k]);
            }
        }
    }
    public void SaveInventory()
    {
        InventoryData data = InventorySystem.GetInventoryData(this);
        InventorySystem.SaveInventory(data);
    }
    #endregion

    #region INPUTS
    public void MouseActions(InputAction.CallbackContext context)
    {
        mousePosition = new Vector3(
            context.ReadValue<Vector2>().x,
            context.ReadValue<Vector2>().y,
            Mathf.Abs(Camera.main.transform.position.z));

        if (icon.activeSelf.Equals(true))
        {
            icon.transform.position = mousePosition;
        }
        if (isOpen)
        {
            Slot slot = InventorySystem.FindSlot(mousePosition);
            if (slot != null)
            {
                if (slot.item != null)
                {
                    TooltipActive(true);
                    ToolTip.instance.transform.position = mousePosition;

                    if (ToolTip.instance.inspectedItem != slot.item)
                    {
                        ToolTip.instance.UpdateToolTip(slot.item);
                    }
                }
                else if (slot.item == null)
                {
                    TooltipActive(false);
                }
            }
            else
            {
                TooltipActive(false);
            }
        }
    }
    public void RightClick(InputAction.CallbackContext context) // Right Click
    {
        Slot slot = InventorySystem.FindSlot(mousePosition);
        if (slot.stackSize > 0 && slot.item.isStackable)
        {
            if (slot.item != null && itemHolding == null) //move item if slot has an item and not holding an item
            {
                returnSlot = slot;
                itemHolding = slot.item;
                numItemHolding++;
                slot.stackSize--;
                slot.stackText.text = slot.stackSize.ToString();
                MoveItem(itemHolding);
            }
            else if (slot.item != null & itemHolding != null & slot.item == itemHolding) //move item if slot has an item and not holding an item
            {
                returnSlot = slot;
                itemHolding = slot.item;
                numItemHolding++;
                slot.stackSize--;
                slot.stackText.text = slot.stackSize.ToString();                  
            }
            if (slot.stackSize == 0)
            {
                InventorySystem.EmptySlot(this, slot);
            }
            if (numItemHolding != 0)
            {
                icon.GetComponentInChildren<TMP_Text>().text = numItemHolding.ToString();
            }
        }
    }
    public void SplitStack(InputAction.CallbackContext context) // Shift + Left Click
    {
        Slot slot = InventorySystem.FindSlot(mousePosition);
        if (slot.stackSize > 1)
        {
            if (slot.item != null && itemHolding == null) //move item if slot has an item and not holding an item
            {
                itemHolding = slot.item;
                numItemHolding += Mathf.CeilToInt(slot.stackSize / 2f);
                slot.stackSize -= Mathf.CeilToInt(slot.stackSize / 2f);
                slot.stackText.text = slot.stackSize.ToString();
                MoveItem(itemHolding);
            }
            if (numItemHolding != 0)
            {
                icon.GetComponentInChildren<TMP_Text>().text = numItemHolding.ToString();
            }
        }
    } 
    public void LeftClick(InputAction.CallbackContext context) // Left Click
    {      
        if(inputs.Inventory.Split.phase == InputActionPhase.Started) { return; } // if we are trying to split item cancel left click action
        if (isOpen)
        {
            Slot slot = InventorySystem.FindSlot(mousePosition);
            if(slot == null && itemHolding != null) // drop item if placed outside the inventory space
            {
                InventorySystem.DropItem(this, itemHolding, numItemHolding ,sharedPlayer.transform.position + sharedPlayer.transform.forward * 2 + Vector3.up);
                icon.SetActive(false);
                itemHolding = null;
                numItemHolding = 0;
            }
            else if (slot == null) // return if clicked on nothing
            {
                return;
            }
            else if (slot.item == null && itemHolding != null) //place item if slot available //swap item if not available
            {
                InventorySystem.TransferItem(this, itemHolding, slot, numItemHolding);

                if (slot.item != null)
                {
                    icon.SetActive(false);
                    itemHolding = null;
                    numItemHolding = 0;
                    returnSlot = null;
                }                      
            }
            else if (slot.item != null && itemHolding != null) //add item to stack or swap items
            {
                if (slot.item.isStackable && itemHolding == slot.item)
                {
                    InventorySystem.AddToStack(slot, numItemHolding);
                }
                else
                {
                    InventorySystem.SwapItems(this, itemHolding, slot, returnSlot, numItemHolding);
                }
                icon.SetActive(false);
                itemHolding = null;
                returnSlot = null;
                numItemHolding = 0;
            }
            else if (slot.item != null && itemHolding == null) //move item if slot has an item and not holding an item
            {
                itemHolding = slot.item;
                numItemHolding = slot.stackSize;
                InventorySystem.EmptySlot(this, slot);
                returnSlot = slot;
                MoveItem(itemHolding);
            }
        }
    }
    #endregion

    #region FUNCTIONS
    public void MoveItem(Item item) // item icon moves to mouse pos
    {
        icon.transform.position = mousePosition;
        icon.SetActive(true);
        icon.GetComponent<Image>().sprite = item.inventoryIcon;
        if (numItemHolding != 0)
        {
            icon.GetComponentInChildren<TMP_Text>().text = numItemHolding.ToString();
        }
        else
        {
            icon.GetComponentInChildren<TMP_Text>().text = "";
        }
    }
    public void TooltipActive(bool state)
    {
        tooltip.SetActive(state);
    }
    #endregion
    private void OnDisable()
    {      
        isOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        TooltipActive(false);
        if (Resources.Load<InventorySystemSettings>("Data/InventorySystemSettings").autoSave)
        {
            SaveInventory();
        }
    }
}

