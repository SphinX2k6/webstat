using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029E2 RID: 10722
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerTeamPanel : UiPanelBase
{
	// Token: 0x060155DD RID: 87517 RVA: 0x005EBB58 File Offset: 0x005E9D58
	public UniTask Init(UUIItem item, ShipTowerStageData data)
	{
		ShipTowerTeamPanel.<Init>d__15 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.data = data;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ShipTowerTeamPanel.<Init>d__15>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060155DE RID: 87518 RVA: 0x005EBBAC File Offset: 0x005E9DAC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnTeamEditClick))
		};
	}

	// Token: 0x060155DF RID: 87519 RVA: 0x005EBC58 File Offset: 0x005E9E58
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerTeamPanel.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerTeamPanel.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060155E0 RID: 87520 RVA: 0x005EBC9C File Offset: 0x005E9E9C
	private void TeamTabFinish()
	{
		foreach (KeyValuePair<int, ShipTowerTeamTabItem> keyValuePair in this.TabComponent.GetTabItemMap())
		{
			int key = keyValuePair.Key;
			keyValuePair.Value.UpdateName(this.TeamTabList[key].Title);
		}
		this.TabComponent.SelectToggleByIndex(0, true, true);
	}

	// Token: 0x060155E1 RID: 87521 RVA: 0x005EBD20 File Offset: 0x005E9F20
	protected override void OnBeforeShow()
	{
		this.ToggleTwoTabCallBack(this.CurSelectTabIndex);
	}

	// Token: 0x060155E2 RID: 87522 RVA: 0x005EBD2E File Offset: 0x005E9F2E
	protected override void OnAfterShow()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.ShipTowerTeamPanelShown);
	}

	// Token: 0x060155E3 RID: 87523 RVA: 0x005EBD40 File Offset: 0x005E9F40
	public void UpdateViewAndShow(ShipTowerTeamData teamData)
	{
		this.CurTeamData = teamData;
		if (base.GetActive())
		{
			this.ToggleTwoTabCallBack(this.CurSelectTabIndex);
			return;
		}
		this.SetActive(true);
	}

	// Token: 0x060155E4 RID: 87524 RVA: 0x005EBD65 File Offset: 0x005E9F65
	protected override void OnBeforeDestroy()
	{
		this.TabComponent = null;
		this.FilterComponent = null;
	}

	// Token: 0x060155E5 RID: 87525 RVA: 0x005EBD75 File Offset: 0x005E9F75
	private ShipTowerTeamTabItem TabItemProxyCreate([Nullable(2)] UUIItem item, int? index)
	{
		return new ShipTowerTeamTabItem();
	}

	// Token: 0x060155E6 RID: 87526 RVA: 0x005EBD7C File Offset: 0x005E9F7C
	private void ToggleTwoTabCallBack(int index)
	{
		if (base.IsStartOrStarting)
		{
			return;
		}
		this.CurSelectTabIndex = index;
		Singleton<Log>.Instance.Info(ELogModule.ShipTower, ELogAuthor.CX, "二级页签点击回调: " + this.CurSelectTabIndex.ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
		int curSelectTabIndex = this.CurSelectTabIndex;
		if (curSelectTabIndex == 0)
		{
			this.UpdateRoleList();
			return;
		}
		if (curSelectTabIndex != 1)
		{
			return;
		}
		this.UpdateTeamList();
	}

	// Token: 0x060155E7 RID: 87527 RVA: 0x005EBDE4 File Offset: 0x005E9FE4
	public void UpdateRoleListByMainRoleChange()
	{
		RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
		List<RoleDataBase> list = new List<RoleDataBase>();
		foreach (RoleInstance item in roleList)
		{
			list.Add(item);
		}
		FilterSortEntrance<RoleDataBase> filterComponent = this.FilterComponent;
		if (filterComponent != null)
		{
			filterComponent.UpdateData(EFilterSortGroupId.ShipTower, list, Array.Empty<object>());
		}
		if (this.TeamList != null)
		{
			this.TeamList = ModelBase<ShipTowerModel>.Instance.GetPlayerTeamList();
		}
	}

	// Token: 0x060155E8 RID: 87528 RVA: 0x005EBE4C File Offset: 0x005EA04C
	private void UpdateRoleList()
	{
		base.GetScrollViewWithScrollbar(2).RootUIComp.Get().SetUIActive(true);
		base.GetScrollViewWithScrollbar(1).RootUIComp.Get().SetUIActive(false);
		FilterSortEntrance<RoleDataBase> filterComponent = this.FilterComponent;
		if (filterComponent != null)
		{
			filterComponent.SetActive(true);
		}
		base.GetButton(4).RootUIComp.Get().SetUIActive(false);
		this.UpdateRoleListFilter();
	}

	// Token: 0x060155E9 RID: 87529 RVA: 0x005EBEC0 File Offset: 0x005EA0C0
	public void UpdateRoleListFilter()
	{
		int filterId = ConfigBase<FilterConfig>.Instance.GetFilterId(EFilterSortGroupId.ShipTower);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFilterDataUpdate, filterId);
	}

	// Token: 0x060155EA RID: 87530 RVA: 0x005EBEEC File Offset: 0x005EA0EC
	private void UpdateTeamList()
	{
		base.GetScrollViewWithScrollbar(2).RootUIComp.Get().SetUIActive(false);
		base.GetScrollViewWithScrollbar(1).RootUIComp.Get().SetUIActive(true);
		FilterSortEntrance<RoleDataBase> filterComponent = this.FilterComponent;
		if (filterComponent != null)
		{
			filterComponent.SetActive(false);
		}
		base.GetButton(4).RootUIComp.Get().SetUIActive(true);
		this.TeamList = ModelBase<ShipTowerModel>.Instance.GetPlayerTeamList();
		GenericScrollViewNew<ShipTowerRoleTeamItem, EditFormationData> teamScrollView = this.TeamScrollView;
		if (teamScrollView != null)
		{
			teamScrollView.SelectGridProxy(-1, false);
		}
		this.OnlyUpdateTeamList();
	}

	// Token: 0x060155EB RID: 87531 RVA: 0x005EBF82 File Offset: 0x005EA182
	public void OnlyUpdateTeamList()
	{
		GenericScrollViewNew<ShipTowerRoleTeamItem, EditFormationData> teamScrollView = this.TeamScrollView;
		if (teamScrollView != null)
		{
			teamScrollView.RefreshByData(this.TeamList, null, false);
		}
		UUIItem emptyStateItem = this.EmptyStateItem;
		if (emptyStateItem == null)
		{
			return;
		}
		emptyStateItem.SetUIActive(false);
	}

	// Token: 0x060155EC RID: 87532 RVA: 0x005EBFAE File Offset: 0x005EA1AE
	public void UpdateTeamListByIndex(int index)
	{
		GenericScrollViewNew<ShipTowerRoleTeamItem, EditFormationData> teamScrollView = this.TeamScrollView;
		if (teamScrollView == null)
		{
			return;
		}
		ShipTowerRoleTeamItem scrollItemByIndex = teamScrollView.GetScrollItemByIndex(index);
		if (scrollItemByIndex == null)
		{
			return;
		}
		scrollItemByIndex.Refresh(this.TeamList[index], false, index);
	}

	// Token: 0x060155ED RID: 87533 RVA: 0x005EBFDC File Offset: 0x005EA1DC
	private void OnFilterSort(List<RoleDataBase> dataList, bool isOutSideChange, EFilterSortType operationType)
	{
		this.RoleList = dataList;
		GenericScrollViewNew<ShipTowerRoleGrid, RoleDataBase> roleScrollView = this.RoleScrollView;
		if (roleScrollView != null)
		{
			roleScrollView.RefreshByData(this.RoleList, null, false);
		}
		UUIItem emptyStateItem = this.EmptyStateItem;
		if (emptyStateItem != null)
		{
			emptyStateItem.SetUIActive(this.RoleList.Count <= 0);
		}
		Action roleListUpdateCallback = this.RoleListUpdateCallback;
		if (roleListUpdateCallback == null)
		{
			return;
		}
		roleListUpdateCallback();
	}

	// Token: 0x060155EE RID: 87534 RVA: 0x005EC03B File Offset: 0x005EA23B
	private ShipTowerRoleGrid OnGridProxyCreate()
	{
		ShipTowerRoleGrid shipTowerRoleGrid = new ShipTowerRoleGrid();
		shipTowerRoleGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.ToggleFunction));
		shipTowerRoleGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeFunction));
		return shipTowerRoleGrid;
	}

	// Token: 0x060155EF RID: 87535 RVA: 0x005EC066 File Offset: 0x005EA266
	private ShipTowerRoleTeamItem OnTeamGridProxyCreate()
	{
		return new ShipTowerRoleTeamItem
		{
			OnClickCallback = this.TeamSelectCallBack,
			StageData = this.StageData
		};
	}

	// Token: 0x060155F0 RID: 87536 RVA: 0x005EC088 File Offset: 0x005EA288
	protected void ToggleFunction(MediumItemGridExtendCallback params_)
	{
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		HashSet<int> selectedRoleSet = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet;
		RoleDataBase roleDataBase = (RoleDataBase)params_.Data;
		bool flag = params_.State == EToggleState.ETT_Checked;
		if (flag)
		{
			for (int i = 1; i <= 3; i++)
			{
				int roleIndexInAllTeam = this.CurTeamData.GetRoleIndexInAllTeam(i);
				if (!roleIndexMap.ContainsKey(roleIndexInAllTeam))
				{
					roleIndexMap[roleIndexInAllTeam] = roleDataBase;
					selectedRoleSet.Add(roleDataBase.GetDataId());
					break;
				}
			}
		}
		else
		{
			int? num = null;
			foreach (KeyValuePair<int, RoleDataBase> keyValuePair in roleIndexMap)
			{
				if (keyValuePair.Value == roleDataBase)
				{
					num = new int?(keyValuePair.Key);
					break;
				}
			}
			if (num != null)
			{
				roleIndexMap.Remove(num.Value);
				selectedRoleSet.Remove(roleDataBase.GetDataId());
			}
		}
		int num2 = this.RoleList.IndexOf(roleDataBase);
		Action<RoleDataBase> roleSelectCallBack = this.RoleSelectCallBack;
		if (roleSelectCallBack != null)
		{
			roleSelectCallBack(roleDataBase);
		}
		ShipTowerRoleGrid scrollItemByIndex = this.RoleScrollView.GetScrollItemByIndex(num2);
		if (scrollItemByIndex == null)
		{
			return;
		}
		scrollItemByIndex.Refresh(roleDataBase, flag, num2);
	}

	// Token: 0x060155F1 RID: 87537 RVA: 0x005EC1C4 File Offset: 0x005EA3C4
	protected bool CanExecuteChangeFunction(object data, bool isForceSelected, EToggleState state)
	{
		RoleDataBase roleDataBase = (RoleDataBase)data;
		if (ModelBase<ShipTowerModel>.Instance.IsOtherTeamRoleData(roleDataBase.GetDataId()))
		{
			return true;
		}
		if (state != EToggleState.ETT_UnChecked)
		{
			return true;
		}
		if (this.RoleIsFull())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamRoleFull", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x060155F2 RID: 87538 RVA: 0x005EC210 File Offset: 0x005EA410
	private bool RoleIsFull()
	{
		for (int i = 1; i <= 3; i++)
		{
			int roleIndexInAllTeam = this.CurTeamData.GetRoleIndexInAllTeam(i);
			if (!ModelBase<RoleSelectModel>.Instance.RoleIndexMap.ContainsKey(roleIndexInAllTeam))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060155F3 RID: 87539 RVA: 0x005EC24C File Offset: 0x005EA44C
	public List<int> GetRoleIdList()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < this.RoleList.Count; i++)
		{
			list.Add(this.RoleList[i].GetDataId());
		}
		return list;
	}

	// Token: 0x060155F4 RID: 87540 RVA: 0x005EC290 File Offset: 0x005EA490
	private void OnTeamEditClick()
	{
		bool flag = false;
		ControllerBase<EditFormationController>.Instance.OpenEditFormationView(flag);
	}

	// Token: 0x060155F5 RID: 87541 RVA: 0x005EC2B0 File Offset: 0x005EA4B0
	public void RefreshRole(int roleId)
	{
		int num = this.RoleList.FindIndex((RoleDataBase roleData) => roleData.GetDataId() == roleId);
		if (num < 0)
		{
			return;
		}
		ShipTowerRoleGrid scrollItemByIndex = this.RoleScrollView.GetScrollItemByIndex(num);
		if (scrollItemByIndex == null)
		{
			return;
		}
		scrollItemByIndex.Refresh(this.RoleList[num], false, num);
	}

	// Token: 0x060155F6 RID: 87542 RVA: 0x005EC30C File Offset: 0x005EA50C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		TabComponent<ShipTowerTeamTabItem> tabComponent = this.TabComponent;
		ShipTowerTeamTabItem shipTowerTeamTabItem = (tabComponent != null) ? tabComponent.GetTabItemByIndex(1) : null;
		UUIItem uuiitem = (shipTowerTeamTabItem != null) ? shipTowerTeamTabItem.GetRootItem() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x0400A485 RID: 42117
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<ShipTowerTeamTabItem> TabComponent;

	// Token: 0x0400A486 RID: 42118
	private int CurSelectTabIndex;

	// Token: 0x0400A487 RID: 42119
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<RoleDataBase> FilterComponent;

	// Token: 0x0400A488 RID: 42120
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ShipTowerRoleGrid, RoleDataBase> RoleScrollView;

	// Token: 0x0400A489 RID: 42121
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ShipTowerRoleTeamItem, EditFormationData> TeamScrollView;

	// Token: 0x0400A48A RID: 42122
	private List<RoleDataBase> RoleList = new List<RoleDataBase>();

	// Token: 0x0400A48B RID: 42123
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<EditFormationData> TeamList;

	// Token: 0x0400A48C RID: 42124
	private ShipTowerStageData StageData;

	// Token: 0x0400A48D RID: 42125
	private List<ShipTowerTeamTab> TeamTabList;

	// Token: 0x0400A48E RID: 42126
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<RoleDataBase> RoleSelectCallBack;

	// Token: 0x0400A48F RID: 42127
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<EditFormationData> TeamSelectCallBack;

	// Token: 0x0400A490 RID: 42128
	[Nullable(2)]
	private ShipTowerTeamData CurTeamData;

	// Token: 0x0400A491 RID: 42129
	[Nullable(2)]
	public UUIItem EmptyStateItem;

	// Token: 0x0400A492 RID: 42130
	[Nullable(2)]
	public Action RoleListUpdateCallback;

	// Token: 0x02008D50 RID: 36176
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F855 RID: 194645
		public const int ItemTabComponent = 0;

		// Token: 0x0402F856 RID: 194646
		public const int ScrollBarTeam = 1;

		// Token: 0x0402F857 RID: 194647
		public const int ScrollBarRole = 2;

		// Token: 0x0402F858 RID: 194648
		public const int ItemFilter = 3;

		// Token: 0x0402F859 RID: 194649
		public const int TeamEditButton = 4;
	}
}
