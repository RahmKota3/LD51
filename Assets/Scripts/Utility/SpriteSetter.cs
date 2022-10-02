using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSetter : MonoBehaviour
{
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] Sprite spriteToSet;

    [ContextMenu("Set sprite to renderer")]
    public void SetSprite()
    {
        renderer.sprite = spriteToSet;
    }
}
