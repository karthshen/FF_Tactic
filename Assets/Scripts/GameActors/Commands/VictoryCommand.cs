using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCommand : Command
{

	public VictoryMenuUI victoryMenuUI;

	public VictoryCommand ()
	{
		victoryMenuUI = GameObject.Find ("VictoryMenu").GetComponent<VictoryMenuUI> ();
	}

	public override void Execute ()
	{
		victoryMenuUI.WinGame ();
	}
}
