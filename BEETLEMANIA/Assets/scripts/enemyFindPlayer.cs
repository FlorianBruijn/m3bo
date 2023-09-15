using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFindPlayer : MonoBehaviour
{
    public Transform target;

    private float shooting_distance;

    public float walking_distance;

    public get_hit hp;

    [SerializeField] private ai_1 ai;
    private void Update()
    {
        // the script below should be in a difrent script becouse it is to find tge enemy
        if (target != null)
        {
            bool inAttackRange = Vector3.Distance(transform.position, target.position) <= shooting_distance;
            bool inWalkRange = Vector3.Distance(transform.position, target.position) <= walking_distance;

            if (inAttackRange)
            {
                ai.LookAtTarget();
            }
            if (inWalkRange && hp.hp > hp.max_hp / 100 * 20)
            {
                ai.UpdatePath();
            }
            else
            {
                ai.WalkBack();
            }
        }
    }
}
