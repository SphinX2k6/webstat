using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02002D11 RID: 11537
public class WeaponInstance : WeaponDataBase
{
	// Token: 0x06017475 RID: 95349 RVA: 0x00673ECB File Offset: 0x006720CB
	[NullableContext(1)]
	public void SetWeaponItem(WeaponItem weaponItem)
	{
		this.WeaponItem = weaponItem;
	}

	// Token: 0x06017476 RID: 95350 RVA: 0x00673ED4 File Offset: 0x006720D4
	public void SetLevel(int level)
	{
		this.WeaponItem.WeaponLevel = level;
	}

	// Token: 0x06017477 RID: 95351 RVA: 0x00673EE2 File Offset: 0x006720E2
	public override int GetLevel()
	{
		return this.WeaponItem.WeaponLevel;
	}

	// Token: 0x06017478 RID: 95352 RVA: 0x00673EEF File Offset: 0x006720EF
	public void SetExp(int exp)
	{
		this.WeaponItem.WeaponExp = exp;
	}

	// Token: 0x06017479 RID: 95353 RVA: 0x00673EFD File Offset: 0x006720FD
	public int GetExp()
	{
		return this.WeaponItem.WeaponExp;
	}

	// Token: 0x0601747A RID: 95354 RVA: 0x00673F0A File Offset: 0x0067210A
	public void SetResonanceLevel(int resonanceLevel)
	{
		this.WeaponItem.WeaponResonLevel = resonanceLevel;
	}

	// Token: 0x0601747B RID: 95355 RVA: 0x00673F18 File Offset: 0x00672118
	public override int GetResonanceLevel()
	{
		return this.WeaponItem.WeaponResonLevel;
	}

	// Token: 0x0601747C RID: 95356 RVA: 0x00673F25 File Offset: 0x00672125
	public void SetBreachLevel(int breachLevel)
	{
		this.WeaponItem.WeaponBreach = breachLevel;
	}

	// Token: 0x0601747D RID: 95357 RVA: 0x00673F33 File Offset: 0x00672133
	public override int GetBreachLevel()
	{
		return this.WeaponItem.WeaponBreach;
	}

	// Token: 0x0601747E RID: 95358 RVA: 0x00673F40 File Offset: 0x00672140
	public int? GetIncId()
	{
		return new int?(this.WeaponItem.IncrId);
	}

	// Token: 0x0601747F RID: 95359 RVA: 0x00673F54 File Offset: 0x00672154
	public override int GetItemId()
	{
		int? incId = this.GetIncId();
		return ModelBase<InventoryModel>.Instance.GetWeaponItemData(incId.Value).GetConfigId();
	}

	// Token: 0x06017480 RID: 95360 RVA: 0x00673F80 File Offset: 0x00672180
	public bool IsLock()
	{
		int? incId = this.GetIncId();
		return ModelBase<InventoryModel>.Instance.GetWeaponItemData(incId.Value).GetIsLock();
	}

	// Token: 0x06017481 RID: 95361 RVA: 0x00673FAA File Offset: 0x006721AA
	public override bool IsTrial()
	{
		return false;
	}

	// Token: 0x06017482 RID: 95362 RVA: 0x00673FAD File Offset: 0x006721AD
	public override bool HasRole()
	{
		return this.GetRoleId() > 0;
	}

	// Token: 0x06017483 RID: 95363 RVA: 0x00673FB8 File Offset: 0x006721B8
	public override void SetRoleId(int roleId)
	{
		this.WeaponItem.RoleId = roleId;
	}

	// Token: 0x06017484 RID: 95364 RVA: 0x00673FC6 File Offset: 0x006721C6
	public override int GetRoleId()
	{
		return this.WeaponItem.RoleId;
	}

	// Token: 0x06017485 RID: 95365 RVA: 0x00673FD4 File Offset: 0x006721D4
	public int GetMaterialExp()
	{
		int qualityId = base.GetItemConfig().QualityId;
		WeaponQualityInfo? weaponQualityInfo = ConfigBase<WeaponConfig>.Instance.GetWeaponQualityInfo(qualityId);
		int exp = this.GetExp();
		int level = this.GetLevel();
		if (exp <= 0 && level == 1)
		{
			return weaponQualityInfo.Value.BasicExp;
		}
		float weaponExpCoefficient = ConfigBase<WeaponConfig>.Instance.GetWeaponExpCoefficient();
		return (int)Math.Floor((double)((float)weaponQualityInfo.Value.BasicExp + (float)(base.GetLastLevelMaxExp() + exp) * weaponExpCoefficient));
	}

	// Token: 0x06017486 RID: 95366 RVA: 0x00674058 File Offset: 0x00672258
	public bool HasWeaponCultivated()
	{
		bool flag = this.GetResonanceLevel() > 1;
		bool flag2 = this.GetLevel() > 1;
		bool flag3 = this.GetExp() > 0;
		return flag || flag2 || flag3;
	}

	// Token: 0x0400B2E4 RID: 45796
	[Nullable(2)]
	protected WeaponItem WeaponItem;
}
