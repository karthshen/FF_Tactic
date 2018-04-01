using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

	#if DEBUG_GAME
	[SerializeField] 
	private float DEBUG_test_height = 1f;
	#endif
	[SerializeField]
	public bool bWalkable = true;
	//Default all tiles are walkable
	[SerializeField]
	public bool bHasEntity = false;
	//if tile has a minion
	[SerializeField]
	public bool bTargetTile = false;
	//if the tile is target tile selecting
	[SerializeField]
	public bool bSelectable = false;
	//if the tile is selectable in this turn

	//default color of this tile
	private Color defaultColor;
	//Blinking Color
	private Color lerpColor;
	private float lerpTime = 1.2f;

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
		#if DEBUG_GAME
		if (bHasMinion)
			lerpColor = Color.red;
		else 
		#endif
		if (bTargetTile)
			lerpColor = Color.Lerp (defaultColor, Color.red, Mathf.PingPong (Time.time, lerpTime));
		else if (bSelectable)
			lerpColor = Color.Lerp (defaultColor, Color.black, Mathf.PingPong (Time.time, lerpTime));
		else {
			lerpColor = defaultColor;
		}
			
		GetComponentInChildren<Renderer> ().material.color = lerpColor;
	}

	public void Reset ()
	{
		if (GetObjectOnTile ()) {
			bHasEntity = true;
		} else {
			bHasEntity = false;
		}

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

	public GameObject GetObjectOnTile ()
	{
		Vector3 halfExtent = new Vector3 (0.25f, 0.25f, 0.25f);
		Collider[] colliders = Physics.OverlapBox (this.transform.position + Vector3.up, halfExtent);
		foreach (Collider obj in colliders) {
			GameObject tileObject = obj.gameObject;
			if (tileObject)
				return tileObject;
		}

		return null;
	}

	private void CheckTile (Vector3 direction, float jumpHeight)
	{

		Vector3 halfExtent = new Vector3 (0.25f, (jumpHeight), 0.25f);

		Collider[] colliders = Physics.OverlapBox (this.transform.position + direction, halfExtent);

		foreach (Collider obj in colliders) {
			Tile tile = obj.GetComponentInParent<Tile> ();
			if (tile && tile.bWalkable && !tile.bHasEntity && tile.CheckSurfaceTile ()) {
				//@TODO if tile is occupied by enemy, make it not walkable
				adj_List.Add (tile);
			}
		}
	}

	private bool CheckSurfaceTile ()
	{
		Vector3 halfExtent = new Vector3 (0.1f, 0.1f, 0.1f);

		Collider[] colliders = Physics.OverlapBox (this.transform.position + Vector3.up, halfExtent);
		//Collider collider = Physics.CheckBox (this.transform.position + Vector3.up, halfExtent);
		foreach (Collider obj in colliders) {
			Tile tile = obj.GetComponentInParent<Tile> ();
			if (tile)
				return false;
		}
		return true;
	}

	public void SetHasEntity (bool bHasEntity)
	{
		this.bHasEntity = bHasEntity;
	}
}
