using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[AddComponentMenu("Inventory/EquipmentLink")]
[RequireComponent(typeof(Inventory))]
public class EquipmentLink : MonoBehaviour
{
    #region DICTIONARIES

    //public Dictionary<string, List<GameObject>> bodyLinks = new Dictionary<string, List<GameObject>>();
    //public Dictionary<string, List<GameObject>> ignoreLinks = new Dictionary<string, List<GameObject>>();
    //public Dictionary<string, List<Mesh>> originalMeshes = new Dictionary<string, List<Mesh>>();
    //public Dictionary<string, List<Material>> originalMaterials = new Dictionary<string, List<Material>>();

    #endregion

    #region MESHES

    [SerializeField] public List<Link> EquipmentLinks = new List<Link>();

    #endregion

    #region FUNCTIONS

    public void EquipItem(Item item)
    {
        for(int i = 0; i < EquipmentLinks.Count; i++)
        {
            if(item.EquipSlot == EquipmentLinks[i].EquipSlot)
            {
                EquipmentLinks[i].TargetMeshFilter.mesh = item.mesh;
                EquipmentLinks[i].TargetMeshRenderer.material = item.material;
            }
        }
    }

    public void UnEquipItem(Item item)
    {
        for (int i = 0; i < EquipmentLinks.Count; i++)
        {
            if (item.EquipSlot == EquipmentLinks[i].EquipSlot)
            {
                EquipmentLinks[i].TargetMeshFilter.mesh = EquipmentLinks[i].DefaultMesh;
                EquipmentLinks[i].TargetMeshRenderer.material = EquipmentLinks[i].DefaultMaterial;
            }
        }
    }





    //public Mesh GetOriginalMeshes(string equipSlot, int index) // returns the original mesh of the given equipSlot;
    //{
    //    originalMeshes.TryGetValue(equipSlot, out List<Mesh> meshes);
    //    return meshes[index];
    //}
    //public Material GetOriginalMaterials(string equipSlot, int index) // returns the original material of the given equipSlot;
    //{
    //    originalMaterials.TryGetValue(equipSlot, out List<Material> materials);
    //    return materials[index];
    //}  
    //public List<GameObject> GetEquipLinks(string equipSlot) //returns a list of the available body links that a given equip slot can use;
    //{
    //    bodyLinks.TryGetValue(equipSlot, out List<GameObject> links);
    //    return links;
    //}
    //public void IgnorePartsSetActive(string equipSlot, bool state) // when called will set the desired ignore parts to be disabled or enabled
    //{
    //    ignoreLinks.TryGetValue(equipSlot, out List<GameObject> ignoreParts);

    //    if (ignoreParts.Count > 0)
    //    {
    //        for (int i = 0; i < ignoreParts.Count; i++)
    //        {
    //            ignoreParts[i].SetActive(state);
    //        }
    //    }
    //    return;
    //}
    #endregion

}

[System.Serializable]
public struct Link : ISerializationCallbackReceiver
{
    public static List<string> equipSlotsTemp;
    public static List<string> equipSlots;
    [ListToPopup(typeof(Link), "equipSlotsTemp")]
    public string EquipSlot;

    public MeshFilter TargetMeshFilter;
    //public MeshFilter m_TargetMeshFilter { set => _ = TargetMeshFilter; }
    public Mesh DefaultMesh;

    public MeshRenderer TargetMeshRenderer;
    //public MeshRenderer m_TargetMeshRenderer { set => _ = TargetMeshRenderer; }
    public Material DefaultMaterial;

    public void OnAfterDeserialize()
    {
       
    }

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
}
