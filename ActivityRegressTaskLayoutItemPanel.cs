using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001561 RID: 5473
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressTaskLayoutItemPanel : UiPanelBase, IGridProxy<ActivityRegressTaskScoreRewardGridData>
{
	// Token: 0x17000D24 RID: 3364
	// (get) Token: 0x06009989 RID: 39305 RVA: 0x00282C23 File Offset: 0x00280E23
	// (set) Token: 0x0600998A RID: 39306 RVA: 0x00282C2B File Offset: 0x00280E2B
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<ActivityRegressTaskScoreRewardGridData>, ActivityRegressTaskScoreRewardGridData> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x17000D25 RID: 3365
	// (get) Token: 0x0600998B RID: 39307 RVA: 0x00282C34 File Offset: 0x00280E34
	// (set) Token: 0x0600998C RID: 39308 RVA: 0x00282C3C File Offset: 0x00280E3C
	public int GridIndex { get; set; }

	// Token: 0x17000D26 RID: 3366
	// (get) Token: 0x0600998D RID: 39309 RVA: 0x00282C45 File Offset: 0x00280E45
	// (set) Token: 0x0600998E RID: 39310 RVA: 0x00282C4D File Offset: 0x00280E4D
	public int DisplayIndex { get; set; }

	// Token: 0x0600998F RID: 39311 RVA: 0x00282C58 File Offset: 0x00280E58
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnBtnRewardClick))
		};
	}

	// Token: 0x06009990 RID: 39312 RVA: 0x00282D74 File Offset: 0x00280F74
	protected override void OnStart()
	{
		this.ItemGridA = new SmallItemGrid();
		this.ItemGridA.Initialize(base.GetItem(6).GetOwner());
		this.ItemGridA.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		this.ItemGridA.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnExtendToggleClickedA));
		this.ItemGridB = new SmallItemGrid();
		this.ItemGridB.Initialize(base.GetItem(7).GetOwner());
		this.ItemGridB.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		this.ItemGridB.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnExtendToggleClickedB));
	}

	// Token: 0x06009991 RID: 39313 RVA: 0x00282E48 File Offset: 0x00281048
	public void Refresh(ActivityRegressTaskScoreRewardGridData data, bool isSelected, int gridIndex)
	{
		this.ScoreRewardGridData = data;
		this.GridIndex = gridIndex;
		List<IRegressRewardItemInfo> regressScoreRewardInfoList = ModelBase<ActivityRegressModel>.Instance.GetRegressScoreRewardInfoList(data.Config.Value);
		ERegressRewardState rewardState = data.RewardState;
		IRegressRewardItemInfo data2 = regressScoreRewardInfoList[0];
		ActivityRegressHelper.RefreshItemGridByData(this.ItemGridA, data2);
		bool flag = regressScoreRewardInfoList.Count > 1;
		this.ItemGridB.SetUiActive(flag);
		if (flag)
		{
			IRegressRewardItemInfo data3 = regressScoreRewardInfoList[1];
			ActivityRegressHelper.RefreshItemGridByData(this.ItemGridB, data3);
		}
		UUIText text = base.GetText(3);
		int needScore = data.Config.Value.NeedScore;
		UUIText uuitext = text;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(needScore);
		uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		text.useChangeColor = (rewardState == ERegressRewardState.Claim);
		if (text.useChangeColor)
		{
			text.SetColor(text.changeColor);
		}
		UUISprite sprite = base.GetSprite(0);
		ValueTuple<int, int> regressTaskRelativeScore = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetRegressTaskRelativeScore(data.Config.Value);
		int item = regressTaskRelativeScore.Item1;
		int item2 = regressTaskRelativeScore.Item2;
		float fillAmount = (float)item / (float)item2;
		sprite.SetFillAmount(fillAmount);
		base.GetItem(5).SetUIActive(rewardState == ERegressRewardState.Reached);
		base.GetItem(1).SetUIActive(rewardState != ERegressRewardState.Claim);
		base.GetItem(2).SetUIActive(rewardState == ERegressRewardState.Reached);
		base.GetItem(8).SetUIActive(rewardState == ERegressRewardState.Claim);
	}

	// Token: 0x06009992 RID: 39314 RVA: 0x00282FA8 File Offset: 0x002811A8
	public void Clear()
	{
		this.ScoreRewardGridData = null;
	}

	// Token: 0x06009993 RID: 39315 RVA: 0x00282FB1 File Offset: 0x002811B1
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x06009994 RID: 39316 RVA: 0x00282FB3 File Offset: 0x002811B3
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x06009995 RID: 39317 RVA: 0x00282FB5 File Offset: 0x002811B5
	public object GetKey(ActivityRegressTaskScoreRewardGridData data, int gridIndex)
	{
		return this.GridIndex;
	}

	// Token: 0x06009996 RID: 39318 RVA: 0x00282FC4 File Offset: 0x002811C4
	private void OnExtendToggleClickedA(MediumItemGridExtendCallback _)
	{
		if (this.ScoreRewardGridData.RewardState == ERegressRewardState.Reached)
		{
			ControllerBase<ActivityRegressController>.Instance.RequestAllTaskScoreRewards();
			return;
		}
		int id = ModelBase<ActivityRegressModel>.Instance.GetRegressScoreRewardInfoList(this.ScoreRewardGridData.Config.Value)[0].ItemInfo.Value.Id;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(id, true, null);
	}

	// Token: 0x06009997 RID: 39319 RVA: 0x00283030 File Offset: 0x00281230
	private void OnExtendToggleClickedB(MediumItemGridExtendCallback _)
	{
		if (this.ScoreRewardGridData.RewardState == ERegressRewardState.Reached)
		{
			ControllerBase<ActivityRegressController>.Instance.RequestAllTaskScoreRewards();
			return;
		}
		int id = ModelBase<ActivityRegressModel>.Instance.GetRegressScoreRewardInfoList(this.ScoreRewardGridData.Config.Value)[1].ItemInfo.Value.Id;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(id, true, null);
	}

	// Token: 0x06009998 RID: 39320 RVA: 0x0028309C File Offset: 0x0028129C
	private void OnBtnRewardClick()
	{
		if (this.ScoreRewardGridData.RewardState == ERegressRewardState.Reached)
		{
			ControllerBase<ActivityRegressController>.Instance.RequestAllTaskScoreRewards();
		}
	}

	// Token: 0x040046EA RID: 18154
	[Nullable(2)]
	private ActivityRegressTaskScoreRewardGridData ScoreRewardGridData;

	// Token: 0x040046EB RID: 18155
	[Nullable(2)]
	private SmallItemGrid ItemGridA;

	// Token: 0x040046EC RID: 18156
	[Nullable(2)]
	private SmallItemGrid ItemGridB;

	// Token: 0x02007923 RID: 31011
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040299F8 RID: 170488
		public const int SprBar = 0;

		// Token: 0x040299F9 RID: 170489
		public const int SprNor = 1;

		// Token: 0x040299FA RID: 170490
		public const int SprReceived = 2;

		// Token: 0x040299FB RID: 170491
		public const int TxtNum = 3;

		// Token: 0x040299FC RID: 170492
		public const int PnlHorItem = 4;

		// Token: 0x040299FD RID: 170493
		public const int RedDotItem = 5;

		// Token: 0x040299FE RID: 170494
		public const int ItemBaseB2A = 6;

		// Token: 0x040299FF RID: 170495
		public const int ItemBaseB2B = 7;

		// Token: 0x04029A00 RID: 170496
		public const int SprDone = 8;

		// Token: 0x04029A01 RID: 170497
		public const int BtnReward = 9;
	}
}
