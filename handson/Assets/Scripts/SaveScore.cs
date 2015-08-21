using NCMB; //mobile backendのSDKを読み込む
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveScore : MonoBehaviour {
	// mobile backendに接続------------------------
	public void save( string name, int score ) {
		NCMBObject obj = new NCMBObject ("Score");
		obj ["name"] = name;//オブジェクトに名前とスコアを設定
		obj ["score"] = score;
		obj.SaveAsync ();//この処理でサーバーに書き込む
	}
}
