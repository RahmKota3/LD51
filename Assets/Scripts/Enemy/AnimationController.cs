using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void PlayAttackAnimation()
    {
        anim.SetTrigger(Globals.EnemyAttackAnimTrigger);
    }
}
