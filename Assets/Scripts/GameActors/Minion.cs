using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : TacticActor
{


	private bool bMinionSelected = false;
	// Use this for initialization
	void Start ()
	{
		Init ();
	}

	public override void Move ()
	{
		if (this.currentState == State.Death) {
			return;
		}

		if (bMinionSelected == true) {
			this.ResetTiles ();
			bMinionSelected = false;
		} else {

			this.FindSelectableTiles ();
			bMinionSelected = true;

			this.currentState = State.Move;
		}
	}

	public void Update ()
	{
		this.TacticActorUpdate ();

		Tile t = null;
		if (bMinionSelected && currentState == State.Move) {

			if (CheckMouseClick ("Tile") && GetIsMoving () == false) {
				RaycastHit hit = GetMouseHit ();
				t = hit.collider.GetComponentInParent<Tile> ();

				if (t != null && t.bSelectable) {
					t.bTargetTile = true;
					this.SetIsMoving (true);
					this.MoveToTile (t);
				}
			}

			if (this.GetIsMoving ()) {
				this.MoveOneStep ();
				if (!this.GetIsMoving ()) //when stopped
					this.bMinionSelected = false;
			}

			//Temp pickup code
			if (CheckMouseClick ("Pickup") && GetIsMoving () == false) {
				RaycastHit hit = GetMouseHit ();
				TacticPickup pickup = hit.collider.gameObject.GetComponent<TacticPickup> ();
				if (pickup && DetectPickup (pickup.GetComponent<Collider> ())) {
					pickup.Pickup (this);
					this.ResetTiles ();
					this.currentState = State.Idle;
					bMinionSelected = false;
				}
			}
		}

		if (bMinionSelected && currentState == State.Attack) {
			
		}

	}

	public override void Attack ()
	{
		//Combat logic
		this.currentState = State.Attack;
	}

	private bool CheckMouseClick (string hitTag)
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hit)) {
			if (hit.transform.parent.tag == hitTag || hit.transform.tag == hitTag) {
				return true;
			}
		}

		return false;
	}

	private RaycastHit GetMouseHit ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast (ray, out hit);
		return hit;
	}
}