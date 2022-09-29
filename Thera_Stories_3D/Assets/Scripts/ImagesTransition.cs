using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesTransition : MonoBehaviour {

    public GameObject[] imagesSprites;
    private int j = 0;
    private float i = 3f;

    public GameObject levelLoader;

    void Update()
    {
        i-=Time.deltaTime;
        if(i <= 0)
        {
            ImageTransition();
            i = 3f;
        }
    }

    private void ImageTransition()
    {
        if(j < 36)
        {
            imagesSprites[j].SetActive(false);
            imagesSprites[j+1].SetActive(true);
            j++;
        }
        else
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                levelLoader.GetComponentInChildren<SceneLoader>().LoadScene("VulcanLevel");
            }
        }
    }
}
