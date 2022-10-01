using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName = "ScriptableObjects/Stats", order = 0)]
public class Stats : ScriptableObject
{
    public List<SerializableAttributeDictionary> Attributes;
}
