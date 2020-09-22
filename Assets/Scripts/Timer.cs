using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeLimit = 120;
    public Text texter;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountingDown());
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        texter.text = "" + timeLimit;
        
        if(timeLimit <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }

    IEnumerator CountingDown ()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLimit--;
        }
    }
}
