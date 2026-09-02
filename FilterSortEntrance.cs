using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018DE RID: 6366
[NullableContext(1)]
[Nullable(0)]
public class FilterSortEntrance<[Nullable(2)] T> : UiPanelBase
{
	// Token: 0x0600B6E3 RID: 46819 RVA: 0x00309F49 File Offset: 0x00308149
	public FilterSortEntrance(UUIItem uiItem, TUpdateDataListFunction<T> updateList)
	{
		this.UpdateList = updateList;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B6E4 RID: 46820 RVA: 0x00309F68 File Offset: 0x00308168
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600B6E5 RID: 46821 RVA: 0x00309FD1 File Offset: 0x003081D1
	protected override void OnStart()
	{
		this.FilterEntrance = new FilterEntrance<T>(base.GetItem(0), this.UpdateList);
		this.SortEntrance = new SortEntrance<T>(base.GetItem(1), this.UpdateList);
	}

	// Token: 0x0600B6E6 RID: 46822 RVA: 0x0030A004 File Offset: 0x00308204
	public void UpdateData(EFilterSortGroupId groupId, List<T> dataList, params object[] parameters)
	{
		this.FilterEntrance.UpdateData(groupId, dataList, parameters);
		int uniqueIdByGroupId = this.FilterEntrance.GetUniqueIdByGroupId(groupId);
		this.SortEntrance.SetFilterUniqueId(uniqueIdByGroupId);
		this.SortEntrance.UpdateData(groupId, dataList, parameters);
		int uniqueIdByGroupId2 = this.SortEntrance.GetUniqueIdByGroupId(groupId);
		this.FilterEntrance.SetSortUniqueId(uniqueIdByGroupId2);
	}

	// Token: 0x0600B6E7 RID: 46823 RVA: 0x0030A060 File Offset: 0x00308260
	public void UpdateDataWithConfig(EFilterSortGroupId groupId, EFilterSortConfigId saveConfigId, List<T> dataList)
	{
		this.FilterEntrance.UpdateDataWithConfig(groupId, saveConfigId, dataList, "", Array.Empty<object>());
		int uniqueIdByGroupId = this.FilterEntrance.GetUniqueIdByGroupId(groupId);
		this.SortEntrance.SetFilterUniqueId(uniqueIdByGroupId);
		this.SortEntrance.UpdateDataWithConfig(groupId, saveConfigId, dataList, "", Array.Empty<object>());
		int uniqueIdByGroupId2 = this.SortEntrance.GetUniqueIdByGroupId(groupId);
		this.FilterEntrance.SetSortUniqueId(uniqueIdByGroupId2);
	}

	// Token: 0x0600B6E8 RID: 46824 RVA: 0x0030A0D0 File Offset: 0x003082D0
	public void ClearData(EFilterSortGroupId groupId)
	{
		int uniqueIdByGroupId = this.FilterEntrance.GetUniqueIdByGroupId(groupId);
		ModelBase<FilterModel>.Instance.ClearData(uniqueIdByGroupId);
		this.SortEntrance.DeleteUniqueIdByGroupId(groupId);
	}

	// Token: 0x0600B6E9 RID: 46825 RVA: 0x0030A101 File Offset: 0x00308301
	[NullableContext(2)]
	public UUIItem GetFilterToggleItem()
	{
		FilterEntrance<T> filterEntrance = this.FilterEntrance;
		if (filterEntrance == null)
		{
			return null;
		}
		return filterEntrance.GetFilterToggleItem();
	}

	// Token: 0x0600B6EA RID: 46826 RVA: 0x0030A114 File Offset: 0x00308314
	protected override void OnBeforeDestroy()
	{
		SortEntrance<T> sortEntrance = this.SortEntrance;
		if (sortEntrance != null)
		{
			sortEntrance.Destroy(null);
		}
		base.OnBeforeDestroy();
	}

	// Token: 0x04005685 RID: 22149
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterEntrance<T> FilterEntrance;

	// Token: 0x04005686 RID: 22150
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private SortEntrance<T> SortEntrance;

	// Token: 0x04005687 RID: 22151
	protected TUpdateDataListFunction<T> UpdateList;

	// Token: 0x02007C4F RID: 31823
	[NullableContext(0)]
	private enum ECompDefine
	{
		// Token: 0x0402A744 RID: 173892
		FilterItem,
		// Token: 0x0402A745 RID: 173893
		SortItem
	}
}
