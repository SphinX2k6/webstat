using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RacingBets.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200272D RID: 10029
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsActivityRewardView : UiViewBase
{
	// Token: 0x06013C76 RID: 81014 RVA: 0x00580A86 File Offset: 0x0057EC86
	public RacingBetsActivityRewardView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06013C77 RID: 81015 RVA: 0x00580A90 File Offset: 0x0057EC90
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseBtn)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickCloseBtn))
		};
	}

	// Token: 0x06013C78 RID: 81016 RVA: 0x00580B7D File Offset: 0x0057ED7D
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsRewardRefresh, new Action(this.RefreshView));
		Singleton<EventSystem>.Instance.Add<RacingBetsSeasonData>(EEventName.OnRacingBetsDataRefresh, new Action<RacingBetsSeasonData>(this.RefreshView));
	}

	// Token: 0x06013C79 RID: 81017 RVA: 0x00580BB7 File Offset: 0x0057EDB7
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsRewardRefresh, new Action(this.RefreshView));
		Singleton<EventSystem>.Instance.Remove<RacingBetsSeasonData>(EEventName.OnRacingBetsDataRefresh, new Action<RacingBetsSeasonData>(this.RefreshView));
	}

	// Token: 0x06013C7A RID: 81018 RVA: 0x00580BF4 File Offset: 0x0057EDF4
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsActivityRewardView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsActivityRewardView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013C7B RID: 81019 RVA: 0x00580C37 File Offset: 0x0057EE37
	private void RefreshView()
	{
		this.RefreshView(null);
	}

	// Token: 0x06013C7C RID: 81020 RVA: 0x00580C40 File Offset: 0x0057EE40
	private void RefreshView(RacingBetsSeasonData data)
	{
		if (this.CurGroupRewardData == null)
		{
			return;
		}
		foreach (RacingBetsRewardTabItem racingBetsRewardTabItem in this.TabLayout.GetLayoutItemList())
		{
			racingBetsRewardTabItem.RefreshItem();
		}
		List<RacingBetsRewardData> rewardDataList = this.CurGroupRewardData.GetRewardDataList();
		this.RewardLayout.RefreshByData(rewardDataList, null, false);
	}

	// Token: 0x06013C7D RID: 81021 RVA: 0x00580CB8 File Offset: 0x0057EEB8
	private RacingBetsActivityRewardItem RewardItemProxyCreate()
	{
		return new RacingBetsActivityRewardItem();
	}

	// Token: 0x06013C7E RID: 81022 RVA: 0x00580CBF File Offset: 0x0057EEBF
	private RacingBetsRewardTabItem TabItemProxyCreate()
	{
		RacingBetsRewardTabItem racingBetsRewardTabItem = new RacingBetsRewardTabItem();
		racingBetsRewardTabItem.BindClickToggleCallBack(new Action<RacingBetsGroupRewardData>(this.OnClickTabToggle));
		return racingBetsRewardTabItem;
	}

	// Token: 0x06013C7F RID: 81023 RVA: 0x00580CD8 File Offset: 0x0057EED8
	private void OnClickTabToggle(RacingBetsGroupRewardData groupData)
	{
		if (this.CurGroupRewardData == groupData)
		{
			return;
		}
		this.CurGroupRewardData = groupData;
		int gridIndex = this.GroupDataList.FindIndex((RacingBetsGroupRewardData data) => data == groupData);
		this.TabLayout.SelectGridProxy(gridIndex, false);
		List<RacingBetsRewardData> rewardDataList = groupData.GetRewardDataList();
		this.RewardLayout.RefreshByData(rewardDataList, null, false);
	}

	// Token: 0x06013C80 RID: 81024 RVA: 0x00580D4C File Offset: 0x0057EF4C
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x040099FA RID: 39418
	[Nullable(2)]
	private RacingBetsGroupRewardData CurGroupRewardData;

	// Token: 0x040099FB RID: 39419
	private List<RacingBetsGroupRewardData> GroupDataList;

	// Token: 0x040099FC RID: 39420
	private GenericLayout<RacingBetsRewardTabItem, RacingBetsGroupRewardData> TabLayout;

	// Token: 0x040099FD RID: 39421
	private GenericLayout<RacingBetsActivityRewardItem, RacingBetsRewardData> RewardLayout;

	// Token: 0x02008AD4 RID: 35540
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ECDD RID: 191709
		public const int CloseBtn = 0;

		// Token: 0x0402ECDE RID: 191710
		public const int TogLayout = 1;

		// Token: 0x0402ECDF RID: 191711
		public const int RewardLayout = 2;

		// Token: 0x0402ECE0 RID: 191712
		public const int ContentItem = 3;

		// Token: 0x0402ECE1 RID: 191713
		public const int TimeText = 4;

		// Token: 0x0402ECE2 RID: 191714
		public const int MaskButton = 5;

		// Token: 0x0402ECE3 RID: 191715
		public const int TitleText = 6;
	}
}
