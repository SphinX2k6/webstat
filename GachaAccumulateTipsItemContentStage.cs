using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001CD9 RID: 7385
[NullableContext(1)]
[Nullable(0)]
public class GachaAccumulateTipsItemContentStage : GachaAccumulateTipsContentBase
{
	// Token: 0x0600D883 RID: 55427 RVA: 0x0039F3A4 File Offset: 0x0039D5A4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickEntry));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D884 RID: 55428 RVA: 0x0039F510 File Offset: 0x0039D710
	protected override void OnStart()
	{
		this.UiSequencePlayer = new UiSequencePlayer(this.RootItem);
	}

	// Token: 0x0600D885 RID: 55429 RVA: 0x0039F523 File Offset: 0x0039D723
	private void OnClickEntry()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaAccumulateBonusView, this.AccumulateId, null);
	}

	// Token: 0x0600D886 RID: 55430 RVA: 0x0039F540 File Offset: 0x0039D740
	public override void RefreshView(int accumulateId, bool needAnimate = true)
	{
		this.AccumulateId = accumulateId;
		GachaAccumulateData accumulateData = ModelBase<GachaAccumulateModel>.Instance.GetAccumulateData(accumulateId);
		if (accumulateData == null)
		{
			return;
		}
		bool ifAllRewardAchieved = accumulateData.GetIfAllRewardAchieved();
		bool ifTakeAllRewardIncludingCyclic = accumulateData.GetIfTakeAllRewardIncludingCyclic();
		base.GetItem(3).SetUIActive(ifTakeAllRewardIncludingCyclic);
		this.RefreshNextRewardIconAndCount(accumulateData, ifAllRewardAchieved, ifTakeAllRewardIncludingCyclic);
		this.RefreshDescText(accumulateData, ifAllRewardAchieved);
		this.RefreshUnTakeTips(accumulateData);
		if (needAnimate)
		{
			UiSequencePlayer uiSequencePlayer = this.UiSequencePlayer;
			if (uiSequencePlayer == null)
			{
				return;
			}
			uiSequencePlayer.PlaySequencePurely("Start", false, false);
		}
	}

	// Token: 0x0600D887 RID: 55431 RVA: 0x0039F5B4 File Offset: 0x0039D7B4
	private void RefreshNextRewardIconAndCount(GachaAccumulateData accumulateData, bool allDone, bool allClaimed)
	{
		RewardItemData tipsShowReward = accumulateData.GetTipsShowReward();
		if (tipsShowReward == null)
		{
			base.GetItem(4).SetUIActive(false);
			return;
		}
		UUITexture texture = base.GetTexture(2);
		base.SetTextureByPath(tipsShowReward.GetConfig().Icon, texture, null, null);
		UUIItem uuiitem = texture;
		FColor? fcolor = new FColor?(texture.changeColor);
		uuiitem.SetChangeColor(allClaimed, fcolor);
		base.GetItem(4).SetUIActive(!allDone);
		if (!allDone)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "GachaAccumulateTipsText", new <>z__ReadOnlySingleElementList<object>(tipsShowReward.Count.ToString()));
		}
	}

	// Token: 0x0600D888 RID: 55432 RVA: 0x0039F64C File Offset: 0x0039D84C
	private void RefreshDescText(GachaAccumulateData accumulateData, bool allDone)
	{
		base.GetText(1).SetUIActive(true);
		int nextRewardNeedGachaNum = accumulateData.GetNextRewardNeedGachaNum();
		string textStringId = (nextRewardNeedGachaNum > 0) ? "GachaAccumulateTipsProgressTipsText" : "GachaAccumulateTipsProgressFinishText";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, new <>z__ReadOnlySingleElementList<object>(nextRewardNeedGachaNum.ToString()));
	}

	// Token: 0x0600D889 RID: 55433 RVA: 0x0039F69C File Offset: 0x0039D89C
	private void RefreshUnTakeTips(GachaAccumulateData accumulateData)
	{
		int unTakeRewardNum = accumulateData.GetUnTakeRewardNum();
		base.GetItem(6).SetUIActive(unTakeRewardNum > 0);
		if (unTakeRewardNum > 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "GachaAccumulateTipsUnTakeNumText", new <>z__ReadOnlySingleElementList<object>(unTakeRewardNum.ToString()));
		}
	}

	// Token: 0x04006751 RID: 26449
	[Nullable(2)]
	private UiSequencePlayer UiSequencePlayer;

	// Token: 0x04006752 RID: 26450
	private int AccumulateId;

	// Token: 0x02008021 RID: 32801
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402B981 RID: 178561
		ButtonClick,
		// Token: 0x0402B982 RID: 178562
		TextDescription,
		// Token: 0x0402B983 RID: 178563
		TextureIcon,
		// Token: 0x0402B984 RID: 178564
		PanelCheck,
		// Token: 0x0402B985 RID: 178565
		PanelCount,
		// Token: 0x0402B986 RID: 178566
		TextCount,
		// Token: 0x0402B987 RID: 178567
		PanelTips,
		// Token: 0x0402B988 RID: 178568
		TextTips
	}
}
