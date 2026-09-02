using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CD1 RID: 7377
[NullableContext(1)]
[Nullable(0)]
public class GachaAccumulateBonusViewContentStage : GachaAccumulateBonusContentBase
{
	// Token: 0x0600D843 RID: 55363 RVA: 0x0039D5B4 File Offset: 0x0039B7B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 18;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D844 RID: 55364 RVA: 0x0039D838 File Offset: 0x0039BA38
	protected override UniTask OnBeforeStartAsync()
	{
		GachaAccumulateBonusViewContentStage.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GachaAccumulateBonusViewContentStage.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D845 RID: 55365 RVA: 0x0039D87C File Offset: 0x0039BA7C
	protected override void OnStart()
	{
		this.UiSequencePlayer = new UiSequencePlayer(this.RootItem);
		this.LoopScroll = new LoopScrollView<GachaAccumulateRewardItemStage, GachaAccumulateRewardItemStageData>(base.GetLoopScrollViewComponent(2), base.GetItem(3).GetOwner() as AUIBaseActor, () => new GachaAccumulateRewardItemStage(), false);
		this.LoopScroll.BindOnScrollValueChanged(delegate(FVector2D _)
		{
			this.OnLoopScrollValueChanged();
		});
		this.LoopScroll.BindLateUpdate(new Action<float>(this.OnLoopScrollLateUpdate));
	}

	// Token: 0x0600D846 RID: 55366 RVA: 0x0039D90B File Offset: 0x0039BB0B
	protected override void OnBeforeDestroy()
	{
		if (this.LoopScroll != null)
		{
			this.LoopScroll.UnBindLateUpdate();
			this.LoopScroll.ClearGridProxies();
			this.LoopScroll = null;
		}
	}

	// Token: 0x0600D847 RID: 55367 RVA: 0x0039D934 File Offset: 0x0039BB34
	public override UniTask PlayStartSequence()
	{
		GachaAccumulateBonusViewContentStage.<PlayStartSequence>d__23 <PlayStartSequence>d__;
		<PlayStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayStartSequence>d__.<>4__this = this;
		<PlayStartSequence>d__.<>1__state = -1;
		<PlayStartSequence>d__.<>t__builder.Start<GachaAccumulateBonusViewContentStage.<PlayStartSequence>d__23>(ref <PlayStartSequence>d__);
		return <PlayStartSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600D848 RID: 55368 RVA: 0x0039D978 File Offset: 0x0039BB78
	public override UniTask PlayCloseSequence()
	{
		GachaAccumulateBonusViewContentStage.<PlayCloseSequence>d__24 <PlayCloseSequence>d__;
		<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseSequence>d__.<>4__this = this;
		<PlayCloseSequence>d__.<>1__state = -1;
		<PlayCloseSequence>d__.<>t__builder.Start<GachaAccumulateBonusViewContentStage.<PlayCloseSequence>d__24>(ref <PlayCloseSequence>d__);
		return <PlayCloseSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600D849 RID: 55369 RVA: 0x0039D9BB File Offset: 0x0039BBBB
	public override void SetOnClickBackButtonCallBack(Action callback)
	{
		this.OnClickBackButtonCallBack = callback;
	}

	// Token: 0x0600D84A RID: 55370 RVA: 0x0039D9C4 File Offset: 0x0039BBC4
	private void OnBackButtonClick()
	{
		this.OnClickBackButtonCallBack();
	}

	// Token: 0x0600D84B RID: 55371 RVA: 0x0039D9D4 File Offset: 0x0039BBD4
	private void RefreshCaptionHelpBtn(int accumulateId)
	{
		int helpId = ConfigBase<GachaAccumulateConfig>.Instance.GetHelpId(accumulateId);
		if (helpId <= 0)
		{
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetHelpBtnActive(false);
			return;
		}
		else
		{
			PopupCaptionItem captionItem2 = this.CaptionItem;
			if (captionItem2 != null)
			{
				captionItem2.SetHelpBtnActive(true);
			}
			PopupCaptionItem captionItem3 = this.CaptionItem;
			if (captionItem3 == null)
			{
				return;
			}
			captionItem3.SetHelpCallBack(delegate
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
			});
			return;
		}
	}

	// Token: 0x0600D84C RID: 55372 RVA: 0x0039DA44 File Offset: 0x0039BC44
	public override void RefreshView(int accumulateId)
	{
		this.CurrentAccumulateId = accumulateId;
		GachaAccumulateData accumulateData = ModelBase<GachaAccumulateModel>.Instance.GetAccumulateData(accumulateId);
		if (accumulateData == null)
		{
			return;
		}
		this.RefreshCaptionHelpBtn(accumulateId);
		int cyclicBaseGachaNum = accumulateData.GetCyclicBaseGachaNum();
		bool flag = cyclicBaseGachaNum > 0 && accumulateData.CurGachaNum >= cyclicBaseGachaNum;
		UUIText text = base.GetText(10);
		UUIItem item = base.GetItem(17);
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "allProgressRewardsCompleted", Array.Empty<object>());
			item.SetUIActive(false);
		}
		else
		{
			text.SetText(accumulateData.CurGachaNum.ToString(), true);
			item.SetUIActive(true);
		}
		bool flag2 = this.CollectNonCyclicMilestones(accumulateData).Count <= 9;
		this.ApplyLayoutVisibility(flag2);
		if (flag2)
		{
			GachaAccumulateStageBigRewardPanel bigRewardPanel = this.BigRewardPanel;
			if (bigRewardPanel != null)
			{
				bigRewardPanel.SetUiActive(false);
			}
			GachaAccumulateStageCyclicPanel cyclicPanel = this.CyclicPanel;
			if (cyclicPanel != null)
			{
				cyclicPanel.SetUiActive(false);
			}
			this.NeedLateUpdate = false;
			this.LastAutoScrollAccumulateId = accumulateId;
			this.RefreshFixedLayout(accumulateId, accumulateData);
			this.RefreshFixedProgressBar(accumulateData);
			return;
		}
		this.RefreshLayout(accumulateId, accumulateData);
		this.RefreshProgressBar(accumulateData);
		this.RefreshBigRewardByScroll(accumulateData);
	}

	// Token: 0x0600D84D RID: 55373 RVA: 0x0039DB54 File Offset: 0x0039BD54
	private void ApplyLayoutVisibility(bool useFixed)
	{
		LoopScrollView<GachaAccumulateRewardItemStage, GachaAccumulateRewardItemStageData> loopScroll = this.LoopScroll;
		if (loopScroll != null)
		{
			loopScroll.SetTargetRootComponentActive(!useFixed);
		}
		base.GetItem(4).SetUIActive(!useFixed);
		base.GetItem(8).SetUIActive(!useFixed);
		base.GetItem(9).SetUIActive(!useFixed);
		base.GetHorizontalLayout(11).RootUIComp.Get().SetUIActive(useFixed);
		base.GetItem(13).SetUIActive(useFixed);
	}

	// Token: 0x0600D84E RID: 55374 RVA: 0x0039DBD0 File Offset: 0x0039BDD0
	private void RefreshLayout(int accumulateId, GachaAccumulateData accumulateData)
	{
		List<GachaAccumulateRewardItemStageData> list = new List<GachaAccumulateRewardItemStageData>();
		GachaAccumulateRewardData lastData = null;
		foreach (GachaAccumulateRewardData gachaAccumulateRewardData in accumulateData.GroupData.RewardInfos)
		{
			if (!gachaAccumulateRewardData.GetIfCyclic())
			{
				list.Add(new GachaAccumulateRewardItemStageData
				{
					AccumulateId = accumulateId,
					Data = gachaAccumulateRewardData,
					LastData = lastData
				});
				lastData = gachaAccumulateRewardData;
			}
		}
		this.LastSeenEndGridIndex = -2;
		if (this.LastAutoScrollAccumulateId != accumulateId)
		{
			this.LastAutoScrollAccumulateId = accumulateId;
			this.NeedLateUpdate = true;
		}
		this.LoopScroll.RefreshByData(list, false, null, false);
	}

	// Token: 0x0600D84F RID: 55375 RVA: 0x0039DC84 File Offset: 0x0039BE84
	private void RefreshProgressBar(GachaAccumulateData accumulateData)
	{
		this.EnsurePointItems(accumulateData);
		List<int> milestones = this.CollectNonCyclicMilestones(accumulateData);
		base.GetSprite(5).SetFillAmount(this.CalcProgressFillAmount(milestones, accumulateData.CurGachaNum));
		this.RefreshPointItemsState(this.SpawnedPointItems, milestones, accumulateData.CurGachaNum);
	}

	// Token: 0x0600D850 RID: 55376 RVA: 0x0039DCCC File Offset: 0x0039BECC
	private void RefreshFixedLayout(int accumulateId, GachaAccumulateData accumulateData)
	{
		if (!this.FixedSpawnStarted)
		{
			this.FixedSpawnStarted = true;
			int count = this.CollectNonCyclicMilestones(accumulateData).Count;
			this.SpawnFixedPointItems(count);
			this.SpawnFixedItemsAsync(accumulateId, count).Forget();
			return;
		}
		if (!this.FixedReady)
		{
			return;
		}
		this.RefreshFixedRewardItemsData(accumulateId, accumulateData);
	}

	// Token: 0x0600D851 RID: 55377 RVA: 0x0039DD1C File Offset: 0x0039BF1C
	private UniTask SpawnFixedItemsAsync(int accumulateId, int count)
	{
		GachaAccumulateBonusViewContentStage.<SpawnFixedItemsAsync>d__33 <SpawnFixedItemsAsync>d__;
		<SpawnFixedItemsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SpawnFixedItemsAsync>d__.<>4__this = this;
		<SpawnFixedItemsAsync>d__.accumulateId = accumulateId;
		<SpawnFixedItemsAsync>d__.count = count;
		<SpawnFixedItemsAsync>d__.<>1__state = -1;
		<SpawnFixedItemsAsync>d__.<>t__builder.Start<GachaAccumulateBonusViewContentStage.<SpawnFixedItemsAsync>d__33>(ref <SpawnFixedItemsAsync>d__);
		return <SpawnFixedItemsAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D852 RID: 55378 RVA: 0x0039DD70 File Offset: 0x0039BF70
	private void RefreshFixedRewardItemsData(int accumulateId, GachaAccumulateData accumulateData)
	{
		GachaAccumulateRewardData lastData = null;
		int num = 0;
		foreach (GachaAccumulateRewardData gachaAccumulateRewardData in accumulateData.GroupData.RewardInfos)
		{
			if (!gachaAccumulateRewardData.GetIfCyclic())
			{
				if (num < this.SpawnedFixedRewardItems.Count)
				{
					GridProxyAbstract<GachaAccumulateRewardItemStageData> gridProxyAbstract = this.SpawnedFixedRewardItems[num];
					GachaAccumulateRewardItemStageData data = new GachaAccumulateRewardItemStageData
					{
						AccumulateId = accumulateId,
						Data = gachaAccumulateRewardData,
						LastData = lastData
					};
					gridProxyAbstract.Refresh(data, false, num);
				}
				lastData = gachaAccumulateRewardData;
				num++;
			}
		}
	}

	// Token: 0x0600D853 RID: 55379 RVA: 0x0039DE14 File Offset: 0x0039C014
	private void SpawnFixedPointItems(int count)
	{
		UUIItem item = base.GetItem(16);
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(15);
		if (item == null || horizontalLayout == null)
		{
			return;
		}
		item.SetUIActive(false);
		for (int i = 0; i < count; i++)
		{
			UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(item, horizontalLayout.RootUIComp);
			uuiitem.SetUIActive(true);
			this.SpawnedFixedPointItems.Add(uuiitem);
		}
	}

	// Token: 0x0600D854 RID: 55380 RVA: 0x0039DE78 File Offset: 0x0039C078
	private void RefreshFixedProgressBar(GachaAccumulateData accumulateData)
	{
		List<int> milestones = this.CollectNonCyclicMilestones(accumulateData);
		UUISprite sprite = base.GetSprite(14);
		float width = base.GetHorizontalLayout(15).RootUIComp.Get().Width;
		sprite.SetFillAmount(this.CalcFixedProgressFillAmount(milestones, accumulateData.CurGachaNum, width));
		this.RefreshPointItemsState(this.SpawnedFixedPointItems, milestones, accumulateData.CurGachaNum);
	}

	// Token: 0x0600D855 RID: 55381 RVA: 0x0039DED8 File Offset: 0x0039C0D8
	private void RefreshPointItemsState(List<UUIItem> pointItems, List<int> milestones, int cur)
	{
		for (int i = 0; i < pointItems.Count; i++)
		{
			UUIItem attachUIChild = pointItems[i].GetAttachUIChild(1);
			if (attachUIChild != null)
			{
				bool uiactive = i < milestones.Count && cur >= milestones[i];
				attachUIChild.SetUIActive(uiactive);
			}
		}
	}

	// Token: 0x0600D856 RID: 55382 RVA: 0x0039DF28 File Offset: 0x0039C128
	private List<int> CollectNonCyclicMilestones(GachaAccumulateData accumulateData)
	{
		List<int> list = new List<int>();
		foreach (GachaAccumulateRewardData gachaAccumulateRewardData in accumulateData.GroupData.RewardInfos)
		{
			if (!gachaAccumulateRewardData.GetIfCyclic())
			{
				list.Add(gachaAccumulateRewardData.GachaNum);
			}
		}
		return list;
	}

	// Token: 0x0600D857 RID: 55383 RVA: 0x0039DF94 File Offset: 0x0039C194
	private float CalcProgressFillAmount(List<int> milestones, int cur)
	{
		if (milestones.Count == 0)
		{
			return 0f;
		}
		int num = 90;
		int num2 = 180;
		int num3 = num + num2 * (milestones.Count - 1);
		int num4 = milestones[milestones.Count - 1];
		double num5;
		if (cur >= num4)
		{
			num5 = (double)num3;
		}
		else if (cur < milestones[0])
		{
			num5 = (double)num * ((double)cur / (double)milestones[0]);
		}
		else
		{
			int num6 = 0;
			while (num6 < milestones.Count - 1 && (cur < milestones[num6] || cur >= milestones[num6 + 1]))
			{
				num6++;
			}
			double num7 = (double)(cur - milestones[num6]) / (double)(milestones[num6 + 1] - milestones[num6]);
			num5 = (double)(num + num2 * num6) + (double)num2 * num7;
		}
		double num8 = (num3 > 0) ? (num5 / (double)num3) : 0.0;
		return (float)((num8 < 0.0) ? 0.0 : ((num8 > 1.0) ? 1.0 : num8));
	}

	// Token: 0x0600D858 RID: 55384 RVA: 0x0039E0AC File Offset: 0x0039C2AC
	private float CalcFixedProgressFillAmount(List<int> milestones, int cur, float pointListWidth)
	{
		if (milestones.Count == 0)
		{
			return 0f;
		}
		int num = 90;
		float num2 = (float)num + pointListWidth;
		if (milestones.Count != 1)
		{
			float num3 = pointListWidth / (float)(milestones.Count - 1);
			int num4 = milestones[milestones.Count - 1];
			double num5;
			if (cur >= num4)
			{
				num5 = (double)num2;
			}
			else if (cur < milestones[0])
			{
				num5 = (double)num * ((double)cur / (double)milestones[0]);
			}
			else
			{
				int num6 = 0;
				while (num6 < milestones.Count - 1 && (cur < milestones[num6] || cur >= milestones[num6 + 1]))
				{
					num6++;
				}
				double num7 = (double)(cur - milestones[num6]) / (double)(milestones[num6 + 1] - milestones[num6]);
				num5 = (double)((float)num + num3 * (float)num6) + (double)num3 * num7;
			}
			double num8 = (num2 > 0f) ? (num5 / (double)num2) : 0.0;
			return (float)((num8 < 0.0) ? 0.0 : ((num8 > 1.0) ? 1.0 : num8));
		}
		int num9 = milestones[0];
		if (num9 <= 0)
		{
			return 0f;
		}
		float num10 = (float)cur / (float)num9;
		if (num10 < 0f)
		{
			return 0f;
		}
		if (num10 <= 1f)
		{
			return num10;
		}
		return 1f;
	}

	// Token: 0x0600D859 RID: 55385 RVA: 0x0039E210 File Offset: 0x0039C410
	private void EnsurePointItems(GachaAccumulateData accumulateData)
	{
		UUIItem item = base.GetItem(7);
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(6);
		if (item == null || horizontalLayout == null)
		{
			return;
		}
		item.SetUIActive(false);
		int count = accumulateData.GroupData.RewardInfos.FindAll((GachaAccumulateRewardData reward) => !reward.GetIfCyclic()).Count;
		if (this.SpawnedPointItems.Count == count)
		{
			return;
		}
		foreach (UUIItem uuiitem in this.SpawnedPointItems)
		{
			AActor owner = uuiitem.GetOwner();
			if (owner != null)
			{
				owner.K2_DestroyActor();
			}
		}
		this.SpawnedPointItems.Clear();
		for (int i = 0; i < count; i++)
		{
			UUIItem uuiitem2 = Singleton<LguiUtil>.Instance.CopyItem(item, horizontalLayout.RootUIComp);
			uuiitem2.SetUIActive(true);
			this.SpawnedPointItems.Add(uuiitem2);
		}
	}

	// Token: 0x0600D85A RID: 55386 RVA: 0x0039E318 File Offset: 0x0039C518
	private void OnLoopScrollLateUpdate(float deltaTime)
	{
		if (!this.NeedLateUpdate || this.LoopScroll == null)
		{
			return;
		}
		this.NeedLateUpdate = false;
		GachaAccumulateData accumulateData = ModelBase<GachaAccumulateModel>.Instance.GetAccumulateData(this.CurrentAccumulateId);
		if (accumulateData == null)
		{
			return;
		}
		int gridIndex = this.FindHighestClaimedIndex(accumulateData);
		this.LoopScroll.ScrollToGridIndex(gridIndex, true);
	}

	// Token: 0x0600D85B RID: 55387 RVA: 0x0039E368 File Offset: 0x0039C568
	private int FindHighestClaimedIndex(GachaAccumulateData accumulateData)
	{
		int num = -1;
		int num2 = 0;
		foreach (GachaAccumulateRewardData gachaAccumulateRewardData in accumulateData.GroupData.RewardInfos)
		{
			if (!gachaAccumulateRewardData.GetIfCyclic())
			{
				if (gachaAccumulateRewardData.Status == EGachaAccumulateRewardStatus.Claimed)
				{
					num = num2;
				}
				num2++;
			}
		}
		if (num >= 0)
		{
			return num;
		}
		return 0;
	}

	// Token: 0x0600D85C RID: 55388 RVA: 0x0039E3DC File Offset: 0x0039C5DC
	private void OnLoopScrollValueChanged()
	{
		if (this.LoopScroll == null)
		{
			return;
		}
		int displayGridEndIndex = this.LoopScroll.GetDisplayGridEndIndex();
		if (displayGridEndIndex == this.LastSeenEndGridIndex)
		{
			return;
		}
		this.LastSeenEndGridIndex = displayGridEndIndex;
		if (displayGridEndIndex < 0)
		{
			return;
		}
		GachaAccumulateData accumulateData = ModelBase<GachaAccumulateModel>.Instance.GetAccumulateData(this.CurrentAccumulateId);
		if (accumulateData == null)
		{
			return;
		}
		this.RefreshBigRewardByScroll(accumulateData);
	}

	// Token: 0x0600D85D RID: 55389 RVA: 0x0039E430 File Offset: 0x0039C630
	private void RefreshBigRewardByScroll(GachaAccumulateData accumulateData)
	{
		BigRewardSlot bigRewardSlot = this.PickBigRewardSlot(accumulateData);
		if (bigRewardSlot.Kind == EBigRewardSlotKind.Big)
		{
			GachaAccumulateStageBigRewardPanel bigRewardPanel = this.BigRewardPanel;
			if (bigRewardPanel != null)
			{
				bigRewardPanel.SetUiActive(true);
			}
			GachaAccumulateStageBigRewardPanel bigRewardPanel2 = this.BigRewardPanel;
			if (bigRewardPanel2 != null)
			{
				bigRewardPanel2.Refresh(this.CurrentAccumulateId, bigRewardSlot.Reward);
			}
			GachaAccumulateStageCyclicPanel cyclicPanel = this.CyclicPanel;
			if (cyclicPanel == null)
			{
				return;
			}
			cyclicPanel.SetUiActive(false);
			return;
		}
		else
		{
			GachaAccumulateStageBigRewardPanel bigRewardPanel3 = this.BigRewardPanel;
			if (bigRewardPanel3 != null)
			{
				bigRewardPanel3.SetUiActive(false);
			}
			if (bigRewardSlot.Kind == EBigRewardSlotKind.Cyclic)
			{
				GachaAccumulateRewardData reward2 = accumulateData.GroupData.RewardInfos.Find((GachaAccumulateRewardData reward) => reward.GetIfCyclic());
				GachaAccumulateStageCyclicPanel cyclicPanel2 = this.CyclicPanel;
				if (cyclicPanel2 != null)
				{
					cyclicPanel2.SetUiActive(true);
				}
				GachaAccumulateStageCyclicPanel cyclicPanel3 = this.CyclicPanel;
				if (cyclicPanel3 == null)
				{
					return;
				}
				cyclicPanel3.Refresh(this.CurrentAccumulateId, reward2, accumulateData);
				return;
			}
			else
			{
				GachaAccumulateStageCyclicPanel cyclicPanel4 = this.CyclicPanel;
				if (cyclicPanel4 == null)
				{
					return;
				}
				cyclicPanel4.SetUiActive(false);
				return;
			}
		}
	}

	// Token: 0x0600D85E RID: 55390 RVA: 0x0039E518 File Offset: 0x0039C718
	private BigRewardSlot PickBigRewardSlot(GachaAccumulateData accumulateData)
	{
		GachaAccumulateBonusViewContentStage.<>c__DisplayClass46_0 CS$<>8__locals1 = new GachaAccumulateBonusViewContentStage.<>c__DisplayClass46_0();
		List<GachaAccumulateRewardData> rewardInfos = accumulateData.GroupData.RewardInfos;
		List<GachaAccumulateRewardData> list = rewardInfos.FindAll((GachaAccumulateRewardData reward) => !reward.GetIfCyclic() && reward.IsBigReward);
		GachaAccumulateRewardData gachaAccumulateRewardData = rewardInfos.Find((GachaAccumulateRewardData reward) => reward.GetIfCyclic());
		bool flag = accumulateData.CurGachaNum >= accumulateData.GetCyclicBaseGachaNum();
		bool flag2 = gachaAccumulateRewardData != null && (gachaAccumulateRewardData.IsPreView || flag);
		LoopScrollView<GachaAccumulateRewardItemStage, GachaAccumulateRewardItemStageData> loopScroll = this.LoopScroll;
		int num = (loopScroll != null) ? loopScroll.GetDisplayGridEndIndex() : -1;
		GachaAccumulateBonusViewContentStage.<>c__DisplayClass46_0 CS$<>8__locals2 = CS$<>8__locals1;
		GachaAccumulateRewardItemStageData endData;
		if (num < 0)
		{
			endData = null;
		}
		else
		{
			LoopScrollView<GachaAccumulateRewardItemStage, GachaAccumulateRewardItemStageData> loopScroll2 = this.LoopScroll;
			endData = ((loopScroll2 != null) ? loopScroll2.TryGetCachedData(num) : null);
		}
		CS$<>8__locals2.endData = endData;
		GachaAccumulateRewardItemStageData endData2 = CS$<>8__locals1.endData;
		if (((endData2 != null) ? endData2.Data : null) == null)
		{
			return this.PickInitialSlot(list, flag2);
		}
		GachaAccumulateRewardData gachaAccumulateRewardData2 = list.Find((GachaAccumulateRewardData reward) => reward.GachaNum > CS$<>8__locals1.endData.Data.GachaNum);
		if (gachaAccumulateRewardData2 != null)
		{
			return BigRewardSlot.MakeBig(gachaAccumulateRewardData2);
		}
		if (flag2)
		{
			return BigRewardSlot.MakeCyclic();
		}
		return BigRewardSlot.MakeNone();
	}

	// Token: 0x0600D85F RID: 55391 RVA: 0x0039E628 File Offset: 0x0039C828
	private BigRewardSlot PickInitialSlot(List<GachaAccumulateRewardData> nonCyclicBigList, bool cyclicAllowed)
	{
		if (nonCyclicBigList.Count > 0)
		{
			return BigRewardSlot.MakeBig(nonCyclicBigList.Find((GachaAccumulateRewardData reward) => reward.Status == EGachaAccumulateRewardStatus.NotReached) ?? nonCyclicBigList[0]);
		}
		if (!cyclicAllowed)
		{
			return BigRewardSlot.MakeNone();
		}
		return BigRewardSlot.MakeCyclic();
	}

	// Token: 0x04006718 RID: 26392
	private const int FirstRewardPixelOffset = 90;

	// Token: 0x04006719 RID: 26393
	private const int BetweenRewardPixelOffset = 180;

	// Token: 0x0400671A RID: 26394
	private const int UnobservedEndGridIndex = -2;

	// Token: 0x0400671B RID: 26395
	private const int FixedLayoutMaxCount = 9;

	// Token: 0x0400671C RID: 26396
	[Nullable(2)]
	private UiSequencePlayer UiSequencePlayer;

	// Token: 0x0400671D RID: 26397
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<GachaAccumulateRewardItemStage, GachaAccumulateRewardItemStageData> LoopScroll;

	// Token: 0x0400671E RID: 26398
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400671F RID: 26399
	[Nullable(2)]
	private GachaAccumulateStageBigRewardPanel BigRewardPanel;

	// Token: 0x04006720 RID: 26400
	[Nullable(2)]
	private GachaAccumulateStageCyclicPanel CyclicPanel;

	// Token: 0x04006721 RID: 26401
	private Action OnClickBackButtonCallBack = delegate()
	{
	};

	// Token: 0x04006722 RID: 26402
	private int CurrentAccumulateId;

	// Token: 0x04006723 RID: 26403
	private int LastSeenEndGridIndex = -2;

	// Token: 0x04006724 RID: 26404
	private int LastAutoScrollAccumulateId;

	// Token: 0x04006725 RID: 26405
	private bool NeedLateUpdate;

	// Token: 0x04006726 RID: 26406
	private readonly List<UUIItem> SpawnedPointItems = new List<UUIItem>();

	// Token: 0x04006727 RID: 26407
	private readonly List<GachaAccumulateRewardItemStage> SpawnedFixedRewardItems = new List<GachaAccumulateRewardItemStage>();

	// Token: 0x04006728 RID: 26408
	private readonly List<UUIItem> SpawnedFixedPointItems = new List<UUIItem>();

	// Token: 0x04006729 RID: 26409
	private bool FixedSpawnStarted;

	// Token: 0x0400672A RID: 26410
	private bool FixedReady;
}
