using NCMB; //mobile backendのSDKを読み込む
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class Ghost : MonoBehaviour {
	int flameCount = 0;
	int limit = 0 ;
	void Start () {
		limit = ((ArrayList)Bg_ghost.posObj["Log"]).Count;
		//limit = 1000;
		Debug.Log ("limit:" +limit);
		
	}
	
	//---Bg_ghost.csで取得したゴーストデータを利用し、ゴーストを操作する----------------------------------------------------
	void Update () {
		if (flameCount < limit) {
			float x = (float)System.Convert.ToDouble (((ArrayList)((ArrayList)Bg_ghost.posObj ["Log"]) [flameCount]) [0]);
			float y = (float)System.Convert.ToDouble (((ArrayList)((ArrayList)Bg_ghost.posObj ["Log"]) [flameCount]) [1]);
			transform.position = new Vector2 (x, y);
			flameCount ++;
		}
	}
	//-------------------------------------------------------------------------------------------------------------
}
