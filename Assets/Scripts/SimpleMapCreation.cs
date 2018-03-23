using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class MenuItems {


	/*
	public static GameObject GrassTile = GameObject.Find("GrassTile");
	public static  GameObject GroundTile = GameObject.Find("GroundTile");
	public static GameObject RockTile = GameObject.Find ("RockTile");
	public static GameObject WaterTile = GameObject.Find("WaterTile");
*/

	// Use this for initialization
	[MenuItem("Tools/Simple Map Generator")]
	public static void GenerateMap () {

		GameObject WaterTile = GameObject.Find("WaterTile"); //1
		GameObject GrassTile = GameObject.Find("GrassTile");//2
		GameObject GroundTile = GameObject.Find("GroundTile");//3
		GameObject RockTile = GameObject.Find ("RockTile");  //4

		string[] map = { 
			  "1111111111" +
				"1111111111" +
				"1111111111" +
				"1111111111" +
				"1111111111" +
				"1111111111" +
				"1111111111" +
				"1111111111" +
				"1111111111" +
				"1111111111",

			    "2222222222" +
				"2200000022" +
				"2200000022" +
				"2200000022" +
				"2222222222" +
				"2222222222" +
				"2200000022" +
				"2200000022" +
				"2200000022" +
				"2222222222",

				"3334004333" +
				"3334004333" +
				"3334004333" +
				"3334004333" +
				"3334004333" +
				"3334004333" +
				"3334004333" +
				"3334004333" +
				"3334004333" +
				"3334004333"
		};

		for(int a = 0; a<map.Length; a++){
			for (int i = 0; i < 10; i++) {
				for (int j = 0; j < 10; j++) {
					char c = map[a][i * 10 + j];
					Vector3 position0 = new Vector3 (i, a, j);

					switch (c) {
					case '0':
						//GameObject.Instantiate (WaterTile, position0, Quaternion.identity);
						break;
					case '1':
						GameObject.Instantiate (WaterTile, position0, Quaternion.identity);
						break;
					case '2':
						GameObject.Instantiate (GrassTile, position0, Quaternion.identity);
						break;
					case '3':
						GameObject.Instantiate (GroundTile, position0, Quaternion.identity);
						break;
					case '4':
						GameObject.Instantiate (RockTile, position0, Quaternion.identity);
						break;
					}
				}
			}
		}

	}

}
