using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020014FE RID: 5374
public class RegressRewardPopup : UiPanelBase
{
	// Token: 0x06009663 RID: 38499 RVA: 0x002754F0 File Offset: 0x002736F0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnMaskBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009664 RID: 38500 RVA: 0x002755D8 File Offset: 0x002737D8
	protected override void OnBeforeCreateImplement()
	{
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x06009665 RID: 38501 RVA: 0x002755EB File Offset: 0x002737EB
	protected override void OnStart()
	{
		this.RewardPanel = new GenericLayout<RegressRewardPanelItem, RegressRewardTuple>(base.GetHorizontalLayout(0), new Func<RegressRewardPanelItem>(this.CreateRewardItem), null, false, true);
		this.SetActive(false);
	}

	// Token: 0x06009666 RID: 38502 RVA: 0x00275618 File Offset: 0x00273818
	protected override UniTask OnShowAsyncImplementImplement()
	{
		RegressRewardPopup.<OnShowAsyncImplementImplement>d__7 <OnShowAsyncImplementImplement>d__;
		<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnShowAsyncImplementImplement>d__.<>4__this = this;
		<OnShowAsyncImplementImplement>d__.<>1__state = -1;
		<OnShowAsyncImplementImplement>d__.<>t__builder.Start<RegressRewardPopup.<OnShowAsyncImplementImplement>d__7>(ref <OnShowAsyncImplementImplement>d__);
		return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06009667 RID: 38503 RVA: 0x0027565C File Offset: 0x0027385C
	protected override UniTask OnHideAsyncImplementImplement()
	{
		RegressRewardPopup.<OnHideAsyncImplementImplement>d__8 <OnHideAsyncImplementImplement>d__;
		<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHideAsyncImplementImplement>d__.<>4__this = this;
		<OnHideAsyncImplementImplement>d__.<>1__state = -1;
		<OnHideAsyncImplementImplement>d__.<>t__builder.Start<RegressRewardPopup.<OnHideAsyncImplementImplement>d__8>(ref <OnHideAsyncImplementImplement>d__);
		return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06009668 RID: 38504 RVA: 0x0027569F File Offset: 0x0027389F
	protected override void OnBeforeDestroy()
	{
		GenericLayout<RegressRewardPanelItem, RegressRewardTuple> rewardPanel = this.RewardPanel;
		if (rewardPanel != null)
		{
			rewardPanel.ClearChildren();
		}
		this.RewardPanel = null;
		this.PopUpData = null;
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.Clear();
		}
		this.SequencePlayer = null;
	}

	// Token: 0x06009669 RID: 38505 RVA: 0x002756DD File Offset: 0x002738DD
	public void Refresh(RegressRewardPopupData data)
	{
		this.PopUpData = new RegressRewardPopupData?(data);
		if (this.PopUpData.Value.RewardLists.Length == 0)
		{
			return;
		}
		this.RefreshAsync().Forget();
	}

	// Token: 0x0600966A RID: 38506 RVA: 0x0027570C File Offset: 0x0027390C
	private UniTask RefreshAsync()
	{
		RegressRewardPopup.<RefreshAsync>d__11 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<RegressRewardPopup.<RefreshAsync>d__11>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600966B RID: 38507 RVA: 0x0027574F File Offset: 0x0027394F
	[NullableContext(1)]
	private RegressRewardPanelItem CreateRewardItem()
	{
		return new RegressRewardPanelItem();
	}

	// Token: 0x0600966C RID: 38508 RVA: 0x00275756 File Offset: 0x00273956
	private void OnMaskBtnClick()
	{
		this.SetActive(false);
	}

	// Token: 0x040045AC RID: 17836
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<RegressRewardPanelItem, RegressRewardTuple> RewardPanel;

	// Token: 0x040045AD RID: 17837
	private RegressRewardPopupData? PopUpData;

	// Token: 0x040045AE RID: 17838
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x020078C2 RID: 30914
	private class ERegressRewardPopup
	{
		// Token: 0x04029843 RID: 170051
		public const int PanelLayout = 0;

		// Token: 0x04029844 RID: 170052
		public const int RewardItem = 1;

		// Token: 0x04029845 RID: 170053
		public const int Panel = 2;

		// Token: 0x04029846 RID: 170054
		public const int MaskBtn = 3;
	}
}
