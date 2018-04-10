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
		if (this.bHasMoved == false) {
			this.currentState = ActorState.Move;
			if (this.currentState == ActorState.Death) {
				return;
			}

			this.FindSelectableMoveTiles ();
			bMinionSelected = true;
			bHasMoved = true;
		}
	}

	public override void Attack ()
	{
		//Combat logic
		if (this.bHasActed == false) {
			this.currentState = ActorState.Attack;
			if (this.currentState == ActorState.Death) {
				return;
			}
			this.FindSelectableAttackTiles ();
			bMinionSelected = true;
		}
	}

	public void Update ()
	{
		this.TacticActorUpdate ();

		Tile t = null;
		if (bMinionSelected && currentState == ActorState.Move) {

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
					this.currentState = ActorState.Idle;
					bMinionSelected = false;
				}
			}
		}

		if (bMinionSelected && currentState == ActorState.Attack && bHasActed == false) {
			if (CheckMouseClick ("Minion")) {
				RaycastHit hit = GetMouseHit ();
				GameActor targetActor = hit.collider.GetComponentInParent<GameActor> ();
				t = GetTargetTile (targetActor.gameObject);
				if (targetActor != null && t.bSelectable) {
					t.bTargetTile = true;
					RotateTowardTarget (targetActor);
					targetActor.TakeDamage (this.GetAttackDamage ());
					bHasActed = true;
					this.PlayAttackAnimation ();
					this.ResetTiles ();
				}
			}
		}

	}

	private void RotateTowardTarget (GameActor actor)
	{
		Vector3 targetDir = actor.transform.position - this.transform.position;
		float step = 2000 * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards (this.transform.forward, targetDir, step, 0.0f);

		transform.rotation = Quaternion.LookRotation (newDir);
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