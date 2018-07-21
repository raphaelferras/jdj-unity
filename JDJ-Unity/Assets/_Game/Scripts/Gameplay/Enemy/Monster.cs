using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : IHitable
{
    public Animator animator;
    private Health health;

    private const string MOVE_BOOL = "Move";
    private const string ATTACK_TRIGGER = "Attack";
    private const string DIE_TRIGGER = "Die";
    private const string DAMAGE_TRIGGER = "TakeDamage";

    private void Start()
    {
        health = GetComponent<Health>();
    }

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
            animator.SetTrigger(DIE_TRIGGER);
        }
        Destroy(this.gameObject, 3.0f);
        Destroy(this);
        Destroy(GetComponent<MoveInLane>());
        Destroy(GetComponent<BoxCollider>());
    }

    public void TakeDamage()
    {
        if (animator != null)
        {
            animator.SetTrigger(DAMAGE_TRIGGER);
        }
    }

    public override void Hit(PowerHitInfo hi)
    {
        health.AddHit(hi.damage);
        if (hi.damage > 0)
        {
            if (health.hp > 0)
            {
                TakeDamage();
            }
            else
            {
                Die();
            }
        }
    }
}
