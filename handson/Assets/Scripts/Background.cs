using UnityEngine;

public class Background : MonoBehaviour
{
	// スクロールするスピード
	public float speed = 0.1f;
	
	void Start ()
	{
		// 画面右上のワールド座標をビューポートから取得
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		
		// スケールを求める。
		Vector2 scale = max * 2;
		
		// スケールを変更。
		transform.localScale = scale;
	}
	
	void Update ()
	{
		// 時間によってYの値が0から1に変化していく。1になったら0に戻り、繰り返す。
		float y = Mathf.Repeat (Time.time * speed, 1);
		
		// Yの値がずれていくオフセットを作成
		Vector2 offset = new Vector2 (0, y);
		
		// マテリアルにオフセットを設定する
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}