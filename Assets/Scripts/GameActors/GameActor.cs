using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameActor : MonoBehaviour
{

	// Use this for initialization
	public abstract void Move ();

	public abstract void Attack ();
}
