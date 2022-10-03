using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    GameObject itemToGet;

    Vector3 spawnPos = new Vector3(999, 999, 0);

    public void SetItemToGet(GameObject itemObj)
    {
        itemToGet = itemObj;
    }

    public void AcquireItem()
    {
        Instantiate(itemToGet, spawnPos, Quaternion.identity);
    }
}
