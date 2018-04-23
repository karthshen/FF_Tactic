using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

	private GameObject[] minions;
	private List<GameActor> human = new List<GameActor> ();
	private List<GameActor> orc = new List<GameActor> ();
	private List<GameActor> allMinion = new List<GameActor> ();

	private int turnCount;

	// Use this for initialization
	public TurnManager ()
	{
		minions = GameObject.FindGameObjectsWithTag ("Minion");
		foreach (GameObject minion_t in minions) {
			GameActor minion = minion_t.GetComponent<GameActor> ();
			allMinion.Add (minion);
			if (minion.gameObject.name.Contains ("Human")) {
				human.Add (minion);
			} else if (minion.gameObject.name.Contains ("Orc")) {
				orc.Add (minion);
			}
		}

		turnCount = 0;
	}

	public GameActor GetCurrentMinion ()
	{
		int index = Random.Range (0, allMinion.Count);
		if (allMinion [index] != null && allMinion [index].bTurnReady) {
			allMinion [index].bTurnReady = false;
			return allMinion [index];
		} else {
			return GetCurrentMinion ();
		}
	}

	public void CheckTurnOver ()
	{
		foreach (GameActor minion in allMinion) {
			if (minion != null && minion.bTurnReady == true)
				return;
		}

		//If every minion has moved this turn, then reset the minion state
		foreach (GameActor minion in allMinion) {
			minion.bTurnReady = true;
		}

		turnCount++;
		Debug.Log ("Current Turn: " + turnCount);
	}

	public bool CheckOrcVictory ()
	{
		foreach (GameActor minion in human) {
			if (minion != null)
				return false;
		}

		return true;
	}

	public bool CheckHumanVictory ()
	{
		foreach (GameActor minion in orc) {
			if (minion != null)
				return false;
		}

		return true;
	}
}
