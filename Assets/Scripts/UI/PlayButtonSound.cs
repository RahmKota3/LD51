using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSound : MonoBehaviour
{
    public void PlaySound()
    {
        SoundManager.Instance.PlaySound(SoundType.MenuButton);
    }
}
