using NCMB; //mobile backendのSDKを読み込む
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveScore : MonoBehaviour {
	// mobile backendに接続------------------------
	public void save( string name, int score ) {
		NCMBObject obj = new NCMBObject ("Score");
		obj.Add ("name", name);//オブジェクトに名前とスコアを設定
		obj.Add ("score", score);
		obj.SaveAsync ((NCMBException e) => {      
			if (e != null) {//エラー処理
			} else {//成功時の処理
			}                   });//この処理でサーバーに書き込む
	}
}
