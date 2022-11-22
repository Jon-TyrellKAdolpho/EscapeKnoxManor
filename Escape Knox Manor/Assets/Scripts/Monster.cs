using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Monster : MonoBehaviour
{
    public Transform target;
    public Transform eyes;
    public LayerMask detectionMask;
    public bool detected;
    public bool inRange;
    public bool canSeePlayer;

    public float moveSpeed;
    public float sprintMultiplier;

    public NavMeshAgent agent;

    public float detectionRadius = 15;
    public float rangeRadius = 2;
    //0 = Slow Chase/ Inspect, 1 = slow chase/attack, 2 = Sprint/attack
    public int action;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) <= detectionRadius)
        {
            //Part One
            detected = true;


            if(Vector3.Distance(eyes.position, target.position) <= rangeRadius)
            {
                //Part Two

            }
        }

        RaycastHit hit;

        if (Physics.Raycast(eyes.transform.position, eyes.transform.forward, out hit, detectionRadius, detectionMask))
        {
            if (hit.collider.CompareTag("Player"))
            {
                canSeePlayer = true;
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else
        {
            canSeePlayer = false;
        }

        if(detected == true)
        {
            eyes.LookAt(target.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(eyes.position, rangeRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(eyes.position, target.position);
    }
}
