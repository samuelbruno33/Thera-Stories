using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    private Rigidbody body;
    private Camera mainCamera;

    private float speed = 5;
    private float xMargin = 4;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 dir = new Vector3 (0,0,0);
        transform.rotation = Quaternion.Euler(0,0,0);

        if(Application.isEditor) //Emuliamo input del touch con la tastiera cosi da non dover testare il gioco buildandolo ogni volta e spostandolo sul telefono
        {
            dir = InEditorMovements(dir);
        }
        else
        {
            dir = InPhoneMovements(dir);
        }

        float posX = transform.position.x;
        posX = Mathf.Clamp(posX, -xMargin, xMargin); //Dò dei margini al giocatore per non sforare nella visuale di gioco: più di un tot non si può spostare sull'asse x
        transform.position = new Vector3(posX, transform.position.y, transform.position.z); //Ricalcolo la posizione del player con il vincolo sulla x

        body.velocity = new Vector3(dir.x * speed, 0, -2); //Movimento del player
    }


    private Vector3 InEditorMovements(Vector3 dir) //emulo i movimenti del touch (il commento dei vari comandi è nel InPhoneMovements)
    {
        if(Input.GetKey(KeyCode.D)){
            dir.x = -1;
            transform.rotation = Quaternion.Euler(0,0,-30);
        }
        else if(Input.GetKey(KeyCode.A)){
            dir.x = 1;
            transform.rotation = Quaternion.Euler(0,0,30);
        }

        return dir;
    }

    private Vector3 InPhoneMovements(Vector3 dir)
    {
        //Vogliamo sapere se il giocatore tocca il touchscreen con almeno un dito, se non tocco lo schermo sto fermo
        if (Input.touches.Length > 0){
            Vector3 touchPosition = Input.touches[0].position; // prendiamo la posizione del primo dito con cui si tocca il touchscreen, così da controllare che non si abbiano due dita both at once
            touchPosition = mainCamera.ScreenToWorldPoint(touchPosition); //Cast sul world point

            if(touchPosition.x > 0)
            {
                dir.x = -1; //vai a dx
                transform.rotation = Quaternion.Euler(0,0,-30); //ruota leggermente il personaggio mentre va in una direzione
            }
            else if (touchPosition.x < 0)
            {
                dir.x = 1; //vai a sx
                transform.rotation = Quaternion.Euler(0,0,30);
            }
            else
            {
                Debug.Log("Che casino!");
            }
        }
        return dir;
    }

}
