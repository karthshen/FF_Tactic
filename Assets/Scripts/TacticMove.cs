using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticMove : MonoBehaviour
{
	private List<Tile> selectableTiles = new List<Tile> ();
	private GameObject[] gameboard;

	private Stack<Tile> path = new Stack<Tile> ();
	//path to the target
	private Tile currentTile;
	//current tile this minion is on

	[SerializeField]
	private int move = 5;
	private float jumpHeight = 1;
	private bool bIsMoving = false;

	Vector3 velocity = new Vector3 ();
	Vector3 target = new Vector3 ();

	float halfHeight;

	//Getters and Setters
	public bool GetIsMoving ()
	{
		return this.bIsMoving;
	}

	public void SetIsMoving (bool bIsMoving)
	{
		this.bIsMoving = bIsMoving;
	}

	protected void Init ()
	{
		gameboard = GameObject.FindGameObjectsWithTag ("Tile");
		halfHeight = GetComponent<Collider> ().bounds.extents.y;
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
	}


}


