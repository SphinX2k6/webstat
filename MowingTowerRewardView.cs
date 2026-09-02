using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001441 RID: 5185
[NullableContext(1)]
[Nullable(0)]
public class MowingTowerRewardView : UiViewBase
{
	// Token: 0x0600904E RID: 36942 RVA: 0x0025EEB6 File Offset: 0x0025D0B6
	public MowingTowerRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600904F RID: 36943 RVA: 0x0025EEC0 File Offset: 0x0025D0C0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06009050 RID: 36944 RVA: 0x0025EF48 File Offset: 0x0025D148
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(delegate
		{
			base.CloseMe(null);
		});
		this.CaptionItem.SetTitleByTextIdAndArgNew("MowingTowerRewardViewTitle", Array.Empty<object>());
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshMowingTowerReward, new Action(this.RefreshRewardLayout));
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.TabDataLayout = new GenericLayout<MowingTowerRewardTabItem, MowingTowerLevelDetailInfo>(base.GetVerticalLayout(1), new Func<MowingTowerRewardTabItem>(this.CreateMowingTowerRewardTabItem), null, false, true);
		this.RewardLayout = new GenericLayout<MowingTowerRewardItem, IActivityRewardData>(base.GetVerticalLayout(3), new Func<MowingTowerRewardItem>(this.CreateMowingTowerRewardItem), null, false, true);
		MowingTowerData mowingTowerData = ModelBase<ActivityModel>.Instance.GetActivityById(ModelBase<MowingTowerModel>.Instance.CurrentSelectActivityId) as MowingTowerData;
		this.MowingTowerData = mowingTowerData;
	}

	// Token: 0x06009051 RID: 36945 RVA: 0x0025F024 File Offset: 0x0025D224
	protected override void OnBeforeShow()
	{
		List<MowingTowerLevelDetailInfo> data = new List<MowingTowerLevelDetailInfo>(this.MowingTowerData.GetMowingTowerLevelDetailInfo());
		GenericLayout<MowingTowerRewardTabItem, MowingTowerLevelDetailInfo> tabDataLayout = this.TabDataLayout;
		if (tabDataLayout != null)
		{
			tabDataLayout.RefreshByData(data, delegate
			{
				GenericLayout<MowingTowerRewardTabItem, MowingTowerLevelDetailInfo> tabDataLayout2 = this.TabDataLayout;
				List<MowingTowerRewardTabItem> list = (tabDataLayout2 != null) ? tabDataLayout2.GetLayoutItemList() : null;
				if (list == null)
				{
					return;
				}
				for (int i = 0; i < list.Count; i++)
				{
					MowingTowerRewardTabItem mowingTowerRewardTabItem = list[i];
					mowingTowerRewardTabItem.SetRedDotActive(this.MowingTowerData.HaveLevelRewardCanTake(mowingTowerRewardTabItem.GetLevelId().GetValueOrDefault()));
				}
			}, false);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x06009052 RID: 36946 RVA: 0x0025F081 File Offset: 0x0025D281
	private MowingTowerRewardTabItem CreateMowingTowerRewardTabItem()
	{
		MowingTowerRewardTabItem mowingTowerRewardTabItem = new MowingTowerRewardTabItem();
		mowingTowerRewardTabItem.SetClickCallBack(new Action<MowingTowerRewardTabItem>(this.ClickTabToggle));
		return mowingTowerRewardTabItem;
	}

	// Token: 0x06009053 RID: 36947 RVA: 0x0025F09A File Offset: 0x0025D29A
	private MowingTowerRewardItem CreateMowingTowerRewardItem()
	{
		return new MowingTowerRewardItem();
	}

	// Token: 0x06009054 RID: 36948 RVA: 0x0025F0A1 File Offset: 0x0025D2A1
	private void ClickTabToggle(MowingTowerRewardTabItem item)
	{
		MowingTowerRewardTabItem currentSelectTabItem = this.CurrentSelectTabItem;
		if (currentSelectTabItem != null)
		{
			currentSelectTabItem.SetToggleUnCheck();
		}
		this.CurrentSelectTabItem = item;
		this.RefreshRewardLayout();
	}

	// Token: 0x06009055 RID: 36949 RVA: 0x0025F0C4 File Offset: 0x0025D2C4
	private void RefreshRewardLayout()
	{
		MowingTowerData mowingTowerData = this.MowingTowerData;
		MowingTowerRewardTabItem currentSelectTabItem = this.CurrentSelectTabItem;
		List<IActivityRewardData> rewardByLevelId = mowingTowerData.GetRewardByLevelId((currentSelectTabItem != null) ? currentSelectTabItem.GetLevelId() : null);
		GenericLayout<MowingTowerRewardItem, IActivityRewardData> rewardLayout = this.RewardLayout;
		if (rewardLayout == null)
		{
			return;
		}
		rewardLayout.RefreshByData(rewardByLevelId, delegate
		{
			GenericLayout<MowingTowerRewardTabItem, MowingTowerLevelDetailInfo> tabDataLayout = this.TabDataLayout;
			List<MowingTowerRewardTabItem> list = (tabDataLayout != null) ? tabDataLayout.GetLayoutItemList() : null;
			if (list == null)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				MowingTowerRewardTabItem mowingTowerRewardTabItem = list[i];
				mowingTowerRewardTabItem.SetRedDotActive(this.MowingTowerData.HaveLevelRewardCanTake(mowingTowerRewardTabItem.GetLevelId().GetValueOrDefault()));
			}
		}, true);
	}

	// Token: 0x06009056 RID: 36950 RVA: 0x0025F115 File Offset: 0x0025D315
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshMowingTowerReward, new Action(this.RefreshRewardLayout));
	}

	// Token: 0x040042FA RID: 17146
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x040042FB RID: 17147
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MowingTowerRewardTabItem, MowingTowerLevelDetailInfo> TabDataLayout;

	// Token: 0x040042FC RID: 17148
	[Nullable(2)]
	private MowingTowerRewardTabItem CurrentSelectTabItem;

	// Token: 0x040042FD RID: 17149
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MowingTowerRewardItem, IActivityRewardData> RewardLayout;

	// Token: 0x040042FE RID: 17150
	[Nullable(2)]
	private MowingTowerData MowingTowerData;

	// Token: 0x040042FF RID: 17151
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0200783D RID: 30781
	[NullableContext(0)]
	private static class EComponent
	{
		// Token: 0x0402959F RID: 169375
		public const int CaptionItem = 0;

		// Token: 0x040295A0 RID: 169376
		public const int TabContentItem = 1;

		// Token: 0x040295A1 RID: 169377
		public const int TabItem = 2;

		// Token: 0x040295A2 RID: 169378
		public const int RewardContentItem = 3;

		// Token: 0x040295A3 RID: 169379
		public const int RewardItem = 4;
	}
}
