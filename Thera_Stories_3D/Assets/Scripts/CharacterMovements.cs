using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    private Rigidbody body;
    private Camera mainCamera;

    [SerializeField] private float speed = 5;
    [SerializeField] private float xMargin = 4;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 dirX = new Vector3 (0,0,0);
        transform.rotation = Quaternion.Euler(0,0,0);

        if(Application.isEditor) //Emuliamo input del touch con la tastiera cosi da non dover testare il gioco buildandolo ogni volta e spostandolo sul telefono
        {
            dirX = InEditorMovements(dirX);
        }
        else
        {
            dirX = InPhoneMovements(dirX);
        }

        //body.velocity = new Vector3(dirX.x * speed * Time.deltaTime, 0, 0); //Alternativa che non funziona troppo bene

        float posX = transform.position.x;
        posX = Mathf.Clamp(posX, -xMargin, xMargin); //Dò dei margini al giocatore per non sforare nella visuale di gioco: più di un tot non si può spostare sull'asse x
        transform.position = new Vector3(posX, transform.position.y, transform.position.z); //Ricalcolo la posizione del player

        body.MovePosition(transform.position + dirX * speed * Time.deltaTime); //Muovo il Player
    }


    private Vector3 InEditorMovements(Vector3 dirX) //emulo i movimenti del touch (il commento dei vari comandi è nel InPhoneMovements)
    {
        if(Input.GetKey(KeyCode.D)){
            dirX.x = 1;
            transform.rotation = Quaternion.Euler(0,0,-30);
        }
        else if(Input.GetKey(KeyCode.A)){
            dirX.x = -1;
            transform.rotation = Quaternion.Euler(0,0,30);
        }

        return dirX;
    }

    private Vector3 InPhoneMovements(Vector3 dirX)
    {
        //Vogliamo sapere se il giocatore tocca il touchscreen con almeno un dito, se non tocco lo schermo sto fermo
        if (Input.touches.Length > 0){
            Vector3 touchPosition = Input.touches[0].position; // prendiamo la posizione del primo dito con cui si tocca il touchscreen, così da controllare che non si abbiano due dita both at once
            touchPosition = mainCamera.ScreenToWorldPoint(touchPosition); //Cast sul world point

            if(touchPosition.x > 0)
            {
                dirX.x = 1; //vai a dx
                transform.rotation = Quaternion.Euler(0,0,-30); //ruota leggermente il personaggio mentre va in una direzione
            }
            else if (touchPosition.x < 0)
            {
                dirX.x = -1; //vai a sx
                transform.rotation = Quaternion.Euler(0,0,30);
            }
        }
        return dirX;
    }

}
