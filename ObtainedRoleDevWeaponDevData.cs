using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002838 RID: 10296
[NullableContext(1)]
[Nullable(0)]
public class ObtainedRoleDevWeaponDevData : RoleDevWeaponDevItemDataBase
{
	// Token: 0x06014680 RID: 83584 RVA: 0x005AC064 File Offset: 0x005AA264
	protected override void InitByRoleType(int roleId)
	{
		this.WeaponInstanceInternal = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(roleId);
		if (this.WeaponInstanceInternal == null)
		{
			return;
		}
		this.InitDetailItemData();
	}

	// Token: 0x06014681 RID: 83585 RVA: 0x005AC086 File Offset: 0x005AA286
	private void InitDetailItemData()
	{
		if (this.WeaponInstanceInternal == null)
		{
			return;
		}
		this.DetailItemDataInternal.InitByWeaponInstance(base.RoleId, this.WeaponInstanceInternal);
	}

	// Token: 0x06014682 RID: 83586 RVA: 0x005AC0A8 File Offset: 0x005AA2A8
	protected override int GetWeaponLevel()
	{
		WeaponInstance weaponInstanceInternal = this.WeaponInstanceInternal;
		if (weaponInstanceInternal == null)
		{
			return 1;
		}
		return weaponInstanceInternal.GetLevel();
	}

	// Token: 0x06014683 RID: 83587 RVA: 0x005AC0BB File Offset: 0x005AA2BB
	protected override int GetWeaponBreachLevel()
	{
		WeaponInstance weaponInstanceInternal = this.WeaponInstanceInternal;
		if (weaponInstanceInternal == null)
		{
			return 0;
		}
		return weaponInstanceInternal.GetBreachLevel();
	}

	// Token: 0x06014684 RID: 83588 RVA: 0x005AC0D0 File Offset: 0x005AA2D0
	protected override int GetWeaponGoalUpgradeLevel()
	{
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(base.RoleId);
		if (cultivateProject == null)
		{
			return 0;
		}
		return cultivateProject.Value.WeaponLevel;
	}

	// Token: 0x06014685 RID: 83589 RVA: 0x005AC104 File Offset: 0x005AA304
	protected override int GetWeaponGoalBreakLevel()
	{
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(base.RoleId);
		if (cultivateProject == null)
		{
			return 0;
		}
		return cultivateProject.Value.WeaponBreachLevel;
	}

	// Token: 0x06014686 RID: 83590 RVA: 0x005AC137 File Offset: 0x005AA337
	protected override int GetMaxLevel()
	{
		WeaponInstance weaponInstanceInternal = this.WeaponInstanceInternal;
		if (weaponInstanceInternal == null)
		{
			return 0;
		}
		return weaponInstanceInternal.GetMaxLevel();
	}

	// Token: 0x06014687 RID: 83591 RVA: 0x005AC14A File Offset: 0x005AA34A
	protected override List<IRoleDevDetailItemData> GetDetailItems()
	{
		return this.DetailItemDataInternal.DetailItems;
	}

	// Token: 0x06014688 RID: 83592 RVA: 0x005AC158 File Offset: 0x005AA358
	protected override string GetWeaponName()
	{
		if (this.WeaponInstanceInternal == null)
		{
			return "";
		}
		WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(this.WeaponInstanceInternal.GetItemId());
		if (weaponConfigByItemId == null)
		{
			return "";
		}
		return weaponConfigByItemId.Value.WeaponName;
	}

	// Token: 0x06014689 RID: 83593 RVA: 0x005AC1A7 File Offset: 0x005AA3A7
	protected override bool GetIsCanUpgrade()
	{
		return this.WeaponInstanceInternal != null && base.IsCanShowUpgradeItem && this.WeaponInstanceInternal.GetLevel() < this.WeaponInstanceInternal.GetCurrentMaxLevel();
	}

	// Token: 0x0601468A RID: 83594 RVA: 0x005AC1D8 File Offset: 0x005AA3D8
	protected override bool GetIsCanBreach()
	{
		if (this.WeaponInstanceInternal == null)
		{
			return false;
		}
		int? incId = this.WeaponInstanceInternal.GetIncId();
		if (incId == null)
		{
			return false;
		}
		EWeaponBreachState weaponBreachState = ModelBase<WeaponModel>.Instance.GetWeaponBreachState(incId.Value);
		return base.IsCanShowBreachItem && weaponBreachState == EWeaponBreachState.CanBreach;
	}

	// Token: 0x0601468B RID: 83595 RVA: 0x005AC228 File Offset: 0x005AA428
	protected override bool GetIsCall()
	{
		return RoleDevUtils.GetRoleGachaIds(ModelBase<WeaponModel>.Instance.GetWeaponIdByRoleDataId(base.RoleId).GetValueOrDefault()).Length != 0;
	}

	// Token: 0x0601468C RID: 83596 RVA: 0x005AC258 File Offset: 0x005AA458
	protected override int GetGachaId()
	{
		int[] roleGachaIds = RoleDevUtils.GetRoleGachaIds(ModelBase<WeaponModel>.Instance.GetWeaponIdByRoleDataId(base.RoleId).GetValueOrDefault());
		if (roleGachaIds.Length != 0)
		{
			return roleGachaIds[0];
		}
		return 0;
	}

	// Token: 0x0601468D RID: 83597 RVA: 0x005AC28C File Offset: 0x005AA48C
	protected override int GetWeaponConfigId()
	{
		return ModelBase<WeaponModel>.Instance.GetWeaponIdByRoleDataId(base.RoleId).GetValueOrDefault();
	}

	// Token: 0x0601468E RID: 83598 RVA: 0x005AC2B1 File Offset: 0x005AA4B1
	protected override bool GetIsHighQuality()
	{
		return this.WeaponInstanceInternal != null && ModelBase<WeaponModel>.Instance.IsWeaponHighQuality(this.WeaponInstanceInternal);
	}

	// Token: 0x17001A68 RID: 6760
	// (get) Token: 0x0601468F RID: 83599 RVA: 0x005AC2CD File Offset: 0x005AA4CD
	public ObtainedRoleDevWeaponDetailItemData DetailItemData
	{
		get
		{
			return this.DetailItemDataInternal;
		}
	}

	// Token: 0x04009E01 RID: 40449
	[Nullable(2)]
	private WeaponInstance WeaponInstanceInternal;

	// Token: 0x04009E02 RID: 40450
	private readonly ObtainedRoleDevWeaponDetailItemData DetailItemDataInternal = new ObtainedRoleDevWeaponDetailItemData();
}
