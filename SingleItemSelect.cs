using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002CF7 RID: 11511
[NullableContext(1)]
[Nullable(0)]
public class SingleItemSelect
{
	// Token: 0x060173A0 RID: 95136 RVA: 0x00670374 File Offset: 0x0066E574
	public void Init(UUIItem uiItem, ESingleItemSelectViewType openViewType = ESingleItemSelectViewType.Right)
	{
		this.ItemGridVariantSelect = new MediumItemGrid();
		this.ItemGridVariantSelect.Initialize(uiItem.GetOwner());
		EmptyItemGrid parameters = new EmptyItemGrid();
		this.ItemGridVariantSelect.Apply<EmptyItemGrid>(parameters);
		this.OpenViewType = openViewType;
		this.ItemGridVariantSelect.BindEmptySlotButtonCallback(delegate(MediumItemGridButtonCallback _)
		{
			this.OpenItemSelectView();
		});
		this.ItemGridVariantSelect.BindReduceButtonCallback(delegate(MediumItemGridButtonCallback _)
		{
			this.OpenItemSelectView();
		}, null);
		this.ItemGridVariantSelect.BindOnExtendToggleRelease(delegate(MediumItemGridExtendCallback _)
		{
			this.OpenItemSelectView();
		});
		this.ItemGridVariantSelect.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
		this.ItemGridVariantSelect.SetReduceButton(null);
		this.ViewSelectData.IsSingleSelected = true;
		this.ViewSelectData.OnChangeSelectedFunction = new Action<List<ISelectedData>, SelectableExpData>(this.OnChangeSameMonsterSelectedFunction);
		this.ViewSelectData.CheckIfCanAddFunction = new Func<List<ISelectedData>, int, int, int, bool>(this.CheckIfCanAdd);
		this.ViewOpenData.SelectableComponentData = this.ViewSelectData;
	}

	// Token: 0x060173A1 RID: 95137 RVA: 0x00670480 File Offset: 0x0066E680
	public void OpenItemSelectView()
	{
		List<ISelectedData> list = new List<ISelectedData>();
		if (this.CurrentSelectItem != null)
		{
			list.Add(this.CurrentSelectItem);
		}
		this.ViewOpenData.ItemDataBaseList = this.GetItemList();
		this.ViewOpenData.SelectedDataList = list;
		this.ViewOpenData.UseWayId = (EFilterSortGroupId)this.UseWayId;
		this.ViewOpenData.InitSortToggleState = this.InitSortToggleState;
		if (this.OpenViewType == ESingleItemSelectViewType.Right)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonItemSelectViewRight, this.ViewOpenData, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonItemSelectViewLeft, this.ViewOpenData, null);
	}

	// Token: 0x060173A2 RID: 95138 RVA: 0x00670520 File Offset: 0x0066E720
	public void SetUseWayId(int useWayId)
	{
		this.UseWayId = useWayId;
	}

	// Token: 0x060173A3 RID: 95139 RVA: 0x00670529 File Offset: 0x0066E729
	public void SetInitSortToggleState(bool bSelect)
	{
		this.InitSortToggleState = bSelect;
	}

	// Token: 0x060173A4 RID: 95140 RVA: 0x00670532 File Offset: 0x0066E732
	private void OnChangeSameMonsterSelectedFunction(List<ISelectedData> currentSelectedData, SelectableExpData expData)
	{
		if (currentSelectedData != null && currentSelectedData.Count > 0)
		{
			this.CurrentSelectItem = currentSelectedData[0];
		}
		else
		{
			this.CurrentSelectItem = null;
		}
		this.RefreshCurrentSelectItemGrid();
	}

	// Token: 0x060173A5 RID: 95141 RVA: 0x0067055C File Offset: 0x0066E75C
	private bool CheckIfCanAdd(List<ISelectedData> currentSelectedData, int uniqueId, int itemId, int count)
	{
		return this.CurrentSelectItem == null || uniqueId != this.CurrentSelectItem.IncId || itemId != this.CurrentSelectItem.ItemId || count <= 0;
	}

	// Token: 0x060173A6 RID: 95142 RVA: 0x0067058C File Offset: 0x0066E78C
	private void RefreshCurrentSelectItemGrid()
	{
		if (this.CurrentSelectItem == null)
		{
			this.ItemGridVariantSelect.SetSelected(false, false);
			EmptyItemGrid parameters = new EmptyItemGrid();
			this.ItemGridVariantSelect.Apply<EmptyItemGrid>(parameters);
		}
		else
		{
			int incId = this.CurrentSelectItem.IncId;
			int itemId = this.CurrentSelectItem.ItemId;
			InventoryModel instance = ModelBase<InventoryModel>.Instance;
			ItemDataBase itemDataBase = instance.GetAttributeItemData(incId);
			if (itemDataBase == null)
			{
				itemDataBase = instance.GetCommonItemData(itemId, 0);
			}
			PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
			{
				ItemConfigId = new int?(itemId),
				StarLevel = new int?(itemDataBase.GetQuality())
			};
			if (itemDataBase is AttributeItemData)
			{
				propMediumItemGrid.BottomTextId = "Text_LevelShow_Text";
				if (itemDataBase is PhantomItemData)
				{
					ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
					PhantomBattleModel instance2 = ModelBase<PhantomBattleModel>.Instance;
					PhantomBattleData phantomBattleData = instance2.GetPhantomBattleData(incId);
					int phantomLevel = instance2.GetPhantomBattleData(incId).GetPhantomLevel();
					propMediumItemGrid.BottomTextParameter = new object[]
					{
						phantomLevel
					};
					propMediumItemGrid.BottomTextId = itemConfigData.Name;
					propMediumItemGrid.StarLevel = new int?(itemConfigData.QualityId);
					propMediumItemGrid.Level = new int?(phantomBattleData.GetCost());
					propMediumItemGrid.IsLevelTextUseChangeColor = new bool?(true);
				}
				if (itemDataBase is WeaponItemData)
				{
					WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
					int level = weaponDataByIncId.GetLevel();
					propMediumItemGrid.Level = new int?(weaponDataByIncId.GetResonanceLevel());
					propMediumItemGrid.BottomTextParameter = new object[]
					{
						level
					};
				}
			}
			else
			{
				propMediumItemGrid.BottomText = this.CurrentSelectItem.SelectedCount.ToString();
			}
			this.ItemGridVariantSelect.Apply<PropMediumItemGrid>(propMediumItemGrid);
			this.ItemGridVariantSelect.SetSelected(true, false);
		}
		this.OnItemSelectChange(this.CurrentSelectItem);
	}

	// Token: 0x060173A7 RID: 95143 RVA: 0x00670754 File Offset: 0x0066E954
	public void ClearSelectData()
	{
		this.CurrentSelectItem = null;
		this.RefreshCurrentSelectItemGrid();
	}

	// Token: 0x060173A8 RID: 95144 RVA: 0x00670763 File Offset: 0x0066E963
	public void SetItemSelectChangeCallBack(Action<ISelectedData> callBack)
	{
		this.OnItemSelectChange = callBack;
	}

	// Token: 0x060173A9 RID: 95145 RVA: 0x0067076C File Offset: 0x0066E96C
	public void SetGetItemListFunction(Func<List<ItemDataBase>> func)
	{
		this.GetItemList = func;
	}

	// Token: 0x060173AA RID: 95146 RVA: 0x00670775 File Offset: 0x0066E975
	[NullableContext(2)]
	public ISelectedData GetCurrentSelectedData()
	{
		return this.CurrentSelectItem;
	}

	// Token: 0x0400B29A RID: 45722
	[Nullable(2)]
	private ISelectedData CurrentSelectItem;

	// Token: 0x0400B29B RID: 45723
	[Nullable(2)]
	private MediumItemGrid ItemGridVariantSelect;

	// Token: 0x0400B29C RID: 45724
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Func<List<ItemDataBase>> GetItemList;

	// Token: 0x0400B29D RID: 45725
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<ISelectedData> OnItemSelectChange;

	// Token: 0x0400B29E RID: 45726
	private readonly CommonItemSelectViewOpenViewData<ItemDataBase> ViewOpenData = new CommonItemSelectViewOpenViewData<ItemDataBase>();

	// Token: 0x0400B29F RID: 45727
	private readonly SelectableComponentData ViewSelectData = new SelectableComponentData();

	// Token: 0x0400B2A0 RID: 45728
	private ESingleItemSelectViewType OpenViewType;

	// Token: 0x0400B2A1 RID: 45729
	private int UseWayId;

	// Token: 0x0400B2A2 RID: 45730
	private bool InitSortToggleState;
}
