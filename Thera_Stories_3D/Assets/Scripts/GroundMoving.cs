using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoving : MonoBehaviour
{
    private static float offset = 0.2f;

    // Update is called once per frame
    void Update()
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
