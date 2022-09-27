using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private CharacterMovements playerController;
    private GameObject rockController;

    private Vector3 initialPosition;
    private float initialSpeed;
    private Vector3 changedPos;
    private IEnumerator slowingCoroutine;

    int countCollide = 0;

    private void Start()
    {
        playerController = GetComponent<CharacterMovements>();
        rockController = GameObject.Find("BoulderLava");

        initialPosition = rockController.transform.position; //pos iniziale della roccia
        initialSpeed = playerController.Speed;  //speed iniziale del player
        changedPos = initialPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            countCollide ++;

            playerController.Speed = 5;
            playerController.animator.speed = 0.8f;
            changedPos.z += -3.5f;
            ChangeRockPosition(changedPos); //Sposto la pos della roccia di 5 unità più vicino al player
            if(slowingCoroutine != null){
                StopCoroutine(slowingCoroutine);
            }
            slowingCoroutine = TimerToRestoreValues();
            StartCoroutine(slowingCoroutine); //Coroutine che mi serve per far tornare tutto normale dopo un tot
        }

        if(other.gameObject.tag == "BoulderLava")
        {
            Destroy(this.gameObject);
            Debug.Log("Hai perso!");
        }
    }

    private void ChangeRockPosition(Vector3 pos)
    {
        rockController.transform.position = pos;
    }

    IEnumerator TimerToRestoreValues()
    {
        yield return new WaitForSecondsRealtime(5);

        playerController.Speed = initialSpeed;
        rockController.transform.position = initialPosition;
        playerController.animator.speed = 1;
        changedPos = initialPosition;
        countCollide = 0;
    }

}