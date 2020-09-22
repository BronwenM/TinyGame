using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{

    public GameObject[] FoodPrefabs;
    public GameObject newFood;

    public int arrSize = 9;

    public float time;
    public float x = 0;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        //StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int i;
    IEnumerator Spawner()
    {
        while (gameManager.gameOver == false)
        {

            i = Random.Range(0, arrSize);
            newFood = Instantiate(FoodPrefabs[i], transform.position, Quaternion.identity);

            x++;

            time = 0.9f + Mathf.Pow(0.9f, x - 13f); //better
            //time = 1f + Mathf.Pow(0.8f, x - 5f); //even better
            //time = 1f + Mathf.Pow(0.989f, x - 125f); //more  better

            yield return new WaitForSeconds(time);
            //yield return new WaitForSeconds(1);

        }
    }

    public void startSpawn()
    {
        StartCoroutine(Spawner());
    }
}
