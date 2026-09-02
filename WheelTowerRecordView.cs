using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016E1 RID: 5857
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerRecordView : UiViewBase
{
	// Token: 0x0600A28C RID: 41612 RVA: 0x002AE06F File Offset: 0x002AC26F
	[NullableContext(1)]
	public WheelTowerRecordView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A28D RID: 41613 RVA: 0x002AE078 File Offset: 0x002AC278
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnResetBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A28E RID: 41614 RVA: 0x002AE22C File Offset: 0x002AC42C
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerRecordView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerRecordView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A28F RID: 41615 RVA: 0x002AE26F File Offset: 0x002AC46F
	public void RefreshView()
	{
		WheelTowerRecordScoreInfoPanel scoreInfoPanel = this.ScoreInfoPanel;
		if (scoreInfoPanel != null)
		{
			scoreInfoPanel.Refresh();
		}
		WheelTowerRecordTeamInfoPanel teamInfoPanel = this.TeamInfoPanel;
		if (teamInfoPanel != null)
		{
			teamInfoPanel.Refresh();
		}
		this.RefreshBossList();
	}

	// Token: 0x0600A290 RID: 41616 RVA: 0x002AE29C File Offset: 0x002AC49C
	public void RefreshBossList()
	{
		int selectedRound = ModelBase<WheelTowerModel>.Instance.SelectedRound;
		List<IBossInfo> teamKillBossInfo = ModelBase<WheelTowerModel>.Instance.GetTeamKillBossInfo(selectedRound, null);
		List<IBossItemData> list = new List<IBossItemData>();
		foreach (IBossInfo bossInfo in teamKillBossInfo)
		{
			list.Add(new BossItemData
			{
				BossInfo = bossInfo,
				StartPercent = new float?(0f)
			});
		}
		GenericLayout<WheelTowerRecordBossItem, IBossItemData> bossLayout = this.BossLayout;
		if (bossLayout == null)
		{
			return;
		}
		bossLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0600A291 RID: 41617 RVA: 0x002AE340 File Offset: 0x002AC540
	private void OnTeamItemClick(int index)
	{
		GenericScrollViewNew<WheelTowerRecordTeamItem, int> teamScrollView = this.TeamScrollView;
		if (teamScrollView != null)
		{
			teamScrollView.SelectGridProxy(index, false);
		}
		ModelBase<WheelTowerModel>.Instance.UpdateSelectRound(index, false);
		base.PlayOrReplaySequence("Switch", false, null);
		this.RefreshView();
	}

	// Token: 0x0600A292 RID: 41618 RVA: 0x002AE387 File Offset: 0x002AC587
	[NullableContext(1)]
	private WheelTowerRecordTeamItem CreateTeamItem()
	{
		return new WheelTowerRecordTeamItem
		{
			OnToggleClickCallback = new Action<int>(this.OnTeamItemClick)
		};
	}

	// Token: 0x0600A293 RID: 41619 RVA: 0x002AE3A0 File Offset: 0x002AC5A0
	private void OnCloseBtnClick()
	{
		ModelBase<WheelTowerModel>.Instance.UpdateSelectRound(this.FirstSelectedIndex, false);
		base.CloseMe(null);
	}

	// Token: 0x0600A294 RID: 41620 RVA: 0x002AE3BC File Offset: 0x002AC5BC
	private void OnResetBtnClick()
	{
		if (!ModelBase<WheelTowerModel>.Instance.HasChallengeAnyRound(null))
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WheelTowerRoundResetAllConfirm);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			NewTowerClimbingLevelRecord currentLevelRecord = ModelBase<WheelTowerModel>.Instance.GetCurrentLevelRecord(null);
			ControllerBase<WheelTowerController>.Instance.RequestResetLevelRecord(currentLevelRecord.LevelId).ContinueWith(new Action(this.CloseSelf));
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x04004CEE RID: 19694
	private int FirstSelectedIndex;

	// Token: 0x04004CEF RID: 19695
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004CF0 RID: 19696
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<WheelTowerRecordTeamItem, int> TeamScrollView;

	// Token: 0x04004CF1 RID: 19697
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerRecordBossItem, IBossItemData> BossLayout;

	// Token: 0x04004CF2 RID: 19698
	private WheelTowerRecordScoreInfoPanel ScoreInfoPanel;

	// Token: 0x04004CF3 RID: 19699
	private WheelTowerRecordTeamInfoPanel TeamInfoPanel;
}
