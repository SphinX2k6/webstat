using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CB9 RID: 27833
	public class LevelConditionCheckCalabashChildFunctionOpen : LevelConditionBase
	{
		// Token: 0x06044374 RID: 279412 RVA: 0x011B44BC File Offset: 0x011B26BC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("ChildViewName");
			if (limitParams == null)
			{
				return false;
			}
			UiDynamicTab[] viewTabList = ModelBase<CalabashModel>.Instance.GetViewTabList();
			bool flag = false;
			foreach (UiDynamicTab uiDynamicTab in viewTabList)
			{
				if (uiDynamicTab.ChildViewName == limitParams)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
			VisionIntensifyView visionIntensifyView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.VisionIntensifyView) as VisionIntensifyView;
			if (visionIntensifyView == null)
			{
				return false;
			}
			int currentUniqueId = visionIntensifyView.GetCurrentUniqueId();
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(currentUniqueId);
			return phantomBattleData != null && phantomBattleData.GetVisionIfCanRefine(EVisionRefineRefineType.Main);
		}
	}
}
