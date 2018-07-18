using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public Animator animator;

    private const string MOVE_BOOL = "Move";
    private const string ATTACK_TRIGGER = "Attack";
    private const string DIE_TRIGGER = "Die";
    private const string DAMAGE_TRIGGER = "TakeDamage";

    public void SetMove(bool value)
    {
        if (animator != null)
        {
            animator.SetBool(MOVE_BOOL, value);
        }
    }

    public void Attack()
    {
        if (animator != null)
        {
            animator.SetTrigger(ATTACK_TRIGGER);
        }
    }

    public void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger(ATTACK_TRIGGER);
        }
    }

    public void TakeDamage()
    {
        if (animator != null)
        {
            animator.SetTrigger(ATTACK_TRIGGER);
        }
    }
}
