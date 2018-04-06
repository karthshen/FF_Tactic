using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TacticPickup : MonoBehaviour
{

	protected PickupType type;

	public enum PickupType
	{
		Chest,
		Weapon,
		Potion
	}

	public TacticPickup ()
	{
		
	}

	public abstract void Pickup (TacticActor actor);

	public abstract void DestoryPickup ();

	public PickupType GetPickupType ()
	{
		return this.type;
	}
}
