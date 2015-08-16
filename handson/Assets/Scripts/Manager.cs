using UnityEngine;

public class Manager : MonoBehaviour
{
	// Playerプレハブ
	public GameObject player;
	public GameObject ghost;
	// タイトル
	private GameObject title;

	private bool leaderBoardButton;
	private bool ghostButton;

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
				GameStart (false);

			// ランキングボタンが押されたら
			if ( leaderBoardButton )
				Application.LoadLevel("LeaderBoard");

			//—--ゴーストボタンが押下場合の挙動定義---------
			if ( ghostButton )
				GameStart (true);
			//----------------------------------------
		}
	}

	void GameStart (bool withGhost)
	{
		// ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
		title.SetActive (false);

		//------------------------------------------------------------------------------
		if (withGhost == true) {
			// ゴーストボタンを押下したらゴーストを表示する
			Instantiate (ghost, ghost.transform.position, ghost.transform.rotation);
			Instantiate (player, player.transform.position, player.transform.rotation);
		} else {
			// 画面を押下したらゴーストを表示しないでゲームを開始する
			Instantiate (player, player.transform.position, player.transform.rotation);
		}
		//------------------------------------------------------------------------------
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

		//---Bg_ghost.csでゴーストデータを取得できたら、ゴーストボタンを表示する-------------
		if (Bg_ghost.readyGhost == true) {
				ghostButton = GUI.Button (new Rect (btnW, 0, btnW, btnH), "Ghost");
		}
		//--------------------------------------------------------------------------
	}
}