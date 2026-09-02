using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x02001656 RID: 5718
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerRecordRoleGridItem : LoopScrollMediumItemGrid<RoleDataWithBranch>
{
	// Token: 0x0600A06C RID: 41068 RVA: 0x0029FE46 File Offset: 0x0029E046
	protected override void OnStart()
	{
		base.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		base.SetToggleInteractive(false);
	}

	// Token: 0x0600A06D RID: 41069 RVA: 0x0029FE74 File Offset: 0x0029E074
	protected override void OnRefresh(RoleDataWithBranch data, bool isSelected, int gridIndex)
	{
		int roleId = data.RoleId;
		int num = ModelBase<WheelTowerModel>.Instance.TryGetRealRoleId(roleId);
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
		if (roleDataById == null)
		{
			return;
		}
		int roleEnergy = ModelBase<WheelTowerModel>.Instance.SelectedEnergyInfo.GetRoleEnergy(roleId);
		int roleCost = ModelBase<WheelTowerModel>.Instance.GetRoleCost(roleId);
		bool flag = ModelBase<WheelTowerModel>.Instance.IsTemplateRole(roleId);
		TrialRoleInfo? trialRoleInfo;
		int num2 = flag ? ((ConfigBase<TrialRoleConfig>.Instance.GetTrialRoleConfig(roleId) != null) ? trialRoleInfo.GetValueOrDefault().Level : 90) : roleDataById.GetLevelData().GetLevel();
		int roleBranchIndexById = ModelBase<RoleModel>.Instance.GetRoleBranchIndexById(roleId, data.SkillBranchId);
		base.SetUseFixedAsync(true);
		CharacterMediumItemGrid characterMediumItemGrid = new CharacterMediumItemGrid();
		characterMediumItemGrid.Data = roleDataById;
		characterMediumItemGrid.ItemConfigId = new int?(num);
		characterMediumItemGrid.SkinId = roleDataById.GetRoleConfig().SkinId;
		characterMediumItemGrid.BottomTextId = "Text_LevelShow_Text";
		characterMediumItemGrid.BottomTextParameter = new object[]
		{
			num2
		};
		characterMediumItemGrid.ElementId = new int?(roleDataById.GetRoleConfig().ElementId);
		CharacterMediumItemGrid characterMediumItemGrid2 = characterMediumItemGrid;
		MediumItemGridCostComponentData mediumItemGridCostComponentData = new MediumItemGridCostComponentData();
		mediumItemGridCostComponentData.Cost = roleEnergy;
		mediumItemGridCostComponentData.Color = TowerData.highColor.Value;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(roleEnergy - roleCost);
		defaultInterpolatedStringHandler.AppendLiteral("(-");
		defaultInterpolatedStringHandler.AppendFormatted<int>(roleCost);
		defaultInterpolatedStringHandler.AppendLiteral(")");
		mediumItemGridCostComponentData.Text = defaultInterpolatedStringHandler.ToStringAndClear();
		characterMediumItemGrid2.ShowCostData = mediumItemGridCostComponentData;
		characterMediumItemGrid.SkillBranchIndex = ((roleBranchIndexById >= 0) ? new int?(roleBranchIndexById) : null);
		base.Apply<CharacterMediumItemGrid>(characterMediumItemGrid);
		base.SetTemplateIcon(new bool?(flag));
		base.SetUpgradeArrow(new bool?(ModelBase<WheelTowerModel>.Instance.IsEnhanceRole(num)));
	}
}
