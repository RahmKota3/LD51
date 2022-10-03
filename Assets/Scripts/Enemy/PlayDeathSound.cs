using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDeathSound : MonoBehaviour
{
    public void PlayDeathSoundClip()
    {
        SoundManager.Instance.PlaySound(SoundType.Death);
    }
}
