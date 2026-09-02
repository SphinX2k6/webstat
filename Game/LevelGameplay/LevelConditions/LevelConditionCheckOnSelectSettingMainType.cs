using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D31 RID: 27953
	public class LevelConditionCheckOnSelectSettingMainType : LevelConditionBase
	{
		// Token: 0x0604449F RID: 279711 RVA: 0x011BDA9C File Offset: 0x011BBC9C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("MainType");
			if (limitParams == null)
			{
				return false;
			}
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MenuView))
			{
				return false;
			}
			MenuView menuView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.MenuView) as MenuView;
			return int.Parse(limitParams) == menuView.MenuViewDataExternal.MenuViewDataCurMainType;
		}
	}
}
