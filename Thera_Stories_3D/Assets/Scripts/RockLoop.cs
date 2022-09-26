using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLoop : MonoBehaviour
{
    private float speed = 150f;
    Vector3 newRotation;
    private float transitionTime = 0;
    public AnimationCurve curve;
    Vector3 initialRockPos;
    private float jumpHeight = 5;
    bool isCollided = false;

    void Start()
    {
        initialRockPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        XRotation();

        if(isCollided)
        {
            transitionTime += Time.deltaTime;
            Vector3 vector = initialRockPos;
            vector.y = curve.Evaluate(transitionTime) * jumpHeight + initialRockPos.y;
            transform.position = vector;
            if(transitionTime >= 1){
                isCollided = false;
                transitionTime = 0;
            }
        }
    }

    void XRotation()
    {
        newRotation.x -= speed * Time.deltaTime;
        transform.localEulerAngles = newRotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            isCollided = true;
        }
    }
}
