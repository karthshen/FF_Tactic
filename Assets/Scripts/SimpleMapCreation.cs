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
		GameObject GrassTile = GameObject.Find("GrassTile");
		GameObject GroundTile = GameObject.Find("GroundTile");
		GameObject RockTile = GameObject.Find ("RockTile");
		GameObject WaterTile = GameObject.Find("WaterTile");

		string map =
			"03211110210311332232\n13220311232201103010\n11120002233101003300\n23302002213132232000\n12331111033021323331\n33031230223012103013\n33331122333031223031\n02022012132100211002\n30312313132223231323\n12131223332200103232\n30333312221300021010\n02112233222300230022\n00332323123321013112\n31120122231223202033\n22222302320030201022\n10322020220311200100\n11000111033202233313\n32301010300320013031\n20112203212223031203\n03131131123131030320";
		
		for (int i = 0; i < 20; i++) {
			for (int j = 0; j < 20; j++) {
				char c = map [i * 10 + j];
				Vector3 position0 = new Vector3 (i, 0, j);
				Vector3 position1 = new Vector3 (i, 1, j);
				Vector3 position2 = new Vector3 (i, 2, j);
				Vector3 position3 = new Vector3 (i, 3, j);

				switch (c) {
				case '0':
					GameObject.Instantiate (WaterTile, position0, Quaternion.identity);
					break;
				case '1':
					GameObject.Instantiate (WaterTile, position0, Quaternion.identity);
					GameObject.Instantiate (GrassTile, position1, Quaternion.identity);
					break;
				case '2':
					GameObject.Instantiate (WaterTile, position0, Quaternion.identity);
					GameObject.Instantiate (GrassTile, position1, Quaternion.identity);
					GameObject.Instantiate (RockTile, position2, Quaternion.identity);
					break;
				case '3':
					GameObject.Instantiate (WaterTile, position0, Quaternion.identity);
					GameObject.Instantiate (GrassTile, position1, Quaternion.identity);
					GameObject.Instantiate (RockTile, position2, Quaternion.identity);
					GameObject.Instantiate (GroundTile, position3, Quaternion.identity);
					break;
				}
			}
		}

	}

}
