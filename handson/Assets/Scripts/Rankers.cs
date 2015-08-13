using UnityEngine;
using System.Collections;

namespace NCMB
{

	public class Rankers
	{

		public int score   { get; set; }
		public string name { get; private set; }
	
		// コンストラクタ -----------------------------------
		public Rankers(int _score, string _name)
		{
			score = _score;
			name  = _name;
		}

		// ランキングで表示するために文字列を整形 -----------
		public string print()
		{
			return name + ' ' + score;
		}
	}

}