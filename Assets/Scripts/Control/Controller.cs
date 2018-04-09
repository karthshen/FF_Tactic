﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

	private InputHandler inputHandler;
	private GameActor selectedActor;
	private float loseCountDown = 2.0f;

	private int coinCount;
	public Text countText;

	// Use this for initialization
	void Start ()
	{
		this.inputHandler = new InputHandler ();
		this.selectedActor = inputHandler.GetSelectedActor ();

		//coinCount = 0;
		//countText.text = coinCount.ToString ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.inputHandler.HandleInput ();
		this.selectedActor = inputHandler.GetSelectedActor ();

		//UpdateScore ();
		/* Victory/Lose condition - OLD
		if (this.coinCount >= 40) {
			command = new VictoryCommand ();
			command.Execute ();
		}


		if (this.selectedActor && this.selectedActor.GetHealthPercentage () <= 0) {
			loseCountDown -= Time.deltaTime;
			if (loseCountDown <= 0) {
				command = new LoseCommand ();
				command.Execute ();
			}
		}
		*/
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

	private void UpdateScore ()
	{
		if (selectedActor) {
			this.coinCount = selectedActor.GetCoins ();
			countText.text = coinCount.ToString ();
		}
	}

	public void ButtonMove ()
	{
		Command moveCommand = this.inputHandler.ButtonMove ();
		if (!ReferenceEquals (moveCommand, null))
			moveCommand.Execute ();
	}

	public void ButtonAttack ()
	{
		Command attackCommand = this.inputHandler.ButtonAttack ();
		if (!ReferenceEquals (attackCommand, null))
			attackCommand.Execute ();
	}

	public void ButtonItems ()
	{
		Command itemCommand = this.inputHandler.ButtonItems ();
		if (!ReferenceEquals (itemCommand, null))
			itemCommand.Execute ();
	}

	public void ButtonSpells ()
	{
		Command spellCommand = this.inputHandler.ButtonSpells ();
		if (!ReferenceEquals (spellCommand, null))
			spellCommand.Execute ();
	}
}
