using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002834 RID: 10292
[NullableContext(1)]
[Nullable(0)]
public class NotObtainedRoleDevWeaponDevData : RoleDevWeaponDevItemDataBase
{
	// Token: 0x0601464A RID: 83530 RVA: 0x005AB81C File Offset: 0x005A9A1C
	protected override void InitByRoleType(int roleId)
	{
		RoleDevProject? roleDevProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(roleId);
		if (roleDevProjectConfig == null)
		{
			return;
		}
		this.WeaponTypeInternal = roleDevProjectConfig.Value.WeaponType;
		this.InitDetailItemData();
	}

	// Token: 0x0601464B RID: 83531 RVA: 0x005AB85A File Offset: 0x005A9A5A
	private void InitDetailItemData()
	{
		this.DetailItemDataInternal.InitByWeaponType(base.RoleId, this.WeaponTypeInternal);
	}

	// Token: 0x0601464C RID: 83532 RVA: 0x005AB873 File Offset: 0x005A9A73
	protected override int GetWeaponLevel()
	{
		return 1;
	}

	// Token: 0x0601464D RID: 83533 RVA: 0x005AB876 File Offset: 0x005A9A76
	protected override int GetWeaponBreachLevel()
	{
		return 0;
	}

	// Token: 0x0601464E RID: 83534 RVA: 0x005AB87C File Offset: 0x005A9A7C
	protected override int GetWeaponGoalUpgradeLevel()
	{
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(base.RoleId);
		if (cultivateProject == null)
		{
			return 0;
		}
		return cultivateProject.Value.WeaponLevel;
	}

	// Token: 0x0601464F RID: 83535 RVA: 0x005AB8B0 File Offset: 0x005A9AB0
	protected override int GetWeaponGoalBreakLevel()
	{
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(base.RoleId);
		if (cultivateProject == null)
		{
			return 0;
		}
		return cultivateProject.Value.WeaponBreachLevel;
	}

	// Token: 0x06014650 RID: 83536 RVA: 0x005AB8E3 File Offset: 0x005A9AE3
	protected override int GetMaxLevel()
	{
		return 0;
	}

	// Token: 0x06014651 RID: 83537 RVA: 0x005AB8E6 File Offset: 0x005A9AE6
	protected override List<IRoleDevDetailItemData> GetDetailItems()
	{
		return this.DetailItemDataInternal.DetailItems;
	}

	// Token: 0x06014652 RID: 83538 RVA: 0x005AB8F4 File Offset: 0x005A9AF4
	protected override string GetWeaponName()
	{
		RoleDevWeaponItem? roleDevWeaponItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(this.WeaponTypeInternal);
		if (roleDevWeaponItemConfig == null)
		{
			return "";
		}
		return roleDevWeaponItemConfig.Value.WeaponTypeDescribe;
	}

	// Token: 0x06014653 RID: 83539 RVA: 0x005AB930 File Offset: 0x005A9B30
	protected override bool GetIsCanUpgrade()
	{
		return base.IsCanShowUpgradeItem;
	}

	// Token: 0x06014654 RID: 83540 RVA: 0x005AB938 File Offset: 0x005A9B38
	protected override bool GetIsCanBreach()
	{
		return base.IsCanShowBreachItem;
	}

	// Token: 0x06014655 RID: 83541 RVA: 0x005AB940 File Offset: 0x005A9B40
	protected override bool GetIsCall()
	{
		return false;
	}

	// Token: 0x06014656 RID: 83542 RVA: 0x005AB943 File Offset: 0x005A9B43
	protected override int GetGachaId()
	{
		return 0;
	}

	// Token: 0x06014657 RID: 83543 RVA: 0x005AB946 File Offset: 0x005A9B46
	protected override int GetWeaponConfigId()
	{
		return 0;
	}

	// Token: 0x06014658 RID: 83544 RVA: 0x005AB949 File Offset: 0x005A9B49
	protected override bool GetIsHighQuality()
	{
		return false;
	}

	// Token: 0x17001A66 RID: 6758
	// (get) Token: 0x06014659 RID: 83545 RVA: 0x005AB94C File Offset: 0x005A9B4C
	public NotObtainedRoleDevWeaponDetailItemData DetailItemData
	{
		get
		{
			return this.DetailItemDataInternal;
		}
	}

	// Token: 0x04009DFB RID: 40443
	private int WeaponTypeInternal;

	// Token: 0x04009DFC RID: 40444
	private readonly NotObtainedRoleDevWeaponDetailItemData DetailItemDataInternal = new NotObtainedRoleDevWeaponDetailItemData();
}
