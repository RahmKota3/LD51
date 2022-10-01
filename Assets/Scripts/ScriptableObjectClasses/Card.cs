using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card", order = 0)]
public class Card : ScriptableObject
{
    public string Name = "Name";
	[Multiline]
    public string Description = "Deal 5 damage";
	public Sprite CardIcon;
	public Sprite EffectIcon;
	public int EffectStrength = 0;
}
