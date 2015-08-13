using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeaderBoardManager : MonoBehaviour {
	
	private LeaderBoard lBoard;
	public GameObject[] top = new GameObject[5];

	bool isRankFetched;
	bool isLeaderBoardFetched;
	
	// ボタンが押されると対応する変数がtrueになる
	private bool backButton;
	
	void Start ()
	{
		lBoard = new LeaderBoard();
		
		// テキストを表示するゲームオブジェクトを取得
		for( int i = 0; i < 5; ++i ) {
			top[i] = GameObject.Find ("Top" + i);
		}
		
		// フラグ初期化
		isRankFetched  = false;
		isLeaderBoardFetched = false;

	}
	
	void Update()
	{
		// 現在の順位の取得が完了したら1度だけ実行
		if( !isRankFetched ){
			lBoard.fetchTopRankers();
			isRankFetched = true;
		}
		
		// ランキングの取得が完了したら1度だけ実行
		if( lBoard.topRankers != null && !isLeaderBoardFetched){ 
			
			// 取得したトップ5ランキングを表示
			for( int i = 0; i < lBoard.topRankers.Count; ++i) {
				top[i].guiText.text = i+1 + ". " + lBoard.topRankers[i].print();
			}

			isLeaderBoardFetched = true;
		}
	}
	
	void OnGUI () {
		drawMenu();
		// 戻るボタンが押されたら
		if( backButton )
			Application.LoadLevel("Stage");
	}
	
	private void drawMenu() {
		// ボタンの設置
		int btnW = 170, btnH = 30;
		GUI.skin.button.fontSize = 20;
		backButton = GUI.Button( new Rect(Screen.width*1/2 - btnW*1/2, Screen.height*7/8 - btnH*1/2, btnW, btnH), "Back" );
	}
}
