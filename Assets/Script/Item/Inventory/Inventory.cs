using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    private void Start()
    {
        this.AddItem(ItemCode.Hp, 3);
    }

    protected virtual bool AddItem(ItemCode itemCode, int addCount)         // nhặt đồ bằng item code
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount + addCount;
        if (newCount > itemInventory.maxStack) return false;
        itemInventory.itemCount = newCount;
        return true;
    }
    public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);     //tìm item trong list items có itemcode == itemcode truyền vào
        if (itemInventory == null) itemInventory = this.AddEmtyProfile(itemCode);                            // nếu trường hợp itemcode kh có thì add emty profile
        return itemInventory;
    }

    protected virtual ItemInventory AddEmtyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack
            };

            this.items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    }
}
