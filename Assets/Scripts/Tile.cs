using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

	[SerializeField]
	protected bool bWalkable = true;
	//Default all tiles are walkable
	[SerializeField]
	protected bool bHasMinion = false;
	//if tile has a minion
	[SerializeField]
	protected bool bTargetTile = false;
	//if the tile is target tile selecting
	[SerializeField]
	public bool bSelectable = false;
	//if the tile is selectable in this turn

	//default color of this tile
	private Color defaultColor;

	//Graph theroy stuff
	public List<Tile> adj_List = new List<Tile> ();
	public bool visited = false;
	public Tile parent = null;
	public int distance = 0;

	// Use this for initialization
	void Start ()
	{
		defaultColor = GetComponentInChildren<Renderer> ().material.color;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (bHasMinion)
			GetComponentInChildren<Renderer> ().material.color = Color.blue;
		else if (bTargetTile)
			GetComponentInChildren<Renderer> ().material.color = Color.green;
		else if (bSelectable)
			GetComponentInChildren<Renderer> ().material.color = Color.red;
		else {
			GetComponentInChildren<Renderer> ().material.color = defaultColor;
		}
	}

	public void Reset ()
	{
		bHasMinion = false;
		bTargetTile = false;
		bSelectable = false;

		adj_List.Clear ();
		visited = false;
		parent = null;
		distance = 0;
	}

	public void Find_Adj (float jumpHeight)
	{
		Reset ();

		CheckTile (Vector3.forward, jumpHeight);
		CheckTile (-Vector3.forward, jumpHeight);
		CheckTile (Vector3.right, jumpHeight);
		CheckTile (Vector3.left, jumpHeight);

	}

	private void CheckTile (Vector3 direction, float jumpHeight)
	{

		Vector3 halfExtent = new Vector3 (0.25f, jumpHeight / 4, 0.25f);

		Collider[] colliders = Physics.OverlapBox (this.transform.position + direction, halfExtent);

		foreach (Collider obj in colliders) {
			Tile tile = obj.GetComponentInParent<Tile> ();
			if (tile && tile.bWalkable) {
				//@TODO if tile is occupied by enemy, make it not walkable
				adj_List.Add (tile);
			}
		}
	}
}
