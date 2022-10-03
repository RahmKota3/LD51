using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseChooseItemMenu : MonoBehaviour
{
    public void CloseMenu()
    {
        GameReferenceManager.Instance.ChooseItemMenu.SetActive(false);
    }
}
