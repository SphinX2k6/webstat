using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001499 RID: 5273
[NullableContext(2)]
[Nullable(0)]
public abstract class PinballRoleDataBase
{
	// Token: 0x06009383 RID: 37763 RVA: 0x0026F095 File Offset: 0x0026D295
	public PinballRoleDataBase(int id)
	{
		this.Id = id;
	}

	// Token: 0x06009384 RID: 37764 RVA: 0x0026F0AF File Offset: 0x0026D2AF
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x06009385 RID: 37765 RVA: 0x0026F0B7 File Offset: 0x0026D2B7
	public void SetLevel(int level)
	{
		this.Level = level;
		this.UpdateAttribute();
	}

	// Token: 0x06009386 RID: 37766 RVA: 0x0026F0C6 File Offset: 0x0026D2C6
	public int GetLevel()
	{
		return this.Level;
	}

	// Token: 0x06009387 RID: 37767 RVA: 0x0026F0CE File Offset: 0x0026D2CE
	public void SetWeaponData(PinballWeaponData weaponData)
	{
		this.WeaponData = weaponData;
		this.UpdateAttribute();
	}

	// Token: 0x06009388 RID: 37768 RVA: 0x0026F0DD File Offset: 0x0026D2DD
	public PinballWeaponData GetWeaponData()
	{
		return this.WeaponData;
	}

	// Token: 0x06009389 RID: 37769 RVA: 0x0026F0E5 File Offset: 0x0026D2E5
	[NullableContext(1)]
	public Dictionary<EPinballAttr, int> GetAttributes()
	{
		return this.Attributes;
	}

	// Token: 0x0600938A RID: 37770 RVA: 0x0026F0F0 File Offset: 0x0026D2F0
	public int GetAttribute(EPinballAttr id)
	{
		int result;
		if (!this.Attributes.TryGetValue(id, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x0600938B RID: 37771 RVA: 0x0026F110 File Offset: 0x0026D310
	public PinballRoleConfig GetConfig()
	{
		return ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(this.Id).Value;
	}

	// Token: 0x0600938C RID: 37772 RVA: 0x0026F138 File Offset: 0x0026D338
	protected void UpdateAttribute()
	{
		this.Attributes.Clear();
		int gradeUpGroup = this.GetConfig().GradeUpGroup;
		PinballRoleLevelConfig? pinballRoleLevelConfigByGroupIdAndLevel = ConfigBase<PinballConfig>.Instance.GetPinballRoleLevelConfigByGroupIdAndLevel(gradeUpGroup, this.Level);
		if (pinballRoleLevelConfigByGroupIdAndLevel == null)
		{
			return;
		}
		int prop = pinballRoleLevelConfigByGroupIdAndLevel.Value.Prop;
		PinballAttr? pinballRoleAttrConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleAttrConfigById(prop);
		if (pinballRoleAttrConfigById == null)
		{
			return;
		}
		this.Attributes[EPinballAttr.MaxLife] = pinballRoleAttrConfigById.Value.LifeMax;
		this.Attributes[EPinballAttr.Atk] = pinballRoleAttrConfigById.Value.Atk;
		this.Attributes[EPinballAttr.Def] = pinballRoleAttrConfigById.Value.Def;
		this.Attributes[EPinballAttr.EnergyEfficiency] = pinballRoleAttrConfigById.Value.EnergyEfficiency;
		this.Attributes[EPinballAttr.Crit] = pinballRoleAttrConfigById.Value.Crit;
		this.Attributes[EPinballAttr.CritDamage] = pinballRoleAttrConfigById.Value.CritDamage;
		this.Attributes[EPinballAttr.DamageChange] = pinballRoleAttrConfigById.Value.DamageChange;
		this.Attributes[EPinballAttr.DamageChangeAuto] = pinballRoleAttrConfigById.Value.DamageChangeAuto;
		this.Attributes[EPinballAttr.DamageChangeStrong] = pinballRoleAttrConfigById.Value.DamageChangeStrong;
		this.Attributes[EPinballAttr.DamageChangeSkill] = pinballRoleAttrConfigById.Value.DamageChangeSkill;
		this.Attributes[EPinballAttr.DamageChangeSprint] = pinballRoleAttrConfigById.Value.DamageChangeSprint;
		this.Attributes[EPinballAttr.DamageChangeSummon] = pinballRoleAttrConfigById.Value.DamageChangeSummon;
		this.Attributes[EPinballAttr.HealEfficiency] = pinballRoleAttrConfigById.Value.HealEfficiency;
		this.Attributes[EPinballAttr.ProtectEfficiency] = pinballRoleAttrConfigById.Value.ProtectEfficiency;
		this.Attributes[EPinballAttr.EnergyRecoverSpeed] = pinballRoleAttrConfigById.Value.EnergyRecoverSpeed;
		this.AddWeaponAttribute();
	}

	// Token: 0x0600938D RID: 37773 RVA: 0x0026F358 File Offset: 0x0026D558
	protected void AddWeaponAttribute()
	{
		PinballWeaponData weaponData = this.GetWeaponData();
		if (weaponData == null)
		{
			return;
		}
		foreach (int id in weaponData.PropList)
		{
			PinballWeaponAttr? pinballWeaponAttrConfigById = ConfigBase<PinballConfig>.Instance.GetPinballWeaponAttrConfigById(id);
			if (pinballWeaponAttrConfigById != null)
			{
				EPinballAttr properKey = (EPinballAttr)pinballWeaponAttrConfigById.Value.ProperKey;
				int num2;
				int num = this.Attributes.TryGetValue(properKey, out num2) ? num2 : 0;
				this.Attributes[properKey] = num + (int)pinballWeaponAttrConfigById.Value.ProperVal;
			}
		}
	}

	// Token: 0x0600938E RID: 37774
	public abstract bool IsLocked();

	// Token: 0x04004440 RID: 17472
	protected int Id;

	// Token: 0x04004441 RID: 17473
	protected int Level;

	// Token: 0x04004442 RID: 17474
	protected PinballWeaponData WeaponData;

	// Token: 0x04004443 RID: 17475
	[Nullable(1)]
	protected Dictionary<EPinballAttr, int> Attributes = new Dictionary<EPinballAttr, int>();
}
