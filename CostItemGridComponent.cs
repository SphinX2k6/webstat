using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Module.RoleUi.RoleBreach;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020027AF RID: 10159
[NullableContext(1)]
[Nullable(0)]
public class CostItemGridComponent : UiPanelBase
{
	// Token: 0x0601410E RID: 82190 RVA: 0x0059A176 File Offset: 0x00598376
	public CostItemGridComponent(UUIItem uiItem, Action<int> levelUpClickCallBack, [Nullable(2)] Action lockTipClickCallBack = null, EUiViewName? belongView = null)
	{
		this.LevelUpClickCallBack = levelUpClickCallBack;
		this.LockTipClickCallBack = lockTipClickCallBack;
		this.BelongView = belongView;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0601410F RID: 82191 RVA: 0x0059A1A4 File Offset: 0x005983A4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		if (this.LockTipClickCallBack != null)
		{
			this.BtnBindInfo.Add(new ValueTuple<int, Delegate>(17, this.LockTipClickCallBack));
		}
	}

	// Token: 0x06014110 RID: 82192 RVA: 0x0059A380 File Offset: 0x00598580
	protected override void OnStart()
	{
		this.ButtonItem = new ButtonItem(base.GetItem(11));
		this.ButtonItem.SetFunction(this.LevelUpClickCallBack);
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
		this.ScrollView = new GenericScrollView<CostMediumItemGrid>(scrollViewWithScrollbar, new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CostMediumItemGrid>(this.InitItem), base.GetItem(4));
		UUIButtonComponent button = base.GetButton(17);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(this.LockTipClickCallBack != null);
	}

	// Token: 0x06014111 RID: 82193 RVA: 0x0059A400 File Offset: 0x00598600
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private ILayoutItem<CostMediumItemGrid> InitItem(object data, UUIItem uiItem, int index)
	{
		CostMediumItemGrid costMediumItemGrid = new CostMediumItemGrid();
		costMediumItemGrid.Initialize(uiItem.GetOwner());
		costMediumItemGrid.Refresh((ISelectedData)data, false, index);
		costMediumItemGrid.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
		costMediumItemGrid.BindOnExtendToggleRelease(new Action<MediumItemGridExtendCallback>(this.OnExtendToggleStateChanged));
		return new LayoutItem<CostMediumItemGrid>
		{
			Key = index,
			Value = costMediumItemGrid
		};
	}

	// Token: 0x06014112 RID: 82194 RVA: 0x0059A47C File Offset: 0x0059867C
	private void OnExtendToggleStateChanged(MediumItemGridExtendCallback callbackParameter)
	{
		ISelectedData selectedData = (ISelectedData)callbackParameter.Data;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(selectedData.ItemId, true, null);
		ModelBase<ComposeModel>.Instance.ComposeSelectItem = selectedData;
		ModelBase<ComposeModel>.Instance.ComposeSkipSourceView = this.BelongView;
		ModelBase<InventoryModel>.Instance.SetItemNeedCount(new int?(selectedData.Count - selectedData.SelectedCount));
	}

	// Token: 0x06014113 RID: 82195 RVA: 0x0059A4DE File Offset: 0x005986DE
	public void Update(List<ISelectedData> dataList, int moneyId, int needMoney)
	{
		this.UpdateByDataList(dataList);
		this.UpdateMoney(moneyId, needMoney);
	}

	// Token: 0x06014114 RID: 82196 RVA: 0x0059A4F0 File Offset: 0x005986F0
	public void UpdateByDataList(List<ISelectedData> dataList)
	{
		this.DataList = dataList;
		this.ScrollView.RefreshByData<ISelectedData>(dataList, null);
	}

	// Token: 0x06014115 RID: 82197 RVA: 0x0059A51C File Offset: 0x0059871C
	public void UpdateMoney(int moneyId, int needMoney)
	{
		this.MoneyId = moneyId;
		this.NeedMoney = needMoney;
		base.SetItemIcon(base.GetTexture(7), this.MoneyId, null, null);
		UUIText text = base.GetText(8);
		text.SetText(this.NeedMoney.ToString(), true);
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.MoneyId, 0);
		this.IsMoneyEnough = (itemCountByConfigId >= this.NeedMoney);
		UUIItem uuiitem = text;
		bool bUseChangeColor = !this.IsMoneyEnough;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x06014116 RID: 82198 RVA: 0x0059A5AF File Offset: 0x005987AF
	public bool GetIsMoneyEnough()
	{
		return this.IsMoneyEnough;
	}

	// Token: 0x06014117 RID: 82199 RVA: 0x0059A5B7 File Offset: 0x005987B7
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<ISelectedData> GetDataList()
	{
		return this.DataList;
	}

	// Token: 0x06014118 RID: 82200 RVA: 0x0059A5BF File Offset: 0x005987BF
	public void SetMaxItemActive(bool active)
	{
		base.GetItem(12).SetUIActive(active);
	}

	// Token: 0x06014119 RID: 82201 RVA: 0x0059A5CF File Offset: 0x005987CF
	public void SetLockItemActive(bool active)
	{
		base.GetItem(13).SetUIActive(active);
	}

	// Token: 0x0601411A RID: 82202 RVA: 0x0059A5DF File Offset: 0x005987DF
	public void SetButtonItemActive(bool active)
	{
		this.ButtonItem.SetActive(active);
	}

	// Token: 0x0601411B RID: 82203 RVA: 0x0059A5ED File Offset: 0x005987ED
	public void SetLockLocalText(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), textId, args);
	}

	// Token: 0x0601411C RID: 82204 RVA: 0x0059A603 File Offset: 0x00598803
	public void SetButtonItemLocalText(string textId)
	{
		this.ButtonItem.SetLocalText(textId, Array.Empty<object>());
	}

	// Token: 0x0601411D RID: 82205 RVA: 0x0059A616 File Offset: 0x00598816
	public void SetButtonItemLocalTextNew(string textId)
	{
		this.ButtonItem.SetLocalTextNew(textId, Array.Empty<object>());
	}

	// Token: 0x0601411E RID: 82206 RVA: 0x0059A629 File Offset: 0x00598829
	public void SetButtonItemText(string text)
	{
		this.ButtonItem.SetText(text);
	}

	// Token: 0x0601411F RID: 82207 RVA: 0x0059A637 File Offset: 0x00598837
	public void SetButtonItemInteractive(bool interactive)
	{
		UUIButtonComponent btn = this.ButtonItem.GetBtn();
		if (btn == null)
		{
			return;
		}
		btn.SetSelfInteractive(interactive);
	}

	// Token: 0x04009C48 RID: 40008
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollView<CostMediumItemGrid> ScrollView;

	// Token: 0x04009C49 RID: 40009
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ISelectedData> DataList;

	// Token: 0x04009C4A RID: 40010
	private int MoneyId;

	// Token: 0x04009C4B RID: 40011
	private int NeedMoney;

	// Token: 0x04009C4C RID: 40012
	[Nullable(2)]
	private ButtonItem ButtonItem;

	// Token: 0x04009C4D RID: 40013
	private bool IsMoneyEnough;

	// Token: 0x04009C4E RID: 40014
	private readonly Action<int> LevelUpClickCallBack;

	// Token: 0x04009C4F RID: 40015
	[Nullable(2)]
	private readonly Action LockTipClickCallBack;

	// Token: 0x04009C50 RID: 40016
	public readonly EUiViewName? BelongView;

	// Token: 0x02008B6D RID: 35693
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F004 RID: 192516
		AddMaterialText,
		// Token: 0x0402F005 RID: 192517
		PanelButton,
		// Token: 0x0402F006 RID: 192518
		ConditionButton,
		// Token: 0x0402F007 RID: 192519
		AutoButton,
		// Token: 0x0402F008 RID: 192520
		LoopItem,
		// Token: 0x0402F009 RID: 192521
		ScrollView,
		// Token: 0x0402F00A RID: 192522
		CostRootItem,
		// Token: 0x0402F00B RID: 192523
		ConsumeTexture,
		// Token: 0x0402F00C RID: 192524
		ConsumeText,
		// Token: 0x0402F00D RID: 192525
		ConditionText,
		// Token: 0x0402F00E RID: 192526
		MaterialRootItem,
		// Token: 0x0402F00F RID: 192527
		StrengthItem,
		// Token: 0x0402F010 RID: 192528
		MaxItem,
		// Token: 0x0402F011 RID: 192529
		LockItem,
		// Token: 0x0402F012 RID: 192530
		TopButtons,
		// Token: 0x0402F013 RID: 192531
		AutoButtonText,
		// Token: 0x0402F014 RID: 192532
		LockText,
		// Token: 0x0402F015 RID: 192533
		LockTipButton
	}
}
