using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnCommand : Command
{

	GameActor actor;

	public EndTurnCommand (GameActor actor)
	{
		this.actor = actor;
	}

	public override void Execute ()
	{
		actor.EndTurn ();
	}
}
