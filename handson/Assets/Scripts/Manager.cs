using UnityEngine;

public class Manager : MonoBehaviour
{
	// Playerプレハブ
	public GameObject player;
	
	// タイトル
	private GameObject title;

	private bool leaderBoardButton;

	 void Start ()
	{
		// Titleゲームオブジェクトを検索し取得する
		title = GameObject.Find ("Title");
	}
	
	void OnGUI ()
	{
		// ゲーム中ではなく、タッチまたはマウスクリック直後であればtrueを返す。
		if (!IsPlaying()) {
			drawButton();
			// 画面タップでゲームスタート
			if ( Event.current.type == EventType.MouseDown) 
				GameStart ();

			// ランキングボタンが押されたら
			if ( leaderBoardButton )
				Application.LoadLevel("LeaderBoard");
		}
	}

	void GameStart ()
	{
		// ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
		title.SetActive (false);
		Instantiate (player, player.transform.position, player.transform.rotation);
	}
	
	public void GameOver ()
	{
		FindObjectOfType<Score> ().Save ();
		Application.LoadLevel ("SaveScore");
		// ゲームオーバー時に、タイトルを表示する
		//title.SetActive (true);
	}
	
	public bool IsPlaying ()
	{
		// ゲーム中かどうかはタイトルの表示/非表示で判断する
		return title.activeSelf == false;
	}

	private void drawButton() {
		// ボタンの設置
		int btnW = 140, btnH = 50;
		GUI.skin.button.fontSize = 18;
		leaderBoardButton = GUI.Button( new Rect(0*btnW, 0, btnW, btnH), "Leader Board" );
	}
}