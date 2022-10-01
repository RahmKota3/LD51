using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableAttributeDictionary
{
    public AttributeType Attribute = AttributeType.None;
    public float Value;

    public float MinValue = -99999;
    public float MaxValue = 99999;
}
