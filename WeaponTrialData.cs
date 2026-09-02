using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002CF3 RID: 11507
[NullableContext(2)]
[Nullable(0)]
public class WeaponTrialData : WeaponDataBase
{
	// Token: 0x06017354 RID: 95060 RVA: 0x0066EA29 File Offset: 0x0066CC29
	public void SetTrialId(int trialId, bool needFullLevelWeaponData = true)
	{
		this.TrialId = trialId;
		this.TrialConfig = ConfigBase<WeaponConfig>.Instance.GetTrialWeaponConfig(this.TrialId);
		this.InitWeaponBreachLevel();
		if (needFullLevelWeaponData)
		{
			this.InitFullLevelWeaponData();
			return;
		}
		this.FullLevelWeaponData = null;
	}

	// Token: 0x06017355 RID: 95061 RVA: 0x0066EA60 File Offset: 0x0066CC60
	protected void InitWeaponBreachLevel()
	{
		IEnumerable<WeaponBreach> breachConfigList = base.GetBreachConfigList();
		int level = this.GetLevel();
		foreach (WeaponBreach weaponBreach in breachConfigList)
		{
			if (level <= weaponBreach.LevelLimit)
			{
				this.BreachLevel = weaponBreach.Level;
				break;
			}
		}
	}

	// Token: 0x06017356 RID: 95062 RVA: 0x0066EAC8 File Offset: 0x0066CCC8
	protected void InitFullLevelWeaponData()
	{
		int fullLevelTrialId = this.TrialConfig.Value.FullLevelTrialId;
		if (fullLevelTrialId <= 0)
		{
			return;
		}
		TrialWeaponInfo? trialWeaponConfig = ConfigBase<WeaponConfig>.Instance.GetTrialWeaponConfig(fullLevelTrialId);
		if (trialWeaponConfig == null)
		{
			this.FullLevelWeaponData = null;
			return;
		}
		this.FullLevelWeaponData = new WeaponTrialData();
		this.FullLevelWeaponData.SetTrialId(trialWeaponConfig.Value.Id, false);
	}

	// Token: 0x06017357 RID: 95063 RVA: 0x0066EB34 File Offset: 0x0066CD34
	public override int GetItemId()
	{
		return this.TrialConfig.Value.WeaponId;
	}

	// Token: 0x06017358 RID: 95064 RVA: 0x0066EB54 File Offset: 0x0066CD54
	public int GetSkinId()
	{
		if (this.TrialConfig.Value.WeaponSkinId > 0)
		{
			return this.TrialConfig.Value.WeaponSkinId;
		}
		return -1;
	}

	// Token: 0x06017359 RID: 95065 RVA: 0x0066EB8C File Offset: 0x0066CD8C
	public override int GetLevel()
	{
		return this.TrialConfig.Value.WeaponLevel;
	}

	// Token: 0x0601735A RID: 95066 RVA: 0x0066EBAC File Offset: 0x0066CDAC
	public override int GetResonanceLevel()
	{
		return this.TrialConfig.Value.WeaponResonanceLevel;
	}

	// Token: 0x0601735B RID: 95067 RVA: 0x0066EBCC File Offset: 0x0066CDCC
	public override int GetBreachLevel()
	{
		return this.BreachLevel;
	}

	// Token: 0x0601735C RID: 95068 RVA: 0x0066EBD4 File Offset: 0x0066CDD4
	public override bool HasRole()
	{
		return this.RoleId != 0;
	}

	// Token: 0x0601735D RID: 95069 RVA: 0x0066EBDF File Offset: 0x0066CDDF
	public override void SetRoleId(int roleId)
	{
		this.RoleId = roleId;
	}

	// Token: 0x0601735E RID: 95070 RVA: 0x0066EBE8 File Offset: 0x0066CDE8
	public override int GetRoleId()
	{
		return this.RoleId;
	}

	// Token: 0x0601735F RID: 95071 RVA: 0x0066EBF0 File Offset: 0x0066CDF0
	public override bool IsTrial()
	{
		return true;
	}

	// Token: 0x06017360 RID: 95072 RVA: 0x0066EBF3 File Offset: 0x0066CDF3
	public override bool CanGoBreach()
	{
		return false;
	}

	// Token: 0x06017361 RID: 95073 RVA: 0x0066EBF6 File Offset: 0x0066CDF6
	public TrialWeaponInfo? GetTrialConfig()
	{
		return this.TrialConfig;
	}

	// Token: 0x06017362 RID: 95074 RVA: 0x0066EBFE File Offset: 0x0066CDFE
	public WeaponTrialData GetFullLevelWeaponData()
	{
		return this.FullLevelWeaponData;
	}

	// Token: 0x0400B280 RID: 45696
	protected int TrialId;

	// Token: 0x0400B281 RID: 45697
	protected TrialWeaponInfo? TrialConfig;

	// Token: 0x0400B282 RID: 45698
	protected WeaponTrialData FullLevelWeaponData;

	// Token: 0x0400B283 RID: 45699
	protected int RoleId;

	// Token: 0x0400B284 RID: 45700
	protected int BreachLevel;
}
