using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D0A RID: 27914
	public class LevelConditionCheckGolemHackingId : LevelConditionBase
	{
		// Token: 0x0604444A RID: 279626 RVA: 0x011BBE78 File Offset: 0x011BA078
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			GolemHackingGameView golemHackingGameView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.GolemHackingGameView) as GolemHackingGameView;
			return golemHackingGameView != null && int.Parse(inConditionInfo.GetLimitParams("ID")) == golemHackingGameView.GetConfigId();
		}
	}
}
