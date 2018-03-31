﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class MenuItems
{


	/*
	public static GameObject GrassTile = GameObject.Find("GrassTile");
	public static  GameObject GroundTile = GameObject.Find("GroundTile");
	public static GameObject RockTile = GameObject.Find ("RockTile");
	public static GameObject WaterTile = GameObject.Find("WaterTile");
*/

	// Use this for initialization
	[MenuItem ("Tools/Simple Map Generator")]
	public static void GenerateMap ()
	{

		int size = 27;

		GameObject WaterTile = GameObject.Find ("WaterTile"); //1
		GameObject GrassTile = GameObject.Find ("GrassTile");//2
		GameObject GroundTile = GameObject.Find ("GroundTile");//3
		GameObject RockTile = GameObject.Find ("RockTile");  //4

		string[] map = { 
			"22222222222222222222222222\n" +
			"22222222222222222222222222\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111133111144111133111111\n" +
			"11113331111133111113331111\n" +
			"11333331111333311113333311\n" +
			"13333333111333311133333331\n" +
			"13333333333333333333333331\n" +
			"33333333333333333333333333\n" +
			"33333333333333333333333333\n" +
			"13333333333333333333333331\n" +
			"13333113331333313331133331\n" +
			"11331111111133111111113311\n" +
			"11133111111133111111133111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +

			"11111111111122111111111111\n",
			"22222222222222222222222222\n" +
			"22222222222222222222222222\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111133111144111133111111\n" +
			"11113331111133111113331111\n" +
			"11333331111333311113333311\n" +
			"13333333111333311133333331\n" +
			"13333333333333333333333331\n" +
			"33333333333333333333333333\n" +
			"33333333333333333333333333\n" +
			"13333333333333333333333331\n" +
			"13333113331333313331133331\n" +
			"11331111111133111111113311\n" +
			"11133111111133111111133111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n",

			"22222222222222222222222222\n" +
			"22222222222222222222222222\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111111111144111111111111\n" +
			"11111133111144111133111111\n" +
			"11113331111133111113331111\n" +
			"11333331111333311113333311\n" +
			"13333333111333311133333331\n" +
			"13333333333333333333333331\n" +
			"33333333333333333333333333\n" +
			"33333333333333333333333333\n" +
			"13333333333333333333333331\n" +
			"13333113331333313331133331\n" +
			"11331111111133111111113311\n" +
			"11133111111133111111133111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n" +
			"11111111111122111111111111\n"
		};

		for (int a = 0; a < map.Length; a++) {
			for (int i = 0; i < size; i++) {
				for (int j = 0; j < size; j++) {
					char c = map [a] [i * size + j];
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