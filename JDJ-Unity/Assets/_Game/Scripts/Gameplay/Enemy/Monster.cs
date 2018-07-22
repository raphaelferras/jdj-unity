﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : IHitable
{
    public Animator animator;
    public int damage;
    public float attackInterval;
    private float attackTimer;
    private Health health;
    private MoveInLane move;

    private const string MOVE_BOOL = "Move";
    private const string ATTACK_TRIGGER = "Attack";
    private const string DIE_TRIGGER = "Die";
    private const string DAMAGE_TRIGGER = "TakeDamage";

    private void Start()
    {
        health = GetComponent<Health>();
        move = GetComponent<MoveInLane>();
        attackTimer = 0.0f;
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
        attackTimer -= Time.deltaTime;
        if (animator != null)
        {
            animator.SetTrigger(ATTACK_TRIGGER);
        }
        if(attackTimer < 0)
        {
            attackTimer += attackInterval;
            GameMode.Instance.lanes.Attack(move.lane, move.lanesSize, damage);
        }
    }

    public void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger(DIE_TRIGGER);
        }
        Destroy(this.gameObject, 1.0f);
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
