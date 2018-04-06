using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{

	public GameObject pauseMenuCanvas;

	// Use this for initialization
	void Start ()
	{
		pauseMenuCanvas.SetActive (false);
	}

	public void PauseGame ()
	{
		pauseMenuCanvas.SetActive (true);
	}

	public void ResumeGame ()
	{
		pauseMenuCanvas.SetActive (false);
	}

	public void MainMenu ()
	{
		SceneManager.LoadScene (0);
	}
}
