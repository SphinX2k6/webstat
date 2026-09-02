using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200283F RID: 10303
[NullableContext(1)]
[Nullable(0)]
public class RoleDevWeaponSubRecommendItemDataBase
{
	// Token: 0x060146E6 RID: 83686 RVA: 0x005AC816 File Offset: 0x005AAA16
	public void InitByWeaponId(int weaponId, int roleId)
	{
		this.RoleIdInternal = roleId;
		this.WeaponIdInternal = weaponId;
	}

	// Token: 0x17001A89 RID: 6793
	// (get) Token: 0x060146E7 RID: 83687 RVA: 0x005AC826 File Offset: 0x005AAA26
	public int RoleId
	{
		get
		{
			return this.RoleIdInternal;
		}
	}

	// Token: 0x17001A8A RID: 6794
	// (get) Token: 0x060146E8 RID: 83688 RVA: 0x005AC82E File Offset: 0x005AAA2E
	public int WeaponId
	{
		get
		{
			return this.WeaponIdInternal;
		}
	}

	// Token: 0x17001A8B RID: 6795
	// (get) Token: 0x060146E9 RID: 83689 RVA: 0x005AC836 File Offset: 0x005AAA36
	public bool HasRole
	{
		get
		{
			return ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId) != null;
		}
	}

	// Token: 0x17001A8C RID: 6796
	// (get) Token: 0x060146EA RID: 83690 RVA: 0x005AC84C File Offset: 0x005AAA4C
	public string WeaponName
	{
		get
		{
			WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(this.WeaponIdInternal);
			if (weaponConfigByItemId == null)
			{
				return "";
			}
			return weaponConfigByItemId.Value.WeaponName;
		}
	}

	// Token: 0x17001A8D RID: 6797
	// (get) Token: 0x060146EB RID: 83691 RVA: 0x005AC888 File Offset: 0x005AAA88
	public int WeaponQuality
	{
		get
		{
			WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(this.WeaponIdInternal);
			if (weaponConfigByItemId == null)
			{
				return 0;
			}
			return weaponConfigByItemId.Value.QualityId;
		}
	}

	// Token: 0x17001A8E RID: 6798
	// (get) Token: 0x060146EC RID: 83692 RVA: 0x005AC8C0 File Offset: 0x005AAAC0
	public RoleDevWeaponJumpGroup? WeaponJumpGroupConfig
	{
		get
		{
			RoleDevConfig instance = ConfigBase<RoleDevConfig>.Instance;
			if (instance == null)
			{
				return null;
			}
			return instance.GetWeaponJumpGroupConfigByWeaponId(this.WeaponIdInternal);
		}
	}

	// Token: 0x17001A8F RID: 6799
	// (get) Token: 0x060146ED RID: 83693 RVA: 0x005AC8EC File Offset: 0x005AAAEC
	public bool IsCall
	{
		get
		{
			RoleDevWeaponJumpGroup? weaponJumpGroupConfig = this.WeaponJumpGroupConfig;
			if (weaponJumpGroupConfig == null)
			{
				return false;
			}
			int jumpType = weaponJumpGroupConfig.Value.JumpType;
			return (jumpType == 1 || jumpType == 2) && RoleDevUtils.GetRoleGachaIds(this.WeaponIdInternal).Length != 0;
		}
	}

	// Token: 0x17001A90 RID: 6800
	// (get) Token: 0x060146EE RID: 83694 RVA: 0x005AC934 File Offset: 0x005AAB34
	public int GachaId
	{
		get
		{
			RoleDevWeaponJumpGroup? weaponJumpGroupConfig = this.WeaponJumpGroupConfig;
			if (weaponJumpGroupConfig == null)
			{
				return 0;
			}
			int jumpType = weaponJumpGroupConfig.Value.JumpType;
			if (jumpType == 1 || jumpType == 2)
			{
				int[] roleGachaIds = RoleDevUtils.GetRoleGachaIds(this.WeaponIdInternal);
				if (roleGachaIds.Length != 0)
				{
					return roleGachaIds[0];
				}
			}
			return 0;
		}
	}

	// Token: 0x17001A91 RID: 6801
	// (get) Token: 0x060146EF RID: 83695 RVA: 0x005AC980 File Offset: 0x005AAB80
	public bool IsEquipped
	{
		get
		{
			if (!this.HasRole)
			{
				return false;
			}
			int? weaponIdByRoleDataId = ModelBase<WeaponModel>.Instance.GetWeaponIdByRoleDataId(this.RoleId);
			return weaponIdByRoleDataId != null && weaponIdByRoleDataId.Value == this.WeaponId;
		}
	}

	// Token: 0x17001A92 RID: 6802
	// (get) Token: 0x060146F0 RID: 83696 RVA: 0x005AC9C2 File Offset: 0x005AABC2
	public bool IsObtained
	{
		get
		{
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.WeaponId, 0) > 0;
		}
	}

	// Token: 0x04009E0A RID: 40458
	protected int RoleIdInternal;

	// Token: 0x04009E0B RID: 40459
	protected int WeaponIdInternal;
}
