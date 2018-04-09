using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
	private GameActor selectedActor;
	private bool bActionUI = false;

	public InputHandler ()
	{
		selectedActor = null;
	}

	public Command HandleInput ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hit)) {
			GameActor actor = hit.collider.GetComponentInParent<GameActor> ();

			/*if (ReferenceEquals (actor, null)) { //If clicked floor or something
				selectedActor.CharacterDeselected ();
				this.selectedActor = null;
			} else */
			/*if (!ReferenceEquals (actor, selectedActor) && !ReferenceEquals (selectedActor, null) && bActionUI == false) { //if clicked on other character
				selectedActor.CharacterDeselected ();
				selectedActor = actor;
				selectedActor.CharacterSelected ();
			} else */
			if (ReferenceEquals (actor, selectedActor)) { //if clicked on same character
				selectedActor.CharacterDeselected ();
				selectedActor = null;
			} else if (!ReferenceEquals (actor, null)) { //if clicked on a new character
				if (selectedActor != null) {
					selectedActor.CharacterDeselected ();
				}
				selectedActor = actor;
				selectedActor.CharacterSelected ();
			}
				
			//@TODO move this to the ActionUI
			/*
			if (!ReferenceEquals (actor, null)) {
				MoveCommand command = new MoveCommand (actor);
				return command;
			}*/
		}

		if (Input.GetKeyUp (KeyCode.Escape)) {
			PauseMenuCommand pauseMenuCommand = new PauseMenuCommand ();
			return pauseMenuCommand;
		}

		if (!ReferenceEquals (selectedActor, null)) {
			bActionUI = true;
		} else {
			bActionUI = false;
		}

		return null;
	}

	public GameActor GetSelectedActor ()
	{
		return selectedActor;
	}

	public Command ButtonMove ()
	{
		if (bActionUI) {
			MoveCommand command = new MoveCommand (selectedActor);
			return command;
		}
		return null;
	}

	public Command ButtonAttack ()
	{
		return null;
	}

	public Command ButtonItems ()
	{
		return null;
	}

	public Command ButtonSpells ()
	{
		return null;
	}
}
