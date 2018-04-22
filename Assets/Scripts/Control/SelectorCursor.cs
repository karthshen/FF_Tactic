using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorCursor : MonoBehaviour
{

	private bool bDisplay = false;
	private Vector3 position;

	public AnimationCurve cursorCurve;

	void Start ()
	{
		
	}

	void Update ()
	{
		
	}

	public void CursorDisplay ()
	{
		this.bDisplay = true;
		this.gameObject.SetActive (bDisplay);
	}

	public void CursorDisappear ()
	{
		this.bDisplay = false;
		this.gameObject.SetActive (bDisplay);
	}

	public void UpdatePosition (Vector3 ActorPosition)
	{
		this.position = ActorPosition;
		this.position.y += 1 + cursorCurve.Evaluate (Time.time % cursorCurve.length);
		this.transform.position = position;
	}
}
