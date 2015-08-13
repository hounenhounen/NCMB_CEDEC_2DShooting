using UnityEngine;
using System.Collections;

public class ScoreUI : MonoBehaviour {
	
	private GameObject guiTextSaveScore;   // SaveScore Text
	
	// ボタンが押されると対応する変数がtrueになる
	private bool SubmitButton;
	
	// テキストボックスで入力される文字列を格納
	public string name;
	public string score_string;
	public int score;
	
	void Start () {
		
		// ゲームオブジェクトを検索し取得する
		guiTextSaveScore  = GameObject.Find ("GUITextSaveScore");
		score = PlayerPrefs.GetInt ("Score", 1);
		score_string = score.ToString();
	}
	
	void OnGUI () {
		drawSaveScore();
		// ボタンが押されたら
		if (SubmitButton) {
			FindObjectOfType<SaveScore> ().save (name, score);
			Application.LoadLevel ("Stage");
		}
		
	}
	
	private void drawSaveScore()
	{
		guiTextSaveScore.SetActive (true);
		// テキストボックスの設置と入力値の取得
		GUI.skin.textField.fontSize = 20;
		int txtW = 150, txtH = 40;
		name = GUI.TextField     (new Rect(Screen.width*1/2, Screen.height*1/3 - txtH*1/2, txtW, txtH), name);
		GUI.TextField (new Rect(Screen.width*1/2, Screen.height*1/2 - txtH*1/2, txtW, txtH), score_string);
		
		// ボタンの設置
		int btnW = 180, btnH = 50;
		GUI.skin.button.fontSize = 20;
		SubmitButton = GUI.Button( new Rect(Screen.width*1/2 - btnW*1/2, Screen.height*3/4 - btnH*1/2, btnW, btnH), "Submit" );
		
	}
}
