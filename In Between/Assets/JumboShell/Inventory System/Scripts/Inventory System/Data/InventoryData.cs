
[System.Serializable]
public class InventoryData
{
    public int[] itemID;
    public int[] itemAmount;
    public int numOfInventorySlots;
    public int numOfEquipSlots;

    public InventoryData(int[] itemID, int[] itemAmount, int numOfInventorySlots, int numOfEquipSlots)
    {
        this.itemID = itemID;
        this.itemAmount = itemAmount;
        this.numOfInventorySlots = numOfInventorySlots;
        this.numOfEquipSlots = numOfEquipSlots;
    }
}
