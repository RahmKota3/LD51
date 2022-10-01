using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StartingCardData", menuName = "ScriptableObjects/StartingCardData", order = 0)]
public class StartingCardData : ScriptableObject
{
	public List<int> StartingCards;
}
