using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticCamera : MonoBehaviour
{

	[SerializeField] private float cameraSpeed = 1.0f;
	[SerializeField] private float rotation = 10;
	[SerializeField] private float rotationMax = 3;

	private int rotateCount = 0;

	private void Update ()
	{
		if (Input.GetButton ("CameraUp"))
			this.CameraUp ();
		if (Input.GetButton ("CameraDown"))
			this.CameraDown ();
		if (Input.GetButton ("CameraLeft"))
			this.CameraLeft ();
		if (Input.GetButton ("CameraRight"))
			this.CameraRight ();

		//CameraMovement (x, z);
	}

	private void CameraRight ()
	{
		this.transform.Translate (cameraSpeed * Time.deltaTime, 0, cameraSpeed * Time.deltaTime);
	}

	private void CameraLeft ()
	{
		this.transform.Translate (-cameraSpeed * Time.deltaTime, 0, -cameraSpeed * Time.deltaTime);
	}

	private void CameraUp ()
	{
		this.transform.Translate (-cameraSpeed * Time.deltaTime, 0, cameraSpeed * Time.deltaTime);
	}

	private void CameraDown ()
	{
		this.transform.Translate (cameraSpeed * Time.deltaTime, 0, -cameraSpeed * Time.deltaTime);
	}

	//Rotate Left
	public void RotateLeft ()
	{
		if (rotateCount > -rotationMax) {
			rotateCount--;
			this.transform.Rotate (Vector3.up, -rotation, Space.World);
		}
	}

	//Rotate Right
	public void RotateRight ()
	{
		if (rotateCount < rotationMax) {
			rotateCount++;
			this.transform.Rotate (Vector3.up, rotation, Space.World);
		}
	}
}
