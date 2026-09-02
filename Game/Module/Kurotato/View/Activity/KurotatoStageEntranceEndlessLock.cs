using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005AE1 RID: 23265
	public class KurotatoStageEntranceEndlessLock : UiPanelBase
	{
		// Token: 0x0603AD1E RID: 240926 RVA: 0x00EEAC8C File Offset: 0x00EE8E8C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AD1F RID: 240927 RVA: 0x00EEACF8 File Offset: 0x00EE8EF8
		public void RefreshView()
		{
			int levelId = ConfigBase<KurotatoConfig>.Instance.GetLevelGroupConfig(3).Value.LevelId;
			if (levelId <= 0)
			{
				return;
			}
			KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
			KurotatoLevelData kurotatoLevelData = activityData.GetKurotatoLevelData(levelId);
			if (kurotatoLevelData == null)
			{
				return;
			}
			if (!kurotatoLevelData.IsReachUnlockTime())
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Kurotato_Level_Select_UnlockTip2", null);
				long endlessLevelUnlockTime = activityData.GetEndlessLevelUnlockTime();
				string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(endlessLevelUnlockTime, localTextNew);
				base.GetText(1).SetText(remainTimeText, true);
				return;
			}
			KurotatoLevel value = ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(levelId).Value;
			KurotatoLevel value2 = ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(value.PerId).Value;
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(value2.Name);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Kurotato_Level_Select_UnlockTip", new <>z__ReadOnlySingleElementList<object>(multiTextByKey));
		}

		// Token: 0x0200BB13 RID: 47891
		private enum ELockComponents
		{
			// Token: 0x04039BDB RID: 236507
			UpText,
			// Token: 0x04039BDC RID: 236508
			DownText
		}
	}
}
