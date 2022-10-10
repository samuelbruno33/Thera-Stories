using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutSprites : MonoBehaviour
{
    private Sprite thisSprite;
    private SpriteRenderer prova;
    private Image image;
    private Color alpha;

    // Start is called before the first frame update
    /*void Start()
    {
        thisSprite.GetComponent<SpriteRenderer>().color = alpha;
        gameObject1.GetComponent<Image>().sprite = thisSprite;
        image = gameObject1;
    }*/

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FadeSprites")
        {
            //prova = other.gameObject.GetComponent<SpriteRenderer>();
            //thisSprite.GetComponent<SpriteRenderer>().sprite = prova;
            //image.CrossFadeAlpha(0f, 2f, false);
            //alpha.a = 0f;
            //other.gameObject.GetComponent<SpriteRenderer>().color = alpha;
        }

    }
}


