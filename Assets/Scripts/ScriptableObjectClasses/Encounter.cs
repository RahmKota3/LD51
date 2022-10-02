using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Encounter", menuName = "ScriptableObjects/Encounter", order = 0)]
public class Encounter : ScriptableObject
{
	public List<GameObject> EnemiesInEncounter;
}
