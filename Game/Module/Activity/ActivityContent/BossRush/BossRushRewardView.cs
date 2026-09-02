using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069C8 RID: 27080
	[NullableContext(1)]
	[Nullable(0)]
	public class BossRushRewardView : UiTabViewBase
	{
		// Token: 0x06043226 RID: 274982 RVA: 0x0113F33C File Offset: 0x0113D53C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06043227 RID: 274983 RVA: 0x0113F3E7 File Offset: 0x0113D5E7
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.BossRefreshBossRushReward, new Action(this.RefreshRewardLayout));
		}

		// Token: 0x06043228 RID: 274984 RVA: 0x0113F405 File Offset: 0x0113D605
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BossRefreshBossRushReward, new Action(this.RefreshRewardLayout));
		}

		// Token: 0x06043229 RID: 274985 RVA: 0x0113F424 File Offset: 0x0113D624
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.TabDataLayout = new GenericLayout<BossRushRewardTabItem, BossRushTaskTab>(base.GetVerticalLayout(0), new Func<BossRushRewardTabItem>(this.CreateBossRushRewardTabItem), null, false, true);
			this.RewardLayout = new GenericLayout<BossRushRewardItem, RewardContentData>(base.GetVerticalLayout(2), new Func<BossRushRewardItem>(this.CreateBossRushRewardItem), null, false, true);
			BossRushData bossRushData = ModelBase<ActivityModel>.Instance.GetActivityById(ModelBase<BossRushModel>.Instance.CurrentSelectActivityId) as BossRushData;
			this.BossRushData = bossRushData;
		}

		// Token: 0x0604322A RID: 274986 RVA: 0x0113F4A8 File Offset: 0x0113D6A8
		protected override void OnBeforeShow()
		{
			this.RefreshTabLayout();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0604322B RID: 274987 RVA: 0x0113F4DB File Offset: 0x0113D6DB
		private void RefreshTabLayout()
		{
			GenericLayout<BossRushRewardTabItem, BossRushTaskTab> tabDataLayout = this.TabDataLayout;
			if (tabDataLayout == null)
			{
				return;
			}
			tabDataLayout.RefreshByData(this.BossRushData.GetBossRushAllTabData(), null, false);
		}

		// Token: 0x0604322C RID: 274988 RVA: 0x0113F4FA File Offset: 0x0113D6FA
		private BossRushRewardTabItem CreateBossRushRewardTabItem()
		{
			BossRushRewardTabItem bossRushRewardTabItem = new BossRushRewardTabItem();
			bossRushRewardTabItem.SetClickCallBack(new Action<BossRushRewardTabItem>(this.ClickTabToggle));
			return bossRushRewardTabItem;
		}

		// Token: 0x0604322D RID: 274989 RVA: 0x0113F513 File Offset: 0x0113D713
		private BossRushRewardItem CreateBossRushRewardItem()
		{
			return new BossRushRewardItem();
		}

		// Token: 0x0604322E RID: 274990 RVA: 0x0113F51A File Offset: 0x0113D71A
		private void ClickTabToggle(BossRushRewardTabItem item)
		{
			BossRushRewardTabItem currentSelectTabItem = this.CurrentSelectTabItem;
			if (currentSelectTabItem != null)
			{
				currentSelectTabItem.SetToggleUnCheck();
			}
			this.CurrentSelectTabItem = item;
			this.RefreshRewardLayout();
		}

		// Token: 0x0604322F RID: 274991 RVA: 0x0113F53C File Offset: 0x0113D73C
		private void RefreshRewardLayout()
		{
			BossRushData bossRushData = this.BossRushData;
			BossRushRewardTabItem currentSelectTabItem = this.CurrentSelectTabItem;
			bool flag;
			if (currentSelectTabItem == null)
			{
				flag = false;
			}
			else
			{
				int tabId = currentSelectTabItem.GetTab().TabId;
				flag = true;
			}
			List<IActivityRewardData> tabRewardData = bossRushData.GetTabRewardData(flag ? this.CurrentSelectTabItem.GetTab().TabId : 0);
			List<RewardContentData> list = new List<RewardContentData>();
			foreach (IActivityRewardData rewardData in tabRewardData)
			{
				list.Add(new RewardContentData
				{
					RewardData = rewardData
				});
			}
			GenericLayout<BossRushRewardItem, RewardContentData> rewardLayout = this.RewardLayout;
			if (rewardLayout != null)
			{
				rewardLayout.RefreshByData(list, null, true);
			}
			GenericLayout<BossRushRewardTabItem, BossRushTaskTab> tabDataLayout = this.TabDataLayout;
			List<BossRushRewardTabItem> list2 = (tabDataLayout != null) ? tabDataLayout.GetLayoutItemList() : null;
			if (list2 == null)
			{
				return;
			}
			foreach (BossRushRewardTabItem bossRushRewardTabItem in list2)
			{
				bossRushRewardTabItem.RefreshRedDot();
			}
		}

		// Token: 0x06043230 RID: 274992 RVA: 0x0113F648 File Offset: 0x0113D848
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x04025696 RID: 153238
		private GenericLayout<BossRushRewardTabItem, BossRushTaskTab> TabDataLayout;

		// Token: 0x04025697 RID: 153239
		private BossRushRewardTabItem CurrentSelectTabItem;

		// Token: 0x04025698 RID: 153240
		private GenericLayout<BossRushRewardItem, RewardContentData> RewardLayout;

		// Token: 0x04025699 RID: 153241
		private BossRushData BossRushData;

		// Token: 0x0402569A RID: 153242
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200C94D RID: 51533
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403DE93 RID: 253587
			public const int TabContentItem = 0;

			// Token: 0x0403DE94 RID: 253588
			public const int TabItem = 1;

			// Token: 0x0403DE95 RID: 253589
			public const int RewardContentItem = 2;

			// Token: 0x0403DE96 RID: 253590
			public const int RewardItem = 3;
		}
	}
}
