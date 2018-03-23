using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMove : TacticMove
{
	private bool bMinionSelected = false;
	// Use this for initialization
	void Start ()
	{
		Init ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (!bMinionSelected) {
			if (CheckMouseClick ("Minion")) {
				this.FindSelectableTiles ();
				bMinionSelected = true;
			} else {
			
				//If moving, disable the selectable Tile UI
			}

		} else if (bMinionSelected) {
			//if selected, do moving stuff
			if (CheckMouseClick ("Minion")) {
				this.ResetTiles ();
				bMinionSelected = false;
			} else if (CheckMouseClick ("Tile")) {
				RaycastHit hit = GetMouseHit ();
				Tile t = hit.collider.GetComponentInParent<Tile> ();
				if (t.bSelectable) {
					t.bTargetTile = true;
					this.SetIsMoving (false);
				}
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
