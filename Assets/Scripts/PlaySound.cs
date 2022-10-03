using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] SoundType sound;

    public void Play()
    {
        SoundManager.Instance.PlaySound(sound);
    }
}
