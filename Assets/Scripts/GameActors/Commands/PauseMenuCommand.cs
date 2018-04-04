using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuCommand : Command
{
	
	private PauseMenuUI pauseMenuUI;

	public PauseMenuCommand ()
	{
		this.pauseMenuUI = GameObject.Find ("PauseMenu").GetComponent<PauseMenuUI> ();
	}

	public override void Execute ()
	{
		pauseMenuUI.PauseGame ();
	}
}
