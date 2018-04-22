using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticCamera : MonoBehaviour
{

	[SerializeField] private float cameraSpeed = 1.0f;
	[SerializeField] private float rotation = 10;
	[SerializeField] private float rotationMax = 3;

	public SelectorCursor cursor;

	private Camera camera;
	private int rotateCount = 0;
	private bool cameraStick = true;

	void Start ()
	{
		camera = this.GetComponentInChildren<Camera> ();
	}

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
		if (Input.GetKeyUp (KeyCode.LeftShift))
			this.cameraStick = !cameraStick;

		if (Input.GetButton ("CameraRotateLeft"))
			this.ZoomIn ();
		if (Input.GetButton ("CameraRotateRight"))
			this.ZoomOut ();
		//CameraMovement (x, z);
		if (cursor && cursor.gameObject.activeSelf) {
			Vector3 newPosition = cursor.gameObject.transform.position;
			newPosition.y = this.transform.position.y;
			//This part is magic number
			newPosition.x += 10;
			newPosition.z += 5;
			if (cameraStick)
				this.transform.position = Vector3.Lerp (this.transform.position, newPosition, 0.2f);
		}
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
	public void ZoomIn ()
	{
		

		//Use this function for zoom in and zoom out instead
		if (camera.orthographicSize > 4)
			camera.orthographicSize -= Time.deltaTime;
	}

	//Rotate Right
	public void ZoomOut ()
	{
		if (camera.orthographicSize < 10)
			camera.orthographicSize += Time.deltaTime;
	}
}
