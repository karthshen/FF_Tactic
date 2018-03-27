using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

	public InputHandler ()
	{
	}

	public Command HandleInput ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hit)) {
			GameActor actor = hit.collider.GetComponentInParent<GameActor> ();
			if (actor != null) {
				MoveCommand command = new MoveCommand (actor);
				return command;
			}
		}

		return null;
	}

}
