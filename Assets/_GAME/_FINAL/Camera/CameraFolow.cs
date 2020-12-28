using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed;
    public float speed = 3.5f;
    private float X;
    private float Y;

    public void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, 5, target.position.z - 1.5F);
    }

}
