using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameActorStat : MonoBehaviour
{

	private Image content;
	private Controller controller;

	[SerializeField]
	private bool HealthBar = false;
	[SerializeField]
	private bool ManaBar = false;
	// Use this for initialization
	void Start ()
	{
		controller = GameObject.Find ("Gameboard").GetComponent<Controller> ();
		content = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (controller.IsCharacterSelected ()) {
			if (HealthBar)
				content.fillAmount = controller.GetSelectedActor ().GetHealthPercentage ();
			if (ManaBar)
				content.fillAmount = controller.GetSelectedActor ().GetManaPercentage ();
		} else
			content.fillAmount = 0;
	}
}
