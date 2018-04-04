using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCommand : Command
{

	private LoseMenuUI loseMenuUI;

	public LoseCommand ()
	{
		loseMenuUI = GameObject.Find ("LoseMenu").GetComponent<LoseMenuUI> ();
	}


	public override void Execute ()
	{
		loseMenuUI.LoseGame ();
	}
}
