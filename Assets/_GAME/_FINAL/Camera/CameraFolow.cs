using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform target;

    public void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, 7, target.position.z - 1.5F);
    }

}
