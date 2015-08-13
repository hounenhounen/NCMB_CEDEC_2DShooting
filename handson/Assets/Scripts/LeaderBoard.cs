using NCMB;
using System.Collections;
using System.Collections.Generic;

public class LeaderBoard {
	
	public int currentRank = 0;
	public List<NCMB.Rankers> topRankers = null;
	
	// サーバーからトップ5を取得 ---------------    
	public void fetchTopRankers()
	{
		// データストアの「Score」クラスから検索

		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("Score");
		query.OrderByDescending ("score");
		query.Limit = 5;

		query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
			
			if (e != null) {
				//検索失敗時の処理
			} else {
				//検索成功時の処理
				List<NCMB.Rankers> list = new List<NCMB.Rankers>();
				// 取得したレコードをscoreクラスとして保存
				foreach (NCMBObject obj in objList) {
					int    s = System.Convert.ToInt32(obj["score"]);
					string n = System.Convert.ToString(obj["name"]);
					list.Add( new Rankers( s, n ) );
				}
				topRankers = list;
			}
		});
	}

}

