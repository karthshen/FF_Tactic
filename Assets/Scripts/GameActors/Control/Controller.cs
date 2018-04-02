﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Controller : MonoBehaviour
{

	private InputHandler inputHandler;
	private GameActor selectedActor;

	// Use this for initialization
	void Start ()
	{
		this.inputHandler = new InputHandler ();
		this.selectedActor = inputHandler.GetSelectedActor ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Command command = null;
		command = inputHandler.HandleInput ();
		if (!ReferenceEquals (command, null))
			command.Execute ();

		this.selectedActor = inputHandler.GetSelectedActor ();

		if (Input.GetKeyUp (KeyCode.Escape)) {
			ExitToMenu ();
		}
	}

	public bool IsCharacterSelected ()
	{
		return !ReferenceEquals (this.selectedActor, null);
	}

	public GameActor GetSelectedActor ()
	{
		return this.selectedActor;
	}

	public void ExitToMenu ()
	{
		SceneManager.LoadScene (0);
	}
}
