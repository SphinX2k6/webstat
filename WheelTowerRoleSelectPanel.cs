using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020016A2 RID: 5794
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerRoleSelectPanel : UiPanelBase
{
	// Token: 0x0600A15C RID: 41308 RVA: 0x002A6688 File Offset: 0x002A4888
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

	// Token: 0x0600A15D RID: 41309 RVA: 0x002A66F4 File Offset: 0x002A48F4
	protected override void OnStart()
	{
		this.RoleScroll = new GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch>(base.GetScrollViewWithScrollbar(0), new Func<WheelTowerRoleGridItem>(this.CreateWheelTowerRoleGridItem), null, false, null);
		this.FilterSortEntrance = new FilterSortEntrance<RoleDataBase>(base.GetItem(1), new TUpdateDataListFunction<RoleDataBase>(this.UpdateRoleList));
	}

	// Token: 0x0600A15E RID: 41310 RVA: 0x002A6740 File Offset: 0x002A4940
	protected override void OnBeforeDestroy()
	{
		FilterSortEntrance<RoleDataBase> filterSortEntrance = this.FilterSortEntrance;
		if (filterSortEntrance != null)
		{
			filterSortEntrance.Destroy(null);
		}
		this.FilterSortEntrance = null;
	}

	// Token: 0x0600A15F RID: 41311 RVA: 0x002A675C File Offset: 0x002A495C
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

	// Token: 0x0600A160 RID: 41312 RVA: 0x002A67B4 File Offset: 0x002A49B4
	public int GetFirstRoleId()
	{
		return this.FirstRoleId;
	}

	// Token: 0x0600A161 RID: 41313 RVA: 0x002A67BC File Offset: 0x002A49BC
	public void OnlyRefreshScroll()
	{
		GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch> roleScroll = this.RoleScroll;
		if (roleScroll == null)
		{
			return;
		}
		GenericLayout<WheelTowerRoleGridItem, RoleDataWithBranch> genericLayout = roleScroll.GetGenericLayout();
		if (genericLayout == null)
		{
			return;
		}
		genericLayout.RefreshWithoutDataSync();
	}

	// Token: 0x0600A162 RID: 41314 RVA: 0x002A67D8 File Offset: 0x002A49D8
	public void RefreshRoleSkillBranch(int roleId)
	{
		GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch> roleScroll = this.RoleScroll;
		IReadOnlyList<RoleDataWithBranch> readOnlyList;
		if (roleScroll == null)
		{
			readOnlyList = null;
		}
		else
		{
			GenericLayout<WheelTowerRoleGridItem, RoleDataWithBranch> genericLayout = roleScroll.GetGenericLayout();
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
		int roleSkillBranchIdInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInCurrentGamePlay(roleDataWithBranch.RoleId);
		roleDataWithBranch.SkillBranchId = roleSkillBranchIdInCurrentGamePlay;
		roleDataWithBranch.SkillBranchIndex = ((roleDataWithBranch.RoleId > 0 && roleSkillBranchIdInCurrentGamePlay > 0) ? ModelBase<RoleModel>.Instance.GetRoleBranchIndexById(roleDataWithBranch.RoleId, roleSkillBranchIdInCurrentGamePlay) : -1);
		GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch> roleScroll2 = this.RoleScroll;
		if (roleScroll2 == null)
		{
			return;
		}
		WheelTowerRoleGridItem scrollItemByIndex = roleScroll2.GetScrollItemByIndex(num);
		if (scrollItemByIndex == null)
		{
			return;
		}
		scrollItemByIndex.Refresh(roleDataWithBranch, false, num);
	}

	// Token: 0x0600A163 RID: 41315 RVA: 0x002A689E File Offset: 0x002A4A9E
	private WheelTowerRoleGridItem CreateWheelTowerRoleGridItem()
	{
		WheelTowerRoleGridItem wheelTowerRoleGridItem = new WheelTowerRoleGridItem();
		wheelTowerRoleGridItem.SetToggleClickCallback(new Action<int>(this.OnToggleClick));
		return wheelTowerRoleGridItem;
	}

	// Token: 0x0600A164 RID: 41316 RVA: 0x002A68B7 File Offset: 0x002A4AB7
	private void OnToggleClick(int roleId)
	{
		Action<int> onRoleSelect = this.OnRoleSelect;
		if (onRoleSelect != null)
		{
			onRoleSelect(roleId);
		}
		this.OnlyRefreshScroll();
	}

	// Token: 0x0600A165 RID: 41317 RVA: 0x002A68D4 File Offset: 0x002A4AD4
	private void UpdateRoleList(List<RoleDataBase> list, bool isShowText, EFilterSortType sortType)
	{
		List<int> list2 = new List<int>();
		Dictionary<int, int> tmpSelectedRoleMap = ModelBase<WheelTowerModel>.Instance.TmpSelectedRoleMap;
		for (int i = 0; i < ModelBase<WheelTowerModel>.Instance.GetTeamMaxRoleCount(); i++)
		{
			int num;
			if (tmpSelectedRoleMap.TryGetValue(i, out num) && num != 0)
			{
				list2.Add(num);
			}
		}
		List<int> list3 = new List<int>();
		foreach (RoleDataBase roleDataBase in list)
		{
			if (!list2.Contains(roleDataBase.GetRoleId()))
			{
				int roleEnergy = ModelBase<WheelTowerModel>.Instance.SelectedEnergyInfo.GetRoleEnergy(roleDataBase.GetRoleId());
				if (roleEnergy >= 0)
				{
					if (roleEnergy == 0)
					{
						list3.Add(roleDataBase.GetRoleId());
					}
					else
					{
						list2.Add(roleDataBase.GetRoleId());
					}
				}
			}
		}
		list2.AddRange(list3);
		bool flag = list2.Count > 0;
		GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch> roleScroll = this.RoleScroll;
		if (roleScroll != null)
		{
			if (roleScroll.ContentItem != null)
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
		GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch> roleScroll2 = this.RoleScroll;
		if (roleScroll2 == null)
		{
			return;
		}
		roleScroll2.RefreshByData(list4, null, false);
	}

	// Token: 0x04004B58 RID: 19288
	[Nullable(2)]
	public Action<int> OnRoleSelect;

	// Token: 0x04004B59 RID: 19289
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<WheelTowerRoleGridItem, RoleDataWithBranch> RoleScroll;

	// Token: 0x04004B5A RID: 19290
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<RoleDataBase> FilterSortEntrance;

	// Token: 0x04004B5B RID: 19291
	private int FirstRoleId;
}
