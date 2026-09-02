using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D21 RID: 27937
	public class LevelConditionCheckIsShowProgressBarInMapExploreDetailView : LevelConditionBase
	{
		// Token: 0x06044479 RID: 279673 RVA: 0x011BCAE4 File Offset: 0x011BACE4
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.MapExploreDetailView);
			return viewByName != null && (viewByName as MapExploreDetailView).IsShowProgressBar.GetValueOrDefault();
		}
	}
}
