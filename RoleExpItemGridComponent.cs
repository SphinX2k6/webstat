using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002889 RID: 10377
[NullableContext(1)]
[Nullable(0)]
public class RoleExpItemGridComponent : UiPanelBase
{
	// Token: 0x060148A5 RID: 84133 RVA: 0x005B23B5 File Offset: 0x005B05B5
	public RoleExpItemGridComponent(Action levelUpClickCallBack, Action autoBtnClick, Action<int> itemClickCallBack, Action<int> itemReduceCallBack, Func<int, bool> canItemLongPress, Func<int, bool> canItemReduceLongPress, EUiViewName? belongView = null)
	{
		this.LevelUpClickCallBack = levelUpClickCallBack;
		this.AutoBtnClick = autoBtnClick;
		this.ItemClickCallBack = itemClickCallBack;
		this.ItemReduceCallBack = itemReduceCallBack;
		this.CanItemLongPress = canItemLongPress;
		this.CanItemReduceLongPress = canItemReduceLongPress;
		this.BelongView = belongView;
	}

	// Token: 0x060148A6 RID: 84134 RVA: 0x005B23F4 File Offset: 0x005B05F4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickAutoButton))
		};
	}

	// Token: 0x060148A7 RID: 84135 RVA: 0x005B24FC File Offset: 0x005B06FC
	protected override void OnStart()
	{
		this.ButtonItem = new ButtonItem(base.GetItem(11));
		this.ButtonItem.SetFunction(delegate(int _)
		{
			this.LevelUpClickCallBack();
		});
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
		this.ScrollView = new GenericScrollViewNew<RoleLevelUpCostMediumItemGrid, ISelectedData>(scrollViewWithScrollbar, new Func<RoleLevelUpCostMediumItemGrid>(this.InitItem), null, false, null);
	}

	// Token: 0x060148A8 RID: 84136 RVA: 0x005B2558 File Offset: 0x005B0758
	private RoleLevelUpCostMediumItemGrid InitItem()
	{
		RoleLevelUpCostMediumItemGrid roleLevelUpCostMediumItemGrid = new RoleLevelUpCostMediumItemGrid();
		roleLevelUpCostMediumItemGrid.BindLongPress(LongPressButtonItem.ELongPressConfigId.LongPressOne, new Action<bool, ItemGridBase, object>(this.OnExtendToggleStateChanged), null);
		roleLevelUpCostMediumItemGrid.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
		roleLevelUpCostMediumItemGrid.BindReduceLongPress(new Action<bool, MediumItemGrid, object>(this.OnReduceButtonCallback));
		return roleLevelUpCostMediumItemGrid;
	}

	// Token: 0x060148A9 RID: 84137 RVA: 0x005B25B8 File Offset: 0x005B07B8
	private void OnExtendToggleStateChanged(bool isShortPress, ItemGridBase itemGrid, object data)
	{
		int itemId = ((ISelectedData)data).ItemId;
		if (!isShortPress && !this.CanItemLongPress(itemId))
		{
			return;
		}
		this.ItemClickCallBack(itemId);
	}

	// Token: 0x060148AA RID: 84138 RVA: 0x005B25F0 File Offset: 0x005B07F0
	private void OnReduceButtonCallback(bool isShortPress, MediumItemGrid mediumItemGrid, [Nullable(2)] object data)
	{
		int itemId = ((ISelectedData)data).ItemId;
		if (!this.CanItemReduceLongPress(itemId))
		{
			return;
		}
		this.ItemReduceCallBack(itemId);
	}

	// Token: 0x060148AB RID: 84139 RVA: 0x005B2624 File Offset: 0x005B0824
	public void Update(List<ISelectedData> dataList, int moneyId, int needMoney)
	{
		this.UpdateByDataList(dataList);
		this.UpdateMoney(moneyId, needMoney);
	}

	// Token: 0x060148AC RID: 84140 RVA: 0x005B2635 File Offset: 0x005B0835
	public void UpdateByDataList(List<ISelectedData> dataList)
	{
		this.DataList = dataList;
		this.ScrollView.RefreshByData(this.DataList, null, false);
		this.UpdateAutoButtonState();
	}

	// Token: 0x060148AD RID: 84141 RVA: 0x005B2658 File Offset: 0x005B0858
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

	// Token: 0x060148AE RID: 84142 RVA: 0x005B26EB File Offset: 0x005B08EB
	public bool GetIsMoneyEnough()
	{
		return this.IsMoneyEnough;
	}

	// Token: 0x060148AF RID: 84143 RVA: 0x005B26F4 File Offset: 0x005B08F4
	public void UpdateAutoButtonState()
	{
		if (this.DataList == null)
		{
			this.AutoButtonState = EAutoButtonState.AutoAdd;
			return;
		}
		using (List<ISelectedData>.Enumerator enumerator = this.DataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SelectedCount > 0)
				{
					this.AutoButtonState = EAutoButtonState.Clear;
					return;
				}
			}
		}
		this.AutoButtonState = EAutoButtonState.AutoAdd;
	}

	// Token: 0x060148B0 RID: 84144 RVA: 0x005B2768 File Offset: 0x005B0968
	public EAutoButtonState GetAutoButtonState()
	{
		return this.AutoButtonState;
	}

	// Token: 0x060148B1 RID: 84145 RVA: 0x005B2770 File Offset: 0x005B0970
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<ISelectedData> GetDataList()
	{
		return this.DataList;
	}

	// Token: 0x060148B2 RID: 84146 RVA: 0x005B2778 File Offset: 0x005B0978
	public void SetMaxItemActive(bool bActive)
	{
		base.GetItem(12).SetUIActive(bActive);
	}

	// Token: 0x060148B3 RID: 84147 RVA: 0x005B2788 File Offset: 0x005B0988
	public void SetLockItemActive(bool bActive)
	{
		base.GetItem(13).SetUIActive(bActive);
	}

	// Token: 0x060148B4 RID: 84148 RVA: 0x005B2798 File Offset: 0x005B0998
	public void SetButtonItemActive(bool bActive)
	{
		this.ButtonItem.SetActive(bActive);
	}

	// Token: 0x060148B5 RID: 84149 RVA: 0x005B27A6 File Offset: 0x005B09A6
	public void SetMaxText(string textId)
	{
	}

	// Token: 0x060148B6 RID: 84150 RVA: 0x005B27A8 File Offset: 0x005B09A8
	public void SetLockText(string textId)
	{
	}

	// Token: 0x060148B7 RID: 84151 RVA: 0x005B27AA File Offset: 0x005B09AA
	public void SetButtonItemText(string textId)
	{
		this.ButtonItem.SetLocalText(textId, Array.Empty<object>());
	}

	// Token: 0x060148B8 RID: 84152 RVA: 0x005B27BD File Offset: 0x005B09BD
	public void SetAutoButtonText(string textId)
	{
		base.GetText(15).ShowTextNew(textId);
	}

	// Token: 0x060148B9 RID: 84153 RVA: 0x005B27CD File Offset: 0x005B09CD
	[return: Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public GenericScrollViewNew<RoleLevelUpCostMediumItemGrid, ISelectedData> GetGenericScrollView()
	{
		return this.ScrollView;
	}

	// Token: 0x060148BA RID: 84154 RVA: 0x005B27D5 File Offset: 0x005B09D5
	private void OnClickAutoButton()
	{
		this.AutoBtnClick();
	}

	// Token: 0x04009EDF RID: 40671
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericScrollViewNew<RoleLevelUpCostMediumItemGrid, ISelectedData> ScrollView;

	// Token: 0x04009EE0 RID: 40672
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ISelectedData> DataList;

	// Token: 0x04009EE1 RID: 40673
	private int MoneyId;

	// Token: 0x04009EE2 RID: 40674
	private int NeedMoney;

	// Token: 0x04009EE3 RID: 40675
	[Nullable(2)]
	private ButtonItem ButtonItem;

	// Token: 0x04009EE4 RID: 40676
	private EAutoButtonState AutoButtonState;

	// Token: 0x04009EE5 RID: 40677
	private bool IsMoneyEnough;

	// Token: 0x04009EE6 RID: 40678
	private readonly Action LevelUpClickCallBack;

	// Token: 0x04009EE7 RID: 40679
	private readonly Action AutoBtnClick;

	// Token: 0x04009EE8 RID: 40680
	private readonly Action<int> ItemClickCallBack;

	// Token: 0x04009EE9 RID: 40681
	private readonly Action<int> ItemReduceCallBack;

	// Token: 0x04009EEA RID: 40682
	private readonly Func<int, bool> CanItemLongPress;

	// Token: 0x04009EEB RID: 40683
	private readonly Func<int, bool> CanItemReduceLongPress;

	// Token: 0x04009EEC RID: 40684
	public EUiViewName? BelongView;
}
