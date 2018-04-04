using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenuUI : MonoBehaviour
{

	public GameObject ControlMenuCanvas;

	// Use this for initialization
	void Start ()
	{
		ControlMenuCanvas.SetActive (false);
	}

	public void ControlButton ()
	{
		ControlMenuCanvas.SetActive (true);
	}

	public void Resume ()
	{
		ControlMenuCanvas.SetActive (false);
	}
}
