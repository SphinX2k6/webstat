using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02001A72 RID: 6770
[NullableContext(2)]
[Nullable(0)]
public class CommonTipsComponentUtil
{
	// Token: 0x0600C1C8 RID: 49608 RVA: 0x0033090C File Offset: 0x0032EB0C
	public static WeaponTipsData GetWeaponTipsDataByUniqueId(int uniqueId)
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(uniqueId);
		if (attributeItemData == null)
		{
			return null;
		}
		TItemConfig config = attributeItemData.GetConfig();
		if (attributeItemData.GetItemDataType() != InventoryDefine.EItemDataType.WeaponItem)
		{
			return null;
		}
		return CommonTipsComponentUtil.GetWeaponTipsData(config.As<WeaponConf>().Value, new int?(uniqueId));
	}

	// Token: 0x0600C1C9 RID: 49609 RVA: 0x00330958 File Offset: 0x0032EB58
	public static PhantomTipsData GetPhantomTipsDataByUniqueId(int uniqueId)
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(uniqueId);
		if (attributeItemData == null)
		{
			return null;
		}
		TItemConfig config = attributeItemData.GetConfig();
		if (attributeItemData.GetItemDataType() != InventoryDefine.EItemDataType.PhantomItem)
		{
			return null;
		}
		return CommonTipsComponentUtil.GetPhantomTipsData(config.As<Aki.Config.PhantomItem>().Value, new int?(uniqueId));
	}

	// Token: 0x0600C1CA RID: 49610 RVA: 0x003309A4 File Offset: 0x0032EBA4
	public static CommonTipsBaseData GetTipsDataByItemId(int itemId)
	{
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemId));
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.WeaponItem)
		{
			return CommonTipsComponentUtil.GetWeaponTipsData(ConfigBase<InventoryConfig>.Instance.GetWeaponItemConfig(itemId).Value, new int?(itemId));
		}
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.PhantomItem)
		{
			return CommonTipsComponentUtil.GetPhantomTipsData(ConfigBase<InventoryConfig>.Instance.GetPhantomItemConfig(itemId).Value, new int?(itemId));
		}
		return null;
	}

	// Token: 0x0600C1CB RID: 49611 RVA: 0x00330A0C File Offset: 0x0032EC0C
	public static WeaponTipsData GetWeaponTipsDataByItemId(int itemId)
	{
		WeaponConf? weaponItemConfig = ConfigBase<InventoryConfig>.Instance.GetWeaponItemConfig(itemId);
		if (weaponItemConfig == null)
		{
			return null;
		}
		return CommonTipsComponentUtil.GetWeaponTipsData(weaponItemConfig.Value, null);
	}

	// Token: 0x0600C1CC RID: 49612 RVA: 0x00330A48 File Offset: 0x0032EC48
	public static PhantomTipsData GetPhantomTipsDataByItemId(int itemId)
	{
		Aki.Config.PhantomItem? phantomItemConfig = ConfigBase<InventoryConfig>.Instance.GetPhantomItemConfig(itemId);
		if (phantomItemConfig == null)
		{
			return null;
		}
		return CommonTipsComponentUtil.GetPhantomTipsData(phantomItemConfig.Value, null);
	}

	// Token: 0x0600C1CD RID: 49613 RVA: 0x00330A84 File Offset: 0x0032EC84
	[NullableContext(1)]
	protected static WeaponTipsData GetWeaponTipsData(WeaponConf config, int? incId = null)
	{
		WeaponTipsData weaponTipsData = new WeaponTipsData();
		WeaponInstance weaponInstance = (incId != null) ? ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId.Value) : null;
		WeaponConf? weaponConf = (weaponInstance != null) ? weaponInstance.GetWeaponConfig() : ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(config.ItemId);
		int num = (weaponInstance != null) ? weaponInstance.GetBreachLevel() : 0;
		int resonanceLevel = (weaponInstance != null) ? weaponInstance.GetResonanceLevel() : 1;
		WeaponBreach? weaponBreach = (weaponInstance != null) ? weaponInstance.GetBreachConfig() : ConfigBase<WeaponConfig>.Instance.GetWeaponBreach(weaponConf.Value.BreachId, num);
		int level = (weaponInstance != null) ? weaponInstance.GetLevel() : 1;
		int levelLimit = weaponBreach.Value.LevelLimit;
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("WeaponLevelUpLevelText");
		int breachId = weaponConf.Value.BreachId;
		int weaponBreachMaxLevel = ModelBase<WeaponModel>.Instance.GetWeaponBreachMaxLevel(breachId);
		float curveValue = ModelBase<WeaponModel>.Instance.GetCurveValue(weaponConf.Value.FirstCurve, weaponConf.Value.FirstPropId.Value.Value, level, num);
		CSharpScript.Game.Module.Common.AttributeData item = new CSharpScript.Game.Module.Common.AttributeData
		{
			Id = weaponConf.Value.FirstPropId.Value.Id,
			IsRatio = weaponConf.Value.FirstPropId.Value.IsRatio,
			CurValue = curveValue
		};
		float curveValue2 = ModelBase<WeaponModel>.Instance.GetCurveValue(weaponConf.Value.SecondCurve, weaponConf.Value.SecondPropId.Value.Value, level, num);
		CSharpScript.Game.Module.Common.AttributeData item2 = new CSharpScript.Game.Module.Common.AttributeData
		{
			Id = weaponConf.Value.SecondPropId.Value.Id,
			IsRatio = weaponConf.Value.SecondPropId.Value.IsRatio,
			CurValue = curveValue2
		};
		weaponTipsData.IncId = incId;
		weaponTipsData.ConfigId = config.ItemId;
		weaponTipsData.Name = config.WeaponName;
		weaponTipsData.QualityId = config.QualityId;
		weaponTipsData.ItemType = CommonComponentDefine.ECommonTipsType.Weapon;
		weaponTipsData.BgDescription = config.BgDescription;
		weaponTipsData.LevelText = StringUtils.Format(textById, new string[]
		{
			level.ToString(),
			levelLimit.ToString()
		});
		weaponTipsData.CurrentStar = num;
		weaponTipsData.MaxStar = weaponBreachMaxLevel;
		weaponTipsData.Type = ConfigBase<WeaponConfig>.Instance.GetWeaponTypeName(weaponConf.Value.WeaponType);
		weaponTipsData.AttributeList.Add(item);
		weaponTipsData.AttributeList.Add(item2);
		weaponTipsData.ResonanceLevel = resonanceLevel;
		if (weaponInstance != null)
		{
			weaponTipsData.EquippedId = weaponInstance.GetRoleId();
			if (weaponTipsData.EquippedId != 0)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(weaponTipsData.EquippedId, true);
				weaponTipsData.EquippedIcon = roleDataById.GetRoleConfig().RoleHeadIcon;
				weaponTipsData.EquippedName = roleDataById.GetName(null);
			}
		}
		return weaponTipsData;
	}

	// Token: 0x0600C1CE RID: 49614 RVA: 0x00330DB8 File Offset: 0x0032EFB8
	[NullableContext(1)]
	protected static PhantomTipsData GetPhantomTipsData(Aki.Config.PhantomItem config, int? incId = null)
	{
		PhantomTipsData phantomTipsData = new PhantomTipsData();
		PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
		PhantomBattleData phantomBattleData = (incId != null) ? instance.GetPhantomBattleData(incId.Value) : null;
		int itemId = config.ItemId;
		int levelLimit = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityByItemQuality(config.QualityId).Value.LevelLimit;
		int level = (phantomBattleData != null) ? phantomBattleData.GetPhantomLevel() : 1;
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(config.TypeDescription, null);
		phantomTipsData.Name = config.MonsterName;
		phantomTipsData.IncId = incId;
		phantomTipsData.ConfigId = itemId;
		phantomTipsData.QualityId = config.QualityId;
		phantomTipsData.ItemType = CommonComponentDefine.ECommonTipsType.Phantom;
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("LevelShow");
		phantomTipsData.LevelText = StringUtils.Format(textById, new string[]
		{
			level.ToString()
		});
		string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("RoleMaxLevel02");
		phantomTipsData.MaxLevelText = StringUtils.Format(textById2, new string[]
		{
			levelLimit.ToString()
		});
		phantomTipsData.Level = level;
		phantomTipsData.Type = (localTextNew ?? "");
		phantomTipsData.PhantomId = config.MonsterId;
		int? equipRole = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(incId.Value);
		if (equipRole != null)
		{
			phantomTipsData.EquippedId = equipRole.Value;
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(equipRole.Value, true);
			phantomTipsData.EquippedIcon = roleDataById.GetRoleConfig().RoleHeadIcon;
			phantomTipsData.EquippedName = roleDataById.GetName(null);
		}
		phantomTipsData.RarityId = "CalabashCatchGain_" + config.Rarity.ToString();
		phantomTipsData.PropertyTexture = ConfigBase<CommonConfig>.Instance.GetElementConfig(config.ElementType(0)).Value.Icon;
		phantomTipsData.PropertyId = config.ElementType(0);
		PhantomBattleInstance phantomInstanceByItemId = instance.GetPhantomInstanceByItemId(itemId);
		if (phantomInstanceByItemId != null)
		{
			PhantomSkill? phantomSkillInfoByLevel = phantomInstanceByItemId.GetPhantomSkillInfoByLevel();
			phantomTipsData.MainSkillText = phantomSkillInfoByLevel.Value.DescriptionEx;
			string[] phantomSkillDescExBySkillIdAndQuality = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillDescExBySkillIdAndQuality(phantomSkillInfoByLevel.Value.Id, config.QualityId);
			phantomTipsData.MainSkillParameter = phantomSkillDescExBySkillIdAndQuality;
			phantomTipsData.SkillIcon = phantomInstanceByItemId.PhantomItem.Value.SkillIcon;
		}
		else
		{
			PhantomBattleConfig instance2 = ConfigBase<PhantomBattleConfig>.Instance;
			Aki.Config.PhantomItem? phantomItemById = instance2.GetPhantomItemById(itemId);
			if (phantomItemById != null)
			{
				int skillId = phantomItemById.Value.SkillId;
				PhantomSkill? phantomSkillBySkillId = instance2.GetPhantomSkillBySkillId(skillId);
				if (phantomSkillBySkillId != null)
				{
					phantomTipsData.MainSkillText = phantomSkillBySkillId.Value.DescriptionEx;
					string[] phantomSkillDescExByPhantomSkillIdAndQuality = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillDescExByPhantomSkillIdAndQuality(skillId, config.QualityId);
					phantomTipsData.MainSkillParameter = phantomSkillDescExByPhantomSkillIdAndQuality;
					phantomTipsData.SkillIcon = phantomItemById.Value.SkillIcon;
				}
			}
		}
		phantomTipsData.IsBreak = false;
		List<Aki.Protocol.PhantomPropInfo> list = (phantomBattleData != null) ? phantomBattleData.GetPhantomMainProp() : null;
		phantomTipsData.IsMain = ControllerBase<PhantomBattleController>.Instance.CheckIsMain(incId.Value);
		if (list != null && list.Count > 0)
		{
			foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in list)
			{
				PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(phantomPropInfo.PhantomPropId);
				PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(phantomMainPropertyItemId.PropId);
				bool isRatio = propertyIndexInfo.Value.IsPercent > false;
				phantomTipsData.MainAttributeList.Add(new CommonComponentDefine.TipsAttributeData(propertyIndexInfo.Value.Id, (double)phantomPropInfo.Value, isRatio));
			}
		}
		List<Aki.Protocol.PhantomPropInfo> list2 = (phantomBattleData != null) ? phantomBattleData.GetPhantomSubProp() : null;
		phantomTipsData.IsSub = ControllerBase<PhantomBattleController>.Instance.CheckIsSub(incId.Value);
		if (list2 != null && list2.Count > 0)
		{
			phantomTipsData.IsUnlockSub = true;
			foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo2 in list2)
			{
				bool isRatio2 = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(phantomPropInfo2.PhantomPropId).AddType == 2;
				phantomTipsData.SubAttributeList.Add(new CommonComponentDefine.TipsAttributeData(phantomPropInfo2.PhantomPropId, (double)phantomPropInfo2.Value, isRatio2));
			}
		}
		return phantomTipsData;
	}
}
