using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029D3 RID: 10707
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerRewardView : UiViewBase
{
	// Token: 0x06015579 RID: 87417 RVA: 0x005EA139 File Offset: 0x005E8339
	public ShipTowerRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601557A RID: 87418 RVA: 0x005EA14C File Offset: 0x005E834C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
	}

	// Token: 0x0601557B RID: 87419 RVA: 0x005EA1E8 File Offset: 0x005E83E8
	private void InitDataParam()
	{
		this.AreaList = ModelBase<ShipTowerModel>.Instance.GetAreaList();
	}

	// Token: 0x0601557C RID: 87420 RVA: 0x005EA1FC File Offset: 0x005E83FC
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerRewardView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerRewardView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601557D RID: 87421 RVA: 0x005EA240 File Offset: 0x005E8440
	private UniTask CheckIsNeedShowSeasonReview()
	{
		ShipTowerRewardView.<CheckIsNeedShowSeasonReview>d__12 <CheckIsNeedShowSeasonReview>d__;
		<CheckIsNeedShowSeasonReview>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckIsNeedShowSeasonReview>d__.<>1__state = -1;
		<CheckIsNeedShowSeasonReview>d__.<>t__builder.Start<ShipTowerRewardView.<CheckIsNeedShowSeasonReview>d__12>(ref <CheckIsNeedShowSeasonReview>d__);
		return <CheckIsNeedShowSeasonReview>d__.<>t__builder.Task;
	}

	// Token: 0x0601557E RID: 87422 RVA: 0x005EA27B File Offset: 0x005E847B
	private void EventOnActivitySequenceEmitEvent(string name)
	{
		if (name == "Start")
		{
			LoopScrollView<ShipTowerAreaItem, ShipTowerAreaItemData> areaLoopView = this.AreaLoopView;
			if (areaLoopView == null)
			{
				return;
			}
			areaLoopView.SelectGridProxy(this.GetSelectAreaIndex(), false);
		}
	}

	// Token: 0x0601557F RID: 87423 RVA: 0x005EA2A1 File Offset: 0x005E84A1
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ShipTowerRewardReceive, new Action<int>(this.EventRewardReceive));
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.EventOnActivitySequenceEmitEvent));
	}

	// Token: 0x06015580 RID: 87424 RVA: 0x005EA2DB File Offset: 0x005E84DB
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ShipTowerRewardReceive, new Action<int>(this.EventRewardReceive));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.EventOnActivitySequenceEmitEvent));
	}

	// Token: 0x06015581 RID: 87425 RVA: 0x005EA318 File Offset: 0x005E8518
	protected override void OnBeforeShow()
	{
		this.UpdateRemainTime();
		int num = 500;
		this.RefreshTimerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.OnTimerRefresh), (float)num, 1f, null, null, true);
	}

	// Token: 0x06015582 RID: 87426 RVA: 0x005EA357 File Offset: 0x005E8557
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x06015583 RID: 87427 RVA: 0x005EA359 File Offset: 0x005E8559
	private ShipTowerAreaItem CreateAreaItem()
	{
		return new ShipTowerAreaItem
		{
			ClickCallBack = new Action<ShipTowerAreaItemData>(this.OnAreaItemClick)
		};
	}

	// Token: 0x06015584 RID: 87428 RVA: 0x005EA372 File Offset: 0x005E8572
	private ShipTowerRewardItem CreateRewardItem()
	{
		return new ShipTowerRewardItem
		{
			ClickCallBack = new Action<ShipTowerRewardItemData>(this.OnRewardItemClick)
		};
	}

	// Token: 0x06015585 RID: 87429 RVA: 0x005EA38B File Offset: 0x005E858B
	private void OnAreaItemClick(ShipTowerAreaItemData data)
	{
		this.SelectData = data;
		LoopScrollView<ShipTowerRewardItem, ShipTowerRewardItemData> rewardLoopView = this.RewardLoopView;
		if (rewardLoopView != null)
		{
			rewardLoopView.RefreshByData(data.RewardList, false, null, this.IsPlayAnim);
		}
		this.IsPlayAnim = true;
	}

	// Token: 0x06015586 RID: 87430 RVA: 0x005EA3BC File Offset: 0x005E85BC
	private void OnRewardItemClick(ShipTowerRewardItemData data)
	{
		List<ShipTowerRewardItemData> list = null;
		ShipTowerAreaItemData selectData = this.SelectData;
		if (((selectData != null) ? selectData.RewardList : null) != null)
		{
			list = new List<ShipTowerRewardItemData>();
			foreach (ShipTowerRewardItemData shipTowerRewardItemData in this.SelectData.RewardList)
			{
				if (shipTowerRewardItemData.IsReceive)
				{
					list.Add(shipTowerRewardItemData);
				}
			}
		}
		List<int> list2 = new List<int>();
		if (list != null)
		{
			foreach (ShipTowerRewardItemData shipTowerRewardItemData2 in list)
			{
				list2.Add(shipTowerRewardItemData2.Id);
			}
		}
		ModelBase<ShipTowerModel>.Instance.ReceiveAward(data.Id, list2.ToArray()).Forget();
	}

	// Token: 0x06015587 RID: 87431 RVA: 0x005EA4A0 File Offset: 0x005E86A0
	private void OnTimerRefresh(float delta)
	{
		this.UpdateRemainTime();
		if (ModelBase<ShipTowerModel>.Instance.TimeIsOver())
		{
			this.ClearTimer();
		}
	}

	// Token: 0x06015588 RID: 87432 RVA: 0x005EA4BA File Offset: 0x005E86BA
	private void ClearTimer()
	{
		if (this.RefreshTimerHandle != null)
		{
			TimerSystem.Instance.Remove(this.RefreshTimerHandle);
			this.RefreshTimerHandle = null;
		}
	}

	// Token: 0x06015589 RID: 87433 RVA: 0x005EA4DC File Offset: 0x005E86DC
	private int GetSelectAreaIndex()
	{
		ShipTowerRewardViewParams shipTowerRewardViewParams = this.OpenParam as ShipTowerRewardViewParams;
		if (shipTowerRewardViewParams == null || shipTowerRewardViewParams.RewardId == null)
		{
			return this.GetCanReceiveAwardIndex();
		}
		int value = shipTowerRewardViewParams.RewardId.Value;
		int index = -1;
		for (int i = 0; i < this.AreaList.Count; i++)
		{
			ShipTowerAreaItemData shipTowerAreaItemData = this.AreaList[i];
			if (shipTowerAreaItemData.RewardList != null)
			{
				bool flag = false;
				using (List<ShipTowerRewardItemData>.Enumerator enumerator = shipTowerAreaItemData.RewardList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Id == value)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					index = i;
					break;
				}
			}
		}
		return this.GetRangeIndex(index);
	}

	// Token: 0x0601558A RID: 87434 RVA: 0x005EA5AC File Offset: 0x005E87AC
	private int GetCanReceiveAwardIndex()
	{
		int index = -1;
		for (int i = 0; i < this.AreaList.Count; i++)
		{
			ShipTowerAreaItemData shipTowerAreaItemData = this.AreaList[i];
			if (shipTowerAreaItemData.RewardList != null)
			{
				bool flag = false;
				using (List<ShipTowerRewardItemData>.Enumerator enumerator = shipTowerAreaItemData.RewardList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.IsReceive)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					index = i;
					break;
				}
			}
		}
		return this.GetRangeIndex(index);
	}

	// Token: 0x0601558B RID: 87435 RVA: 0x005EA640 File Offset: 0x005E8840
	private int GetRangeIndex(int index)
	{
		if (index == -1)
		{
			return 0;
		}
		return index;
	}

	// Token: 0x0601558C RID: 87436 RVA: 0x005EA64C File Offset: 0x005E884C
	private void UpdateRemainTime()
	{
		string rewardCountDownDesc = ModelBase<ShipTowerModel>.Instance.GetRewardCountDownDesc();
		UUIText text = base.GetText(5);
		if (text == null)
		{
			return;
		}
		text.SetText(rewardCountDownDesc, true);
	}

	// Token: 0x0601558D RID: 87437 RVA: 0x005EA677 File Offset: 0x005E8877
	private void EventRewardReceive(int id)
	{
		if (this.SelectData == null)
		{
			return;
		}
		LoopScrollView<ShipTowerAreaItem, ShipTowerAreaItemData> areaLoopView = this.AreaLoopView;
		if (areaLoopView == null)
		{
			return;
		}
		areaLoopView.RefreshByData(this.AreaList, true, delegate
		{
			this.IsPlayAnim = false;
			LoopScrollView<ShipTowerAreaItem, ShipTowerAreaItemData> areaLoopView2 = this.AreaLoopView;
			if (areaLoopView2 != null)
			{
				areaLoopView2.DeselectCurrentGridProxy(false);
			}
			LoopScrollView<ShipTowerAreaItem, ShipTowerAreaItemData> areaLoopView3 = this.AreaLoopView;
			if (areaLoopView3 == null)
			{
				return;
			}
			areaLoopView3.SelectGridProxy(this.GetCanReceiveAwardIndex(), false);
		}, false);
	}

	// Token: 0x0400A46A RID: 42090
	[Nullable(2)]
	private PopupCaptionItem PopupCaption;

	// Token: 0x0400A46B RID: 42091
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<ShipTowerAreaItem, ShipTowerAreaItemData> AreaLoopView;

	// Token: 0x0400A46C RID: 42092
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<ShipTowerRewardItem, ShipTowerRewardItemData> RewardLoopView;

	// Token: 0x0400A46D RID: 42093
	private List<ShipTowerAreaItemData> AreaList;

	// Token: 0x0400A46E RID: 42094
	[Nullable(2)]
	private ShipTowerAreaItemData SelectData;

	// Token: 0x0400A46F RID: 42095
	private bool IsPlayAnim = true;

	// Token: 0x0400A470 RID: 42096
	[Nullable(2)]
	private TimerHandle RefreshTimerHandle;

	// Token: 0x02008D39 RID: 36153
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F7EA RID: 194538
		public const int ItemCaption = 0;

		// Token: 0x0402F7EB RID: 194539
		public const int LoopViewArea = 1;

		// Token: 0x0402F7EC RID: 194540
		public const int LoopViewReward = 2;

		// Token: 0x0402F7ED RID: 194541
		public const int ItemArea = 3;

		// Token: 0x0402F7EE RID: 194542
		public const int ItemReward = 4;

		// Token: 0x0402F7EF RID: 194543
		public const int CountDownText = 5;
	}
}
