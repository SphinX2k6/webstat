using System;
using System.Collections.Generic;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069E2 RID: 27106
	public class AnniversarySubActivityWuWuPackUiItem : AnniversaryActivityEnterItem
	{
		// Token: 0x060432F8 RID: 275192 RVA: 0x01143918 File Offset: 0x01141B18
		public override void ChildUpdateTips()
		{
			UUIText text = base.GetText(1);
			if (text == null || this.Data == null)
			{
				return;
			}
			text.SetUIActive(false);
			WuWuLogisticsActivityData wuWuLogisticsActivityData = this.Data.GetActivityData() as WuWuLogisticsActivityData;
			if (wuWuLogisticsActivityData == null || !wuWuLogisticsActivityData.IsUnLock())
			{
				return;
			}
			IReadOnlyList<WuWuTaskPackage> allTaskPackage = ConfigBase<WuWuLogisticsConfig>.Instance.GetAllTaskPackage();
			if (allTaskPackage == null || allTaskPackage.Count == 0)
			{
				return;
			}
			int num = 0;
			foreach (WuWuTaskPackage wuWuTaskPackage in allTaskPackage)
			{
				if (wuWuLogisticsActivityData.IsPackUnlocked(wuWuTaskPackage.Id))
				{
					WuWuTaskPackData taskPackById = wuWuLogisticsActivityData.GetTaskPackById(wuWuTaskPackage.Id);
					if (taskPackById == null || !taskPackById.HadReward || !wuWuLogisticsActivityData.TargetPackIsAllRewarded(wuWuTaskPackage.Id))
					{
						text.SetUIActive(true);
						Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Activity_Anniversary2_04_Reward", Array.Empty<object>());
						return;
					}
				}
				else if (num == 0)
				{
					num = wuWuTaskPackage.Id;
				}
			}
			if (num > 0)
			{
				WuWuTaskPackData taskPackById2 = wuWuLogisticsActivityData.GetTaskPackById(num);
				if (taskPackById2 != null && !taskPackById2.IsUnlock)
				{
					double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
					if ((double)taskPackById2.UnlockTime - serverTime > 0.0)
					{
						string text2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Activity_Anniversary2_04_Time") ?? "";
						string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(taskPackById2.UnlockTime, text2);
						if (string.IsNullOrEmpty(remainTimeText))
						{
							return;
						}
						text.SetUIActive(true);
						text.SetText(remainTimeText, true);
					}
				}
			}
		}
	}
}
