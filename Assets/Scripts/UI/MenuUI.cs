using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuUI : MonoBehaviour
{

	// Use this for initialization
	public void StartGame ()
	{
		SceneManager.LoadScene (1);
	}

	public void ExitGame ()
	{
		Application.Quit ();
	}
}
