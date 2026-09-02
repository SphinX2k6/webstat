using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020016B1 RID: 5809
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerTemplateSelectPanel : UiPanelBase
{
	// Token: 0x0600A19C RID: 41372 RVA: 0x002A7958 File Offset: 0x002A5B58
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A19D RID: 41373 RVA: 0x002A79C4 File Offset: 0x002A5BC4
	protected override void OnStart()
	{
		this.ScrollView = new GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch>(base.GetScrollViewWithScrollbar(0), new Func<WheelTowerRoleGridItem>(this.CreateWheelTowerRoleGridItem), null, false, null);
		this.FilterSortEntrance = new FilterSortEntrance<RoleDataBase>(base.GetItem(1), new TUpdateDataListFunction<RoleDataBase>(this.UpdateRoleList));
	}

	// Token: 0x0600A19E RID: 41374 RVA: 0x002A7A10 File Offset: 0x002A5C10
	public void Refresh()
	{
		List<RoleDataBase> dataList = (from roleId in ModelBase<RoleModel>.Instance.GetRoleIdList()
		select ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true)).ToList<RoleDataBase>();
		FilterSortEntrance<RoleDataBase> filterSortEntrance = this.FilterSortEntrance;
		if (filterSortEntrance == null)
		{
			return;
		}
		filterSortEntrance.UpdateData(EFilterSortGroupId.EditFormation, dataList, Array.Empty<object>());
	}

	// Token: 0x0600A19F RID: 41375 RVA: 0x002A7A68 File Offset: 0x002A5C68
	public int GetFirstRoleId()
	{
		return this.FirstRoleId;
	}

	// Token: 0x0600A1A0 RID: 41376 RVA: 0x002A7A70 File Offset: 0x002A5C70
	public void OnlyRefreshScroll()
	{
		GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch> scrollView = this.ScrollView;
		if (scrollView == null)
		{
			return;
		}
		GenericLayout<WheelTowerRoleGridItem, RoleDataWithBranch> genericLayout = scrollView.GetGenericLayout();
		if (genericLayout == null)
		{
			return;
		}
		genericLayout.RefreshWithoutDataSync();
	}

	// Token: 0x0600A1A1 RID: 41377 RVA: 0x002A7A8C File Offset: 0x002A5C8C
	public void RefreshRoleSkillBranch(int roleId)
	{
		if (roleId <= 0)
		{
			return;
		}
		GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch> scrollView = this.ScrollView;
		IReadOnlyList<RoleDataWithBranch> readOnlyList;
		if (scrollView == null)
		{
			readOnlyList = null;
		}
		else
		{
			GenericLayout<WheelTowerRoleGridItem, RoleDataWithBranch> genericLayout = scrollView.GetGenericLayout();
			readOnlyList = ((genericLayout != null) ? genericLayout.GetDatas() : null);
		}
		IReadOnlyList<RoleDataWithBranch> readOnlyList2 = readOnlyList;
		if (readOnlyList2 == null)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < readOnlyList2.Count; i++)
		{
			if (readOnlyList2[i].RoleId == roleId)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return;
		}
		RoleDataWithBranch roleDataWithBranch = readOnlyList2[num];
		int roleSkillBranchIdInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInCurrentGamePlay(roleId);
		roleDataWithBranch.SkillBranchId = roleSkillBranchIdInCurrentGamePlay;
		roleDataWithBranch.SkillBranchIndex = ((roleDataWithBranch.RoleId > 0 && roleSkillBranchIdInCurrentGamePlay > 0) ? ModelBase<RoleModel>.Instance.GetRoleBranchIndexById(roleId, roleSkillBranchIdInCurrentGamePlay) : -1);
		GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch> scrollView2 = this.ScrollView;
		if (scrollView2 == null)
		{
			return;
		}
		WheelTowerRoleGridItem scrollItemByIndex = scrollView2.GetScrollItemByIndex(num);
		if (scrollItemByIndex == null)
		{
			return;
		}
		scrollItemByIndex.Refresh(roleDataWithBranch, false, num);
	}

	// Token: 0x0600A1A2 RID: 41378 RVA: 0x002A7B4D File Offset: 0x002A5D4D
	private WheelTowerRoleGridItem CreateWheelTowerRoleGridItem()
	{
		WheelTowerRoleGridItem wheelTowerRoleGridItem = new WheelTowerRoleGridItem();
		wheelTowerRoleGridItem.SetToggleClickCallback(new Action<int>(this.OnToggleClick));
		return wheelTowerRoleGridItem;
	}

	// Token: 0x0600A1A3 RID: 41379 RVA: 0x002A7B66 File Offset: 0x002A5D66
	private void OnToggleClick(int roleId)
	{
		Action<int> onTemplateSelect = this.OnTemplateSelect;
		if (onTemplateSelect != null)
		{
			onTemplateSelect(roleId);
		}
		this.OnlyRefreshScroll();
	}

	// Token: 0x0600A1A4 RID: 41380 RVA: 0x002A7B80 File Offset: 0x002A5D80
	private void UpdateRoleList(List<RoleDataBase> list, bool isShowText, EFilterSortType sortType)
	{
		List<int> list2 = new List<int>();
		Dictionary<int, int> tmpSelectedRoleMap = ModelBase<WheelTowerModel>.Instance.TmpSelectedRoleMap;
		for (int i = 0; i < ModelBase<WheelTowerModel>.Instance.GetTeamMaxRoleCount(); i++)
		{
			int item;
			if (tmpSelectedRoleMap.TryGetValue(i, out item))
			{
				list2.Add(item);
			}
		}
		List<int> list3 = new List<int>();
		foreach (RoleDataBase roleDataBase in list)
		{
			int templateRoleId = ModelBase<WheelTowerModel>.Instance.GetTemplateRoleId(roleDataBase.GetRoleId());
			if (templateRoleId != 0 && !list2.Contains(templateRoleId))
			{
				int roleEnergy = ModelBase<WheelTowerModel>.Instance.SelectedEnergyInfo.GetRoleEnergy(roleDataBase.GetRoleId());
				if (roleEnergy >= 0)
				{
					if (roleEnergy == 0)
					{
						list3.Add(templateRoleId);
					}
					else
					{
						list2.Add(templateRoleId);
					}
				}
			}
		}
		list2.AddRange(list3);
		bool flag = list2.Count > 0;
		GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch> scrollView = this.ScrollView;
		if (scrollView != null)
		{
			if (scrollView.ContentItem != null)
			{
				TWeakObjectPtr<UUIItem>? tweakObjectPtr;
				UUIItem uuiitem = tweakObjectPtr.GetValueOrDefault().Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(flag);
				}
			}
		}
		if (!flag)
		{
			return;
		}
		List<RoleDataWithBranch> list4 = new List<RoleDataWithBranch>();
		foreach (int roleId in list2)
		{
			list4.Add(new RoleDataWithBranch(roleId, ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInCurrentGamePlay(roleId)));
		}
		this.FirstRoleId = list4[0].RoleId;
		GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch> scrollView2 = this.ScrollView;
		if (scrollView2 == null)
		{
			return;
		}
		scrollView2.RefreshByData(list4, null, false);
	}

	// Token: 0x04004B8E RID: 19342
	[Nullable(2)]
	public Action<int> OnTemplateSelect;

	// Token: 0x04004B8F RID: 19343
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch> ScrollView;

	// Token: 0x04004B90 RID: 19344
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<RoleDataBase> FilterSortEntrance;

	// Token: 0x04004B91 RID: 19345
	private int FirstRoleId;
}
