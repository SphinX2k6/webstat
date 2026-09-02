using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D43 RID: 27971
	public class LevelConditionCheckPureModeWhenBattleViewActive : LevelConditionBase
	{
		// Token: 0x060444C5 RID: 279749 RVA: 0x011BEDDC File Offset: 0x011BCFDC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			BattleUiPureModeData pureModeData = ModelBase<BattleUiModel>.Instance.PureModeData;
			bool flag = pureModeData != null && pureModeData.IsOpen;
			bool flag2 = Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView);
			return flag && flag2;
		}
	}
}
