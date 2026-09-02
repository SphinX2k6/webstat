using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001223 RID: 4643
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerRoleSelectPanel : UiPanelBase
{
	// Token: 0x06007B92 RID: 31634 RVA: 0x002062F0 File Offset: 0x002044F0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIMultiTemplateScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007B93 RID: 31635 RVA: 0x0020635C File Offset: 0x0020455C
	protected override void OnStart()
	{
		this.RoleMultiTemplateScrollView = new MultiTemplateScrollView(base.GetMultiTemplateScrollViewComponent(0));
		UUIItem item = base.GetItem(1);
		this.FilterSortEntrance = new FilterSortEntrance<RoleDataBase>(item, new TUpdateDataListFunction<RoleDataBase>(this.OnFilterSort));
	}

	// Token: 0x06007B94 RID: 31636 RVA: 0x0020639B File Offset: 0x0020459B
	protected override void OnBeforeDestroy()
	{
		FilterSortEntrance<RoleDataBase> filterSortEntrance = this.FilterSortEntrance;
		if (filterSortEntrance != null)
		{
			filterSortEntrance.Destroy(null);
		}
		this.FilterSortEntrance = null;
	}

	// Token: 0x06007B95 RID: 31637 RVA: 0x002063B6 File Offset: 0x002045B6
	public void Refresh(List<RoleDataBase> roleList)
	{
		this.RoleList = roleList;
		FilterSortEntrance<RoleDataBase> filterSortEntrance = this.FilterSortEntrance;
		if (filterSortEntrance != null)
		{
			filterSortEntrance.UpdateData(EFilterSortGroupId.ShipTower, this.RoleList, Array.Empty<object>());
		}
		this.RefreshScroll();
	}

	// Token: 0x06007B96 RID: 31638 RVA: 0x002063E3 File Offset: 0x002045E3
	public void RefreshWithSelectedState(List<RoleDataBase> roleList)
	{
		this.RoleList = roleList;
		FilterSortEntrance<RoleDataBase> filterSortEntrance = this.FilterSortEntrance;
		if (filterSortEntrance != null)
		{
			filterSortEntrance.UpdateData(EFilterSortGroupId.ShipTower, this.RoleList, Array.Empty<object>());
		}
		this.RefreshScroll();
	}

	// Token: 0x06007B97 RID: 31639 RVA: 0x00206410 File Offset: 0x00204610
	private void OnFilterSort(List<RoleDataBase> dataList, bool isOutSideChange, EFilterSortType operationType)
	{
		this.RoleList = dataList;
		if (operationType == EFilterSortType.Filter)
		{
			HashSet<int> hashSet = new HashSet<int>(from r in dataList
			select r.GetDataId());
			foreach (int item in this.SelectedConfigIds.ToList<int>())
			{
				if (!hashSet.Contains(item))
				{
					this.SelectedConfigIds.Remove(item);
				}
			}
		}
		this.RefreshScroll();
	}

	// Token: 0x06007B98 RID: 31640 RVA: 0x002064B4 File Offset: 0x002046B4
	private void RefreshScroll()
	{
		this.DataList = this.BuildDataList();
		MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.DataList);
		multiTemplateScrollViewRefreshContext.ScrollToGridIndex = 0;
		multiTemplateScrollViewRefreshContext.PlayGridAnim = true;
		MultiTemplateScrollView roleMultiTemplateScrollView = this.RoleMultiTemplateScrollView;
		if (roleMultiTemplateScrollView == null)
		{
			return;
		}
		roleMultiTemplateScrollView.RefreshByData(multiTemplateScrollViewRefreshContext);
	}

	// Token: 0x06007B99 RID: 31641 RVA: 0x002064F8 File Offset: 0x002046F8
	public List<RoleDataBase> GetTrialRoleList()
	{
		return (from r in this.RoleList
		where r.IsTrialRole()
		select r).ToList<RoleDataBase>();
	}

	// Token: 0x06007B9A RID: 31642 RVA: 0x0020652C File Offset: 0x0020472C
	[NullableContext(2)]
	public RoleDataBase FindRoleDataById(int configId)
	{
		return this.RoleList.Find((RoleDataBase r) => r.GetDataId() == configId);
	}

	// Token: 0x06007B9B RID: 31643 RVA: 0x00206560 File Offset: 0x00204760
	private List<IMultiTemplateGridData> BuildDataList()
	{
		List<IMultiTemplateGridData> list = new List<IMultiTemplateGridData>();
		List<RoleDataBase> list2 = (from r in this.RoleList
		where r.IsTrialRole()
		select r).ToList<RoleDataBase>();
		List<RoleDataBase> list3 = (from r in this.RoleList
		where !r.IsTrialRole()
		select r).ToList<RoleDataBase>();
		if (list2.Count > 0)
		{
			list.Add(new RoleGroupTitleData
			{
				Data = new RoleGroupTitleData_Data
				{
					TitleTextId = "Morale_32_Role_TempRole_Title",
					TitleParam = list2.Count.ToString(),
					IsEmpty = false
				}
			});
			foreach (RoleDataBase roleData in list2)
			{
				list.Add(new RoleListData
				{
					Data = new BabelTowerRoleListItemData
					{
						RoleData = roleData,
						OwnerPanel = this
					}
				});
			}
		}
		if (list3.Count > 0)
		{
			list.Add(new RoleGroupTitleData
			{
				Data = new RoleGroupTitleData_Data
				{
					TitleTextId = "Morale_32_Role_MyRole_Title",
					TitleParam = list3.Count.ToString(),
					IsEmpty = false
				}
			});
			foreach (RoleDataBase roleData2 in list3)
			{
				list.Add(new RoleListData
				{
					Data = new BabelTowerRoleListItemData
					{
						RoleData = roleData2,
						OwnerPanel = this
					}
				});
			}
		}
		return list;
	}

	// Token: 0x06007B9C RID: 31644 RVA: 0x00206738 File Offset: 0x00204938
	public void RefreshRole(int roleId)
	{
		if (this.RoleList.FindIndex((RoleDataBase r) => r.GetDataId() == roleId) < 0)
		{
			return;
		}
		this.RefreshRoleGridProxy(roleId);
	}

	// Token: 0x06007B9D RID: 31645 RVA: 0x0020677C File Offset: 0x0020497C
	public int GetGridIndexByRoleId(int roleId)
	{
		for (int i = 0; i < this.DataList.Count; i++)
		{
			IMultiTemplateGridData multiTemplateGridData = this.DataList[i];
			if (multiTemplateGridData.GetTemplateIndex() == 1)
			{
				BabelTowerRoleListItemData data = ((RoleListData)multiTemplateGridData).Data;
				bool flag;
				if (data == null)
				{
					flag = false;
				}
				else
				{
					RoleDataBase roleData = data.RoleData;
					int? num = (roleData != null) ? new int?(roleData.GetDataId()) : null;
					flag = (num.GetValueOrDefault() == roleId & num != null);
				}
				if (flag)
				{
					return i;
				}
			}
		}
		return -1;
	}

	// Token: 0x06007B9E RID: 31646 RVA: 0x00206800 File Offset: 0x00204A00
	public void RefreshRoleGridProxy(int roleId)
	{
		int gridIndexByRoleId = this.GetGridIndexByRoleId(roleId);
		if (gridIndexByRoleId < 0)
		{
			return;
		}
		MultiTemplateScrollView roleMultiTemplateScrollView = this.RoleMultiTemplateScrollView;
		if (roleMultiTemplateScrollView == null)
		{
			return;
		}
		roleMultiTemplateScrollView.RefreshProxyByData(gridIndexByRoleId, this.DataList[gridIndexByRoleId]);
	}

	// Token: 0x06007B9F RID: 31647 RVA: 0x00206838 File Offset: 0x00204A38
	public void RefreshSelectedRoleGridProxies()
	{
		HashSet<int> selectedRoleSet = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet;
		for (int i = 0; i < this.DataList.Count; i++)
		{
			IMultiTemplateGridData multiTemplateGridData = this.DataList[i];
			if (multiTemplateGridData.GetTemplateIndex() == 1)
			{
				RoleListData roleListData = (RoleListData)multiTemplateGridData;
				BabelTowerRoleListItemData data = roleListData.Data;
				if (((data != null) ? data.RoleData : null) != null && selectedRoleSet.Contains(roleListData.Data.RoleData.GetDataId()))
				{
					MultiTemplateScrollView roleMultiTemplateScrollView = this.RoleMultiTemplateScrollView;
					if (roleMultiTemplateScrollView != null)
					{
						roleMultiTemplateScrollView.RefreshProxyByData(i, multiTemplateGridData);
					}
				}
			}
		}
	}

	// Token: 0x04003B25 RID: 15141
	private const int MAX_SELECT_ROLE_COUNT = 3;

	// Token: 0x04003B26 RID: 15142
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<RoleDataBase, bool> OnRoleSelect;

	// Token: 0x04003B27 RID: 15143
	[Nullable(2)]
	public Action OnMaxSelectReached;

	// Token: 0x04003B28 RID: 15144
	[Nullable(2)]
	private MultiTemplateScrollView RoleMultiTemplateScrollView;

	// Token: 0x04003B29 RID: 15145
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<RoleDataBase> FilterSortEntrance;

	// Token: 0x04003B2A RID: 15146
	private List<RoleDataBase> RoleList = new List<RoleDataBase>();

	// Token: 0x04003B2B RID: 15147
	private List<IMultiTemplateGridData> DataList = new List<IMultiTemplateGridData>();

	// Token: 0x04003B2C RID: 15148
	public readonly HashSet<int> SelectedConfigIds = new HashSet<int>();

	// Token: 0x0200758B RID: 30091
	[NullableContext(0)]
	private class EComp
	{
		// Token: 0x040288E4 RID: 166116
		public const int RoleScrollView = 0;

		// Token: 0x040288E5 RID: 166117
		public const int SortFilter = 1;
	}
}
