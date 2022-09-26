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
            playerController.Speed = 1;
            playerController.animator.speed = 0.5f;
            changedPos.z += -5;
            ChangeRockPosition(changedPos); //Sposto la pos della roccia di 5 unità più vicino al player

            StartCoroutine(TimerToRestoreValues()); //Coroutine che mi serve per far tornare tutto normale dopo un tot
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
    }
}
