using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x020061F4 RID: 25076
	public static class WheelTowerDefine
	{
		// Token: 0x04023856 RID: 145494
		public const int LEVEL_BOSS_NUM = 4;

		// Token: 0x04023857 RID: 145495
		public const int TEMPLATE_ROLE_LEVEL = 90;

		// Token: 0x04023858 RID: 145496
		public const int WHEEL_TOWER_VERSION_32 = 32;

		// Token: 0x04023859 RID: 145497
		public const float WHEEL_TOWER_RESULT_SCORE_TWEEN_DURATION = 0.4f;

		// Token: 0x0402385A RID: 145498
		public const int WHEEL_TOWER_REPEAT_WAVE_ROUND = 3;

		// Token: 0x0402385B RID: 145499
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<EScoreLevel, string> LevelItemMappingTable = new Dictionary<EScoreLevel, string>
		{
			{
				EScoreLevel.B,
				"UiItem_ScoreB"
			},
			{
				EScoreLevel.A,
				"UiItem_ScoreA"
			},
			{
				EScoreLevel.S,
				"UiItem_ScoreS"
			},
			{
				EScoreLevel.SS,
				"UiItem_ScoreSS"
			},
			{
				EScoreLevel.SSS,
				"UiItem_ScoreSSS"
			},
			{
				EScoreLevel.KingRed,
				"UiItem_ScoreKingRed"
			},
			{
				EScoreLevel.King,
				"UiItem_ScoreKingColor"
			}
		};
	}
}
