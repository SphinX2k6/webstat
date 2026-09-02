using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200197A RID: 6522
[NullableContext(1)]
[Nullable(0)]
public class ItemSelectView : UiViewBase
{
	// Token: 0x0600BB81 RID: 48001 RVA: 0x0031CD5F File Offset: 0x0031AF5F
	public ItemSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600BB82 RID: 48002 RVA: 0x0031CD68 File Offset: 0x0031AF68
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickMask))
		};
	}

	// Token: 0x0600BB83 RID: 48003 RVA: 0x0031CE28 File Offset: 0x0031B028
	protected override UniTask OnBeforeStartAsync()
	{
		ItemSelectView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ItemSelectView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BB84 RID: 48004 RVA: 0x0031CE6C File Offset: 0x0031B06C
	protected override void OnStart()
	{
		this.SelectComponent = new CommonItemSelectView<ItemDataBase>(base.GetItem(0));
		this.SortEntrance = new SortEntrance<ItemDataBase>(base.GetItem(5), new TUpdateDataListFunction<ItemDataBase>(this.OnFilterRefresh));
		this.FilterEntrance = new FilterEntrance<ItemDataBase>(base.GetItem(4), new TUpdateDataListFunction<ItemDataBase>(this.OnFilterRefresh));
	}

	// Token: 0x0600BB85 RID: 48005 RVA: 0x0031CEC7 File Offset: 0x0031B0C7
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnSelectItemAdd, new Action<int, int>(this.OnSelectItem));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
	}

	// Token: 0x0600BB86 RID: 48006 RVA: 0x0031CF01 File Offset: 0x0031B101
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectItemAdd, new Action<int, int>(this.OnSelectItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
	}

	// Token: 0x0600BB87 RID: 48007 RVA: 0x0031CF3C File Offset: 0x0031B13C
	protected override void OnBeforeShow()
	{
		CommonItemSelectViewOpenViewData<ItemDataBase> commonItemSelectViewOpenViewData = this.OpenParam as CommonItemSelectViewOpenViewData<ItemDataBase>;
		this.SelectComponent.UpdateSelectableComponent(commonItemSelectViewOpenViewData.SelectableComponentType, commonItemSelectViewOpenViewData.ItemDataBaseList, commonItemSelectViewOpenViewData.SelectedDataList, commonItemSelectViewOpenViewData.SelectableComponentData, commonItemSelectViewOpenViewData.ExpData);
		this.SortEntrance.SetSortToggleState(commonItemSelectViewOpenViewData.InitSortToggleState);
		this.UpdateFilterComponent(commonItemSelectViewOpenViewData.UseWayId, commonItemSelectViewOpenViewData.ItemDataBaseList);
	}

	// Token: 0x0600BB88 RID: 48008 RVA: 0x0031CFA1 File Offset: 0x0031B1A1
	private void OnClickMask()
	{
		base.GetItem(3).SetUIActive(false);
		base.CloseMe(null);
	}

	// Token: 0x0600BB89 RID: 48009 RVA: 0x0031CFB8 File Offset: 0x0031B1B8
	private void OnSelectItem(int itemId, int incId)
	{
		ItemTipsData tipsDataById = ItemTipsComponentUtilTool.GetTipsDataById(itemId, new int?(incId), null);
		if (tipsDataById == null)
		{
			return;
		}
		this.ItemTipsComponentContentComponent.Refresh(tipsDataById);
		base.GetItem(3).SetUIActive(true);
	}

	// Token: 0x0600BB8A RID: 48010 RVA: 0x0031CFF0 File Offset: 0x0031B1F0
	private void OnFilterRefresh(List<ItemDataBase> dataList, bool isOutSideChange, EFilterSortType operationType)
	{
		this.SelectComponent.UpdateByDataList(dataList);
	}

	// Token: 0x0600BB8B RID: 48011 RVA: 0x0031D000 File Offset: 0x0031B200
	public void UpdateFilterComponent(EFilterSortGroupId useWayId, List<ItemDataBase> list)
	{
		bool flag = false;
		bool flag2 = false;
		if (useWayId != EFilterSortGroupId.None)
		{
			if (ConfigBase<SortConfig>.Instance.GetSortId(useWayId) > 0)
			{
				flag = true;
			}
			if (ConfigBase<FilterConfig>.Instance.GetFilterId(useWayId) > 0)
			{
				flag2 = true;
			}
		}
		this.SortEntrance.GetRootItem().SetUIActive(flag);
		this.FilterEntrance.GetRootItem().SetUIActive(flag2);
		if (!flag && !flag2)
		{
			this.SelectComponent.UpdateByDataList(list);
			return;
		}
		if (flag)
		{
			this.SortEntrance.UpdateData(useWayId, list, Array.Empty<object>());
			int uniqueIdByGroupId = this.SortEntrance.GetUniqueIdByGroupId(useWayId);
			this.FilterEntrance.SetSortUniqueId(uniqueIdByGroupId);
		}
		if (flag2)
		{
			this.FilterEntrance.UpdateData(useWayId, list, Array.Empty<object>());
			int uniqueIdByGroupId2 = this.FilterEntrance.GetUniqueIdByGroupId(useWayId);
			this.SortEntrance.SetFilterUniqueId(uniqueIdByGroupId2);
		}
	}

	// Token: 0x0600BB8C RID: 48012 RVA: 0x0031D0C5 File Offset: 0x0031B2C5
	protected override void OnBeforeDestroy()
	{
		this.SelectComponent.Destroy(null);
		this.ItemTipsComponentContentComponent.Destroy(null);
	}

	// Token: 0x0600BB8D RID: 48013 RVA: 0x0031D0E0 File Offset: 0x0031B2E0
	private void OnItemFuncValueChange(int uniqueId)
	{
		CommonItemSelectViewOpenViewData<ItemDataBase> commonItemSelectViewOpenViewData = this.OpenParam as CommonItemSelectViewOpenViewData<ItemDataBase>;
		if (commonItemSelectViewOpenViewData == null || commonItemSelectViewOpenViewData.ItemDataBaseList == null)
		{
			return;
		}
		int num = commonItemSelectViewOpenViewData.ItemDataBaseList.FindIndex((ItemDataBase itemData) => itemData.GetUniqueId() == uniqueId);
		if (num < 0)
		{
			return;
		}
		bool isLock = commonItemSelectViewOpenViewData.ItemDataBaseList[num].GetIsLock();
		if (commonItemSelectViewOpenViewData.SelectedDataList != null && isLock)
		{
			int num2 = commonItemSelectViewOpenViewData.SelectedDataList.FindIndex((ISelectedData selectData) => selectData.IncId == uniqueId);
			if (num2 >= 0)
			{
				commonItemSelectViewOpenViewData.SelectedDataList.RemoveAt(num2);
			}
		}
		this.SelectComponent.UpdateSelectableComponent(commonItemSelectViewOpenViewData.SelectableComponentType, commonItemSelectViewOpenViewData.ItemDataBaseList, commonItemSelectViewOpenViewData.SelectedDataList, commonItemSelectViewOpenViewData.SelectableComponentData, commonItemSelectViewOpenViewData.ExpData);
		this.SelectComponent.RefreshPartByIndex(num);
		this.SelectComponent.UpdateChangeItemSelectList();
	}

	// Token: 0x0400588E RID: 22670
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CommonItemSelectView<ItemDataBase> SelectComponent;

	// Token: 0x0400588F RID: 22671
	[Nullable(2)]
	private ItemTipsComponentContentComponent ItemTipsComponentContentComponent;

	// Token: 0x04005890 RID: 22672
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private SortEntrance<ItemDataBase> SortEntrance;

	// Token: 0x04005891 RID: 22673
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterEntrance<ItemDataBase> FilterEntrance;

	// Token: 0x02007C8F RID: 31887
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A892 RID: 174226
		Pad,
		// Token: 0x0402A893 RID: 174227
		TipsPos,
		// Token: 0x0402A894 RID: 174228
		Mask,
		// Token: 0x0402A895 RID: 174229
		ItemTips,
		// Token: 0x0402A896 RID: 174230
		FilterItem,
		// Token: 0x0402A897 RID: 174231
		SortItem
	}
}
