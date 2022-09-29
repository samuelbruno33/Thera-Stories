using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private GameObject cameraPov;

    public float speed;


    // Update is called once per frame
    void Update()
    {
        float yAxisAngle = cameraPov.transform.localEulerAngles.y;

        yAxisAngle += speed * Time.deltaTime; 

        cameraPov.transform.localEulerAngles = new Vector3(0, yAxisAngle, 0);
        
    }
}
