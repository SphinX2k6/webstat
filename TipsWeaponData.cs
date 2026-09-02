using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

// Token: 0x02001987 RID: 6535
[NullableContext(1)]
[Nullable(0)]
public class TipsWeaponData : ItemTipsData
{
	// Token: 0x0600BBE3 RID: 48099 RVA: 0x0031E054 File Offset: 0x0031C254
	public TipsWeaponData(ItemTipsParam data) : base(data)
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.IncId);
		WeaponConf? weaponConf = (this.IncId != 0) ? attributeItemData.GetConfig().As<WeaponConf>() : ConfigBase<InventoryConfig>.Instance.GetWeaponItemConfig(this.ConfigId);
		if (weaponConf == null)
		{
			return;
		}
		WeaponInstance weaponInstance = (this.IncId != 0) ? ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.IncId) : null;
		WeaponConf? weaponConf2 = (weaponInstance != null) ? weaponInstance.GetWeaponConfig() : ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(weaponConf.Value.ItemId);
		int num = (weaponInstance != null) ? weaponInstance.GetBreachLevel() : 0;
		int num2 = (weaponInstance != null) ? weaponInstance.GetResonanceLevel() : 1;
		WeaponBreach? weaponBreach = (weaponInstance != null) ? weaponInstance.GetBreachConfig() : ConfigBase<WeaponConfig>.Instance.GetWeaponBreach(weaponConf2.Value.BreachId, num);
		int breachId = weaponConf2.Value.BreachId;
		WeaponReson? weaponResonanceConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponResonanceConfig(weaponConf2.Value.ResonId, num2);
		this.ItemType = EItemTipsType.Weapon;
		this.WeaponType = ConfigBase<WeaponConfig>.Instance.GetWeaponTypeName(weaponConf2.Value.WeaponType);
		int num3 = (weaponInstance != null) ? weaponInstance.GetLevel() : 1;
		int levelLimit = weaponBreach.Value.LevelLimit;
		this.WeaponLevel = num3;
		this.WeaponLimitLevel = levelLimit;
		this.BreachLevel = num;
		int weaponBreachMaxLevel = ModelBase<WeaponModel>.Instance.GetWeaponBreachMaxLevel(breachId);
		this.BreachMaxLevel = weaponBreachMaxLevel;
		this.WeaponStage = num2;
		this.WeaponSkillName = weaponResonanceConfig.Value.Name;
		this.WeaponEffect = weaponConf2.Value.Desc;
		string[] weaponConfigDescParams = ModelBase<WeaponModel>.Instance.GetWeaponConfigDescParams(weaponConf2.Value, num2);
		this.WeaponEffectParam = weaponConfigDescParams;
		this.WeaponDescription = weaponConf2.Value.AttributesDescription;
		List<ITipsAttributeItemData> list = new List<ITipsAttributeItemData>();
		int id = weaponConf2.Value.FirstPropId.Value.Id;
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(id);
		float curveValue = ModelBase<WeaponModel>.Instance.GetCurveValue(weaponConf2.Value.FirstCurve, weaponConf2.Value.FirstPropId.Value.Value, num3, num);
		TipsAttributeItemData item = new TipsAttributeItemData
		{
			Id = id,
			IsMainAttribute = true,
			Name = propertyIndexInfo.Value.Name,
			IconPath = propertyIndexInfo.Value.Icon,
			Value = (double)curveValue,
			IsRatio = weaponConf2.Value.FirstPropId.Value.IsRatio
		};
		int id2 = weaponConf2.Value.SecondPropId.Value.Id;
		propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(id2);
		float curveValue2 = ModelBase<WeaponModel>.Instance.GetCurveValue(weaponConf2.Value.SecondCurve, weaponConf2.Value.SecondPropId.Value.Value, num3, num);
		TipsAttributeItemData item2 = new TipsAttributeItemData
		{
			Id = id2,
			IsMainAttribute = true,
			Name = propertyIndexInfo.Value.Name,
			IconPath = propertyIndexInfo.Value.Icon,
			Value = (double)curveValue2,
			IsRatio = weaponConf2.Value.SecondPropId.Value.IsRatio
		};
		list.Add(item);
		list.Add(item2);
		this.AttributeData = list.ToArray();
		if (weaponInstance != null)
		{
			this.EquippedId = new int?(weaponInstance.GetRoleId());
			int? equippedId = this.EquippedId;
			int num4 = 0;
			this.IsEquip = !(equippedId.GetValueOrDefault() == num4 & equippedId != null);
		}
	}

	// Token: 0x0600BBE4 RID: 48100 RVA: 0x0031E497 File Offset: 0x0031C697
	protected override bool OnIsShowIconBig()
	{
		return true;
	}

	// Token: 0x040058D9 RID: 22745
	public string WeaponType = "";

	// Token: 0x040058DA RID: 22746
	public int WeaponLevel;

	// Token: 0x040058DB RID: 22747
	public int WeaponLimitLevel;

	// Token: 0x040058DC RID: 22748
	public int BreachLevel;

	// Token: 0x040058DD RID: 22749
	public int BreachMaxLevel;

	// Token: 0x040058DE RID: 22750
	public int WeaponStage;

	// Token: 0x040058DF RID: 22751
	public string WeaponSkillName = "";

	// Token: 0x040058E0 RID: 22752
	public string WeaponEffect = "";

	// Token: 0x040058E1 RID: 22753
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] WeaponEffectParam;

	// Token: 0x040058E2 RID: 22754
	public string WeaponDescription = "";

	// Token: 0x040058E3 RID: 22755
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public ITipsAttributeItemData[] AttributeData;

	// Token: 0x040058E4 RID: 22756
	public bool IsEquip;

	// Token: 0x040058E5 RID: 22757
	public int? EquippedId;
}
