using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : TacticPickup
{
	private Mesh primaryMesh;
	private Mesh secondaryMesh;

	private GameObject openChest;

	private AudioSource chestOpenFX;

	[SerializeField]
	private int coins = 10;

	[SerializeField]
	private float destoryCountdown = 5.0f;

	public TreasureChest ()
	{
		
	}

	public void Start ()
	{
		this.type = PickupType.Chest;
		this.primaryMesh = this.GetComponent<MeshFilter> ().mesh;
		this.openChest = GameObject.Find ("OpenChest");
		this.secondaryMesh = openChest.GetComponent<MeshFilter> ().mesh;

		this.chestOpenFX = GameObject.Find ("ChestAudio").GetComponent<AudioSource> ();
	}

	public void Update ()
	{
		if (this.coins == 0) {
			destoryCountdown -= Time.deltaTime;
			if (destoryCountdown <= 0) {
				this.DestoryPickup ();
			}
		}
	}

	public override void Pickup (TacticActor actor)
	{
		this.GetComponent<MeshFilter> ().mesh = secondaryMesh;
		this.chestOpenFX.Play ();
		actor.addPickupItem (this);
		this.coins = 0;
	}

	public override void DestoryPickup ()
	{
		Object.Destroy (this.gameObject);
		Object.Destroy (this);
	}

	public int getCoins ()
	{
		return this.coins;
	}
}
