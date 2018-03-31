using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameActor : MonoBehaviour
{
	protected enum State
	{
		Move,
		Attack,
		Idle
	}

	protected State currentState;
	// Use this for initialization
	public abstract void Move ();

	public abstract void Attack ();
}
