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

	public void HandleInput ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hit)) {
			GameActor actor = hit.collider.GetComponentInParent<GameActor> ();
		
			//1. If nothing is selected, select the clicked minion
			//2. If same minion is clicked, deselect the minion
			//3. If another minion clicked while current is idle, switch minion.
			//UPDATE: The GameActor selection is now handled by TurnManager
			/*
			if (selectedActor == null && !ReferenceEquals (actor, null)) {
				selectedActor = actor;
				selectedActor.CharacterSelected ();
			} else if (ReferenceEquals (actor, selectedActor)) {
				selectedActor.CharacterDeselected ();
				selectedActor = null;
			} else if (selectedActor.GetActorState () == ActorState.Idle
			           && selectedActor.bHasMoved == false && selectedActor.bHasActed == false) {

				selectedActor.CharacterDeselected ();
				selectedActor = actor;
				selectedActor.CharacterSelected ();
			}*/
				
		}

		if (Input.GetKeyUp (KeyCode.Escape)) {
			PauseMenuCommand pauseMenuCommand = new PauseMenuCommand ();
			pauseMenuCommand.Execute ();
		}

		if (!ReferenceEquals (selectedActor, null)) {
			bActionUI = true;
		} else {
			bActionUI = false;
		}
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
		if (bActionUI) {
			AttackCommand command = new AttackCommand (selectedActor);
			return command;
		}
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

	public Command ButtonEndTurn ()
	{
		if (bActionUI) {
			EndTurnCommand command = new EndTurnCommand (selectedActor);
			this.selectedActor = null;
			return command;
		}
		return null;
	}

	public void SetGameActor (GameActor actor)
	{
		this.selectedActor = actor;
	}
}
