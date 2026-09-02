using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x02002782 RID: 10114
[NullableContext(1)]
[Nullable(0)]
public class RogueBattleTeamRoleSelectView : UiViewBase
{
	// Token: 0x06013F1A RID: 81690 RVA: 0x0058F232 File Offset: 0x0058D432
	public RogueBattleTeamRoleSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013F1B RID: 81691 RVA: 0x0058F26C File Offset: 0x0058D46C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
	}

	// Token: 0x06013F1C RID: 81692 RVA: 0x0058F378 File Offset: 0x0058D578
	protected override UniTask OnBeforeStartAsync()
	{
		RogueBattleTeamRoleSelectView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleTeamRoleSelectView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013F1D RID: 81693 RVA: 0x0058F3BC File Offset: 0x0058D5BC
	protected override void OnStart()
	{
		RogueResFormation formationDataByIndex = ModelBase<RogueBattleModel>.Instance.GetFormationDataByIndex(this.FormationIndex);
		this.RoleList = ModelBase<RogueBattleModel>.Instance.GetRoleList();
		this.RoleList.Sort((RoleDataBase a, RoleDataBase b) => b.GetRoleConfig().Priority - a.GetRoleConfig().Priority);
		RepeatedField<int> roleId = formationDataByIndex.RoleId;
		ModelBase<RoleSelectModel>.Instance.ClearData();
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		int num = 1;
		while (num <= 3 && num <= roleId.Count)
		{
			int num2 = roleId[num - 1];
			foreach (RoleDataBase roleDataBase in this.RoleList)
			{
				if (roleDataBase.GetDataId() == num2)
				{
					roleIndexMap[num] = roleDataBase;
					break;
				}
			}
			num++;
		}
		this.InitDropDown();
		ModelBase<RogueBattleModel>.Instance.SetRogueResNewRoleFlag(false);
	}

	// Token: 0x06013F1E RID: 81694 RVA: 0x0058F4B4 File Offset: 0x0058D6B4
	private void OnBtnClose()
	{
		if (this.WaitClose)
		{
			return;
		}
		this.WaitClose = true;
		base.CloseMe(null);
	}

	// Token: 0x06013F1F RID: 81695 RVA: 0x0058F4D0 File Offset: 0x0058D6D0
	private void OnClickConfirm(int _)
	{
		if (this.WaitClose)
		{
			return;
		}
		List<int> currentSelectRoleList = this.GetCurrentSelectRoleList();
		if (currentSelectRoleList.Count == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RogueBattle_TeamEmpty_QuickSelect", Array.Empty<object>());
			return;
		}
		this.WaitClose = true;
		if (this.OnConfirm != null)
		{
			this.OnConfirm(currentSelectRoleList).Forget();
			base.CloseMe(null);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x06013F20 RID: 81696 RVA: 0x0058F53C File Offset: 0x0058D73C
	private unsafe void OnClickRoleDetail(int _)
	{
		if (this.WaitClose)
		{
			return;
		}
		if (this.CurSelectRole == null)
		{
			return;
		}
		bool flag = this.CurSelectRole.IsTrialRole();
		int num = this.CurSelectRole.GetDataId();
		if (!flag)
		{
			RogueResBondRole? rogueResBondRole = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBondRole(num);
			if (rogueResBondRole != null)
			{
				num = rogueResBondRole.Value.TrialRoleId;
			}
		}
		RoleController instance = ControllerBase<RoleController>.Instance;
		ERoleAgentType agentType = ERoleAgentType.Preview;
		int selectRoleId = 0;
		int num2 = 1;
		List<int> list = new List<int>(num2);
		CollectionsMarshal.SetCount<int>(list, num2);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int index = 0;
		*span[index] = num;
		instance.OpenRoleMainView(agentType, selectRoleId, list, new EUiTabViewName?(EUiTabViewName.RoleSkillTabView), null);
	}

	// Token: 0x06013F21 RID: 81697 RVA: 0x0058F5D5 File Offset: 0x0058D7D5
	private RogueBattleFilterDropDownItem CreateDropDownItem(UUIItem uiItem, RoleBondInfo data)
	{
		return new RogueBattleFilterDropDownItem(uiItem);
	}

	// Token: 0x06013F22 RID: 81698 RVA: 0x0058F5DD File Offset: 0x0058D7DD
	private RogueBattleFilterDropDownTitle CreateTitleItem(UUIItem uiItem)
	{
		return new RogueBattleFilterDropDownTitle(uiItem);
	}

	// Token: 0x06013F23 RID: 81699 RVA: 0x0058F5E8 File Offset: 0x0058D7E8
	private void InitDropDown()
	{
		this.CurrentBondInfoList.Clear();
		this.CurrentBondInfoList.AddRange(ModelBase<RogueBattleModel>.Instance.GetAllOwnedRoleBondData());
		List<RoleBondInfo> currentBondInfoList = this.CurrentBondInfoList;
		Comparison<RoleBondInfo> comparison;
		if ((comparison = RogueBattleTeamRoleSelectView.<>O.<0>__SortRogueBattleRoleBondInfo) == null)
		{
			comparison = (RogueBattleTeamRoleSelectView.<>O.<0>__SortRogueBattleRoleBondInfo = new Comparison<RoleBondInfo>(RogueBattleDefine.SortRogueBattleRoleBondInfo));
		}
		currentBondInfoList.Sort(comparison);
		RoleBondInfo item = new RoleBondInfo
		{
			ConfigId = 0,
			CurStar = 0,
			TargetStar = 0,
			Level = 0
		};
		this.CurrentBondInfoList.Insert(0, item);
		this.CurrentSelectBondIndex = 0;
		this.CommonDropDown.SetOnSelectCall(new Action<int, RoleBondInfo>(this.OnDropDownSelectCall));
		this.CommonDropDown.SetShowType(ECommonDropDownShowType.Down);
		this.CommonDropDown.InitScroll(this.CurrentBondInfoList, new Func<RoleBondInfo, RoleBondInfo>(this.GetDropDownTextId), this.CurrentSelectBondIndex, true);
		this.CommonDropDown.SetSelectedIndex(this.CurrentSelectBondIndex, true);
	}

	// Token: 0x06013F24 RID: 81700 RVA: 0x0058F6CA File Offset: 0x0058D8CA
	private void OnDropDownSelectCall(int index, object _)
	{
		this.CurrentSelectBondIndex = index;
		this.RefreshRoleList();
	}

	// Token: 0x06013F25 RID: 81701 RVA: 0x0058F6D9 File Offset: 0x0058D8D9
	private RoleBondInfo GetDropDownTextId(object data)
	{
		return (RoleBondInfo)data;
	}

	// Token: 0x06013F26 RID: 81702 RVA: 0x0058F6E4 File Offset: 0x0058D8E4
	private List<int> GetCurrentSelectRoleList()
	{
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		List<int> list = new List<int>();
		for (int i = 1; i <= 3; i++)
		{
			RoleDataBase roleDataBase;
			if (roleIndexMap.TryGetValue(i, out roleDataBase))
			{
				list.Add(roleDataBase.GetDataId());
			}
		}
		return list;
	}

	// Token: 0x06013F27 RID: 81703 RVA: 0x0058F728 File Offset: 0x0058D928
	private List<IRogueBattleTeamRoleGridInfo> GetRoleListInfo()
	{
		List<IRogueBattleTeamRoleGridInfo> list = new List<IRogueBattleTeamRoleGridInfo>();
		List<int> recommendBondLinkRole = this.GetRecommendBondLinkRole();
		foreach (RoleDataBase roleDataBase in this.RoleList)
		{
			int dataId = roleDataBase.GetDataId();
			RoleBondInfo roleBondInfo = this.CurrentBondInfoList[this.CurrentSelectBondIndex];
			if (ModelBase<RoleSelectModel>.Instance.GetRoleIndex(dataId) != 0 || roleBondInfo.ConfigId <= 0 || ConfigBase<RogueBattleConfig>.Instance.GetRogueResBondRole(roleDataBase.GetRoleId()).Value.BondIdsIter().Contains(roleBondInfo.ConfigId))
			{
				RogueResRole roleInfoById = ModelBase<RogueBattleModel>.Instance.GetRoleInfoById(dataId);
				RogueBattleTeamRoleGridInfo item = new RogueBattleTeamRoleGridInfo
				{
					RoleData = roleDataBase,
					RoleStarLv = roleInfoById.Level,
					FormationIndex = this.FormationIndex,
					IsLinkOn = recommendBondLinkRole.Contains(dataId)
				};
				list.Add(item);
			}
		}
		int noPositionSort = 4;
		list.Sort(delegate(IRogueBattleTeamRoleGridInfo a, IRogueBattleTeamRoleGridInfo b)
		{
			int num = ModelBase<RoleSelectModel>.Instance.GetRoleIndex(a.RoleData.GetDataId());
			if (num == 0)
			{
				num = noPositionSort;
			}
			int num2 = ModelBase<RoleSelectModel>.Instance.GetRoleIndex(b.RoleData.GetDataId());
			if (num2 == 0)
			{
				num2 = noPositionSort;
			}
			if (num == num2)
			{
				return b.RoleStarLv - a.RoleStarLv;
			}
			return num - num2;
		});
		return list;
	}

	// Token: 0x06013F28 RID: 81704 RVA: 0x0058F85C File Offset: 0x0058DA5C
	private int GetIndexByRoleData(List<IRogueBattleTeamRoleGridInfo> infoList, RoleDataBase roleData)
	{
		for (int i = 0; i < infoList.Count; i++)
		{
			if (infoList[i].RoleData == roleData)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06013F29 RID: 81705 RVA: 0x0058F88C File Offset: 0x0058DA8C
	private void RefreshRoleList()
	{
		List<IRogueBattleTeamRoleGridInfo> newRoleListInfo = this.GetRoleListInfo();
		this.RoleScrollView.RefreshByData(newRoleListInfo, false, delegate
		{
			RoleDataBase roleData = newRoleListInfo[0].RoleData;
			Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
			foreach (RoleDataBase roleDataBase in roleIndexMap.Values)
			{
				int indexByRoleData = this.GetIndexByRoleData(this.RoleGridInfoList, roleDataBase);
				int indexByRoleData2 = this.GetIndexByRoleData(newRoleListInfo, roleDataBase);
				if (this.RoleScrollView.StartGridIndex >= 0 && indexByRoleData != indexByRoleData2)
				{
					ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Remove(roleDataBase.GetDataId());
					if (this.RoleScrollView.IsGridDisplaying(indexByRoleData))
					{
						RogueBattleTeamRoleGrid rogueBattleTeamRoleGrid = this.RoleScrollView.UnsafeGetGridProxy(indexByRoleData, false);
						if (rogueBattleTeamRoleGrid != null)
						{
							rogueBattleTeamRoleGrid.OnForceSelected(false);
						}
					}
				}
			}
			foreach (RoleDataBase roleDataBase2 in roleIndexMap.Values)
			{
				int indexByRoleData3 = this.GetIndexByRoleData(newRoleListInfo, roleDataBase2);
				ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Add(roleDataBase2.GetDataId());
				if (this.RoleScrollView.IsGridDisplaying(indexByRoleData3))
				{
					RogueBattleTeamRoleGrid rogueBattleTeamRoleGrid2 = this.RoleScrollView.UnsafeGetGridProxy(indexByRoleData3, false);
					if (rogueBattleTeamRoleGrid2 != null)
					{
						rogueBattleTeamRoleGrid2.OnForceSelected(true);
					}
				}
			}
			this.RoleGridInfoList = newRoleListInfo;
			if (this.CurSelectRole != null && this.GetIndexByRoleData(newRoleListInfo, this.CurSelectRole) >= 0)
			{
				return;
			}
			this.OnRoleSelect(roleData);
		}, true);
	}

	// Token: 0x06013F2A RID: 81706 RVA: 0x0058F8D1 File Offset: 0x0058DAD1
	private RogueBattleTeamRoleGrid OnGridProxyCreate()
	{
		RogueBattleTeamRoleGrid rogueBattleTeamRoleGrid = new RogueBattleTeamRoleGrid();
		rogueBattleTeamRoleGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.ToggleFunction));
		rogueBattleTeamRoleGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeFunction));
		return rogueBattleTeamRoleGrid;
	}

	// Token: 0x06013F2B RID: 81707 RVA: 0x0058F8FC File Offset: 0x0058DAFC
	private void ToggleFunction(MediumItemGridExtendCallback param)
	{
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		HashSet<int> selectedRoleSet = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet;
		IRogueBattleTeamRoleGridInfo rogueBattleTeamRoleGridInfo = (IRogueBattleTeamRoleGridInfo)param.Data;
		RoleDataBase roleData = rogueBattleTeamRoleGridInfo.RoleData;
		if (param.State == EToggleState.ETT_UnChecked)
		{
			int? num = null;
			foreach (KeyValuePair<int, RoleDataBase> keyValuePair in roleIndexMap)
			{
				if (keyValuePair.Value == roleData)
				{
					num = new int?(keyValuePair.Key);
					break;
				}
			}
			if (num != null)
			{
				roleIndexMap.Remove(num.Value);
				selectedRoleSet.Remove(roleData.GetDataId());
			}
		}
		else if (param.State == EToggleState.ETT_Checked)
		{
			for (int i = 1; i <= 3; i++)
			{
				if (!roleIndexMap.ContainsKey(i))
				{
					roleIndexMap[i] = roleData;
					selectedRoleSet.Add(roleData.GetDataId());
					break;
				}
			}
		}
		int gridIndex = this.RoleGridInfoList.IndexOf(rogueBattleTeamRoleGridInfo);
		this.RoleScrollView.RefreshGridProxy(gridIndex);
		this.OnRoleSelect(roleData);
	}

	// Token: 0x06013F2C RID: 81708 RVA: 0x0058FA1C File Offset: 0x0058DC1C
	[NullableContext(2)]
	private bool CanExecuteChangeFunction(object data, bool isForceSelected, EToggleState state)
	{
		if (this.WaitClose)
		{
			return false;
		}
		if (state != EToggleState.ETT_UnChecked)
		{
			return true;
		}
		if (ModelBase<RoleSelectModel>.Instance.RoleIndexMap.Count >= 3)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamRoleFull", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x06013F2D RID: 81709 RVA: 0x0058FA5C File Offset: 0x0058DC5C
	public void OnRoleSelect(RoleDataBase roleData)
	{
		this.CurSelectRole = roleData;
		base.GetText(4).SetText(roleData.GetName(null), true);
		this.RefreshFetterIconList(roleData);
	}

	// Token: 0x06013F2E RID: 81710 RVA: 0x0058FA93 File Offset: 0x0058DC93
	private RogueBattleRoleSelectFetterItem InitFetterIcon()
	{
		return new RogueBattleRoleSelectFetterItem
		{
			OnToggleClick = new Action<RoleBondInfo>(this.OnFetterIconToggleSelect)
		};
	}

	// Token: 0x06013F2F RID: 81711 RVA: 0x0058FAAC File Offset: 0x0058DCAC
	private void OnFetterIconToggleSelect(RoleBondInfo bondInfo)
	{
		this.FetterIconLayout.DeselectCurrentGridProxy();
		this.FetterIconLayout.SelectGridProxyByKey(bondInfo.ConfigId, true);
		this.RefreshFetterDescList(bondInfo.ConfigId);
	}

	// Token: 0x06013F30 RID: 81712 RVA: 0x0058FADC File Offset: 0x0058DCDC
	private void RefreshFetterIconList(RoleDataBase roleData)
	{
		RoleBondInfo roleBondInfo = this.CurrentBondInfoList[this.CurrentSelectBondIndex];
		int selectBondId = roleBondInfo.ConfigId;
		bool hasBondId = false;
		this.FetterIconLayout.DeselectCurrentGridProxy();
		RoleInfo roleConfig = roleData.GetRoleConfig();
		RogueResBondRole? rogueResBondRole = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBondRole(roleConfig.Id);
		List<RoleBondInfo> list = new List<RoleBondInfo>();
		foreach (int num in rogueResBondRole.Value.BondIdsIter())
		{
			RoleBondInfo roleBondDataById = ModelBase<RogueBattleModel>.Instance.GetRoleBondDataById(num);
			if (selectBondId == num)
			{
				hasBondId = true;
			}
			list.Add(roleBondDataById);
		}
		List<RoleBondInfo> list2 = list;
		Comparison<RoleBondInfo> comparison;
		if ((comparison = RogueBattleTeamRoleSelectView.<>O.<0>__SortRogueBattleRoleBondInfo) == null)
		{
			comparison = (RogueBattleTeamRoleSelectView.<>O.<0>__SortRogueBattleRoleBondInfo = new Comparison<RoleBondInfo>(RogueBattleDefine.SortRogueBattleRoleBondInfo));
		}
		list2.Sort(comparison);
		this.FetterIconLayout.RefreshByData(list, delegate
		{
			if (hasBondId)
			{
				this.FetterIconLayout.SelectGridProxyByKey(selectBondId, true);
				return;
			}
			this.FetterIconLayout.SelectGridProxy(0, true);
		}, false);
	}

	// Token: 0x06013F31 RID: 81713 RVA: 0x0058FBF4 File Offset: 0x0058DDF4
	private RogueBattleMapFetterInfoItem InitFetter()
	{
		return new RogueBattleMapFetterInfoItem();
	}

	// Token: 0x06013F32 RID: 81714 RVA: 0x0058FBFC File Offset: 0x0058DDFC
	private void RefreshFetterDescList(int bondId)
	{
		RoleBondInfo roleBondDataById = ModelBase<RogueBattleModel>.Instance.GetRoleBondDataById(bondId);
		RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(bondId);
		List<IRogueBattleMapFetterInfo> list = new List<IRogueBattleMapFetterInfo>();
		List<DicIntInt> list2 = rogueResBond.Value.StarMapIter().ToList<DicIntInt>();
		list2.Sort((DicIntInt a, DicIntInt b) => a.Key - b.Key);
		if (list2.Count > 0)
		{
			foreach (DicIntInt dicIntInt in list2)
			{
				int key = dicIntInt.Key;
				RogueBattleMapFetterInfo item = new RogueBattleMapFetterInfo
				{
					ConfigId = bondId,
					Level = key,
					IsReached = (key <= roleBondDataById.Level)
				};
				list.Add(item);
			}
			this.FetterLayout.SetActive(true);
			this.FetterLayout.RefreshByData(list, null, false);
			return;
		}
		this.FetterLayout.SetActive(false);
	}

	// Token: 0x06013F33 RID: 81715 RVA: 0x0058FD0C File Offset: 0x0058DF0C
	private List<int> GetRecommendBondLinkRole()
	{
		List<int> list = new List<int>();
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		List<RoleDataBase> list2 = new List<RoleDataBase>();
		for (int i = 1; i <= 3; i++)
		{
			RoleDataBase item;
			if (roleIndexMap.TryGetValue(i, out item))
			{
				list2.Add(item);
			}
		}
		if (ModelBase<RogueBattleModel>.Instance.GetLinkIdByRoleList(list2) > 0)
		{
			return list;
		}
		int num = 0;
		List<RoleBondInfo> allOwnedRoleBondData = ModelBase<RogueBattleModel>.Instance.GetAllOwnedRoleBondData();
		Comparison<RoleBondInfo> comparison;
		if ((comparison = RogueBattleTeamRoleSelectView.<>O.<0>__SortRogueBattleRoleBondInfo) == null)
		{
			comparison = (RogueBattleTeamRoleSelectView.<>O.<0>__SortRogueBattleRoleBondInfo = new Comparison<RoleBondInfo>(RogueBattleDefine.SortRogueBattleRoleBondInfo));
		}
		allOwnedRoleBondData.Sort(comparison);
		foreach (RoleBondInfo roleBondInfo in allOwnedRoleBondData)
		{
			if (ModelBase<RogueBattleModel>.Instance.IsBondLinkCanActivate(roleBondInfo.ConfigId))
			{
				num = roleBondInfo.ConfigId;
				break;
			}
		}
		if (num == 0)
		{
			return list;
		}
		int num2 = 0;
		for (int j = 0; j < this.CurrentBondInfoList.Count; j++)
		{
			if (num == this.CurrentBondInfoList[j].ConfigId)
			{
				num2 = j;
				break;
			}
		}
		if (this.CurrentSelectBondIndex != 0 && this.CurrentSelectBondIndex != num2)
		{
			return list;
		}
		RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(num);
		List<<RogueBattleTeamRoleSelectView>FBD1E266F1DA3F5ACCE51563B2F32DB6CF507E847A70B0E30F1254639F95EFFCB__RecommendRoleIdInfo> list3 = new List<<RogueBattleTeamRoleSelectView>FBD1E266F1DA3F5ACCE51563B2F32DB6CF507E847A70B0E30F1254639F95EFFCB__RecommendRoleIdInfo>();
		foreach (RoleDataBase roleDataBase in this.RoleList)
		{
			int dataId = roleDataBase.GetDataId();
			RogueResBondRole? rogueResBondRole = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBondRole(roleDataBase.GetRoleId());
			if (rogueResBondRole != null && rogueResBondRole.Value.BondIdsIter().Contains(num))
			{
				RogueResRole roleInfoById = ModelBase<RogueBattleModel>.Instance.GetRoleInfoById(dataId);
				<RogueBattleTeamRoleSelectView>FBD1E266F1DA3F5ACCE51563B2F32DB6CF507E847A70B0E30F1254639F95EFFCB__RecommendRoleIdInfo item2 = new <RogueBattleTeamRoleSelectView>FBD1E266F1DA3F5ACCE51563B2F32DB6CF507E847A70B0E30F1254639F95EFFCB__RecommendRoleIdInfo
				{
					RoleId = dataId,
					RoleStarLv = roleInfoById.Level
				};
				list3.Add(item2);
			}
		}
		list3.Sort((<RogueBattleTeamRoleSelectView>FBD1E266F1DA3F5ACCE51563B2F32DB6CF507E847A70B0E30F1254639F95EFFCB__RecommendRoleIdInfo a, <RogueBattleTeamRoleSelectView>FBD1E266F1DA3F5ACCE51563B2F32DB6CF507E847A70B0E30F1254639F95EFFCB__RecommendRoleIdInfo b) => b.RoleStarLv - a.RoleStarLv);
		int num3 = 0;
		while (num3 < rogueResBond.Value.ActLinkNum && num3 <= list3.Count)
		{
			list.Add(list3[num3].RoleId);
			num3++;
		}
		return list;
	}

	// Token: 0x06013F34 RID: 81716 RVA: 0x0058FF70 File Offset: 0x0058E170
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		int num;
		if (configParams.Length != 0 && int.TryParse(configParams[0], out num) && num != 0)
		{
			UUIItem scrollItemByRoleId = this.GetScrollItemByRoleId(num);
			if (scrollItemByRoleId != null)
			{
				return new UUIItem[]
				{
					scrollItemByRoleId,
					scrollItemByRoleId
				};
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Guide;
		ELogAuthor author = ELogAuthor.TZJ;
		string message = "聚焦引导extraParam项配置有误";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x06013F35 RID: 81717 RVA: 0x0058FFD4 File Offset: 0x0058E1D4
	[NullableContext(2)]
	private UUIItem GetScrollItemByRoleId(int roleId)
	{
		int index = this.RoleGridInfoList.FindIndex((IRogueBattleTeamRoleGridInfo info) => info.RoleData.GetRoleId() == roleId);
		if (index < 0)
		{
			return null;
		}
		LoopScrollView<RogueBattleTeamRoleGrid, IRogueBattleTeamRoleGridInfo> roleScrollView = this.RoleScrollView;
		UUIItem result = (roleScrollView != null) ? roleScrollView.GetGrid(index) : null;
		TimerSystem.GameplayTimeInstance.Next(delegate(float _)
		{
			this.RoleScrollView.ScrollToGridIndex(index, false);
		}, null, null);
		return result;
	}

	// Token: 0x04009B5E RID: 39774
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private CommonDropDown<RoleBondInfo, RoleBondInfo> CommonDropDown;

	// Token: 0x04009B5F RID: 39775
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04009B60 RID: 39776
	[Nullable(2)]
	private ButtonItem ButtonConfirm;

	// Token: 0x04009B61 RID: 39777
	[Nullable(2)]
	private ButtonItem ButtonRoleDetail;

	// Token: 0x04009B62 RID: 39778
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<RogueBattleTeamRoleGrid, IRogueBattleTeamRoleGridInfo> RoleScrollView;

	// Token: 0x04009B63 RID: 39779
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RogueBattleRoleSelectFetterItem, RoleBondInfo> FetterIconLayout;

	// Token: 0x04009B64 RID: 39780
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RogueBattleMapFetterInfoItem, IRogueBattleMapFetterInfo> FetterLayout;

	// Token: 0x04009B65 RID: 39781
	private int FormationIndex = -1;

	// Token: 0x04009B66 RID: 39782
	private int CurrentSelectBondIndex = -1;

	// Token: 0x04009B67 RID: 39783
	private List<RoleBondInfo> CurrentBondInfoList = new List<RoleBondInfo>();

	// Token: 0x04009B68 RID: 39784
	private List<RoleDataBase> RoleList = new List<RoleDataBase>();

	// Token: 0x04009B69 RID: 39785
	private List<IRogueBattleTeamRoleGridInfo> RoleGridInfoList = new List<IRogueBattleTeamRoleGridInfo>();

	// Token: 0x04009B6A RID: 39786
	[Nullable(2)]
	private RoleDataBase CurSelectRole;

	// Token: 0x04009B6B RID: 39787
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Func<List<int>, UniTask> OnConfirm;

	// Token: 0x04009B6C RID: 39788
	private bool WaitClose;

	// Token: 0x02008B37 RID: 35639
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402EEEE RID: 192238
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Comparison<RoleBondInfo> <0>__SortRogueBattleRoleBondInfo;
	}
}
