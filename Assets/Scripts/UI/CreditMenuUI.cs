using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditMenuUI : MonoBehaviour
{

	public GameObject CreditMenuCanvas;

	// Use this for initialization
	void Start ()
	{
		CreditMenuCanvas.SetActive (false);
	}

	public void CreditButton ()
	{
		CreditMenuCanvas.SetActive (true);
	}

	public void Resume ()
	{
		CreditMenuCanvas.SetActive (false);
	}
}
