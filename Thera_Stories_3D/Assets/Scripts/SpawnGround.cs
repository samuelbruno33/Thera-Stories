using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    private GameObject rockController;

    public GameObject groundSpawner;
    public Transform groundSpawnPosition;
    public GameObject templeActivation;
    public GameObject groundFadeOut;
    private static int count = 0;
    public static List<GameObject> groundsCount = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        rockController = GameObject.Find("BoulderLava");
        groundsCount.Add(groundSpawner);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        count++;

        if(other.gameObject.tag == "Player" && count <= 2) //<=2
        {
            GameObject ground = Instantiate(groundSpawner, groundSpawnPosition.position, Quaternion.identity);
            groundsCount.Add(ground);
        }
        else
        {
            templeActivation.SetActive(true);
        }
    }
}
