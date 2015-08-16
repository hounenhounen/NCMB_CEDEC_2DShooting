using UnityEngine;

public class DestroyArea : MonoBehaviour
{
	void Start ()
	{
		// 画面右上のワールド座標をビューポートから取得
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		
		// サイズを求める
		Vector2 size = max * 2;

		// BoxCollider2Dのサイズを変更
		GetComponent<BoxCollider2D> ().size = size;
		
	}
	
	void OnTriggerExit2D (Collider2D c)
	{
		Destroy (c.gameObject);
	}
}