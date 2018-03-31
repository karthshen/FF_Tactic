﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TacticActor : GameActor
{
	private List<Tile> selectableTiles = new List<Tile> ();
	private GameObject[] gameboard;

	private Stack<Tile> path = new Stack<Tile> ();
	//path to the target
	private Tile currentTile;
	//current tile this minion is on

	[SerializeField]
	private float maxHealthT = 100f;
	[SerializeField]
	private float maxManaT = 100f;


	[SerializeField]
	private int move = 5;
	[SerializeField]
	private float jumpHeight = 1f;
	[SerializeField]
	private float moveSpeed = 1f;
	private bool bIsMoving = false;

	private Animation animat;

	Vector3 velocity = new Vector3 ();
	Vector3 targetDirection = new Vector3 ();

	float halfHeight;

	protected void Init ()
	{
		gameboard = GameObject.FindGameObjectsWithTag ("Tile");
		halfHeight = GetComponentInChildren<MeshRenderer> ().bounds.extents.y;
		this.currentState = State.Idle;
		this.ResetTiles ();

		this.animat = GetComponent<Animation> ();
		this.animat.Play ("Idle");

		this.maxHealth = maxHealthT;
		this.maxMana = maxManaT;

		this.health = maxHealth;
		this.mana = maxMana;

	}


	public override void Move ()
	{
	}

	public override void Attack ()
	{
		
	}

	public void TacticActorUpdate ()
	{
		if (animat != null) {

			if (this.currentState == State.Idle) {
				animat.Play ("Idle");
			} else if (this.currentState == State.Move) {
				animat.Play ("RunFront");
			}
		}
	}

	public void ComputeAdjList ()
	{
		foreach (GameObject tile in gameboard) {
			Tile t = tile.GetComponent<Tile> ();
			if (t) {
				t.Find_Adj (this.jumpHeight);
			}
		}
	}

	public void FindSelectableTiles ()
	{
		ComputeAdjList ();
		GetCurrentTile ();

		Queue<Tile> queue = new Queue<Tile> ();

		//BFS
		queue.Enqueue (currentTile);
		currentTile.visited = true;
		currentTile.SetHasMinion (true);

		while (queue.Count > 0) {
			Tile t = queue.Dequeue ();

			t.bSelectable = true;
			selectableTiles.Add (t);
			//if the tile interested is in the move count
			if (t.distance < this.move) {
				foreach (Tile tile in t.adj_List) {
					if (!tile.visited) {
						tile.parent = t;
						tile.visited = true;
						tile.distance = tile.parent.distance + 1;
						queue.Enqueue (tile);
					}
				}
			}
		}
	}

	public void ResetTiles ()
	{
		foreach (Tile tile in selectableTiles) {
			tile.Reset ();
		}

		selectableTiles.Clear ();
		this.currentState = State.Idle;
	}

	public void ResetXRotation ()
	{
		this.transform.rotation = Quaternion.Euler (new Vector3 (0, transform.eulerAngles.y, transform.eulerAngles.z));
	}

	public void MoveToTile (Tile targetTile)
	{
		path.Clear ();

		//Safe guard
		if (!targetTile.bTargetTile)
			targetTile.bTargetTile = true;

		Tile nextTile = targetTile;
		while (nextTile != null) {
			path.Push (nextTile);
			nextTile = nextTile.parent;
		}

	}

	public void MoveOneStep ()
	{
		if (path.Count > 0) {
			//move
			this.currentState = State.Move;
			Tile t = path.Peek ();
			Vector3 target = t.transform.position;

			//Unit position after move
			target.y += halfHeight + t.GetComponentInChildren<Collider> ().bounds.extents.y;

			if (Vector3.Distance (transform.position, target) >= 0.05) {
				//keep going
				CalculateDest (target);
				SetHorizontalVelocity ();
				transform.forward = targetDirection;
				transform.position += velocity * Time.deltaTime;
			} else {
				//Minion reached tile
				transform.position = target;
				path.Pop ();
			}
		} else {
			//not move, out of path
			this.SetIsMoving (false);
			ResetTiles ();

			ResetXRotation ();
		}
	}

	private void CalculateDest (Vector3 target)
	{
		this.targetDirection = target - transform.position;
		targetDirection.Normalize ();
	}

	private void SetVerticalVelocity ()
	{
		
	}

	private void SetHorizontalVelocity ()
	{
		velocity = targetDirection * moveSpeed;
	}


	//Getters and Setters
	public bool GetIsMoving ()
	{
		return this.bIsMoving;
	}

	public void SetIsMoving (bool bIsMoving)
	{
		this.bIsMoving = bIsMoving;
	}


	public int GetMove ()
	{
		return move; 
	}

	public float GetJumpHeight ()
	{
		return jumpHeight;
	}

	public void GetCurrentTile ()
	{
		currentTile = GetTargetTile (this.gameObject);
	}

	public Tile GetTargetTile (GameObject target)
	{

		RaycastHit hit;
		Tile targetTile = null;

		if (Physics.Raycast (target.transform.position, -Vector3.up, out hit, 1f)) {
			targetTile = hit.collider.GetComponentInParent<Tile> ();
		}

		return targetTile;
	}

	public float GetHealthPercentage ()
	{
		return health / maxHealth;
	}

	public float GetManaPercentage ()
	{
		return mana / maxMana;
	}
}


