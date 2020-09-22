using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float speed;
    private float gameSpeed;
    // Start is called before the first frame update
    void Start()
    {
        gameSpeed = speed;   
    }

    // Update is called once per frame
   
    void Update()
    {
        gameObject.transform.Translate(Vector2.right * Time.deltaTime * gameSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "stop")
        {
            gameSpeed = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "stop")
        {
            gameSpeed = speed;
        }
        if (collision.gameObject.tag == "counter")
        {
            gameSpeed = 1;
        }

    }
}
