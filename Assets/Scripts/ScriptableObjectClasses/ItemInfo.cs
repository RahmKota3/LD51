using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "ScriptableObjects/ItemInfo", order = 0)]
public class ItemInfo : ScriptableObject
{
    public Sprite itemIcon;
    public GameObject objectToSpawn;
    [Multiline] public string Tooltip;
}
