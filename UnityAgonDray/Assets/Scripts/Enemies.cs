using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public float startWaitTime = 4f;
    public float timeToRotate = 2f;
    public float speedWalk = 6f;

    public float viewRadius = 5f;
    public float viewAngle = 90f;
    public LayerMask playerMask;
    public LayerMask obsMask;
    public float meshResolution = 1f;
    public int edgeIterations = 4;
    public float edgeDistance = 0.5f;

    public Transform[] waypoints;
    int m_CurrWaypointIdx;

    Vector3 playerLastPos = Vector3.zero;
    Vector3 m_PlayerPos;

    float waitTime;
    float mTimeToRotate;
    bool playerInRange;
    bool playerNear;
    bool isPatrol;
    bool seePlayer;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerPos = Vector3.zero;
        isPatrol = true;
        seePlayer = false;
        playerInRange = false;
        waitTime = startWaitTime;
        mTimeToRotate = timeToRotate;
        m_CurrWaypointIdx = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedWalk;
        navMeshAgent.SetDestination(waypoints[m_CurrWaypointIdx].position);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Chasing()
    {
        playerNear = false;
        playerLastPos = Vector3.zero;

        if (!seePlayer)
        {
            Move(speedWalk);
            navMeshAgent.SetDestination(m_PlayerPos);
        }
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            //if(waitTime <= 0 && !seePlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectsWithTag("player").transform.position) >= 6f){

            //}
        }
    }

    private void Patrolling()
    {
        if (playerNear)
        {
            if(mTimeToRotate <= 0)
            {
                Move(speedWalk);
                LookingForPlayer(playerLastPos);
            }
            else
            {
                Stop();
                mTimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            playerNear = false;
            playerLastPos = Vector3.zero;
            navMeshAgent.SetDestination(waypoints[m_CurrWaypointIdx].position);
            if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if(waitTime <= 0)
                {
                    NextPoint();
                    Move(speedWalk);
                    waitTime = startWaitTime;
                }
                else
                {
                    Stop();
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    void Move(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }

    void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
    }

    public void NextPoint()
    {
        m_CurrWaypointIdx = (m_CurrWaypointIdx + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[m_CurrWaypointIdx].position);
    }
    void SeePlayer()
    {
        seePlayer = true;
    }

    void LookingForPlayer(Vector3 player)
    {
        navMeshAgent.SetDestination(player);
        if(Vector3.Distance(transform.position, player) <= 0.3)
        {
            if(waitTime <= 0)
            {
                playerNear = false;
                Move(speedWalk);
                navMeshAgent.SetDestination(waypoints[m_CurrWaypointIdx].position);
                waitTime = startWaitTime;
                mTimeToRotate = timeToRotate;
            }
            else
            {
                Stop();
                waitTime -= Time.deltaTime;
            }
        }
    }

    void EnviromentView()
    {
        Collider[] isPlayerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);
        for(int i = 0; i < isPlayerInRange.Length; i++)
        {
            Transform player = isPlayerInRange[i].transform;
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, directionToPlayer) < viewAngle / 2)
            {
                float destToPlayer = Vector3.Distance(transform.position, player.position);
                if(!Physics.Raycast(transform.position, directionToPlayer, destToPlayer, obsMask))
                {
                    playerInRange = true;
                    isPatrol = false;
                }
                else
                {
                    playerInRange = false;
                }
            }
            if(Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                playerInRange = false;
            }
            if (playerInRange)
            {
                m_PlayerPos = player.transform.position;
            }
        }
    }

}
