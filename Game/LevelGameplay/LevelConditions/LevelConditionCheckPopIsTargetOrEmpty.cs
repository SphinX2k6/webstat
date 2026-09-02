using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D41 RID: 27969
	public class LevelConditionCheckPopIsTargetOrEmpty : LevelConditionBase
	{
		// Token: 0x060444C1 RID: 279745 RVA: 0x011BECE0 File Offset: 0x011BCEE0
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("UIName");
			UiViewBase topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Pop);
			EUiViewName? euiViewName;
			if (topView == null)
			{
				euiViewName = null;
			}
			else
			{
				UiViewInfo viewInfo = topView.ViewInfo;
				euiViewName = ((viewInfo != null) ? new EUiViewName?(viewInfo.Name) : null);
			}
			EUiViewName? euiViewName2 = euiViewName;
			if (string.IsNullOrEmpty(limitParams))
			{
				return topView == null;
			}
			return euiViewName2 != null && euiViewName2 == (EUiViewName)limitParams;
		}
	}
}
