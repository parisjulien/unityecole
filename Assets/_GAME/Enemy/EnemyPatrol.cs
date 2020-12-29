using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    private float initialPosition;
    private float initialRotation;
    private Animation animation;

    public NavMeshAgent agent;
    public float distance;
    public bool isVertical;
    public bool isLeftToRight;
    public bool isTopToBottom;

    // Start is called before the first frame update
    void Start()
    {
        animation = gameObject.GetComponent<Animation>();
        initialPosition = isVertical ? transform.position.z : transform.position.x;
        initialRotation = transform.rotation.y;
        Invoke("Move", 1F);
    }

    private void Move()
    {
        Vector3 destination;

        if (isVertical)
        {
            if (transform.position.z == initialPosition)
            {
                float newZ = isTopToBottom ? initialPosition - distance : initialPosition + distance;
                destination = new Vector3(transform.position.x, transform.position.y, newZ);
            }
            else
            {
                destination = new Vector3(transform.position.x, transform.position.y, initialPosition);
            }
        }
        else
        {
            if (transform.position.x == initialPosition)
            {
                float newX = isLeftToRight ? initialPosition - distance : initialPosition + distance;
                destination = new Vector3(newX, transform.position.y, transform.position.z);
            }
            else
            {
                destination = new Vector3(initialPosition, transform.position.y, transform.position.z);
            }
        }

        animation.Play("Walk");
        agent.SetDestination(destination);
        Invoke("Rotate", 2F);
    }

    private void Rotate()
    {
        if (transform.rotation.y == initialRotation)
        {
            transform.SetPositionAndRotation(transform.position, new Quaternion(transform.rotation.x, initialRotation - 90, transform.rotation.z, transform.rotation.w));
        }
        else
        {
            transform.SetPositionAndRotation(transform.position, new Quaternion(transform.rotation.x, initialRotation, transform.rotation.z, transform.rotation.w));
        }

        Invoke("Move", 5F);
    }
}
