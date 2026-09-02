using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001CC6 RID: 7366
[NullableContext(1)]
[Nullable(0)]
public class GachaAccumulateTipsItemContent : GachaAccumulateTipsContentBase
{
	// Token: 0x0600D81C RID: 55324 RVA: 0x0039CE94 File Offset: 0x0039B094
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnButtonGoClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D81D RID: 55325 RVA: 0x0039D022 File Offset: 0x0039B222
	protected override void OnStart()
	{
		this.UiSequencePlayer = new UiSequencePlayer(this.RootItem);
	}

	// Token: 0x0600D81E RID: 55326 RVA: 0x0039D035 File Offset: 0x0039B235
	private void OnButtonGoClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaAccumulateBonusView, this.AccumulateId, null);
	}

	// Token: 0x0600D81F RID: 55327 RVA: 0x0039D054 File Offset: 0x0039B254
	public override void RefreshView(int accumulateId, bool needAnimate = true)
	{
		this.AccumulateId = accumulateId;
		GachaAccumulateData accumulateData = ModelBase<GachaAccumulateModel>.Instance.GetAccumulateData(accumulateId);
		if (accumulateData == null)
		{
			return;
		}
		this.RefreshRewardTexture(accumulateData);
		this.RefreshRewardNum(accumulateData);
		this.RefreshAllFinishItem(accumulateData);
		this.RefreshRewardUnTakeItem(accumulateData);
		this.RefreshProgressText(accumulateData);
		this.RefreshProgressTipsText(accumulateData);
		this.RefreshNumItem(accumulateData);
		if (needAnimate)
		{
			this.PlayStartSequence();
		}
	}

	// Token: 0x0600D820 RID: 55328 RVA: 0x0039D0B2 File Offset: 0x0039B2B2
	private void PlayStartSequence()
	{
		UiSequencePlayer uiSequencePlayer = this.UiSequencePlayer;
		if (uiSequencePlayer == null)
		{
			return;
		}
		uiSequencePlayer.PlaySequencePurely("Start", false, false);
	}

	// Token: 0x0600D821 RID: 55329 RVA: 0x0039D0CC File Offset: 0x0039B2CC
	private void RefreshRewardTexture(GachaAccumulateData accumulateData)
	{
		RewardItemData tipsShowReward = accumulateData.GetTipsShowReward();
		if (tipsShowReward == null)
		{
			return;
		}
		UUITexture texture = base.GetTexture(1);
		base.SetTextureByPath(tipsShowReward.GetConfig().Icon, texture, null, null);
		UUIItem uuiitem = texture;
		bool ifTakeAllRewardIncludingCyclic = accumulateData.GetIfTakeAllRewardIncludingCyclic();
		FColor? fcolor = new FColor?(texture.changeColor);
		uuiitem.SetChangeColor(ifTakeAllRewardIncludingCyclic, fcolor);
	}

	// Token: 0x0600D822 RID: 55330 RVA: 0x0039D124 File Offset: 0x0039B324
	private void RefreshRewardNum(GachaAccumulateData accumulateData)
	{
		RewardItemData tipsShowReward = accumulateData.GetTipsShowReward();
		if (tipsShowReward == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "GachaAccumulateTipsText", new <>z__ReadOnlySingleElementList<object>(tipsShowReward.Count.ToString()));
	}

	// Token: 0x0600D823 RID: 55331 RVA: 0x0039D162 File Offset: 0x0039B362
	private void RefreshAllFinishItem(GachaAccumulateData accumulateData)
	{
		base.GetItem(6).SetUIActive(accumulateData.GetIfTakeAllRewardIncludingCyclic());
	}

	// Token: 0x0600D824 RID: 55332 RVA: 0x0039D176 File Offset: 0x0039B376
	private void RefreshNumItem(GachaAccumulateData accumulateData)
	{
		base.GetItem(5).SetUIActive(!accumulateData.GetIfAllRewardAchieved());
	}

	// Token: 0x0600D825 RID: 55333 RVA: 0x0039D190 File Offset: 0x0039B390
	private void RefreshRewardUnTakeItem(GachaAccumulateData accumulateData)
	{
		int unTakeRewardNum = accumulateData.GetUnTakeRewardNum();
		base.GetItem(7).SetUIActive(unTakeRewardNum > 0);
		if (unTakeRewardNum > 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "GachaAccumulateTipsUnTakeNumText", new <>z__ReadOnlySingleElementList<object>(unTakeRewardNum.ToString()));
		}
	}

	// Token: 0x0600D826 RID: 55334 RVA: 0x0039D1DC File Offset: 0x0039B3DC
	private void RefreshProgressText(GachaAccumulateData accumulateData)
	{
		ValueTuple<int, int> progress = accumulateData.GetProgress();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "GachaAccumulateTipsProgressText", new <>z__ReadOnlyArray<object>(new object[]
		{
			progress.Item1.ToString(),
			progress.Item2.ToString()
		}));
	}

	// Token: 0x0600D827 RID: 55335 RVA: 0x0039D230 File Offset: 0x0039B430
	private void RefreshProgressTipsText(GachaAccumulateData accumulateData)
	{
		int nextRewardNeedGachaNum = accumulateData.GetNextRewardNeedGachaNum();
		UUIText text = base.GetText(4);
		if (nextRewardNeedGachaNum > 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "GachaAccumulateTipsProgressTipsText", new <>z__ReadOnlySingleElementList<object>(nextRewardNeedGachaNum.ToString()));
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "GachaAccumulateTipsProgressFinishText", new <>z__ReadOnlySingleElementList<object>(nextRewardNeedGachaNum.ToString()));
	}

	// Token: 0x040066F3 RID: 26355
	[Nullable(2)]
	private UiSequencePlayer UiSequencePlayer;

	// Token: 0x040066F4 RID: 26356
	private int AccumulateId;

	// Token: 0x02008015 RID: 32789
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402B947 RID: 178503
		ButtonGo,
		// Token: 0x0402B948 RID: 178504
		Texture,
		// Token: 0x0402B949 RID: 178505
		NumText,
		// Token: 0x0402B94A RID: 178506
		ProgressText,
		// Token: 0x0402B94B RID: 178507
		TipsText,
		// Token: 0x0402B94C RID: 178508
		NumItem,
		// Token: 0x0402B94D RID: 178509
		AllFinishItem,
		// Token: 0x0402B94E RID: 178510
		RewardUnTakeTipsItem,
		// Token: 0x0402B94F RID: 178511
		RewardUnTakeNumText
	}
}
