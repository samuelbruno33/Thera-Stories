using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLoop : MonoBehaviour
{
    private float speed = 150f;
    private Vector3 newRotation;
    private float transitionTime = 0;
    public AnimationCurve curve;
    private float initialYRockPos;
    private float jumpHeight = 5;
    private bool isCollided = false;

    void Start()
    {
        initialYRockPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        XRotation();

        if(isCollided)
        {
            transitionTime += Time.deltaTime;
            Vector3 vector = new Vector3(transform.position.x, initialYRockPos, transform.position.z);
            vector.y = curve.Evaluate(transitionTime) * jumpHeight + initialYRockPos;
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
