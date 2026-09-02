using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029B1 RID: 10673
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerDescLeftPanel : UiPanelBase
{
	// Token: 0x06015474 RID: 87156 RVA: 0x005E58DC File Offset: 0x005E3ADC
	public UniTask Init(UUIItem item, ShipTowerStageData data)
	{
		ShipTowerDescLeftPanel.<Init>d__4 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.data = data;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ShipTowerDescLeftPanel.<Init>d__4>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06015475 RID: 87157 RVA: 0x005E5930 File Offset: 0x005E3B30
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(7, typeof(UUIMultiTemplateLayout)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnBtnRewardDetailClick))
		};
	}

	// Token: 0x06015476 RID: 87158 RVA: 0x005E5A60 File Offset: 0x005E3C60
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerDescLeftPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerDescLeftPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015477 RID: 87159 RVA: 0x005E5AA3 File Offset: 0x005E3CA3
	private CommonItemSmallItemGrid CreateRewardItemGrid()
	{
		return new CommonItemSmallItemGrid
		{
			ShowReceivedCallBack = ((TItem _) => this.StageData.IsPassed())
		};
	}

	// Token: 0x06015478 RID: 87160 RVA: 0x005E5ABC File Offset: 0x005E3CBC
	protected override void OnBeforeShow()
	{
		this.UpdateData(this.StageData);
	}

	// Token: 0x06015479 RID: 87161 RVA: 0x005E5ACA File Offset: 0x005E3CCA
	public void UpdateViewAndShow(ShipTowerStageData data)
	{
		this.StageData = data;
		if (base.GetActive())
		{
			this.UpdateData(this.StageData);
			return;
		}
		this.SetActive(true);
	}

	// Token: 0x0601547A RID: 87162 RVA: 0x005E5AF0 File Offset: 0x005E3CF0
	private void UpdateData(ShipTowerStageData data)
	{
		this.StageData = data;
		this.UpdateIndex();
		base.GetText(3).ShowTextNew(this.StageData.TitleKey);
		string textStringId = "GhostShipPoint_Text";
		UUIText text = base.GetText(4);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlySingleElementList<object>(this.StageData.CurrentScore.ToString()));
		base.GetText(5).ShowTextNew(this.StageData.DescKey);
		this.UpdateName();
		GenericLayout<ShipTowerScoreInfoItem, ShipTowerScoreInfoData> scoreInfoLayout = this.ScoreInfoLayout;
		if (scoreInfoLayout != null)
		{
			scoreInfoLayout.RefreshByData(this.StageData.GetTargetScoreInfoList(), null, false);
		}
		List<TItem> passUnlockBuffList = this.StageData.GetPassUnlockBuffList();
		UUIItem item = base.GetItem(10);
		if (item != null)
		{
			item.SetUIActive(passUnlockBuffList.Count > 0);
		}
		if (passUnlockBuffList.Count > 0)
		{
			GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
			if (rewardLayout == null)
			{
				return;
			}
			rewardLayout.RefreshByData(passUnlockBuffList, null, false);
		}
	}

	// Token: 0x0601547B RID: 87163 RVA: 0x005E5BD0 File Offset: 0x005E3DD0
	private void UpdateIndex()
	{
		bool isEndLess = this.StageData.IsEndLess;
		base.GetTexture(2).SetUIActive(isEndLess);
		base.GetTexture(0).SetUIActive(!isEndLess);
		if (!isEndLess)
		{
			base.GetText(1).SetText(this.StageData.OrderIndex.ToString(), true);
		}
	}

	// Token: 0x0601547C RID: 87164 RVA: 0x005E5C26 File Offset: 0x005E3E26
	private void UpdateName()
	{
	}

	// Token: 0x0601547D RID: 87165 RVA: 0x005E5C28 File Offset: 0x005E3E28
	private void OnBtnRewardDetailClick()
	{
		ShipTowerStageData stageData = this.StageData;
		if (stageData == null)
		{
			return;
		}
		stageData.OpenViewPassBuffShow();
	}

	// Token: 0x0400A413 RID: 42003
	[Nullable(2)]
	private ShipTowerStageData StageData;

	// Token: 0x0400A414 RID: 42004
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerScoreInfoItem, ShipTowerScoreInfoData> ScoreInfoLayout;

	// Token: 0x0400A415 RID: 42005
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x02008D03 RID: 36099
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F6E7 RID: 194279
		public const int TextureIndexBg = 0;

		// Token: 0x0402F6E8 RID: 194280
		public const int TxtIndex = 1;

		// Token: 0x0402F6E9 RID: 194281
		public const int TextureEndlessNode = 2;

		// Token: 0x0402F6EA RID: 194282
		public const int TxtStageName = 3;

		// Token: 0x0402F6EB RID: 194283
		public const int TxtScore = 4;

		// Token: 0x0402F6EC RID: 194284
		public const int TxtDesc = 5;

		// Token: 0x0402F6ED RID: 194285
		public const int VLayoutScoreTarget = 6;

		// Token: 0x0402F6EE RID: 194286
		public const int MLayoutReward = 7;

		// Token: 0x0402F6EF RID: 194287
		public const int ItemReward = 8;

		// Token: 0x0402F6F0 RID: 194288
		public const int BtnRewardDetail = 9;

		// Token: 0x0402F6F1 RID: 194289
		public const int RewardTipRoot = 10;
	}
}
