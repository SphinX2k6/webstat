using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F48 RID: 8008
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryPickUpMobileView : UiViewBase
{
	// Token: 0x0600EFC2 RID: 61378 RVA: 0x00418477 File Offset: 0x00416677
	public HonamiStoryPickUpMobileView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EFC3 RID: 61379 RVA: 0x00418498 File Offset: 0x00416698
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickMask));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickPlayerToggle));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnClickBackpackToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600EFC4 RID: 61380 RVA: 0x004186D4 File Offset: 0x004168D4
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryPickUpMobileView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryPickUpMobileView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFC5 RID: 61381 RVA: 0x00418717 File Offset: 0x00416917
	protected override void OnStart()
	{
		base.GetItem(8).SetUIActive(false);
		base.GetItem(9).SetUIActive(false);
		this.InitTipsItem();
	}

	// Token: 0x0600EFC6 RID: 61382 RVA: 0x0041873C File Offset: 0x0041693C
	private UniTask InitPickUpPanel()
	{
		HonamiStoryPickUpMobileView.<InitPickUpPanel>d__16 <InitPickUpPanel>d__;
		<InitPickUpPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPickUpPanel>d__.<>4__this = this;
		<InitPickUpPanel>d__.<>1__state = -1;
		<InitPickUpPanel>d__.<>t__builder.Start<HonamiStoryPickUpMobileView.<InitPickUpPanel>d__16>(ref <InitPickUpPanel>d__);
		return <InitPickUpPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFC7 RID: 61383 RVA: 0x00418780 File Offset: 0x00416980
	private UniTask InitEquipBackpackPanel()
	{
		HonamiStoryPickUpMobileView.<InitEquipBackpackPanel>d__17 <InitEquipBackpackPanel>d__;
		<InitEquipBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitEquipBackpackPanel>d__.<>4__this = this;
		<InitEquipBackpackPanel>d__.<>1__state = -1;
		<InitEquipBackpackPanel>d__.<>t__builder.Start<HonamiStoryPickUpMobileView.<InitEquipBackpackPanel>d__17>(ref <InitEquipBackpackPanel>d__);
		return <InitEquipBackpackPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFC8 RID: 61384 RVA: 0x004187C4 File Offset: 0x004169C4
	private UniTask InitDiscardBackpackPanel()
	{
		HonamiStoryPickUpMobileView.<InitDiscardBackpackPanel>d__18 <InitDiscardBackpackPanel>d__;
		<InitDiscardBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitDiscardBackpackPanel>d__.<>4__this = this;
		<InitDiscardBackpackPanel>d__.<>1__state = -1;
		<InitDiscardBackpackPanel>d__.<>t__builder.Start<HonamiStoryPickUpMobileView.<InitDiscardBackpackPanel>d__18>(ref <InitDiscardBackpackPanel>d__);
		return <InitDiscardBackpackPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFC9 RID: 61385 RVA: 0x00418808 File Offset: 0x00416A08
	private UniTask InitTipsItem()
	{
		HonamiStoryPickUpMobileView.<InitTipsItem>d__19 <InitTipsItem>d__;
		<InitTipsItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTipsItem>d__.<>4__this = this;
		<InitTipsItem>d__.<>1__state = -1;
		<InitTipsItem>d__.<>t__builder.Start<HonamiStoryPickUpMobileView.<InitTipsItem>d__19>(ref <InitTipsItem>d__);
		return <InitTipsItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFCA RID: 61386 RVA: 0x0041884C File Offset: 0x00416A4C
	private void ShowTips([Nullable(2)] HonamiStoryItemGridItem item, Vector2D loc, Vector2D size, EHonamiStoryBackpackType packType)
	{
		if (item == null || item.GetData() == null)
		{
			return;
		}
		this.DragController.OnClickedItem(true, item.GetData().GetIncId(), item);
		HonamiStoryItemDataBase data = item.GetData();
		HonamiStoryItemTipsBase tipsItem = this.TipsItem;
		if (tipsItem == null)
		{
			return;
		}
		tipsItem.Refresh(data, packType, data.GetPosition(), new Action(item.OnHideCallback), loc, size);
	}

	// Token: 0x0600EFCB RID: 61387 RVA: 0x004188AC File Offset: 0x00416AAC
	protected void ShowTipsAttrChange([Nullable(2)] HonamiStoryEquipGridItem item, HonamiStoryInteractOperateAgent operateAgent)
	{
		this.TipsItemDetail.SetUiActive(false);
		this.TipsAttrChange.SetUiActive(false);
		if (item == null || operateAgent.OperateData == null || operateAgent.OperateData.GetItemType() == EHonamiStoryItemType.Normal)
		{
			return;
		}
		HonamiStoryItemDataBase data = item.GetData();
		if (data == null)
		{
			return;
		}
		HonamiStoryEquipItemData honamiStoryEquipItemData = (HonamiStoryEquipItemData)ModelBase<HonamiStoryModel>.Instance.GetItemData(data.GetIncId());
		HonamiStoryEquipItemData newData = (HonamiStoryEquipItemData)ModelBase<HonamiStoryModel>.Instance.GetItemData(operateAgent.OperateData.GetIncId());
		if (honamiStoryEquipItemData == null)
		{
			return;
		}
		this.TipsAttrChange.SetUiActive(true);
		this.TipsAttrChange.Refresh(honamiStoryEquipItemData, newData, delegate
		{
			this.TipsAttrChange.GetRootItem().SetUIParent(this.DragController.GetDragTipsRoot(), false);
		});
	}

	// Token: 0x0600EFCC RID: 61388 RVA: 0x00418950 File Offset: 0x00416B50
	protected override void OnBeforeShow()
	{
		this.DragController.OnBeforeShow();
		HonamiStorySkillDescToggle descToggleItem = this.DescToggleItem;
		if (descToggleItem == null)
		{
			return;
		}
		descToggleItem.RefreshState();
	}

	// Token: 0x0600EFCD RID: 61389 RVA: 0x0041896D File Offset: 0x00416B6D
	private void HideTipsDetail()
	{
		this.TipsItemDetail.SetUiActive(false);
	}

	// Token: 0x0600EFCE RID: 61390 RVA: 0x0041897C File Offset: 0x00416B7C
	[NullableContext(2)]
	private void ShowTipsDetail(HonamiStoryItemGridItem item, EHonamiStoryBackpackType type)
	{
		bool flag = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState() == EHonamiStoryBackpackLogicState.Sell;
		HonamiStoryItemTipsBase tipsItem = this.TipsItem;
		bool flag2 = tipsItem != null && tipsItem.GetActive();
		bool flag3 = HonamiStoryUtil.IsMobileView();
		if (item == null || item.GetData() == null || flag || flag2 || flag3)
		{
			return;
		}
		HonamiStoryItemDataBase data = item.GetData();
		this.TipsItemDetail.Refresh(data, type);
		this.TipsItemDetail.SetAutoLocation(item.GetRootItem());
		this.TipsItemDetail.SetUiActive(true);
	}

	// Token: 0x0600EFCF RID: 61391 RVA: 0x004189F9 File Offset: 0x00416BF9
	private void OnClickMask()
	{
		if (this.OnTipsClickCb != null)
		{
			this.OnTipsClickCb();
		}
	}

	// Token: 0x0600EFD0 RID: 61392 RVA: 0x00418A0E File Offset: 0x00416C0E
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600EFD1 RID: 61393 RVA: 0x00418A17 File Offset: 0x00416C17
	private void OnClickPlayerToggle(EToggleState toggleState)
	{
		this.EquipBackpackPanel.OnClickedEquipToggle();
	}

	// Token: 0x0600EFD2 RID: 61394 RVA: 0x00418A24 File Offset: 0x00416C24
	private void OnClickBackpackToggle(EToggleState toggleState)
	{
		this.EquipBackpackPanel.OnClickedBackpackToggle();
	}

	// Token: 0x0600EFD3 RID: 61395 RVA: 0x00418A31 File Offset: 0x00416C31
	[NullableContext(2)]
	private void OnEnterItem(HonamiStoryItemGridItem item, EHonamiStoryBackpackType type)
	{
		this.ShowTipsDetail(item, type);
	}

	// Token: 0x0600EFD4 RID: 61396 RVA: 0x00418A3B File Offset: 0x00416C3B
	private void OnExitItem()
	{
		this.HideTipsDetail();
	}

	// Token: 0x0600EFD5 RID: 61397 RVA: 0x00418A43 File Offset: 0x00416C43
	private void OnClickItem([Nullable(2)] HonamiStoryItemGridItem data, Vector2D loc, Vector2D size, EHonamiStoryBackpackType packType)
	{
		this.HideTipsDetail();
		this.ShowTips(data, loc, size, packType);
	}

	// Token: 0x04007349 RID: 29513
	private HonamiStoryMobileEquipPanel EquipBackpackPanel;

	// Token: 0x0400734A RID: 29514
	private HonamiStoryBackpackPanel PickUpPanel;

	// Token: 0x0400734B RID: 29515
	private HonamiStoryDiscardBackpackPanel DiscardPanel;

	// Token: 0x0400734C RID: 29516
	private readonly HonamiStoryInteractController DragController = new HonamiStoryInteractController();

	// Token: 0x0400734D RID: 29517
	private readonly HonamiStoryBackpackLogicController BackpackLogicController = new HonamiStoryBackpackLogicController();

	// Token: 0x0400734E RID: 29518
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400734F RID: 29519
	[Nullable(2)]
	private HonamiStoryItemTipsBase TipsItem;

	// Token: 0x04007350 RID: 29520
	[Nullable(2)]
	private HonamiStoryItemTipsDetail TipsItemDetail;

	// Token: 0x04007351 RID: 29521
	[Nullable(2)]
	private HonamiStoryItemTipsAttrChange TipsAttrChange;

	// Token: 0x04007352 RID: 29522
	[Nullable(2)]
	private HonamiStorySkillDescToggle DescToggleItem;

	// Token: 0x04007353 RID: 29523
	[Nullable(2)]
	private Action OnTipsClickCb;

	// Token: 0x020082CB RID: 33483
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402C592 RID: 181650
		PanelLeft,
		// Token: 0x0402C593 RID: 181651
		PanelPickupBox,
		// Token: 0x0402C594 RID: 181652
		AttachPanel,
		// Token: 0x0402C595 RID: 181653
		CaptionItem,
		// Token: 0x0402C596 RID: 181654
		PanelTips,
		// Token: 0x0402C597 RID: 181655
		BtnMask,
		// Token: 0x0402C598 RID: 181656
		TogTabA,
		// Token: 0x0402C599 RID: 181657
		TogTabB,
		// Token: 0x0402C59A RID: 181658
		MoveUp,
		// Token: 0x0402C59B RID: 181659
		MoveDown,
		// Token: 0x0402C59C RID: 181660
		DescToggleItem,
		// Token: 0x0402C59D RID: 181661
		DeletePanel
	}
}
