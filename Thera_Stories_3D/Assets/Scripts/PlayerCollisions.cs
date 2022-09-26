using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private CharacterMovements playerController;

    void Start()
    {
        playerController = GetComponent<CharacterMovements>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            playerController.Speed = 2;
        }
    }
}
