﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameActor : MonoBehaviour
{
	protected float maxHealth;
	protected float maxMana;
	protected float health;
	protected float mana;
	protected int coins;

	protected ActorState currentState;

	public bool bHasMoved = false;
	public bool bHasActed = false;

	//If the Actor is NOT selected and acted this turn
	public bool bTurnReady = true;
	// Use this for initialization
	public abstract void Move ();

	public abstract void Attack ();

	public abstract void EndTurn ();

	public abstract void CharacterSelected ();

	public abstract void CharacterDeselected ();

	protected abstract void Death ();

	public float GetHealthPercentage ()
	{
		return health / maxHealth;
	}

	public float GetManaPercentage ()
	{
		return mana / maxMana;
	}

	public abstract float TakeDamage (float damage);

	public float HealthDamage (float heal)
	{
		this.health += heal;
		if (this.health > 100)
			this.health = 100;

		return this.health;
	}

	public int GetCoins ()
	{
		return this.coins;
	}

	public ActorState GetActorState ()
	{
		return this.currentState;
	}

	public void ResetState ()
	{
		this.currentState = ActorState.Idle;
		this.bHasActed = false;
		this.bHasMoved = false;
	}
}
