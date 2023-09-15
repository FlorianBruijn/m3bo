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

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator.GetComponent<Animator>();
    }

    void Start()
    {
        start_pos = transform.position;

    }

    //this to the next comment is all moving so this is fine
    public void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
        Attack();
    }

    public void UpdatePath()
    {
        if(Time.time >= pathUpateDeadlind)
        {
            Debug.Log("Updating");
            pathUpateDeadlind = Time.time + pathUpdateDelay;
            navMeshAgent.SetDestination(target.position);
        }
    }

    public void WalkBack()
    {
        Debug.Log("walkback");
        navMeshAgent.SetDestination(start_pos);
    }

    //this attach part does noting but still should have been in a difrent script
    private void Attack()
    {
    }
}
