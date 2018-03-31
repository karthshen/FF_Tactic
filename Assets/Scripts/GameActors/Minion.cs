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
			if (hit.transform.parent.tag == hitTag) {
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

/*
	// Update is called once per frame
void Update ()
{

	//Don't question this
	if (!bMinionSelected) {
		if (CheckMouseClick ("Minion")) {
			RaycastHit hit = GetMouseHit ();
			int insID = hit.collider.gameObject.GetComponentInParent<Minion> ().GetInstanceID ();
			if (insID == this.InstanceID) {
				this.FindSelectableTiles ();
				bMinionSelected = true;
			}
		} else {
			//If moving, disable the selectable Tile UI
		}

	} else if (bMinionSelected) {
		Tile t = null;
		//if selected, do moving stuff
		if (CheckMouseClick ("Minion")) {
			this.ResetTiles ();
			bMinionSelected = false;
		} else if (CheckMouseClick ("Tile") && !GetIsMoving ()) {
			RaycastHit hit = GetMouseHit ();
			t = hit.collider.GetComponentInParent<Tile> ();
			if (t.bSelectable) {
				t.bTargetTile = true;
				this.SetIsMoving (true);
				//Start move to target tile
				this.MoveToTile (t);
			}
		}

		if (this.GetIsMoving ()) {
			this.MoveOneStep ();
			if (!this.GetIsMoving ())
				this.bMinionSelected = false;
		} 
	}

}
*/