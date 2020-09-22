using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public Animator animator;
    private int lvlToLoad;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Escape))
        //{
        //    TransitionToLevel(1);
        //}
    }

    public void TransitionToLevel(int lvlIndex)
    {
        lvlToLoad = lvlIndex;
        animator.SetTrigger("Fader");
      
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(lvlToLoad);
    }
}
