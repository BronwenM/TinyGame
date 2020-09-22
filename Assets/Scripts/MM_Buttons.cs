using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MM_Buttons : MonoBehaviour
{
	public bool start;
	public bool quit;
	public bool htp;
	public bool x;

	public GameObject htplay;

	public AudioClip click;
	AudioSource source;

	public Transitions transitions;

	// Start is called before the first frame update
	void Start()
	{
		source = gameObject.AddComponent<AudioSource>();
		gameObject.GetComponent<TextMesh>().color = Color.white;
		htplay.SetActive(false);
	}

	private void Update()
	{

	}

	void OnMouseEnter()
	{
		source.PlayOneShot(click, 1.0f);
		gameObject.GetComponent<TextMesh>().color = Color.HSVToRGB(239,91,100);
	}

	void OnMouseExit()
	{
		gameObject.GetComponent<TextMesh>().color = Color.white;
	}

	void OnMouseUp()
	{
		if (!source.isPlaying)
		{
			if (start)
			{
				source.PlayOneShot(click, 5.0f);
				transitions.TransitionToLevel(1);
				Debug.Log("lvl1");
			}
			if (quit)
			{
				source.PlayOneShot(click, 5.0f);
				Application.Quit();
				Debug.Log("quit");
			}
			if (htp)
			{
				source.PlayOneShot(click, 5.0f);
				Debug.Log("htp");
				htplay.SetActive(true);
			}
			if (x)
			{
				source.PlayOneShot(click, 5.0f);
				htplay.SetActive(false);
			}
		}
		
	}
}
