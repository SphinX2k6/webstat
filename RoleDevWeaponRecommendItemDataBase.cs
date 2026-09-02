using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200283D RID: 10301
[NullableContext(1)]
[Nullable(0)]
public abstract class RoleDevWeaponRecommendItemDataBase
{
	// Token: 0x060146CA RID: 83658 RVA: 0x005AC65D File Offset: 0x005AA85D
	public void InitByRoleId(int roleId)
	{
		this.RoleIdInternal = roleId;
		this.InitByRoleType(roleId);
	}

	// Token: 0x060146CB RID: 83659
	protected abstract void InitByRoleType(int roleId);

	// Token: 0x17001A7D RID: 6781
	// (get) Token: 0x060146CC RID: 83660 RVA: 0x005AC66D File Offset: 0x005AA86D
	public int RoleId
	{
		get
		{
			return this.RoleIdInternal;
		}
	}

	// Token: 0x17001A7E RID: 6782
	// (get) Token: 0x060146CD RID: 83661 RVA: 0x005AC675 File Offset: 0x005AA875
	public bool IsRoleObtained
	{
		get
		{
			return ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId) != null;
		}
	}

	// Token: 0x17001A7F RID: 6783
	// (get) Token: 0x060146CE RID: 83662 RVA: 0x005AC68A File Offset: 0x005AA88A
	public List<RoleDevWeaponSubRecommendItemDataBase> SubRecommendItems
	{
		get
		{
			return this.SubRecommendItemsInternal;
		}
	}

	// Token: 0x060146CF RID: 83663
	protected abstract int GetWeaponConfigId();

	// Token: 0x060146D0 RID: 83664
	protected abstract string GetWeaponName();

	// Token: 0x060146D1 RID: 83665
	protected abstract int GetWeaponLevel();

	// Token: 0x060146D2 RID: 83666
	protected abstract int GetWeaponGoalUpgradeLevel();

	// Token: 0x060146D3 RID: 83667
	protected abstract bool GetIsCall();

	// Token: 0x060146D4 RID: 83668
	protected abstract int GetGachaId();

	// Token: 0x060146D5 RID: 83669
	protected abstract bool GetIsWeaponHighQuality();

	// Token: 0x060146D6 RID: 83670
	protected abstract bool GetIsObtained();

	// Token: 0x060146D7 RID: 83671
	protected abstract bool GetIsForecast();

	// Token: 0x17001A80 RID: 6784
	// (get) Token: 0x060146D8 RID: 83672 RVA: 0x005AC692 File Offset: 0x005AA892
	public int WeaponConfigId
	{
		get
		{
			return this.GetWeaponConfigId();
		}
	}

	// Token: 0x17001A81 RID: 6785
	// (get) Token: 0x060146D9 RID: 83673 RVA: 0x005AC69A File Offset: 0x005AA89A
	public string WeaponName
	{
		get
		{
			return this.GetWeaponName();
		}
	}

	// Token: 0x17001A82 RID: 6786
	// (get) Token: 0x060146DA RID: 83674 RVA: 0x005AC6A2 File Offset: 0x005AA8A2
	public int WeaponLevel
	{
		get
		{
			return this.GetWeaponLevel();
		}
	}

	// Token: 0x17001A83 RID: 6787
	// (get) Token: 0x060146DB RID: 83675 RVA: 0x005AC6AA File Offset: 0x005AA8AA
	public int WeaponGoalUpgradeLevel
	{
		get
		{
			return this.GetWeaponGoalUpgradeLevel();
		}
	}

	// Token: 0x17001A84 RID: 6788
	// (get) Token: 0x060146DC RID: 83676 RVA: 0x005AC6B2 File Offset: 0x005AA8B2
	public bool IsCall
	{
		get
		{
			return this.GetIsCall();
		}
	}

	// Token: 0x17001A85 RID: 6789
	// (get) Token: 0x060146DD RID: 83677 RVA: 0x005AC6BA File Offset: 0x005AA8BA
	public int GachaId
	{
		get
		{
			return this.GetGachaId();
		}
	}

	// Token: 0x17001A86 RID: 6790
	// (get) Token: 0x060146DE RID: 83678 RVA: 0x005AC6C2 File Offset: 0x005AA8C2
	public bool IsWeaponHighQuality
	{
		get
		{
			return this.GetIsWeaponHighQuality();
		}
	}

	// Token: 0x17001A87 RID: 6791
	// (get) Token: 0x060146DF RID: 83679 RVA: 0x005AC6CA File Offset: 0x005AA8CA
	public bool IsObtained
	{
		get
		{
			return this.GetIsObtained();
		}
	}

	// Token: 0x17001A88 RID: 6792
	// (get) Token: 0x060146E0 RID: 83680 RVA: 0x005AC6D2 File Offset: 0x005AA8D2
	public bool IsForecast
	{
		get
		{
			return this.GetIsForecast();
		}
	}

	// Token: 0x060146E1 RID: 83681 RVA: 0x005AC6DC File Offset: 0x005AA8DC
	protected void InitSubRecommendItems(int roleId)
	{
		this.SubRecommendItemsInternal.Clear();
		int[] weaponRecommendListConfig = ConfigBase<RoleDevConfig>.Instance.GetWeaponRecommendListConfig(roleId);
		if (weaponRecommendListConfig == null || weaponRecommendListConfig.Length == 0)
		{
			return;
		}
		foreach (int weaponId in weaponRecommendListConfig)
		{
			RoleDevWeaponSubRecommendItemDataBase roleDevWeaponSubRecommendItemDataBase = new RoleDevWeaponSubRecommendItemDataBase();
			roleDevWeaponSubRecommendItemDataBase.InitByWeaponId(weaponId, roleId);
			this.SubRecommendItemsInternal.Add(roleDevWeaponSubRecommendItemDataBase);
		}
	}

	// Token: 0x060146E2 RID: 83682 RVA: 0x005AC73C File Offset: 0x005AA93C
	public bool IsEquipRecommendWeapon()
	{
		int weaponConfigId = this.GetWeaponConfigId();
		if (weaponConfigId <= 0)
		{
			return false;
		}
		using (List<RoleDevWeaponSubRecommendItemDataBase>.Enumerator enumerator = this.SubRecommendItemsInternal.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.WeaponId == weaponConfigId)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x04009E08 RID: 40456
	protected int RoleIdInternal;

	// Token: 0x04009E09 RID: 40457
	protected readonly List<RoleDevWeaponSubRecommendItemDataBase> SubRecommendItemsInternal = new List<RoleDevWeaponSubRecommendItemDataBase>();
}
