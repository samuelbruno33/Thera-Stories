using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera theCam;
    public bool useStaticBillboard;

    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!useStaticBillboard)
        {
            transform.LookAt(theCam.transform);
        }
        else
        {
            transform.rotation = theCam.transform.rotation;
        }

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
