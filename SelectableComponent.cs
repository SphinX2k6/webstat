using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A04 RID: 6660
[NullableContext(1)]
[Nullable(0)]
public class SelectableComponent<[Nullable(0)] T> : UiPanelBase where T : ItemDataBase
{
	// Token: 0x0600BE9E RID: 48798 RVA: 0x0032753E File Offset: 0x0032573E
	public void InitLoopScroller(UUILoopScrollViewComponent loopComponent, UUIItem templateActor, SelectableComponentData data)
	{
		this.LoopScrollView = new LoopScrollView<SelectablePropMediumItemGrid, SelectablePropData>(loopComponent, templateActor.GetOwner() as AUIBaseActor, new Func<SelectablePropMediumItemGrid>(this.InitItem), false);
		this.SetData(data);
	}

	// Token: 0x0600BE9F RID: 48799 RVA: 0x0032756C File Offset: 0x0032576C
	protected void SetData(SelectableComponentData data)
	{
		this.Data = data;
	}

	// Token: 0x0600BEA0 RID: 48800 RVA: 0x00327575 File Offset: 0x00325775
	public void SetExpData(CommonIntensifyPropExpData expData)
	{
		this.SelectableExpData = SelectableExpData.PhraseData(expData);
	}

	// Token: 0x0600BEA1 RID: 48801 RVA: 0x00327583 File Offset: 0x00325783
	public void SetMaxSize(int size)
	{
		this.MaxSize = size;
	}

	// Token: 0x0600BEA2 RID: 48802 RVA: 0x0032758C File Offset: 0x0032578C
	public void SetOnlyGold(bool onlyGold)
	{
		this.OnlyGold = onlyGold;
	}

	// Token: 0x0600BEA3 RID: 48803 RVA: 0x00327595 File Offset: 0x00325795
	public void UpdateComponent(List<T> itemDataBaseList, List<ISelectedData> selectedDataList, [Nullable(2)] CommonIntensifyPropExpData expData = null)
	{
		this.InitSelectedData(selectedDataList);
		if (expData != null)
		{
			this.ExpData = expData;
			this.SetExpData(expData);
			this.UpdateExp();
		}
	}

	// Token: 0x0600BEA4 RID: 48804 RVA: 0x003275B5 File Offset: 0x003257B5
	public void RefreshPartByIndex(int index)
	{
		this.LoopScrollView.RefreshGridProxy(index);
	}

	// Token: 0x0600BEA5 RID: 48805 RVA: 0x003275C3 File Offset: 0x003257C3
	public void RefreshAllByDisplay()
	{
		this.LoopScrollView.RefreshAllGridProxies();
	}

	// Token: 0x0600BEA6 RID: 48806 RVA: 0x003275D0 File Offset: 0x003257D0
	private void InitSelectedData(List<ISelectedData> selectedDataList)
	{
		if (selectedDataList != null)
		{
			this.SelectedDataList = selectedDataList;
		}
		else
		{
			this.SelectedDataList = new List<ISelectedData>();
		}
		if (this.Data.IsSingleSelected && selectedDataList != null && selectedDataList.Count > 0)
		{
			this.SetLastAddData(selectedDataList[0]);
		}
	}

	// Token: 0x0600BEA7 RID: 48807 RVA: 0x0032760F File Offset: 0x0032580F
	public List<ISelectedData> GetCurrentSelectedData()
	{
		return this.SelectedDataList;
	}

	// Token: 0x0600BEA8 RID: 48808 RVA: 0x00327618 File Offset: 0x00325818
	public void UpdateDataList(List<T> dataList)
	{
		this.ItemDataList = dataList;
		this.LoopScrollView.ReloadProxyData(new Func<int, SelectablePropData>(this.GetPropScrollViewData), this.ItemDataList.Count, true, false);
		if (this.ItemDataList.Count > 0)
		{
			this.LoopScrollView.ScrollToGridIndex(this.LastSelectedIndex, true);
		}
	}

	// Token: 0x0600BEA9 RID: 48809 RVA: 0x00327670 File Offset: 0x00325870
	public void RefreshByData(List<T> dataList, bool keepContentPosition = false, [Nullable(2)] Action callBack = null)
	{
		this.ItemDataList = dataList;
		List<SelectablePropData> list = new List<SelectablePropData>();
		foreach (T t in this.ItemDataList)
		{
			SelectablePropData selectablePropData = SelectablePropDataUtil.GetSelectablePropData(t);
			if (selectablePropData != null)
			{
				int selectedDataCount = this.GetSelectedDataCount(selectablePropData);
				selectablePropData.SelectedCount = selectedDataCount;
				selectablePropData.OnlyGold = this.OnlyGold;
				list.Add(selectablePropData);
			}
		}
		this.LoopScrollView.RefreshByData(list, keepContentPosition, callBack, false);
	}

	// Token: 0x0600BEAA RID: 48810 RVA: 0x00327708 File Offset: 0x00325908
	public void UpdateChangeItemSelectList()
	{
		Action<List<ISelectedData>, SelectableExpData> onChangeSelectedFunction = this.Data.OnChangeSelectedFunction;
		if (onChangeSelectedFunction == null)
		{
			return;
		}
		onChangeSelectedFunction(this.SelectedDataList, this.SelectableExpData);
	}

	// Token: 0x0600BEAB RID: 48811 RVA: 0x0032772C File Offset: 0x0032592C
	private SelectablePropData GetPropScrollViewData(int gridIndex)
	{
		SelectablePropData selectablePropData = SelectablePropDataUtil.GetSelectablePropData(this.ItemDataList[gridIndex]);
		if (selectablePropData == null)
		{
			return new SelectablePropData();
		}
		int selectedDataCount = this.GetSelectedDataCount(selectablePropData);
		selectablePropData.SelectedCount = selectedDataCount;
		selectablePropData.OnlyGold = this.OnlyGold;
		return selectablePropData;
	}

	// Token: 0x0600BEAC RID: 48812 RVA: 0x00327775 File Offset: 0x00325975
	[NullableContext(2)]
	public ISelectedData GetFirstOperationItem()
	{
		return this.FirstOperationData;
	}

	// Token: 0x0600BEAD RID: 48813 RVA: 0x0032777D File Offset: 0x0032597D
	public void SetFirstOperationData(ISelectedData data)
	{
		this.FirstOperationData = data;
	}

	// Token: 0x0600BEAE RID: 48814 RVA: 0x00327786 File Offset: 0x00325986
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x0600BEAF RID: 48815 RVA: 0x00327788 File Offset: 0x00325988
	protected virtual SelectablePropMediumItemGrid InitItem()
	{
		SelectablePropMediumItemGrid selectablePropMediumItemGrid = new SelectablePropMediumItemGrid();
		selectablePropMediumItemGrid.BindLongPress(LongPressButtonItem.ELongPressConfigId.LongPressOne, delegate(bool _1, ItemGridBase _2, [Nullable(2)] object _3)
		{
			this.AddFunction(_1, _2, _3);
		}, new Func<ItemGridBase, object, bool>(this.CanItemLongPress));
		selectablePropMediumItemGrid.BindReduceLongPress(delegate(bool _1, MediumItemGrid _2, object _3)
		{
			this.ReduceFunction(_1, _2, _3);
		});
		selectablePropMediumItemGrid.BindAfterApply(new Action<SelectablePropMediumItemGrid>(this.OnAfterApplyMediumItemGrid));
		selectablePropMediumItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnCanExecuteChange));
		return selectablePropMediumItemGrid;
	}

	// Token: 0x0600BEB0 RID: 48816 RVA: 0x003277EF File Offset: 0x003259EF
	protected void OnAfterApplyMediumItemGrid(SelectablePropMediumItemGrid selectablePropMediumItemGrid)
	{
	}

	// Token: 0x0600BEB1 RID: 48817 RVA: 0x003277F4 File Offset: 0x003259F4
	[NullableContext(2)]
	protected bool OnCanExecuteChange(object data, bool isForceSelected, EToggleState state)
	{
		SelectablePropData selectablePropData = data as SelectablePropData;
		return selectablePropData != null && this.CanAddMaterial(selectablePropData, false);
	}

	// Token: 0x0600BEB2 RID: 48818 RVA: 0x00327818 File Offset: 0x00325A18
	protected bool CanItemLongPress(ItemGridBase itemGrid, [Nullable(2)] object data)
	{
		SelectablePropData selectablePropData = data as SelectablePropData;
		return selectablePropData != null && this.CanAddMaterial(selectablePropData, false);
	}

	// Token: 0x0600BEB3 RID: 48819 RVA: 0x0032783C File Offset: 0x00325A3C
	protected bool AddFunction(bool isShortPress, ItemGridBase itemGrid, [Nullable(2)] object data)
	{
		SelectablePropData selectablePropData = data as SelectablePropData;
		if (selectablePropData == null)
		{
			return false;
		}
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnSelectItemAdd, selectablePropData.ItemId, selectablePropData.IncId);
		this.SetPrevPropItemSelectedState(selectablePropData);
		if (!this.CanAddMaterial(selectablePropData, true))
		{
			return false;
		}
		if (this.Data.IsSingleSelected)
		{
			this.DeleteLastData(selectablePropData);
			this.CancelPropItemSelected(selectablePropData);
		}
		this.SetLastAddData(selectablePropData);
		this.AddData(selectablePropData);
		this.UpdateExp();
		this.OnChangeItemSelectList();
		SelectablePropMediumItemGrid selectablePropMediumItemGrid = itemGrid as SelectablePropMediumItemGrid;
		if (selectablePropMediumItemGrid == null)
		{
			return false;
		}
		ISelectedData selectedData = this.GetSelectedData(selectablePropData);
		if (selectedData != null)
		{
			selectablePropData.SelectedCount = selectedData.SelectedCount;
		}
		selectablePropMediumItemGrid.RefreshCostCount();
		CSharpScript.Game.Module.Common.MediumItemGrid.LongPressButton reduceButton = new CSharpScript.Game.Module.Common.MediumItemGrid.LongPressButton
		{
			IsVisible = new bool?(selectablePropData.SelectedCount > 0),
			LongPressConfigId = new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne)
		};
		SelectableComponentData data2 = this.Data;
		if (data2 != null && data2.IsNumSelectable)
		{
			selectablePropMediumItemGrid.SetReduceButton(reduceButton);
		}
		selectablePropMediumItemGrid.SetSelected(selectablePropData.SelectedCount > 0, true);
		return true;
	}

	// Token: 0x0600BEB4 RID: 48820 RVA: 0x00327934 File Offset: 0x00325B34
	protected bool ReduceFunction(bool isShortPress, MediumItemGrid mediumItemGrid, [Nullable(2)] object data)
	{
		SelectablePropData selectablePropData = data as SelectablePropData;
		if (selectablePropData == null)
		{
			return false;
		}
		this.SetPrevPropItemSelectedState(selectablePropData);
		ISelectedData selectedData = this.GetSelectedData(selectablePropData);
		if (selectedData == null)
		{
			return false;
		}
		int num = selectedData.SelectedCount;
		if (num == 0)
		{
			return false;
		}
		if (--num <= 0)
		{
			this.RemoveSelectedData(selectablePropData);
		}
		else
		{
			selectedData.SelectedCount = num;
		}
		selectablePropData.SelectedCount = num;
		if (this.Data.OtherFunction != null)
		{
			this.Data.OtherFunction();
		}
		this.UpdateExp();
		this.OnChangeItemSelectList();
		SelectablePropMediumItemGrid selectablePropMediumItemGrid = mediumItemGrid as SelectablePropMediumItemGrid;
		if (selectablePropMediumItemGrid == null)
		{
			return false;
		}
		selectablePropMediumItemGrid.RefreshCostCount();
		selectablePropMediumItemGrid.SetSelected(num > 0, true);
		CSharpScript.Game.Module.Common.MediumItemGrid.LongPressButton reduceButton = new CSharpScript.Game.Module.Common.MediumItemGrid.LongPressButton
		{
			IsVisible = new bool?(selectablePropData.SelectedCount > 0),
			LongPressConfigId = new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne)
		};
		SelectableComponentData data2 = this.Data;
		if (data2 != null && data2.IsNumSelectable)
		{
			selectablePropMediumItemGrid.SetReduceButton(reduceButton);
		}
		return true;
	}

	// Token: 0x0600BEB5 RID: 48821 RVA: 0x00327A18 File Offset: 0x00325C18
	protected void SetPrevPropItemSelectedState(SelectablePropData propData)
	{
		if (this.LastSelectedPropData == null || this.IsSameLastAddItemData(propData))
		{
			return;
		}
		if (this.LastAddData == null)
		{
			return;
		}
		int loopScrollViewIndex = this.GetLoopScrollViewIndex(this.LastAddData.IncId, this.LastAddData.ItemId);
		if (loopScrollViewIndex < 0)
		{
			return;
		}
		if (!this.LoopScrollView.IsGridDisplaying(loopScrollViewIndex))
		{
			return;
		}
		SelectablePropMediumItemGrid selectablePropMediumItemGrid = this.LoopScrollView.UnsafeGetGridProxy(loopScrollViewIndex, false);
		if (selectablePropMediumItemGrid == null)
		{
			return;
		}
		selectablePropMediumItemGrid.OnDeselected(false);
	}

	// Token: 0x0600BEB6 RID: 48822 RVA: 0x00327A8C File Offset: 0x00325C8C
	protected virtual bool CanAddMaterial(SelectablePropData propData, bool isShowTip = false)
	{
		if (propData.GetIsLock())
		{
			if (isShowTip)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponLockTipsText", Array.Empty<object>());
			}
			return false;
		}
		SelectableExpData selectableExpData = this.SelectableExpData;
		if (selectableExpData != null && selectableExpData.IsInMax())
		{
			if (isShowTip)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponAddExpTipsText", Array.Empty<object>());
			}
			return false;
		}
		ISelectedData selectedData = this.GetSelectedData(propData);
		if (selectedData != null && selectedData.SelectedCount > 0 && selectedData.SelectedCount == propData.Count)
		{
			return false;
		}
		if (selectedData == null && this.SelectedDataList.Count >= this.MaxSize && !this.Data.IsSingleSelected)
		{
			if (isShowTip)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponFullMaterialText", Array.Empty<object>());
			}
			return false;
		}
		return this.Data.CheckIfCanAddFunction == null || this.Data.CheckIfCanAddFunction(this.SelectedDataList, propData.IncId, propData.ItemId, 1);
	}

	// Token: 0x0600BEB7 RID: 48823 RVA: 0x00327B7C File Offset: 0x00325D7C
	private bool IsSameLastAddItemData(ISelectedData selectedData)
	{
		if (this.LastAddData == null)
		{
			return false;
		}
		int incId = selectedData.IncId;
		if (incId > 0)
		{
			return this.LastAddData.IncId == incId;
		}
		return this.LastAddData.ItemId == selectedData.ItemId;
	}

	// Token: 0x0600BEB8 RID: 48824 RVA: 0x00327BC0 File Offset: 0x00325DC0
	public int GetLoopScrollViewIndex(int incId, int configId)
	{
		if (incId > 0 || configId > 0)
		{
			int i = 0;
			int count = this.ItemDataList.Count;
			while (i < count)
			{
				T t = this.ItemDataList[i];
				if (incId > 0)
				{
					if (t.GetUniqueId() == incId)
					{
						return i;
					}
				}
				else if (t.GetConfigId() == configId)
				{
					return i;
				}
				i++;
			}
		}
		return -1;
	}

	// Token: 0x0600BEB9 RID: 48825 RVA: 0x00327C1F File Offset: 0x00325E1F
	protected void DeleteLastData(SelectablePropData propData)
	{
		if (!this.IsSameLastAddItemData(propData))
		{
			this.RemoveSelectedData(this.LastAddData);
		}
	}

	// Token: 0x0600BEBA RID: 48826 RVA: 0x00327C38 File Offset: 0x00325E38
	private void RemoveSelectedData(ISelectedData selectedData)
	{
		if (selectedData == null)
		{
			return;
		}
		int incId = selectedData.IncId;
		if (incId > 0)
		{
			this.RemoveSelectedDataByIncId(incId);
			return;
		}
		this.RemoveSelectedDataByConfigId(selectedData.ItemId);
	}

	// Token: 0x0600BEBB RID: 48827 RVA: 0x00327C68 File Offset: 0x00325E68
	protected void RemoveSelectedDataByIncId(int incId)
	{
		for (int i = 0; i < this.SelectedDataList.Count; i++)
		{
			ISelectedData selectedData = this.SelectedDataList[i];
			if (selectedData.IncId == incId)
			{
				selectedData.SelectedCount = 0;
				this.SelectedDataList.RemoveAt(i);
				return;
			}
		}
	}

	// Token: 0x0600BEBC RID: 48828 RVA: 0x00327CB8 File Offset: 0x00325EB8
	private void RemoveSelectedDataByConfigId(int configId)
	{
		for (int i = 0; i < this.SelectedDataList.Count; i++)
		{
			ISelectedData selectedData = this.SelectedDataList[i];
			if (selectedData.ItemId == configId)
			{
				selectedData.SelectedCount = 0;
				this.SelectedDataList.RemoveAt(i);
				return;
			}
		}
	}

	// Token: 0x0600BEBD RID: 48829 RVA: 0x00327D08 File Offset: 0x00325F08
	protected void CancelPropItemSelected(SelectablePropData propData)
	{
		if (this.LastAddData == null || this.IsSameLastAddItemData(propData))
		{
			return;
		}
		int loopScrollViewIndex = this.GetLoopScrollViewIndex(this.LastAddData.IncId, this.LastAddData.ItemId);
		if (loopScrollViewIndex < 0)
		{
			return;
		}
		if (!this.LoopScrollView.IsGridDisplaying(loopScrollViewIndex))
		{
			return;
		}
		SelectablePropMediumItemGrid selectablePropMediumItemGrid = this.LoopScrollView.UnsafeGetGridProxy(loopScrollViewIndex, false);
		if (selectablePropMediumItemGrid == null)
		{
			return;
		}
		selectablePropMediumItemGrid.Clear();
		selectablePropMediumItemGrid.SetSelected(false, true);
		selectablePropMediumItemGrid.SetReduceButton(null);
	}

	// Token: 0x0600BEBE RID: 48830 RVA: 0x00327D80 File Offset: 0x00325F80
	private void SetLastAddData(ISelectedData selectedData)
	{
		this.LastAddData = selectedData;
		SelectablePropData selectablePropData = selectedData as SelectablePropData;
		if (selectablePropData != null)
		{
			this.LastSelectedPropData = selectablePropData;
		}
	}

	// Token: 0x0600BEBF RID: 48831 RVA: 0x00327DA8 File Offset: 0x00325FA8
	protected void AddData(SelectablePropData propData)
	{
		ISelectedData selectedData = this.GetSelectedData(propData);
		if (selectedData == null)
		{
			this.SelectedDataList.Add(propData);
			int selectedCount = propData.SelectedCount;
			propData.SelectedCount = selectedCount + 1;
		}
		else
		{
			this.AddSelectedData(selectedData);
		}
		if (this.Data.OtherFunction != null)
		{
			this.Data.OtherFunction();
		}
	}

	// Token: 0x0600BEC0 RID: 48832 RVA: 0x00327E04 File Offset: 0x00326004
	private void AddSelectedData(ISelectedData selectedData)
	{
		int count = this.SelectedDataList.Count;
		for (int i = 0; i < count; i++)
		{
			ISelectedData selectedData2 = this.SelectedDataList[i];
			if (selectedData2.IncId == 0 && selectedData2.ItemId == selectedData.ItemId)
			{
				selectedData2.SelectedCount++;
				return;
			}
		}
		this.SelectedDataList.Add(selectedData);
	}

	// Token: 0x0600BEC1 RID: 48833 RVA: 0x00327E68 File Offset: 0x00326068
	[return: Nullable(2)]
	protected ISelectedData GetSelectedData(ISelectedData selectedData)
	{
		if (selectedData == null)
		{
			return null;
		}
		int incId = selectedData.IncId;
		if (incId > 0)
		{
			foreach (ISelectedData selectedData2 in this.SelectedDataList)
			{
				if (selectedData2.IncId == incId)
				{
					return selectedData2;
				}
			}
			return null;
		}
		int itemId = selectedData.ItemId;
		if (itemId > 0)
		{
			foreach (ISelectedData selectedData3 in this.SelectedDataList)
			{
				if (selectedData3.ItemId == itemId)
				{
					return selectedData3;
				}
			}
		}
		return null;
	}

	// Token: 0x0600BEC2 RID: 48834 RVA: 0x00327F30 File Offset: 0x00326130
	private int GetSelectedDataCount(ISelectedData selectedData)
	{
		ISelectedData selectedData2 = this.GetSelectedData(selectedData);
		if (selectedData2 == null)
		{
			return 0;
		}
		return selectedData2.SelectedCount;
	}

	// Token: 0x0600BEC3 RID: 48835 RVA: 0x00327F50 File Offset: 0x00326150
	protected void UpdateExp()
	{
		CommonIntensifyPropExpData expData = this.ExpData;
		if (((expData != null) ? expData.GetItemExpFunction : null) != null)
		{
			int num = 0;
			foreach (ISelectedData selectedData in this.SelectedDataList)
			{
				num += this.ExpData.GetItemExpFunction(selectedData) * selectedData.SelectedCount;
			}
			this.SelectableExpData.UpdateExp(num);
		}
	}

	// Token: 0x0600BEC4 RID: 48836 RVA: 0x00327FDC File Offset: 0x003261DC
	private void OnChangeItemSelectList()
	{
		this.UpdateChangeItemSelectList();
	}

	// Token: 0x0600BEC5 RID: 48837 RVA: 0x00327FE4 File Offset: 0x003261E4
	[NullableContext(2)]
	public UUIItem GetGridByDisplayIndex(int index)
	{
		LoopScrollView<SelectablePropMediumItemGrid, SelectablePropData> loopScrollView = this.LoopScrollView;
		if (loopScrollView == null)
		{
			return null;
		}
		return loopScrollView.GetGridByDisplayIndex(index);
	}

	// Token: 0x040059A6 RID: 22950
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<SelectablePropMediumItemGrid, SelectablePropData> LoopScrollView;

	// Token: 0x040059A7 RID: 22951
	[Nullable(2)]
	protected SelectableComponentData Data;

	// Token: 0x040059A8 RID: 22952
	protected List<ISelectedData> SelectedDataList = new List<ISelectedData>();

	// Token: 0x040059A9 RID: 22953
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected List<T> ItemDataList;

	// Token: 0x040059AA RID: 22954
	[Nullable(2)]
	protected ISelectedData LastAddData;

	// Token: 0x040059AB RID: 22955
	[Nullable(2)]
	protected SelectablePropData LastSelectedPropData;

	// Token: 0x040059AC RID: 22956
	protected int MaxSize = 20;

	// Token: 0x040059AD RID: 22957
	[Nullable(2)]
	protected SelectableExpData SelectableExpData;

	// Token: 0x040059AE RID: 22958
	[Nullable(2)]
	protected ISelectedData FirstOperationData;

	// Token: 0x040059AF RID: 22959
	[Nullable(2)]
	protected CommonIntensifyPropExpData ExpData;

	// Token: 0x040059B0 RID: 22960
	protected int LastSelectedIndex;

	// Token: 0x040059B1 RID: 22961
	protected bool OnlyGold;
}
