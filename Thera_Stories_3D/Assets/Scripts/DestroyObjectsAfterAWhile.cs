using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsAfterAWhile : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FinishLine")
        {
            Destroy(this.gameObject);
        }
    }
}
