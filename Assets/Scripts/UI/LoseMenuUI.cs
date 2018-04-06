using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenuUI : MonoBehaviour
{

	public GameObject LoseMenuCanvas;

	// Use this for initialization
	void Start ()
	{
		LoseMenuCanvas.SetActive (false);
	}

	public void LoseGame ()
	{
		LoseMenuCanvas.SetActive (true);
	}

	public void ResumeGame ()
	{
		LoseMenuCanvas.SetActive (false);
	}

	public void MainMenu ()
	{
		SceneManager.LoadScene (0);
	}
}
