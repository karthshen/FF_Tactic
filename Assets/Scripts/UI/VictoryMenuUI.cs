using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuUI : MonoBehaviour
{

	public GameObject victoryMenuCanvas;

	// Use this for initialization
	void Start ()
	{
		victoryMenuCanvas.SetActive (false);
	}

	public void WinGame ()
	{
		victoryMenuCanvas.SetActive (true);
	}

	public void ResumeGame ()
	{
		victoryMenuCanvas.SetActive (false);
	}

	public void MainMenu ()
	{
		SceneManager.LoadScene (0);
	}
}
