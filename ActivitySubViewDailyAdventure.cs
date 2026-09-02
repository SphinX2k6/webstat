using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012CA RID: 4810
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewDailyAdventure : ActivitySubViewBase
{
	// Token: 0x06008121 RID: 33057 RVA: 0x00221E7C File Offset: 0x0022007C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06008122 RID: 33058 RVA: 0x00222099 File Offset: 0x00220299
	protected override void OnSetData()
	{
		this.DailyAdventureData = (this.ActivityBaseData as ActivityDailyAdventureData);
		this.ProgressPoint = this.DailyAdventureData.ProgressPoint;
	}

	// Token: 0x06008123 RID: 33059 RVA: 0x002220C0 File Offset: 0x002202C0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewDailyAdventure.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewDailyAdventure.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008124 RID: 33060 RVA: 0x00222104 File Offset: 0x00220304
	[NullableContext(1)]
	private UniTask CreateRewardItem(AActor itemActor)
	{
		ActivitySubViewDailyAdventure.<CreateRewardItem>d__11 <CreateRewardItem>d__;
		<CreateRewardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateRewardItem>d__.<>4__this = this;
		<CreateRewardItem>d__.itemActor = itemActor;
		<CreateRewardItem>d__.<>1__state = -1;
		<CreateRewardItem>d__.<>t__builder.Start<ActivitySubViewDailyAdventure.<CreateRewardItem>d__11>(ref <CreateRewardItem>d__);
		return <CreateRewardItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008125 RID: 33061 RVA: 0x0022214F File Offset: 0x0022034F
	protected override void OnStart()
	{
		this.PanelTime = base.GetItem(5);
		this.TextTime = base.GetText(6);
		this.NiagaraProgressItem = base.GetUiNiagara(14);
		this.NiagaraProgressItem.SetUIActive(false);
		this.RefreshInfo();
	}

	// Token: 0x06008126 RID: 33062 RVA: 0x0022218B File Offset: 0x0022038B
	protected override void OnBeforeDestroy()
	{
		this.NiagaraProgressItem.DeactivateSystem();
		this.NiagaraProgressItem.SetUIActive(false);
	}

	// Token: 0x06008127 RID: 33063 RVA: 0x002221A4 File Offset: 0x002203A4
	[NullableContext(1)]
	private DailyAdventureTaskItem InitQuestItem()
	{
		return new DailyAdventureTaskItem();
	}

	// Token: 0x06008128 RID: 33064 RVA: 0x002221AB File Offset: 0x002203AB
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		Singleton<EventSystem>.Instance.Add(EEventName.ActivityCrossDayRefresh, new Action(this.OnActivityCrossDayRefresh));
	}

	// Token: 0x06008129 RID: 33065 RVA: 0x002221E5 File Offset: 0x002203E5
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		Singleton<EventSystem>.Instance.Remove(EEventName.ActivityCrossDayRefresh, new Action(this.OnActivityCrossDayRefresh));
	}

	// Token: 0x0600812A RID: 33066 RVA: 0x0022221F File Offset: 0x0022041F
	private void OnRefreshCommonActivityRedDot(int id)
	{
		if (id == this.ActivityBaseData.Id)
		{
			this.RefreshTask();
			this.RefreshReward();
		}
	}

	// Token: 0x0600812B RID: 33067 RVA: 0x0022223B File Offset: 0x0022043B
	protected override void OnRefreshView()
	{
		this.RefreshTimerText();
		this.RefreshTask();
		this.RefreshReward();
		this.DailyAdventureData.ReadDailyTips();
	}

	// Token: 0x0600812C RID: 33068 RVA: 0x0022225C File Offset: 0x0022045C
	private void RefreshInfo()
	{
		base.GetText(4).SetText(this.DailyAdventureData.GetTitle(), true);
		DailyAdventureActivity? activityDailyAdventureConfig = ConfigBase<ActivityDailyAdventureConfig>.Instance.GetActivityDailyAdventureConfig(this.DailyAdventureData.Id);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), activityDailyAdventureConfig.Value.AreaTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), activityDailyAdventureConfig.Value.AreaDescription, Array.Empty<object>());
		UUITexture texture = base.GetTexture(2);
		texture.SetUIActive(false);
		base.SetTextureByPath(activityDailyAdventureConfig.Value.AreaPic, texture, null, delegate(bool _)
		{
			texture.SetUIActive(true);
		});
	}

	// Token: 0x0600812D RID: 33069 RVA: 0x00222330 File Offset: 0x00220530
	private void RefreshTask()
	{
		List<DailyAdventureTaskData> allTaskInfo = this.DailyAdventureData.GetAllTaskInfo();
		this.TaskLayout.RefreshByData(allTaskInfo, null, false);
	}

	// Token: 0x0600812E RID: 33070 RVA: 0x00222358 File Offset: 0x00220558
	private void RefreshReward()
	{
		base.GetText(7).SetText(this.DailyAdventureData.ProgressPoint.ToString(), true);
		if (this.DailyAdventureData.ProgressPoint > this.ProgressPoint)
		{
			this.NiagaraProgressItem.SetUIActive(true);
			this.NiagaraProgressItem.ActivateSystem(true);
		}
		this.ProgressPoint = this.DailyAdventureData.ProgressPoint;
		List<DailyAdventureRewardData> allPointReward = this.DailyAdventureData.GetAllPointReward();
		int num = 0;
		while (num < allPointReward.Count && num < this.RewardItemList.Count)
		{
			this.RewardItemList[num].Refresh(allPointReward[num]);
			num++;
		}
	}

	// Token: 0x0600812F RID: 33071 RVA: 0x00222401 File Offset: 0x00220601
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x06008130 RID: 33072 RVA: 0x0022240C File Offset: 0x0022060C
	private void RefreshTimerText()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.PanelTime.SetUIActive(item);
		if (item)
		{
			this.TextTime.SetText(item2, true);
		}
	}

	// Token: 0x06008131 RID: 33073 RVA: 0x00222448 File Offset: 0x00220648
	private void OnActivityCrossDayRefresh()
	{
		if (!this.DailyAdventureData.CheckIfInShowTime())
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DailyAdventureRefresh);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x04003DAF RID: 15791
	protected ActivityDailyAdventureData DailyAdventureData;

	// Token: 0x04003DB0 RID: 15792
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<DailyAdventureTaskItem, DailyAdventureTaskData> TaskLayout;

	// Token: 0x04003DB1 RID: 15793
	[Nullable(1)]
	protected List<DailyAdventureRewardItem> RewardItemList = new List<DailyAdventureRewardItem>();

	// Token: 0x04003DB2 RID: 15794
	private UUIItem PanelTime;

	// Token: 0x04003DB3 RID: 15795
	private UUIText TextTime;

	// Token: 0x04003DB4 RID: 15796
	private UUINiagara NiagaraProgressItem;

	// Token: 0x04003DB5 RID: 15797
	private int ProgressPoint;

	// Token: 0x02007639 RID: 30265
	[NullableContext(0)]
	private class ESubViewComponents
	{
		// Token: 0x04028BF4 RID: 166900
		public const int TxtName = 0;

		// Token: 0x04028BF5 RID: 166901
		public const int TxtInfo = 1;

		// Token: 0x04028BF6 RID: 166902
		public const int TexMap = 2;

		// Token: 0x04028BF7 RID: 166903
		public const int PanelQuest = 3;

		// Token: 0x04028BF8 RID: 166904
		public const int TxtTitle = 4;

		// Token: 0x04028BF9 RID: 166905
		public const int PanelTime = 5;

		// Token: 0x04028BFA RID: 166906
		public const int TxtTime = 6;

		// Token: 0x04028BFB RID: 166907
		public const int TxtProgress = 7;

		// Token: 0x04028BFC RID: 166908
		public const int PanelReward = 8;

		// Token: 0x04028BFD RID: 166909
		public const int Reward1 = 9;

		// Token: 0x04028BFE RID: 166910
		public const int Reward2 = 10;

		// Token: 0x04028BFF RID: 166911
		public const int Reward3 = 11;

		// Token: 0x04028C00 RID: 166912
		public const int Reward4 = 12;

		// Token: 0x04028C01 RID: 166913
		public const int Reward5 = 13;

		// Token: 0x04028C02 RID: 166914
		public const int ProgressNiagara = 14;
	}
}
