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

	protected float maxHealth;
	protected float maxMana;
	protected float health;
	protected float mana;

	protected State currentState;
	// Use this for initialization
	public abstract void Move ();

	public abstract void Attack ();

	public float GetHealthPercentage ()
	{
		return health / maxHealth;
	}

	public float GetManaPercentage ()
	{
		return mana / maxMana;
	}
}
