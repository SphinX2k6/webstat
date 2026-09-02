using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200299D RID: 10653
public class ShipTowerDefine
{
	// Token: 0x0400A35F RID: 41823
	public const int SHIP_TOWER_MARK_ID = 302001;

	// Token: 0x0400A360 RID: 41824
	public const int SHIP_TOWER_ZERO_SEASON = 0;

	// Token: 0x0400A361 RID: 41825
	public const int SHIP_TOWER_HELP_ID = 201;

	// Token: 0x0400A362 RID: 41826
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static IReadOnlyDictionary<string, ShipTowerScoreGrade> shipTowerScoreGradeMap = new Dictionary<string, ShipTowerScoreGrade>
	{
		{
			"D",
			new ShipTowerScoreGrade
			{
				ResId = "T_ScoreD",
				BigResId = "T_ScoreBigD",
				Index = 1
			}
		},
		{
			"C",
			new ShipTowerScoreGrade
			{
				ResId = "T_ScoreC",
				BigResId = "T_ScoreBigC",
				Index = 2
			}
		},
		{
			"B",
			new ShipTowerScoreGrade
			{
				ResId = "T_ScoreB",
				BigResId = "T_ScoreBigB",
				Index = 3
			}
		},
		{
			"A",
			new ShipTowerScoreGrade
			{
				ResId = "T_ScoreA",
				BigResId = "T_ScoreBigA",
				Index = 4
			}
		},
		{
			"S",
			new ShipTowerScoreGrade
			{
				ResId = "T_ScoreS",
				BigResId = "T_ScoreBigS",
				Index = 5
			}
		},
		{
			"SS",
			new ShipTowerScoreGrade
			{
				ResId = "T_ScoreSS",
				BigResId = "T_ScoreBigSS",
				Index = 6
			}
		},
		{
			"SSS",
			new ShipTowerScoreGrade
			{
				ResId = "T_ScoreSSS",
				BigResId = "T_ScoreBigSSS",
				Index = 7
			}
		}
	};
}
