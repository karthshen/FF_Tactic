using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
	GameActor actor;

	public MoveCommand (GameActor actor)
	{
		this.actor = actor;
		//this.GetInstanceID ();
	}

	public override void Execute ()
	{
		actor.Move ();
	}
}
