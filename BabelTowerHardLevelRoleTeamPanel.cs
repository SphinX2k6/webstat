using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200121F RID: 4639
[NullableContext(2)]
[Nullable(0)]
public class BabelTowerHardLevelRoleTeamPanel : UiPanelBase
{
	// Token: 0x06007B64 RID: 31588 RVA: 0x0020552C File Offset: 0x0020372C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnMaskBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007B65 RID: 31589 RVA: 0x00205658 File Offset: 0x00203858
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerHardLevelRoleTeamPanel.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerHardLevelRoleTeamPanel.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007B66 RID: 31590 RVA: 0x0020569C File Offset: 0x0020389C
	protected override void OnStart()
	{
		this.TabComponent = new GenericLayout<BabelTowerTeamTabItem, string>(base.GetHorizontalLayout(0), delegate()
		{
			BabelTowerTeamTabItem babelTowerTeamTabItem = new BabelTowerTeamTabItem();
			babelTowerTeamTabItem.SetToggleClickCallback(new Action<EBabelTowerTeamTabType>(this.OnTabClick));
			return babelTowerTeamTabItem;
		}, null, false, true);
		this.TabComponent.RefreshByData(new List<string>
		{
			"GhostShipRoleList_Text",
			"GhostShipPreTeam_Text"
		}, delegate
		{
			this.OnTabClick(EBabelTowerTeamTabType.RoleList);
		}, false);
	}

	// Token: 0x06007B67 RID: 31591 RVA: 0x002056FD File Offset: 0x002038FD
	private void OnMaskBtnClick()
	{
		base.SetUiActive(false);
		Action onPanelClose = this.OnPanelClose;
		if (onPanelClose == null)
		{
			return;
		}
		onPanelClose();
	}

	// Token: 0x06007B68 RID: 31592 RVA: 0x00205716 File Offset: 0x00203916
	private void OnTabClick(EBabelTowerTeamTabType index)
	{
		this.CurSelectTabIndex = index;
		this.RefreshCurrentTab();
	}

	// Token: 0x06007B69 RID: 31593 RVA: 0x00205728 File Offset: 0x00203928
	private void RefreshCurrentTab()
	{
		if (this.LevelInfo == null)
		{
			return;
		}
		EBabelTowerTeamTabType curSelectTabIndex = this.CurSelectTabIndex;
		GenericLayout<BabelTowerTeamTabItem, string> tabComponent = this.TabComponent;
		if (tabComponent != null)
		{
			tabComponent.SelectGridProxy((int)curSelectTabIndex, false);
		}
		BabelTowerRoleSelectPanel roleSelectPanel = this.RoleSelectPanel;
		if (roleSelectPanel != null)
		{
			roleSelectPanel.SetUiActive(curSelectTabIndex == EBabelTowerTeamTabType.RoleList);
		}
		BabelTowerTeamSelectPanel teamSelectPanel = this.TeamSelectPanel;
		if (teamSelectPanel != null)
		{
			teamSelectPanel.SetUiActive(curSelectTabIndex == EBabelTowerTeamTabType.UseTeam);
		}
		if (curSelectTabIndex != EBabelTowerTeamTabType.RoleList)
		{
			if (curSelectTabIndex == EBabelTowerTeamTabType.UseTeam)
			{
				BabelTowerTeamSelectPanel teamSelectPanel2 = this.TeamSelectPanel;
				if (teamSelectPanel2 != null)
				{
					teamSelectPanel2.RefreshTeamList();
				}
			}
		}
		else
		{
			this.SyncLevelInfoToSelectModel();
			BabelTowerRoleSelectPanel roleSelectPanel2 = this.RoleSelectPanel;
			if (roleSelectPanel2 != null)
			{
				roleSelectPanel2.RefreshWithSelectedState(this.GetRoleListWithTrial());
			}
		}
		Action<EBabelTowerTeamTabType> onSelectModeChange = this.OnSelectModeChange;
		if (onSelectModeChange == null)
		{
			return;
		}
		onSelectModeChange(curSelectTabIndex);
	}

	// Token: 0x06007B6A RID: 31594 RVA: 0x002057CC File Offset: 0x002039CC
	[NullableContext(1)]
	private List<RoleDataBase> GetRoleListWithTrial()
	{
		List<RoleDataBase> list = new List<RoleDataBase>(ModelBase<RoleModel>.Instance.GetRoleList().Cast<RoleDataBase>());
		if (this.LevelInfo == null)
		{
			return list;
		}
		int instanceId = this.LevelInfo.InstanceId;
		int fightFormationId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId).Value.FightFormationId;
		FightFormation? fightFormationConfig = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId);
		if (fightFormationConfig == null)
		{
			return list;
		}
		foreach (int id in fightFormationConfig.Value.GetTrialRoleArray())
		{
			TrialRoleInfo? trialRoleConfigByGroupId = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(id);
			if (trialRoleConfigByGroupId != null)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(trialRoleConfigByGroupId.Value.Id, true);
				if (roleDataById != null)
				{
					list.Add(roleDataById);
				}
			}
		}
		return list;
	}

	// Token: 0x06007B6B RID: 31595 RVA: 0x002058A6 File Offset: 0x00203AA6
	[NullableContext(1)]
	public void SetLevelInfo(IBabelTowerLevelInfo levelInfo)
	{
		this.LevelInfo = levelInfo;
	}

	// Token: 0x06007B6C RID: 31596 RVA: 0x002058AF File Offset: 0x00203AAF
	public void Refresh()
	{
		this.RefreshCurrentTab();
	}

	// Token: 0x06007B6D RID: 31597 RVA: 0x002058B8 File Offset: 0x00203AB8
	private void SyncLevelInfoToSelectModel()
	{
		if (this.LevelInfo == null)
		{
			return;
		}
		RoleSelectModel instance = ModelBase<RoleSelectModel>.Instance;
		instance.ClearData();
		int num = 1;
		foreach (int num2 in this.LevelInfo.RoleList)
		{
			if (num2 > 0)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num2, true);
				if (roleDataById != null)
				{
					instance.SelectedRoleSet.Add(num2);
					instance.RoleIndexMap[num] = roleDataById;
					num++;
				}
			}
		}
	}

	// Token: 0x06007B6E RID: 31598 RVA: 0x00205958 File Offset: 0x00203B58
	private void SyncSelectModelToLevelInfo()
	{
		if (this.LevelInfo == null)
		{
			return;
		}
		this.LevelInfo.RoleList = new List<int>(ModelBase<RoleSelectModel>.Instance.SelectedRoleSet);
	}

	// Token: 0x06007B6F RID: 31599 RVA: 0x00205980 File Offset: 0x00203B80
	[NullableContext(1)]
	private void OnRoleSelect(RoleDataBase roleData, bool isSelected)
	{
		this.SyncSelectModelToLevelInfo();
		BabelTowerTeamSelectPanel teamSelectPanel = this.TeamSelectPanel;
		if (teamSelectPanel != null)
		{
			teamSelectPanel.RefreshTeamList();
		}
		int dataId = roleData.GetDataId();
		if (isSelected)
		{
			BabelTowerRoleSelectPanel roleSelectPanel = this.RoleSelectPanel;
			if (roleSelectPanel != null)
			{
				roleSelectPanel.RefreshRoleGridProxy(dataId);
			}
		}
		else
		{
			BabelTowerRoleSelectPanel roleSelectPanel2 = this.RoleSelectPanel;
			if (roleSelectPanel2 != null)
			{
				roleSelectPanel2.RefreshRoleGridProxy(dataId);
			}
			BabelTowerRoleSelectPanel roleSelectPanel3 = this.RoleSelectPanel;
			if (roleSelectPanel3 != null)
			{
				roleSelectPanel3.RefreshSelectedRoleGridProxies();
			}
		}
		Action onRefreshCallBack = this.OnRefreshCallBack;
		if (onRefreshCallBack == null)
		{
			return;
		}
		onRefreshCallBack();
	}

	// Token: 0x06007B70 RID: 31600 RVA: 0x002059F8 File Offset: 0x00203BF8
	[NullableContext(1)]
	private void OnTeamSelect(EditFormationData teamData)
	{
		if (this.LevelInfo == null)
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (EditFormationRoleData editFormationRoleData in teamData.GetRoleDataMapWithTrial(false).Values)
		{
			list.Add(editFormationRoleData.ConfigId);
		}
		this.LevelInfo.RoleList = list;
		RoleSelectModel instance = ModelBase<RoleSelectModel>.Instance;
		instance.ClearData();
		int num = 1;
		foreach (int num2 in list)
		{
			if (num2 > 0)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num2, true);
				if (roleDataById != null)
				{
					instance.SelectedRoleSet.Add(num2);
					instance.RoleIndexMap[num] = roleDataById;
					num++;
					ControllerBase<RoleController>.Instance.SynRoleSkillBranchNormalToGamePlay(num2, ESkillBranchCacheType.BabelTower);
				}
			}
		}
		Action onRefreshCallBack = this.OnRefreshCallBack;
		if (onRefreshCallBack == null)
		{
			return;
		}
		onRefreshCallBack();
	}

	// Token: 0x06007B71 RID: 31601 RVA: 0x00205B10 File Offset: 0x00203D10
	public void RefreshPanel()
	{
		int selectedGridIndex = this.TabComponent.GetSelectedGridIndex();
		if (selectedGridIndex < 0)
		{
			return;
		}
		EBabelTowerTeamTabType ebabelTowerTeamTabType = (EBabelTowerTeamTabType)selectedGridIndex;
		if (ebabelTowerTeamTabType != EBabelTowerTeamTabType.RoleList)
		{
			if (ebabelTowerTeamTabType != EBabelTowerTeamTabType.UseTeam)
			{
				return;
			}
			BabelTowerTeamSelectPanel teamSelectPanel = this.TeamSelectPanel;
			if (teamSelectPanel == null)
			{
				return;
			}
			teamSelectPanel.RefreshTeamList();
			return;
		}
		else
		{
			this.SyncLevelInfoToSelectModel();
			BabelTowerRoleSelectPanel roleSelectPanel = this.RoleSelectPanel;
			if (roleSelectPanel == null)
			{
				return;
			}
			roleSelectPanel.RefreshSelectedRoleGridProxies();
			return;
		}
	}

	// Token: 0x06007B72 RID: 31602 RVA: 0x00205B5F File Offset: 0x00203D5F
	public void RefreshRoleSkillBranch(int roleId)
	{
		BabelTowerRoleSelectPanel roleSelectPanel = this.RoleSelectPanel;
		if (roleSelectPanel == null)
		{
			return;
		}
		roleSelectPanel.RefreshRole(roleId);
	}

	// Token: 0x04003B17 RID: 15127
	public Action OnRefreshCallBack;

	// Token: 0x04003B18 RID: 15128
	public Action<EBabelTowerTeamTabType> OnSelectModeChange;

	// Token: 0x04003B19 RID: 15129
	public Action OnPanelClose;

	// Token: 0x04003B1A RID: 15130
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<BabelTowerTeamTabItem, string> TabComponent;

	// Token: 0x04003B1B RID: 15131
	private BabelTowerRoleSelectPanel RoleSelectPanel;

	// Token: 0x04003B1C RID: 15132
	private BabelTowerTeamSelectPanel TeamSelectPanel;

	// Token: 0x04003B1D RID: 15133
	private EBabelTowerTeamTabType CurSelectTabIndex;

	// Token: 0x04003B1E RID: 15134
	private IBabelTowerLevelInfo LevelInfo;

	// Token: 0x02007584 RID: 30084
	[NullableContext(0)]
	private class EComp
	{
		// Token: 0x040288C5 RID: 166085
		public const int TabLayout = 0;

		// Token: 0x040288C6 RID: 166086
		public const int TabItem = 1;

		// Token: 0x040288C7 RID: 166087
		public const int RoleSelect = 2;

		// Token: 0x040288C8 RID: 166088
		public const int TeamSelect = 3;

		// Token: 0x040288C9 RID: 166089
		public const int MaskBtn = 5;

		// Token: 0x040288CA RID: 166090
		public const int BlurTex = 6;
	}

	// Token: 0x02007585 RID: 30085
	[NullableContext(0)]
	private class ETabItem
	{
		// Token: 0x040288CB RID: 166091
		public const int Toggle = 0;

		// Token: 0x040288CC RID: 166092
		public const int Name = 1;

		// Token: 0x040288CD RID: 166093
		public const int RedDot = 2;
	}
}
