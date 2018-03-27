using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMove : TacticMove
{
	private bool bMinionSelected = false;
	private int InstanceID;
	// Use this for initialization
	void Start ()
	{
		Init ();
		InstanceID = this.GetInstanceID ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		//Don't question this
		if (!bMinionSelected) {
			if (CheckMouseClick ("Minion")) {
				RaycastHit hit = GetMouseHit ();
				int insID = hit.collider.gameObject.GetComponentInParent<MinionMove> ().GetInstanceID ();
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
