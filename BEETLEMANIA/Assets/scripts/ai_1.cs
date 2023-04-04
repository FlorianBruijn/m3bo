using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai_1 : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public float pathUpdateDelay = 0.2f;

    public Transform target;

    private Vector3 start_pos;

    public GameObject attack;

    private float pathUpateDeadlind;

    private float shooting_distance;

    public float walking_distance;

    public get_hit hp;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator.GetComponent<Animator>();
    }

    void Start()
    {
        start_pos = transform.position;
        shooting_distance = navMeshAgent.stoppingDistance;
    }

    void Update()
    {
        if (target != null)
        {
            bool inAttackRange = Vector3.Distance(transform.position, target.position) <= shooting_distance;
            bool inWalkRange = Vector3.Distance(transform.position, target.position) <= walking_distance;

            if (inAttackRange)
            {
                LookAtTarget();
            }
            if (inWalkRange && hp.hp > hp.max_hp / 100 * 20)
            {
                UpdatePath();
            }
            else
            {
                WalkBack();
            }
        }
    }

    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
        Attack();
    }

    private void UpdatePath()
    {
        if(Time.time >= pathUpateDeadlind)
        {
            Debug.Log("Updating");
            pathUpateDeadlind = Time.time + pathUpdateDelay;
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void WalkBack()
    {
        Debug.Log("walkback");
        navMeshAgent.SetDestination(start_pos);
    }

    [System.Obsolete]
    private void Attack()
    {
        attack.active = true;
    }
}
