using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02002CFA RID: 11514
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeaponReplaceMediumItemGrid : LoopScrollMediumItemGrid<SelectablePropData>
{
	// Token: 0x060173C9 RID: 95177 RVA: 0x00671502 File Offset: 0x0066F702
	public override void OnSelected(bool fireEvent)
	{
		if (fireEvent)
		{
			this.SetSelected(true, true);
		}
	}

	// Token: 0x060173CA RID: 95178 RVA: 0x0067150F File Offset: 0x0066F70F
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x060173CB RID: 95179 RVA: 0x0067151C File Offset: 0x0066F71C
	protected override void OnRefresh(SelectablePropData data, bool isSelected, int gridIndex)
	{
		int incId = data.IncId;
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
		WeaponConf? weaponConfig = weaponDataByIncId.GetWeaponConfig();
		MediumWarningPanelInfo warningPanelInfo = this.GetWarningPanelInfo(data);
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.ItemId),
			IsLockVisible = new bool?(data.GetIsLock()),
			StarLevel = new int?(weaponConfig.Value.QualityId),
			Level = new int?(weaponDataByIncId.GetResonanceLevel()),
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				weaponDataByIncId.GetLevel()
			},
			RoleHeadInfo = new RoleHeadInfo
			{
				RoleConfigId = new int?(data.RoleId)
			},
			WarningPanelInfo = warningPanelInfo
		};
		base.Apply<PropMediumItemGrid>(parameters);
		this.SetSelected(isSelected, true);
	}

	// Token: 0x060173CC RID: 95180 RVA: 0x0067160C File Offset: 0x0066F80C
	[return: Nullable(2)]
	private MediumWarningPanelInfo GetWarningPanelInfo(SelectablePropData data)
	{
		if (this.Source == ERoleViewSource.WheelTower)
		{
			int incId = data.IncId;
			EnergyInfo selectedEnergyInfo = ModelBase<WheelTowerModel>.Instance.SelectedEnergyInfo;
			if (selectedEnergyInfo == null)
			{
				return null;
			}
			if (!selectedEnergyInfo.GetWeaponCanUse(incId, this.RoleId))
			{
				int weaponOccupyRoleId = selectedEnergyInfo.GetWeaponOccupyRoleId(incId, this.RoleId);
				Aki.Config.RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(weaponOccupyRoleId);
				if (roleConfig != null)
				{
					string multiText = ConfigBase<TextConfig>.Instance.GetMultiText("WheelTower_Occupy_Tip", Array.Empty<string>());
					return new MediumWarningPanelInfo
					{
						TipText = multiText,
						IconPath = roleConfig.Value.Card
					};
				}
			}
		}
		return null;
	}

	// Token: 0x0400B2AB RID: 45739
	public ERoleViewSource Source;

	// Token: 0x0400B2AC RID: 45740
	public int RoleId;
}
