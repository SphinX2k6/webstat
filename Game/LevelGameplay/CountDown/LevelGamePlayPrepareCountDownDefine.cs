using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.CountDown
{
	// Token: 0x02006F24 RID: 28452
	public static class LevelGamePlayPrepareCountDownDefine
	{
		// Token: 0x06044E73 RID: 282227 RVA: 0x011EF51C File Offset: 0x011ED71C
		// Note: this type is marked as 'beforefieldinit'.
		static LevelGamePlayPrepareCountDownDefine()
		{
			Dictionary<ECountDownUiStyle, string> dictionary = new Dictionary<ECountDownUiStyle, string>();
			dictionary[ECountDownUiStyle.MotorFight] = "MotorFightCountDown";
			LevelGamePlayPrepareCountDownDefine.countDownUiStyleToResourceId = dictionary;
		}

		// Token: 0x04026698 RID: 157336
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<ECountDownUiStyle, string> countDownUiStyleToResourceId;
	}
}
