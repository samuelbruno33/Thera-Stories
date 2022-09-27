using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    private Rigidbody body;
    private Camera mainCamera;
    public Animator animator;

    private float speed = 13;
    private float xMargin = 6.5f;
    public float jumpForce = 10f;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

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

        body.velocity = new Vector3(dir.x * speed, 0, 0); //Movimento del player
    }


    private Vector3 InEditorMovements(Vector3 dir) //emulo i movimenti del touch (il commento dei vari comandi è nel InPhoneMovements)
    {
        if(Input.GetKey(KeyCode.D)){
            dir.x = 1;
            transform.localRotation = Quaternion.Euler(0,-30,0);
        }
        else if(Input.GetKey(KeyCode.A)){
            dir.x = -1;
            transform.localRotation = Quaternion.Euler(0,30,0);
        }
        else if(Input.GetKey(KeyCode.Space)) {
            Vector3 vector = new Vector3();
            vector.y += jumpForce;
            body.velocity = vector;
            animator.SetTrigger("jump");
        }

        return dir;
    }

    private Vector3 InPhoneMovements(Vector3 dir)
    {
        //voglio sapere se il giocatore tocca il touchscreen con almeno un dito, se non tocco lo schermo sto fermo
        if (Input.touches.Length > 0){
            Vector3 touchPosition = Input.touches[0].position; // prendo la posizione del primo dito con cui si tocca il touchscreen, così da controllare che non si abbiano due dita both at once
            
            if(touchPosition.x > Screen.width / 2)
            {
                dir.x = 1; //vai a dx
                transform.rotation = Quaternion.Euler(0,-30,0); //ruota leggermente il personaggio mentre va in una direzione
            }
            else if (touchPosition.x < Screen.width / 2)
            {
                dir.x = -1; //vai a sx
                transform.rotation = Quaternion.Euler(0,30,0);
            }
        }
        return dir;
    }

}
