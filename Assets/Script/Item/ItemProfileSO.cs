
using UnityEngine;
[CreateAssetMenu (fileName ="ItemProfileSO", menuName ="SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = " no-Name";
    public int defaultMaxStack = 7;
}
