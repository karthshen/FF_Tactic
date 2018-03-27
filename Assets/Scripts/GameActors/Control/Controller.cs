using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

	private InputHandler inputHandler;

	// Use this for initialization
	void Start ()
	{
		this.inputHandler = new InputHandler ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Command command = null;
		command = inputHandler.HandleInput ();
		if (!ReferenceEquals (command, null))
			command.Execute ();
	}
}
