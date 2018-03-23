using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMove : TacticMove
{

	// Use this for initialization
	void Start ()
	{
		Init ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit; 

		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hit)) {
			if (hit.transform.tag == "Minion") {
				this.FindSelectableTiles ();
			}
		}
	}
}
