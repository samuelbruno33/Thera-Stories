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

    private bool isFinished = false;

    void Start()
    {
        initialYRockPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFinished)
            XRotation();
        else
            StopRotation();

        if(isCollided)
            LittleJump();

    }

    private void XRotation()
    {
        newRotation.x -= speed * Time.deltaTime;
        transform.localEulerAngles = newRotation;
    }

    private void StopRotation()
    {
        this.transform.rotation = new Quaternion(0, transform.rotation.y, transform.rotation.z, 1);
    }

    private void LittleJump()
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            isCollided = true;
        }

        if(other.gameObject.tag == "Finish")
        {
            isFinished = true;
            StartCoroutine(StopMovingGround());
        }
    }

    IEnumerator StopMovingGround()
    {
        float timer = 0;
        float duration = 1f;
        float originalOffset = GroundMoving.Offset;

        while(timer < duration) {
            yield return null;
            timer += Time.deltaTime;
            float offset = Mathf.Lerp(originalOffset, 0, timer/duration);
            GroundMoving.Offset = offset;
        }

        foreach (GameObject i in SpawnGround.groundsCount)
        {
            i.gameObject.GetComponent<GroundMoving>().enabled = false;
        }
    }
}