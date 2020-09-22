using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelay : MonoBehaviour
{
    public float waitTime = 5.0f;
    public GameManager gameManager;
    public FoodSpawn foodSpawn;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if(waitTime <= 0.0f)
        {
            gameObject.SetActive(false);
            gameManager.startTimer();
            foodSpawn.startSpawn();
        }
    }
}
