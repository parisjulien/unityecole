using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewDetection : MonoBehaviour
{
    /// <summary>
    /// View distance
    /// </summary>
    public float viewRadius;
    /// <summary>
    /// Field of view angle
    /// </summary>
    [Range(0, 360)]
    public float viewAngle;
    /// <summary>
    /// Target Mask (for player detection)
    /// </summary>
    public LayerMask targetMask;
    /// <summary>
    /// Obstacle Mask (block the enemy vision)
    /// </summary>
    public LayerMask obstacleMask;
    
    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2F);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    /// <summary>
    /// This methods allow to find all visible target in an enemy field of view.
    /// </summary>
    void FindVisibleTargets()
    {
        // Clear the list of visible targets.
        visibleTargets.Clear();
        // Get all collider arround the enemy.
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetInViewRadius.Length; i++)
        {
            // Get current Target
            Transform target = targetInViewRadius[i].transform;
            // Get direction of target
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            // If the current target is in a fov
            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
            {
                // Calc distance between enemy and target
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                // If the target is not an obstacle, add it into a visibleTargets.
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    Debug.Log("PLAYER DETECTED = ", target);
                }
            }
        }
    }

    /// <summary>
    /// Define the field of view
    /// </summary>
    /// <param name="angleInDegrees">Angle in degrees</param>
    /// <returns></returns>
    public Vector3 DirectionFromAngle(float angleInDegrees)
    {
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
