using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B09 RID: 6921
public class DangoAbyssTimeLimitRewardView : UiViewBase
{
	// Token: 0x0600C763 RID: 51043 RVA: 0x0034BE35 File Offset: 0x0034A035
	[NullableContext(1)]
	public DangoAbyssTimeLimitRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C764 RID: 51044 RVA: 0x0034BE48 File Offset: 0x0034A048
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickRewardBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C765 RID: 51045 RVA: 0x0034BFB6 File Offset: 0x0034A1B6
	public override bool GetLoopAudioEventSwitch()
	{
		return !ModelBase<DangoAbyssModel>.Instance.CheckIfInSmallWorldInstance();
	}

	// Token: 0x0600C766 RID: 51046 RVA: 0x0034BFC8 File Offset: 0x0034A1C8
	private void OnClickRewardBtn()
	{
		int? abyssLimitRewardRewardId = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssLimitRewardRewardId();
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(abyssLimitRewardRewardId.Value, true, null);
	}

	// Token: 0x0600C767 RID: 51047 RVA: 0x0034BFF3 File Offset: 0x0034A1F3
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssRewardStateUpdate, new Action(this.RefreshRewardLayout));
	}

	// Token: 0x0600C768 RID: 51048 RVA: 0x0034C011 File Offset: 0x0034A211
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssRewardStateUpdate, new Action(this.RefreshRewardLayout));
	}

	// Token: 0x0600C769 RID: 51049 RVA: 0x0034C02F File Offset: 0x0034A22F
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600C76A RID: 51050 RVA: 0x0034C038 File Offset: 0x0034A238
	protected override void OnStart()
	{
		this.CurrentData = (this.OpenParam as DangoAbyssTimeLimitViewData);
		int[] rewardTypeTabList = this.CurrentData.Data.GetRewardTypeTabList(1);
		if (rewardTypeTabList.Length != 0)
		{
			this.CurrentTabId = rewardTypeTabList[0];
		}
		this.LoopScrollView = new LoopScrollView<DangoAbyssRewardItem, IActivityRewardData>(base.GetLoopScrollViewComponent(4), base.GetItem(5).GetOwner() as AUIBaseActor, new Func<DangoAbyssRewardItem>(this.CreateLoopItem), false);
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.RefreshTimeText();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x0600C76B RID: 51051 RVA: 0x0034C0D0 File Offset: 0x0034A2D0
	private void RefreshTimeText()
	{
		if (this.CurrentData.Data.CheckInLimitTime())
		{
			string remainTimeText = this.CurrentData.Data.GetRemainTimeText();
			base.GetText(1).SetText(remainTimeText, true);
			base.GetText(1).SetUIActive(true);
			return;
		}
		base.GetText(1).SetUIActive(false);
	}

	// Token: 0x0600C76C RID: 51052 RVA: 0x0034C12C File Offset: 0x0034A32C
	private void RefreshRewardLayout()
	{
		IActivityRewardData[] taskActivityRewardDataList = this.CurrentData.Data.GetTaskActivityRewardDataList(1, this.CurrentTabId);
		this.LoopScrollView.RefreshByData(taskActivityRewardDataList.ToList<IActivityRewardData>(), false, null, true);
	}

	// Token: 0x0600C76D RID: 51053 RVA: 0x0034C168 File Offset: 0x0034A368
	private void RefreshRewardTexture()
	{
		string abyssLimitRewardTexture = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssLimitRewardTexture();
		base.SetTextureByPath(abyssLimitRewardTexture, base.GetTexture(2), null, null);
	}

	// Token: 0x0600C76E RID: 51054 RVA: 0x0034C198 File Offset: 0x0034A398
	[NullableContext(1)]
	private DangoAbyssRewardItem CreateLoopItem()
	{
		return new DangoAbyssRewardItem();
	}

	// Token: 0x0600C76F RID: 51055 RVA: 0x0034C19F File Offset: 0x0034A39F
	protected override void OnBeforeShow()
	{
		this.RefreshTimeText();
		this.RefreshRewardLayout();
		this.RefreshRewardTexture();
	}

	// Token: 0x0600C770 RID: 51056 RVA: 0x0034C1B3 File Offset: 0x0034A3B3
	protected override void OnBeforeDestroy()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x04005F7D RID: 24445
	private int CurrentTabId = 1;

	// Token: 0x04005F7E RID: 24446
	[Nullable(2)]
	private DangoAbyssTimeLimitViewData CurrentData;

	// Token: 0x04005F7F RID: 24447
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<DangoAbyssRewardItem, IActivityRewardData> LoopScrollView;

	// Token: 0x04005F80 RID: 24448
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x02007DE4 RID: 32228
	private class EComponent
	{
		// Token: 0x0402AE14 RID: 175636
		public const int BtnClose = 0;

		// Token: 0x0402AE15 RID: 175637
		public const int RemainTimeText = 1;

		// Token: 0x0402AE16 RID: 175638
		public const int RewardTexture = 2;

		// Token: 0x0402AE17 RID: 175639
		public const int RewardDesc = 3;

		// Token: 0x0402AE18 RID: 175640
		public const int LoopScroller = 4;

		// Token: 0x0402AE19 RID: 175641
		public const int ScrollerItem = 5;

		// Token: 0x0402AE1A RID: 175642
		public const int RewardBtn = 6;
	}
}
