using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishControl : MonoBehaviour
{
    //public float cooldown = 0.5f;
    //private float cool = 0;




    private GameManager gameManager;
    public GameObject leverUp;
    public GameObject leverDown;

    public AudioClip crush;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        leverDown.SetActive(false);
        leverUp.SetActive(true);
        source = gameObject.AddComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        // if (cool == 0)
        //{
        if (!source.isPlaying && Input.GetKey("down") && gameManager.gameOver == false)
        {
            source.PlayOneShot(crush, 1.0f);
            leverDown.SetActive(true);
            leverUp.SetActive(false);
            gameObject.transform.position = new Vector2(0.79f, 1.5f);
        }

        //cool = cool + Time.deltaTime;
        //  }
        //else
        //{
        //     cool = cool + Time.deltaTime;
        // }
        if (Input.GetKeyUp("down") || gameManager.gameOver == true)
        {
            leverDown.SetActive(false);
            leverUp.SetActive(true);
            gameObject.transform.position = new Vector2(0.79f, 6.075f);
        }
        // if (cool == cooldown)
        // {
        //cool = 0;
        // }

    }

}
