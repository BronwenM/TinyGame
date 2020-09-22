using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Fail Counter
    public Text failCounter;
    private int fail = 0;
    public bool gameOver;

    //Lose Audio
    public AudioClip youLose;
    private AudioSource loseSource;

    //MainTheme Audio
    public AudioClip theme;
    private AudioSource themeSource;

    //Timer
    private int timeLimit = 120;
    public Text texter;

    //Points
    public Text points;
    private int totalPoints;
    public int keepG = 50;
    public int keepB = -50;
    public int destG = -100;
    public int destB = 100;

    // Start is called before the first frame update
    void Start()
    {
        //Audio
        themeSource = gameObject.AddComponent<AudioSource>();
        loseSource = gameObject.AddComponent<AudioSource>();
        themeSource.PlayOneShot(theme, 0.5f);

        //Fail
        gameOver = false;
        failCounter.text = "";


        //Timer
        Time.timeScale = 1;

        //Points
        points.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            StopAllCoroutines();
        }
        if (gameOver == true && !loseSource.isPlaying)
        {
            themeSource.Stop();
            loseSource.PlayOneShot(youLose, 0.3f);
        }
        if (gameOver == true && Input.GetKey(KeyCode.X))
        {
            Application.Quit();
        }

        //Timer
        texter.text = "" + timeLimit;

        if (timeLimit <= 0)
        {
            gameOver = true;
            Debug.Log("GAME OVER");
        }
    }

    public void squashCorrect(bool hitter)
    {
        if (hitter == false)
        {
            pointsCalculator(destG);
            fail++;
            failCounter.text += " X ";
        }
        else if (hitter)
        {
            pointsCalculator(destB);
        }
        if (fail == 3)
        {
            failCounter.text = "GAME OVER. PRESS X TO QUIT";
            gameOver = true;
        }
    }

    IEnumerator CountingDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLimit--;
        }
    }

    public void pointsCalculator(int add)
    {
        totalPoints += add;
        points.text = "" + totalPoints;
    }

    public void startTimer()
    {
        StartCoroutine(CountingDown());
    }
}
