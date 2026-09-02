using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015A2 RID: 5538
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ScratchTicketCellItem : GridProxyAbstract<ScratchTicketCellData>
{
	// Token: 0x06009BFA RID: 39930 RVA: 0x0028D088 File Offset: 0x0028B288
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickRewardButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009BFB RID: 39931 RVA: 0x0028D170 File Offset: 0x0028B370
	protected override void OnBeforeCreate()
	{
		this.UiLevelSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiLevelSequence);
	}

	// Token: 0x06009BFC RID: 39932 RVA: 0x0028D18C File Offset: 0x0028B38C
	protected override UniTask OnBeforeStartAsync()
	{
		ScratchTicketCellItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ScratchTicketCellItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009BFD RID: 39933 RVA: 0x0028D1CF File Offset: 0x0028B3CF
	protected override void OnBeforeShow()
	{
		this.UiLevelSequence.AddSequenceFinishEvent("RevaelA", new Action<string>(this.OnRevealAnimationFinish), false);
	}

	// Token: 0x06009BFE RID: 39934 RVA: 0x0028D1EE File Offset: 0x0028B3EE
	public override void Refresh(ScratchTicketCellData data, bool isSelected, int gridIndex)
	{
		this.RefreshUi(data);
		base.GetItem(2).SetUIActive(false);
		base.GetItem(3).SetUIActive(false);
		base.GetSprite(1).SetUIActive(false);
	}

	// Token: 0x06009BFF RID: 39935 RVA: 0x0028D21E File Offset: 0x0028B41E
	public void RefreshByResultData(ScratchTicketCellData cellData, IScratchTicketRewardResult resultData)
	{
		this.CellData = cellData;
		if (resultData.SequenceType != ECellSequenceType.Warning && resultData.SequenceType != ECellSequenceType.Reveal)
		{
			this.RefreshUi(this.CellData);
		}
		this.PlaySequence(resultData.SequenceType);
	}

	// Token: 0x06009C00 RID: 39936 RVA: 0x0028D254 File Offset: 0x0028B454
	private void RefreshUi(ScratchTicketCellData data)
	{
		this.CellData = data;
		TItem? itemData = data.GetItemData();
		if (itemData == null)
		{
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			base.GetSprite(1).SetUIActive(false);
			return;
		}
		base.GetItem(2).SetUIActive(true);
		base.GetItem(3).SetUIActive(true);
		base.GetSprite(1).SetUIActive(true);
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = itemData,
			ItemConfigId = new int?(itemData.Value.ItemData.ItemId),
			BottomText = itemData.Value.Count.ToString()
		};
		this.ItemGrid.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x06009C01 RID: 39937 RVA: 0x0028D31C File Offset: 0x0028B51C
	private void PlaySequence(ECellSequenceType sequenceType)
	{
		switch (sequenceType)
		{
		case ECellSequenceType.Center:
		case ECellSequenceType.Last:
			this.UiLevelSequence.PlaySequence("Strike", false, null);
			return;
		case ECellSequenceType.Left:
			this.UiLevelSequence.PlaySequence("StrikeL", false, null);
			return;
		case ECellSequenceType.Right:
			this.UiLevelSequence.PlaySequence("StrikeR", false, null);
			return;
		case ECellSequenceType.Top:
			this.UiLevelSequence.PlaySequence("StrikeA", false, null);
			return;
		case ECellSequenceType.Bottom:
			this.UiLevelSequence.PlaySequence("StrikeB", false, null);
			return;
		case ECellSequenceType.Warning:
			this.UiLevelSequence.PlaySequence("Warning", false, null);
			return;
		case ECellSequenceType.Reveal:
			this.UiLevelSequence.PlaySequence("RevaelA", false, null);
			return;
		default:
			return;
		}
	}

	// Token: 0x06009C02 RID: 39938 RVA: 0x0028D40C File Offset: 0x0028B60C
	protected override void OnBeforeHide()
	{
		this.UiLevelSequence.RemoveSequenceFinishEvent("RevaelA", new Action<string>(this.OnRevealAnimationFinish));
	}

	// Token: 0x06009C03 RID: 39939 RVA: 0x0028D42C File Offset: 0x0028B62C
	private void OnRevealAnimationFinish(string _)
	{
		this.RefreshUi(this.CellData);
		this.UiLevelSequence.PlaySequence("RevaelB", false, null);
	}

	// Token: 0x06009C04 RID: 39940 RVA: 0x0028D45F File Offset: 0x0028B65F
	private void OnClickRewardButton()
	{
		if (this.ClickCallBack != null)
		{
			this.ClickCallBack(this.CellData);
		}
	}

	// Token: 0x06009C05 RID: 39941 RVA: 0x0028D47A File Offset: 0x0028B67A
	public void SetClickCallback(Action<ScratchTicketCellData> callback)
	{
		this.ClickCallBack = callback;
	}

	// Token: 0x06009C06 RID: 39942 RVA: 0x0028D483 File Offset: 0x0028B683
	[NullableContext(2)]
	private bool CanRewardItemChangeToggle(object data, bool isForcedSelect, EToggleState toggleState)
	{
		return false;
	}

	// Token: 0x040047CD RID: 18381
	[Nullable(2)]
	private ScratchTicketCellData CellData;

	// Token: 0x040047CE RID: 18382
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<ScratchTicketCellData> ClickCallBack;

	// Token: 0x040047CF RID: 18383
	[Nullable(2)]
	public UiBehaviorLevelSequence UiLevelSequence;

	// Token: 0x040047D0 RID: 18384
	[Nullable(2)]
	private SmallItemGrid ItemGrid;

	// Token: 0x040047D1 RID: 18385
	private readonly Action<MediumItemGridExtendCallback> OnRewardItemClick = delegate(MediumItemGridExtendCallback callbackParameter)
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(((TItem)callbackParameter.Data).ItemData.ItemId, true, null);
	};

	// Token: 0x02007960 RID: 31072
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04029B20 RID: 170784
		public const int RewardButton = 0;

		// Token: 0x04029B21 RID: 170785
		public const int BgIcon = 1;

		// Token: 0x04029B22 RID: 170786
		public const int RewardRoot = 2;

		// Token: 0x04029B23 RID: 170787
		public const int ReceivedItem = 3;
	}
}
