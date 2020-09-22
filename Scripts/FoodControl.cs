using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodControl : MonoBehaviour
{


    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "destroy")
    //    {
    //        Debug.Log("Squish");
    //        Destroy(gameObject);
    //    }

    //}

    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("destroy"))
        {
            if (!gameObject.CompareTag("toDestroy"))
            {
                gameManager.squashCorrect(false);
                //gameManager.pointsCalculator(gameManager.destG);
                Destroy(gameObject);  
            }
            if (gameObject.CompareTag("toDestroy"))
            {
               
                gameManager.squashCorrect(true);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("basket"))
        {
            Debug.Log("Collided w/ Basket");
            if (!gameObject.CompareTag("toDestroy"))
            {
                gameManager.pointsCalculator(gameManager.keepG);
                Destroy(gameObject);
            }
            if (gameObject.CompareTag("toDestroy"))
            {
                gameManager.squashCorrect(false);
                gameManager.pointsCalculator(50);
                Destroy(gameObject);
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
