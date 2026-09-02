using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FF1 RID: 8177
public class ReputationDetailsView : UiViewBase
{
	// Token: 0x0600F6D4 RID: 63188 RVA: 0x00439418 File Offset: 0x00437618
	[NullableContext(1)]
	public ReputationDetailsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F6D5 RID: 63189 RVA: 0x00439424 File Offset: 0x00437624
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIInteractionGroup));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.CloseClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.TipsClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.ReceiveClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.RewardClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F6D6 RID: 63190 RVA: 0x0043965F File Offset: 0x0043785F
	private void CloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F6D7 RID: 63191 RVA: 0x00439668 File Offset: 0x00437868
	private void TipsClick()
	{
		if (this.Config == null)
		{
			return;
		}
		IntPair[] param = this.Config.Value.ReputationItem();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ReputationTips, param, null);
	}

	// Token: 0x0600F6D8 RID: 63192 RVA: 0x004396A8 File Offset: 0x004378A8
	private void ReceiveClick()
	{
		ControllerBase<InfluenceReputationController>.Instance.RequestInfluenceReward(this.Data.InfluenceId);
	}

	// Token: 0x0600F6D9 RID: 63193 RVA: 0x004396BF File Offset: 0x004378BF
	private void RewardClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ReputationRewardsView, this.Data.InfluenceId, null);
	}

	// Token: 0x0600F6DA RID: 63194 RVA: 0x004396E1 File Offset: 0x004378E1
	protected override void OnBeforeCreate()
	{
		this.Data = (IReputationDetailsData)this.OpenParam;
	}

	// Token: 0x0600F6DB RID: 63195 RVA: 0x004396F4 File Offset: 0x004378F4
	protected override void OnStart()
	{
		this.RewardItem = new InfluenceRewardItem(base.GetItem(10));
	}

	// Token: 0x0600F6DC RID: 63196 RVA: 0x00439709 File Offset: 0x00437909
	protected override void OnAfterShow()
	{
		this.Config = ConfigBase<InfluenceConfig>.Instance.GetInfluenceConfig(this.Data.InfluenceId);
		this.InitView();
		this.RefreshView();
	}

	// Token: 0x0600F6DD RID: 63197 RVA: 0x00439732 File Offset: 0x00437932
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.ReceiveReputationReward, new Action(this.RefreshEvent));
	}

	// Token: 0x0600F6DE RID: 63198 RVA: 0x00439750 File Offset: 0x00437950
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ReceiveReputationReward, new Action(this.RefreshEvent));
	}

	// Token: 0x0600F6DF RID: 63199 RVA: 0x0043976E File Offset: 0x0043796E
	private void RefreshEvent()
	{
		this.RefreshView();
	}

	// Token: 0x0600F6E0 RID: 63200 RVA: 0x00439776 File Offset: 0x00437976
	protected override void OnBeforeDestroy()
	{
		this.RewardItem.Destroy(null);
		this.RewardItem = null;
	}

	// Token: 0x0600F6E1 RID: 63201 RVA: 0x0043978C File Offset: 0x0043798C
	protected void RefreshView()
	{
		ValueTuple<bool, IntPair>? canReceiveReward = ModelBase<InfluenceReputationModel>.Instance.GetCanReceiveReward(this.Data.InfluenceId);
		if (canReceiveReward == null)
		{
			return;
		}
		ValueTuple<bool, IntPair> value = canReceiveReward.Value;
		ValueTuple<int, int> reputationProgress = ModelBase<InfluenceReputationModel>.Instance.GetReputationProgress(this.Data.InfluenceId);
		this.RefreshProgress(reputationProgress.Item1, reputationProgress.Item2);
		this.RefreshRewardItem(value.Item2, value.Item1);
		base.GetButton(2).RootUIComp.Get().SetUIActive(!value.Item1);
		if (value.Item1)
		{
			return;
		}
		base.GetInteractionGroup(3).SetInteractable(reputationProgress.Item1 >= value.Item2.Item1);
	}

	// Token: 0x0600F6E2 RID: 63202 RVA: 0x0043984C File Offset: 0x00437A4C
	protected void RefreshProgress(int current, int max)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(9), "ReputationNormalValue", new <>z__ReadOnlyArray<object>(new object[]
		{
			current,
			max
		}));
		base.GetSprite(6).SetFillAmount((float)current / (float)max);
	}

	// Token: 0x0600F6E3 RID: 63203 RVA: 0x004398A0 File Offset: 0x00437AA0
	protected void InitView()
	{
		if (this.Config == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), this.Config.Value.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), this.Config.Value.ExtraDesc, Array.Empty<object>());
		base.SetTextureByPath(this.Config.Value.Logo, base.GetTexture(5), null, null);
	}

	// Token: 0x0600F6E4 RID: 63204 RVA: 0x00439937 File Offset: 0x00437B37
	private void RefreshRewardItem(IntPair reward, bool isReceived)
	{
		this.RewardItem.UpdateItem(reward, isReceived);
		if (isReceived)
		{
			this.RewardItem.SetAllReceivedTitle();
		}
	}

	// Token: 0x04007739 RID: 30521
	[Nullable(2)]
	private IReputationDetailsData Data;

	// Token: 0x0400773A RID: 30522
	[Nullable(2)]
	private InfluenceRewardItem RewardItem;

	// Token: 0x0400773B RID: 30523
	private Influence? Config;

	// Token: 0x0200836F RID: 33647
	private enum EReputationDetailsView
	{
		// Token: 0x0402C946 RID: 182598
		CloseButton,
		// Token: 0x0402C947 RID: 182599
		TipsButton,
		// Token: 0x0402C948 RID: 182600
		ReceiveButton,
		// Token: 0x0402C949 RID: 182601
		ReceiveInteractionGroup,
		// Token: 0x0402C94A RID: 182602
		RewardButton,
		// Token: 0x0402C94B RID: 182603
		InfluenceTexture,
		// Token: 0x0402C94C RID: 182604
		ReputationProgress,
		// Token: 0x0402C94D RID: 182605
		InfluenceText,
		// Token: 0x0402C94E RID: 182606
		AreaText,
		// Token: 0x0402C94F RID: 182607
		ProgressValue,
		// Token: 0x0402C950 RID: 182608
		RewardItem
	}
}
