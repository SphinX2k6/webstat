using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x0200169A RID: 5786
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerRoleGridItem : LoopScrollMediumItemGrid<RoleDataWithBranch>
{
	// Token: 0x0600A139 RID: 41273 RVA: 0x002A558E File Offset: 0x002A378E
	protected override void OnStart()
	{
		base.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
	}

	// Token: 0x0600A13A RID: 41274 RVA: 0x002A55B8 File Offset: 0x002A37B8
	protected override void OnRefresh(RoleDataWithBranch data, bool isSelected, int gridIndex)
	{
		int roleId = data.RoleId;
		if (roleId == 0)
		{
			base.Apply<OnlyEmptyItemGrid>(new OnlyEmptyItemGrid
			{
				IsClickable = new bool?(false)
			});
			this.SetSelected(false, true);
			return;
		}
		this.RoleId = roleId;
		int num = ModelBase<WheelTowerModel>.Instance.TryGetRealRoleId(roleId);
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		if (roleDataById == null)
		{
			return;
		}
		int roleEnergy = ModelBase<WheelTowerModel>.Instance.SelectedEnergyInfo.GetRoleEnergy(roleId);
		int roleSlot = ModelBase<WheelTowerModel>.Instance.GetRoleSlot(roleId);
		int? index = (roleSlot == -1) ? null : new int?(roleSlot + 1);
		bool flag = ModelBase<WheelTowerModel>.Instance.IsTemplateRole(roleId);
		bool flag2 = roleEnergy <= 0;
		bool value = !flag && !flag2 && ModelBase<WheelTowerModel>.Instance.CheckConflict(roleId) != null;
		TrialRoleInfo? trialRoleInfo;
		int num2 = flag ? ((ConfigBase<TrialRoleConfig>.Instance.GetTrialRoleConfig(roleId) != null) ? trialRoleInfo.GetValueOrDefault().Level : 90) : roleDataById.GetLevelData().GetLevel();
		base.SetUseFixedAsync(true);
		base.Apply<CharacterMediumItemGrid>(new CharacterMediumItemGrid
		{
			Data = roleDataById,
			ItemConfigId = new int?(num),
			SkinId = roleDataById.GetRoleSkinId(),
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				num2
			},
			ElementId = new int?(roleDataById.GetRoleConfig().ElementId),
			ShowCostData = new MediumItemGridCostComponentData
			{
				Cost = roleEnergy,
				Color = ((roleEnergy > 0) ? TowerData.highColor.Value : TowerData.redColor.Value)
			},
			Index = index,
			IsDisable = new bool?(flag2),
			SkillBranchIndex = ((data.SkillBranchIndex > -1) ? new int?(data.SkillBranchIndex) : null)
		});
		base.SetWarningTips(new bool?(value));
		base.SetTemplateIcon(new bool?(flag));
		base.SetUpgradeArrow(new bool?(ModelBase<WheelTowerModel>.Instance.IsEnhanceRole(num)));
		this.GetItemGridExtendToggle().SetToggleStateForce(ModelBase<WheelTowerModel>.Instance.IsSelectRole(roleId) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600A13B RID: 41275 RVA: 0x002A57F1 File Offset: 0x002A39F1
	public void SetToggleClickCallback(Action<int> callback)
	{
		this.ToggleClickCallback = callback;
	}

	// Token: 0x0600A13C RID: 41276 RVA: 0x002A57FA File Offset: 0x002A39FA
	protected override void OnExtendToggleClicked()
	{
		Action<int> toggleClickCallback = this.ToggleClickCallback;
		if (toggleClickCallback == null)
		{
			return;
		}
		toggleClickCallback(this.RoleId);
	}

	// Token: 0x04004B2C RID: 19244
	private int RoleId;

	// Token: 0x04004B2D RID: 19245
	[Nullable(2)]
	private Action<int> ToggleClickCallback;
}
