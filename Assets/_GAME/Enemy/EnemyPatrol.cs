using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Move", 2F);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Move()
    {
        agent.SetDestination(new Vector3(transform.position.x, transform.position.y, transform.position.z + 4));
    }
}
