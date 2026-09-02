using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D97 RID: 28055
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelConditionOnNewViewCovered : LevelConditionBase
	{
		// Token: 0x06044575 RID: 279925 RVA: 0x011C15E0 File Offset: 0x011BF7E0
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("FocusView");
			EUiViewName euiViewName = (EUiViewName)eventArgs[0];
			return limitParams != euiViewName && !LevelConditionOnNewViewCovered.WhiteList.Contains(euiViewName);
		}

		// Token: 0x040260F4 RID: 155892
		[StaticVariableRuleIgnore]
		private static readonly HashSet<EUiViewName> WhiteList = new HashSet<EUiViewName>
		{
			EUiViewName.GuideFocusView,
			EUiViewName.GuideTipsView,
			EUiViewName.GuideTutorialView,
			EUiViewName.GuideTutorialPopView,
			EUiViewName.GuideTutorialTipsView,
			EUiViewName.NetWorkMaskView
		};
	}
}
