using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameActor : MonoBehaviour
{
	protected enum State
	{
		Move,
		Attack,
		Idle,
		Death
	}

	protected float maxHealth;
	protected float maxMana;
	protected float health;
	protected float mana;

	protected int coins;

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

	public float TakeDamage (float damage)
	{
		this.health -= damage;
		if (this.health <= 0) {
			this.Death ();
		}

		return this.health;
	}

	public float HealthDamage (float heal)
	{
		this.health += heal;
		if (this.health > 100)
			this.health = 100;

		return this.health;
	}

	protected abstract void Death ();

	public int GetCoins ()
	{
		return this.coins;
	}
}
