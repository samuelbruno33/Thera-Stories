using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesTransition : MonoBehaviour {

    public GameObject[] imagesSprites;
    private int j = 0;
    private float i = 7f;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position

    public GameObject levelLoader;

    private float dragDistance;  //minimum distance for a swipe to be registered

    void Start() {
        dragDistance = Screen.width * 15 / 100; //dragDistance is 15% width of the screen
    }

    void Update() {

        if(Application.isEditor) //Emuliamo input del touch con la tastiera cosi da non dover testare il gioco buildandolo ogni volta e spostandolo sul telefono
        {
            i -= Time.deltaTime;
            if (i <= 0)
            {
                ImageTransition();
                i = 7f;
            }
        }
        else
        {
            SwipeTransition();
        }
    }

    private void ImageTransition() {
        if (j < 36)
        {
            imagesSprites[j].SetActive(false);
            imagesSprites[j + 1].SetActive(true);
            j++;
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                levelLoader.GetComponentInChildren<SceneLoader>().LoadScene("VulcanLevel");
            }
        }
    }

    private void SwipeTransition()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (j == 36 && (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance))
                {
                    //It's a drag
                    //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {
                        //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {
                            //Right swipe
                            Debug.Log("Right Swipe");
                        }
                        else
                        {
                            //Left swipe
                            Debug.Log("Left Swipe");
                            levelLoader.GetComponentInChildren<SceneLoader>().LoadScene("VulcanLevel");
                        }
                    }
                    /*else
                    {
                        //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {
                            //Up swipe
                            Debug.Log("Up Swipe");
                        }
                        else
                        {
                            //Down swipe
                            Debug.Log("Down Swipe");
                        }
                    }*/
                }
                else
                {
                    //It's a tap as the drag distance is less than 15% of the screen height
                    Debug.Log("Tap");
                    if(j < 36)
                    {
                        imagesSprites[j].SetActive(false);
                        imagesSprites[j + 1].SetActive(true);
                        j++;
                    }
                }
            }
        }
    }
}
