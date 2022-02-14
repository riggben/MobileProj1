using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    //Parameters
    public float sightRange = 20f;
    public float attackRange = 2f;
    public float moveSpeed = 2f;
    public Vector3 flashOffset = Vector3.up;
    
    //Public Variables
    public bool canSeePlayer = false;
    public bool inAttackRange = false;
    public bool isChasing = false, isAttacking = false;
    public bool isCounterable = false;
    public bool countered = false;
    
    //Components
    public GameManager gm;
    public Transform player;
    public Animator anim;
    public GameObject flashEffect;
    public State deadState;
    
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        player = gm.Player.transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleVision();
        
    }

    void HandleVision()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        //simple distance based
        canSeePlayer = dist < sightRange ?  true : false;

        inAttackRange = dist < attackRange ? true : false;
    }

    public void Chase()
    {
        transform.LookAt(player);
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        isChasing = true;
        anim.SetBool("Chase", true);

    }

    public void Attack()
    {
        anim.SetBool("Attack", true);
        isAttacking = true;
    }

    public void Idle()
    {
        isChasing = false;
        isAttacking = false;
        anim.SetBool("Chase", false);
    }


    public void Countered()
    {
        countered = true;
    }

    public void Dead()
    {
        anim.SetBool("Dead", true);
        GetComponent<StateManager>().SetState(deadState);
    }
    /// <summary>
    /// These functions are called by animation events
    /// </summary>
    public void AttackEnd()
    {
        isAttacking = false;
        anim.SetBool("Attack", false);
        //Debug.Log("Attack Has ENDED!!!");
    }

    void TelegraphAttack()
    {
        Instantiate(flashEffect, transform.position + (flashOffset), new Quaternion(), transform);
    }
    
    void Counterable()
    {
        isCounterable = true;

        //Debug.Log(("COUNTER NOW!"));
    }

    void NotCounterable()
    {
        isCounterable = false;
        //Debug.Log(("Too Late!"));
    }
}
