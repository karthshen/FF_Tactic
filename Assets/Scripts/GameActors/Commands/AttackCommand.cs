using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command
{

	GameActor actor;

	public AttackCommand (GameActor actor)
	{
		this.actor = actor;
	}

	public override void Execute ()
	{
		actor.Move ();
	}
}
