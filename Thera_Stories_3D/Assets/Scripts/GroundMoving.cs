using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoving : MonoBehaviour
{
    private static float offset = 0.2f;

    // FixedUpdate is called once per 0.2s
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Offset);
    }

    public static float Offset {
        get {
            return offset;
        }
        set {
            offset = value;
        }
    }
}
