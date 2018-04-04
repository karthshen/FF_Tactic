using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
	private GameActor selectedActor;

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

			if (!ReferenceEquals (actor, null)) {
				selectedActor = actor;
			}
			if (actor != null) {
				MoveCommand command = new MoveCommand (actor);
				return command;
			}
		}

		return null;
	}

	public GameActor GetSelectedActor ()
	{
		return selectedActor;
	}
}
