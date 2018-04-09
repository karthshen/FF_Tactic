using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticTrap : GameActor
{


	[SerializeField]
	private int attackDmg = 10;
	[SerializeField]
	private bool bIsMoving = false;

	private Animation animat;
	private float halfHeight;
	// Use this for initialization
	void Start ()
	{
		this.currentState = ActorState.Attack;
		animat = GetComponent<Animation> ();
		halfHeight = GetComponentInChildren<MeshRenderer> ().bounds.extents.y;
	}



	public override void Move ()
	{
		
	}

	public override void CharacterSelected ()
	{
		
	}

	public override void CharacterDeselected ()
	{
		
	}

	public override void Attack ()
	{
		//throw new System.NotImplementedException ();
	}

	protected override void Death ()
	{
		
	}

	public int GetAttackDamage ()
	{
		return this.attackDmg;
	}
}
