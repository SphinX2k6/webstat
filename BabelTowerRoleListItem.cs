using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x02001228 RID: 4648
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BabelTowerRoleListItem : SyncGridProxyAbstract<BabelTowerRoleListItemData>
{
	// Token: 0x06007BA9 RID: 31657 RVA: 0x00206A04 File Offset: 0x00204C04
	protected override void OnStart()
	{
		this.RoleGrid.Initialize(this.RootActor);
		this.RoleGrid.SetToggleInteractive(true);
		this.RoleGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnCanGridToggleStateChange));
		this.RoleGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnGridToggleStateChanged));
		this.RoleGrid.SetUseFixedAsync(true);
	}

	// Token: 0x06007BAA RID: 31658 RVA: 0x00206A68 File Offset: 0x00204C68
	[NullableContext(2)]
	private bool OnCanGridToggleStateChange(object data, bool isForceSelected, EToggleState state)
	{
		if (state != EToggleState.ETT_UnChecked)
		{
			return true;
		}
		BabelTowerRoleSelectPanel ownerPanel = this.Data.OwnerPanel;
		if (ownerPanel == null)
		{
			return true;
		}
		int configId = this.Data.RoleData.GetDataId();
		int roleId = this.Data.RoleData.GetRoleId();
		HashSet<int> selectedSet = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet;
		if (selectedSet.Count >= 3 && !selectedSet.Contains(configId))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamRoleFull", Array.Empty<object>());
			Action onMaxSelectReached = ownerPanel.OnMaxSelectReached;
			if (onMaxSelectReached != null)
			{
				onMaxSelectReached();
			}
			return false;
		}
		IEnumerable<RoleDataBase> first = ModelBase<RoleModel>.Instance.GetRoleList().Cast<RoleDataBase>().ToList<RoleDataBase>();
		List<RoleDataBase> trialRoleList = ownerPanel.GetTrialRoleList();
		if ((from r in first.Concat(trialRoleList)
		where selectedSet.Contains(r.GetDataId())
		select r).ToList<RoleDataBase>().Any((RoleDataBase r) => r.GetRoleId() == roleId && r.GetDataId() != configId))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamSameRole", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x06007BAB RID: 31659 RVA: 0x00206B78 File Offset: 0x00204D78
	private void OnGridToggleStateChanged(MediumItemGridExtendCallback @params)
	{
		BabelTowerRoleSelectPanel ownerPanel = this.Data.OwnerPanel;
		if (ownerPanel == null)
		{
			return;
		}
		bool flag = @params.State == EToggleState.ETT_Checked;
		int dataId = this.Data.RoleData.GetDataId();
		HashSet<int> selectedRoleSet = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet;
		if (flag)
		{
			if (!selectedRoleSet.Contains(dataId))
			{
				selectedRoleSet.Add(dataId);
				ownerPanel.SelectedConfigIds.Add(dataId);
				int count = selectedRoleSet.Count;
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(dataId, true);
				ModelBase<RoleSelectModel>.Instance.RoleIndexMap[count] = (roleDataById ?? this.Data.RoleData);
				Action<RoleDataBase, bool> onRoleSelect = ownerPanel.OnRoleSelect;
				if (onRoleSelect == null)
				{
					return;
				}
				onRoleSelect(this.Data.RoleData, true);
				return;
			}
		}
		else if (selectedRoleSet.Contains(dataId))
		{
			selectedRoleSet.Remove(dataId);
			ownerPanel.SelectedConfigIds.Remove(dataId);
			this.RebuildRoleIndexMap(selectedRoleSet);
			Action<RoleDataBase, bool> onRoleSelect2 = ownerPanel.OnRoleSelect;
			if (onRoleSelect2 == null)
			{
				return;
			}
			onRoleSelect2(this.Data.RoleData, false);
		}
	}

	// Token: 0x06007BAC RID: 31660 RVA: 0x00206C74 File Offset: 0x00204E74
	private void RebuildRoleIndexMap(HashSet<int> selectedSet)
	{
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		roleIndexMap.Clear();
		BabelTowerRoleListItemData data = this.Data;
		BabelTowerRoleSelectPanel babelTowerRoleSelectPanel = (data != null) ? data.OwnerPanel : null;
		int num = 1;
		foreach (int num2 in selectedSet)
		{
			RoleDataBase roleDataBase = ModelBase<RoleModel>.Instance.GetRoleDataById(num2, true);
			if (roleDataBase == null && babelTowerRoleSelectPanel != null)
			{
				roleDataBase = babelTowerRoleSelectPanel.FindRoleDataById(num2);
			}
			if (roleDataBase != null)
			{
				roleIndexMap[num] = roleDataBase;
				num++;
			}
		}
	}

	// Token: 0x06007BAD RID: 31661 RVA: 0x00206D14 File Offset: 0x00204F14
	public override void Refresh(BabelTowerRoleListItemData data)
	{
		this.Data = data;
		RoleDataBase roleData = data.RoleData;
		int dataId = roleData.GetDataId();
		bool flag = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Contains(dataId);
		RoleLevelData levelData = roleData.GetLevelData();
		int? index = null;
		foreach (KeyValuePair<int, RoleDataBase> keyValuePair in ModelBase<RoleSelectModel>.Instance.RoleIndexMap)
		{
			int key = keyValuePair.Key;
			if (keyValuePair.Value.GetDataId() == dataId)
			{
				index = new int?(key);
				break;
			}
		}
		int roleSkillBranchIndexInGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInGamePlay(dataId, ESkillBranchCacheType.BabelTower);
		CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
		{
			ItemConfigId = new int?(dataId),
			SkinId = roleData.GetRoleSkinId(),
			IsTrialRoleVisible = new bool?(roleData.IsTrialRole()),
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				levelData.GetLevel()
			},
			ElementId = new int?(roleData.GetRoleConfig().ElementId),
			Data = roleData,
			Index = index,
			IsInTeam = null,
			SkillBranchIndex = ((roleSkillBranchIndexInGamePlay > -1) ? new int?(roleSkillBranchIndexInGamePlay) : null)
		};
		this.RoleGrid.Apply<CharacterMediumItemGrid>(parameters);
		this.RoleGrid.GetItemGridExtendToggle().SetToggleStateForce(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04003B32 RID: 15154
	private const int MAX_SELECT_ROLE_COUNT = 3;

	// Token: 0x04003B33 RID: 15155
	public BabelTowerRoleListItemData Data;

	// Token: 0x04003B34 RID: 15156
	private readonly MediumItemGrid RoleGrid = new MediumItemGrid();
}
