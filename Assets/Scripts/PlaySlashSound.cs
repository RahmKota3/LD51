using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySlashSound : MonoBehaviour
{
    public void PlaySound()
    {
        SoundManager.Instance.PlaySound(SoundType.Slash);
    }
}
