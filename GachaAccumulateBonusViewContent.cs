using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CC2 RID: 7362
[NullableContext(1)]
[Nullable(0)]
public class GachaAccumulateBonusViewContent : GachaAccumulateBonusContentBase
{
	// Token: 0x0600D7FF RID: 55295 RVA: 0x0039C44C File Offset: 0x0039A64C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBackButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D800 RID: 55296 RVA: 0x0039C534 File Offset: 0x0039A734
	protected override void OnStart()
	{
		this.UiSequencePlayerInstance = new UiSequencePlayer(this.RootItem);
		this.Layout = new GenericLayout<GachaAccumulateRewardItem, GachaAccumulateRewardItemData>(base.GetHorizontalLayout(2), new Func<GachaAccumulateRewardItem>(this.OnCreateRewardItem), null, false, true);
	}

	// Token: 0x0600D801 RID: 55297 RVA: 0x0039C568 File Offset: 0x0039A768
	public override UniTask PlayStartSequence()
	{
		GachaAccumulateBonusViewContent.<PlayStartSequence>d__5 <PlayStartSequence>d__;
		<PlayStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayStartSequence>d__.<>4__this = this;
		<PlayStartSequence>d__.<>1__state = -1;
		<PlayStartSequence>d__.<>t__builder.Start<GachaAccumulateBonusViewContent.<PlayStartSequence>d__5>(ref <PlayStartSequence>d__);
		return <PlayStartSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600D802 RID: 55298 RVA: 0x0039C5AC File Offset: 0x0039A7AC
	public override UniTask PlayCloseSequence()
	{
		GachaAccumulateBonusViewContent.<PlayCloseSequence>d__6 <PlayCloseSequence>d__;
		<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseSequence>d__.<>4__this = this;
		<PlayCloseSequence>d__.<>1__state = -1;
		<PlayCloseSequence>d__.<>t__builder.Start<GachaAccumulateBonusViewContent.<PlayCloseSequence>d__6>(ref <PlayCloseSequence>d__);
		return <PlayCloseSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600D803 RID: 55299 RVA: 0x0039C5EF File Offset: 0x0039A7EF
	private GachaAccumulateRewardItem OnCreateRewardItem()
	{
		return new GachaAccumulateRewardItem();
	}

	// Token: 0x0600D804 RID: 55300 RVA: 0x0039C5F6 File Offset: 0x0039A7F6
	private void OnBackButtonClick()
	{
		this.OnClickBackButtonCallBack();
	}

	// Token: 0x0600D805 RID: 55301 RVA: 0x0039C603 File Offset: 0x0039A803
	public override void SetOnClickBackButtonCallBack(Action callback)
	{
		this.OnClickBackButtonCallBack = callback;
	}

	// Token: 0x0600D806 RID: 55302 RVA: 0x0039C60C File Offset: 0x0039A80C
	public override void RefreshView(int gachaAccumulateId)
	{
		ModelBase<GachaAccumulateModel>.Instance.GetAccumulateData(gachaAccumulateId);
		this.RefreshNumText(gachaAccumulateId);
		this.RefreshLayoutAsync(gachaAccumulateId).Forget();
	}

	// Token: 0x0600D807 RID: 55303 RVA: 0x0039C630 File Offset: 0x0039A830
	private UniTask RefreshLayoutAsync(int gachaAccumulateId)
	{
		GachaAccumulateBonusViewContent.<RefreshLayoutAsync>d__11 <RefreshLayoutAsync>d__;
		<RefreshLayoutAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshLayoutAsync>d__.<>4__this = this;
		<RefreshLayoutAsync>d__.gachaAccumulateId = gachaAccumulateId;
		<RefreshLayoutAsync>d__.<>1__state = -1;
		<RefreshLayoutAsync>d__.<>t__builder.Start<GachaAccumulateBonusViewContent.<RefreshLayoutAsync>d__11>(ref <RefreshLayoutAsync>d__);
		return <RefreshLayoutAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D808 RID: 55304 RVA: 0x0039C67C File Offset: 0x0039A87C
	public void RefreshSlider()
	{
		int displayGridNum = this.Layout.GetDisplayGridNum();
		if (displayGridNum > 1)
		{
			float anchorOffsetX = this.Layout.GetGrid(1).GetAnchorOffsetX();
			float anchorOffsetX2 = this.Layout.GetGrid(0).GetAnchorOffsetX();
			float width = anchorOffsetX - anchorOffsetX2;
			for (int i = 1; i < displayGridNum; i++)
			{
				this.Layout.GetLayoutItemByIndex(i).RefreshSpriteWidth(width);
			}
		}
	}

	// Token: 0x0600D809 RID: 55305 RVA: 0x0039C6E0 File Offset: 0x0039A8E0
	private void RefreshNumText(int gachaAccumulateId)
	{
		List<GachaAccumulateRewardData> rewardInfos = ModelBase<GachaAccumulateModel>.Instance.GetAccumulateData(gachaAccumulateId).GroupData.RewardInfos;
		int gachaNum = rewardInfos[rewardInfos.Count - 1].GachaNum;
		GachaAccumulateData accumulateData = ModelBase<GachaAccumulateModel>.Instance.GetAccumulateData(gachaAccumulateId);
		int num = (accumulateData != null) ? accumulateData.CurGachaNum : 0;
		if (num >= gachaNum)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "GachaAccumulateAllFinishProgressText", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "GachaAccumulateProgressText", new <>z__ReadOnlyArray<object>(new object[]
		{
			num.ToString(),
			gachaNum.ToString()
		}));
	}

	// Token: 0x040066DA RID: 26330
	[Nullable(2)]
	private UiSequencePlayer UiSequencePlayerInstance;

	// Token: 0x040066DB RID: 26331
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<GachaAccumulateRewardItem, GachaAccumulateRewardItemData> Layout;

	// Token: 0x040066DC RID: 26332
	private Action OnClickBackButtonCallBack = delegate()
	{
	};
}
