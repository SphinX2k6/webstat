using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x020018E0 RID: 6368
[NullableContext(1)]
[Nullable(0)]
public class FilterTypeFunctionLibrary
{
	// Token: 0x0600B6F3 RID: 46835 RVA: 0x0030AEC4 File Offset: 0x003090C4
	public static FilterItemData[] GetElementFilterData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (ElementInfo elementInfo in ConfigBase<ElementInfoConfig>.Instance.GetConfigList(idList))
		{
			string elementInfoLocalName = ConfigBase<ElementInfoConfig>.Instance.GetElementInfoLocalName(elementInfo.Name);
			list.Add(new FilterItemData(elementInfo.Id, elementInfoLocalName, elementInfo.Icon4));
		}
		return list.ToArray();
	}

	// Token: 0x0600B6F4 RID: 46836 RVA: 0x0030AF50 File Offset: 0x00309150
	public static FilterItemData[] GetWeaponFilterData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (Mapping mapping in ConfigBase<MappingConfig>.Instance.GetWeaponConfList())
		{
			if (Array.IndexOf<int>(idList, mapping.Value) >= 0)
			{
				string weaponConfComment = ConfigBase<MappingConfig>.Instance.GetWeaponConfComment(mapping.Comment);
				list.Add(new FilterItemData(mapping.Value, weaponConfComment, mapping.Icon));
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600B6F5 RID: 46837 RVA: 0x0030AFE4 File Offset: 0x003091E4
	public static FilterItemData[] GetPhantomFilterData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			string monsterNameByMonsterId = ConfigBase<CalabashConfig>.Instance.GetMonsterNameByMonsterId(num);
			int skillId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(num)[0].SkillId;
			PhantomSkill? phantomSkillBySkillId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillBySkillId(skillId);
			string iconPath = ((phantomSkillBySkillId != null) ? phantomSkillBySkillId.GetValueOrDefault().BattleViewIcon : null) ?? string.Empty;
			FilterItemData item = new FilterItemData(num, monsterNameByMonsterId, iconPath);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B6F6 RID: 46838 RVA: 0x0030B084 File Offset: 0x00309284
	public static FilterItemData[] GetDetectFilterData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			string localFilterTextById = ConfigBase<AdventureGuideConfig>.Instance.GetLocalFilterTextById(num);
			FilterItemData item = new FilterItemData(num, localFilterTextById, null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B6F7 RID: 46839 RVA: 0x0030B0D4 File Offset: 0x003092D4
	public static FilterItemData[] GetCookMenuFilterData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int filterId in idList)
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("Recipe");
			FilterItemData item = new FilterItemData(filterId, textById, null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B6F8 RID: 46840 RVA: 0x0030B124 File Offset: 0x00309324
	public static FilterItemData[] GetCookTypeFilterData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			string id = (num == 1) ? "Attack" : ((num == 2) ? "Defense" : "Explore");
			string textById = ConfigBase<TextConfig>.Instance.GetTextById(id);
			FilterItemData item = new FilterItemData(num, textById, null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B6F9 RID: 46841 RVA: 0x0030B190 File Offset: 0x00309390
	public static FilterItemData[] GetComposeFilterData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int filterId in idList)
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("Formula");
			FilterItemData item = new FilterItemData(filterId, textById, null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B6FA RID: 46842 RVA: 0x0030B1E0 File Offset: 0x003093E0
	public static FilterItemData[] GetPhantomRarityFilterData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int filterId in idList)
		{
			string id = "CalabashCatchGain_" + filterId.ToString();
			string textById = ConfigBase<TextConfig>.Instance.GetTextById(id);
			FilterItemData item = new FilterItemData(filterId, textById, null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B6FB RID: 46843 RVA: 0x0030B244 File Offset: 0x00309444
	public static FilterItemData[] GetPhantomFettersEquipFilterData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			string id = (num == 1) ? "PhantomFettersEquip" : "PhantomFettersUnEquip";
			string textById = ConfigBase<TextConfig>.Instance.GetTextById(id);
			string iconPath = (num == 1) ? ConfigBase<PhantomBattleConfig>.Instance.GetFilterEquipTexture() : ConfigBase<PhantomBattleConfig>.Instance.GetFilterNoEquipTexture();
			FilterItemData item = new FilterItemData(num, textById, iconPath);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B6FC RID: 46844 RVA: 0x0030B2C0 File Offset: 0x003094C0
	public static FilterItemData[] GetPhantomFettersHasFilterData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			string id = (num == 1) ? "PhantomFettersHas" : "PhantomFettersUnHas";
			string textById = ConfigBase<TextConfig>.Instance.GetTextById(id);
			string iconPath = (num == 1) ? ConfigBase<PhantomBattleConfig>.Instance.GetFilterOwnTexture() : ConfigBase<PhantomBattleConfig>.Instance.GetFilterNotOwnTexture();
			FilterItemData item = new FilterItemData(num, textById, iconPath);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B6FD RID: 46845 RVA: 0x0030B339 File Offset: 0x00309539
	public static FilterItemData[] GetPhantomRarityZeroFilterData(int[] idList)
	{
		return FilterTypeFunctionLibrary.GetPhantomRarityFilterDataByRare(idList, 0);
	}

	// Token: 0x0600B6FE RID: 46846 RVA: 0x0030B344 File Offset: 0x00309544
	private static FilterItemData[] GetPhantomRarityFilterDataByRare(int[] idList, int rare)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			IReadOnlyList<PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(num);
			if (phantomItemByMonsterId != null && phantomItemByMonsterId.Count != 0 && ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(phantomItemByMonsterId[0].Rarity).Value.Rare == rare)
			{
				string monsterNameByMonsterId = ConfigBase<CalabashConfig>.Instance.GetMonsterNameByMonsterId(num);
				int skillId = phantomItemByMonsterId[0].SkillId;
				PhantomSkill? phantomSkillBySkillId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillBySkillId(skillId);
				string iconPath = ((phantomSkillBySkillId != null) ? phantomSkillBySkillId.GetValueOrDefault().BattleViewIcon : null) ?? string.Empty;
				FilterItemData item = new FilterItemData(num, monsterNameByMonsterId, iconPath);
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600B6FF RID: 46847 RVA: 0x0030B430 File Offset: 0x00309630
	public static FilterItemData[] GetPhantomRarityOneFilterData(int[] idList)
	{
		return FilterTypeFunctionLibrary.GetPhantomRarityFilterDataByRare(idList, 1);
	}

	// Token: 0x0600B700 RID: 46848 RVA: 0x0030B439 File Offset: 0x00309639
	public static FilterItemData[] GetPhantomRarityTwoFilterData(int[] idList)
	{
		return FilterTypeFunctionLibrary.GetPhantomRarityFilterDataByRare(idList, 2);
	}

	// Token: 0x0600B701 RID: 46849 RVA: 0x0030B442 File Offset: 0x00309642
	public static FilterItemData[] GetPhantomRarityThreeFilterData(int[] idList)
	{
		return FilterTypeFunctionLibrary.GetPhantomRarityFilterDataByRare(idList, 3);
	}

	// Token: 0x0600B702 RID: 46850 RVA: 0x0030B44C File Offset: 0x0030964C
	public static FilterItemData[] GetItemQualityFilterData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			QualityInfo? qualityConfig = ConfigBase<ItemConfig>.Instance.GetQualityConfig(num);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(qualityConfig.Value.Name, null);
			list.Add(new FilterItemData(num, localTextNew, (qualityConfig != null) ? qualityConfig.GetValueOrDefault().FilterIconPath : null));
		}
		return list.ToArray();
	}

	// Token: 0x0600B703 RID: 46851 RVA: 0x0030B4C8 File Offset: 0x003096C8
	public static FilterItemData[] GetVisionDestroyCostData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			int cost = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(num).Value.Cost;
			string id = StringUtils.Format("Cost{0}", new string[]
			{
				cost.ToString()
			});
			string textById = ConfigBase<TextConfig>.Instance.GetTextById(id);
			string visionDestroyCostSpriteByCost = ConfigBase<PhantomBattleConfig>.Instance.GetVisionDestroyCostSpriteByCost(cost);
			FilterItemData item = new FilterItemData(num, textById, visionDestroyCostSpriteByCost);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B704 RID: 46852 RVA: 0x0030B560 File Offset: 0x00309760
	public static FilterItemData[] GetVisionDestroyQualityData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			QualityInfo? qualityConfig = ConfigBase<ItemConfig>.Instance.GetQualityConfig(num);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(qualityConfig.Value.Name, null);
			list.Add(new FilterItemData(num, localTextNew, (qualityConfig != null) ? qualityConfig.GetValueOrDefault().FilterIconPath : null));
		}
		return list.ToArray();
	}

	// Token: 0x0600B705 RID: 46853 RVA: 0x0030B5DC File Offset: 0x003097DC
	public static FilterItemData[] GetVisionDestroyFetterGroupData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(num);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(fetterGroupById.FetterGroupName, null);
			list.Add(new FilterItemData(num, localTextNew, fetterGroupById.FetterElementPath));
		}
		return list.ToArray();
	}

	// Token: 0x0600B706 RID: 46854 RVA: 0x0030B63C File Offset: 0x0030983C
	public static FilterItemData[] GetVisionDestroyAttribute(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			int sortRuleAttributeId = ConfigBase<SortConfig>.Instance.GetSortRuleAttributeId(num, ESortDataType.Phantom);
			string propertyIndexIcon = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexIcon(sortRuleAttributeId);
			string sortRuleName = ConfigBase<SortConfig>.Instance.GetSortRuleName(num, ESortDataType.Phantom);
			list.Add(new FilterItemData(num, sortRuleName, propertyIndexIcon));
		}
		return list.ToArray();
	}

	// Token: 0x0600B707 RID: 46855 RVA: 0x0030B6A4 File Offset: 0x003098A4
	public static FilterItemData[] GetRoleTagFilterList(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			RoleTag? roleTagConfig = ConfigBase<RoleConfig>.Instance.GetRoleTagConfig(num);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(roleTagConfig.Value.TagName, null);
			list.Add(new FilterItemData(num, localTextNew, roleTagConfig.Value.TagIcon));
		}
		return list.ToArray();
	}

	// Token: 0x0600B708 RID: 46856 RVA: 0x0030B714 File Offset: 0x00309914
	public static FilterItemData[] GetItemDeprecateFilterList(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			string id = "";
			switch (num)
			{
			case 0:
				id = "PhantomNotLabeled";
				break;
			case 1:
				id = "EchoAbandoned";
				break;
			case 2:
				id = "PhantomLocked";
				break;
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(id, null);
			string iconPath = (num == 1) ? ConfigBase<PhantomBattleConfig>.Instance.GetVisionRecoveryDesperateIcon() : ConfigBase<PhantomBattleConfig>.Instance.GetVisionRecoveryUnDesperateIcon();
			FilterItemData item = new FilterItemData(num, localTextNew, iconPath);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B709 RID: 46857 RVA: 0x0030B7B0 File Offset: 0x003099B0
	public static FilterItemData[] GetVisionGroupAttributeFilterList(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int ruleId in idList)
		{
			int sortRuleAttributeId = ConfigBase<SortConfig>.Instance.GetSortRuleAttributeId(ruleId, ESortDataType.Attribute);
			int sortRuleAddType = ConfigBase<SortConfig>.Instance.GetSortRuleAddType(ruleId, ESortDataType.Attribute);
			string icon = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(sortRuleAttributeId).Value.Icon;
			string sortRuleName = ConfigBase<SortConfig>.Instance.GetSortRuleName(ruleId, ESortDataType.Attribute);
			FilterItemData item = new FilterItemData(sortRuleAttributeId * 10 + sortRuleAddType, sortRuleName, icon);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B70A RID: 46858 RVA: 0x0030B848 File Offset: 0x00309A48
	public static FilterItemData[] GetFishingTechData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int filterId in idList)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Fishing_TagName" + filterId.ToString(), null);
			FilterItemData item = new FilterItemData(filterId, localTextNew, null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B70B RID: 46859 RVA: 0x0030B8A4 File Offset: 0x00309AA4
	public static FilterItemData[] GetFishingTimeData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(FishingDefine.fishingItemTimeText[num], null);
			FilterItemData item = new FilterItemData(num, localTextNew, null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B70C RID: 46860 RVA: 0x0030B8F8 File Offset: 0x00309AF8
	public static FilterItemData[] GetFishingAreaData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int filterId in idList)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Area_" + filterId.ToString() + "_Title", null);
			FilterItemData item = new FilterItemData(filterId, localTextNew, null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B70D RID: 46861 RVA: 0x0030B958 File Offset: 0x00309B58
	public static FilterItemData[] GetFishingTypeData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(FishingDefine.fishingItemTypeText[num], null);
			FilterItemData item = new FilterItemData(num, localTextNew, null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B70E RID: 46862 RVA: 0x0030B9AC File Offset: 0x00309BAC
	public static FilterItemData[] GetDangoAbyssPluginQualityData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			AbyssQuality? abyssQualityById = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityById(num);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(abyssQualityById.Value.Name);
			FilterItemData item = new FilterItemData(num, multiTextByKey, (abyssQualityById != null) ? abyssQualityById.GetValueOrDefault().FilterIconPath : null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B70F RID: 46863 RVA: 0x0030BA30 File Offset: 0x00309C30
	public static FilterItemData[] GetDangoAbyssPluginPropData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(num);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(propertyIndexInfo.Value.Name);
			FilterItemData item = new FilterItemData(num, multiTextByKey, propertyIndexInfo.Value.Icon);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B710 RID: 46864 RVA: 0x0030BAA8 File Offset: 0x00309CA8
	public static FilterItemData[] GetDangoAbyssPluginTagData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			AbyssPluginPropDesc? dangoPluginPropDescById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoPluginPropDescById(num);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(dangoPluginPropDescById.Value.Name);
			FilterItemData item = new FilterItemData(num, multiTextByKey, dangoPluginPropDescById.Value.Icon);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B711 RID: 46865 RVA: 0x0030BB20 File Offset: 0x00309D20
	public static FilterItemData[] GetDangoAbyssPluginLockStateData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			string key = (num == 1) ? "AbyssItem_Lock1" : "AbyssItem_UnLock1";
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(key);
			FilterItemData item = new FilterItemData(num, multiTextByKey, null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B712 RID: 46866 RVA: 0x0030BB7C File Offset: 0x00309D7C
	public static FilterItemData[] GetPhantomManageFirstMainPropData(int[] sortRuleIdList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in sortRuleIdList)
		{
			int sortRuleAttributeId = ConfigBase<SortConfig>.Instance.GetSortRuleAttributeId(num, ESortDataType.Phantom);
			string propertyIndexIcon = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexIcon(sortRuleAttributeId);
			string sortRuleName = ConfigBase<SortConfig>.Instance.GetSortRuleName(num, ESortDataType.Phantom);
			list.Add(new FilterItemData(num, sortRuleName, propertyIndexIcon));
		}
		return list.ToArray();
	}

	// Token: 0x0600B713 RID: 46867 RVA: 0x0030BBE4 File Offset: 0x00309DE4
	public static FilterItemData[] GetPhantomManageCostData(int[] costList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in costList)
		{
			string id = StringUtils.Format("Cost{0}", new string[]
			{
				num.ToString()
			});
			string textById = ConfigBase<TextConfig>.Instance.GetTextById(id);
			string visionDestroyCostSpriteByCost = ConfigBase<PhantomBattleConfig>.Instance.GetVisionDestroyCostSpriteByCost(num);
			FilterItemData item = new FilterItemData(num, textById, visionDestroyCostSpriteByCost);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B714 RID: 46868 RVA: 0x0030BC5C File Offset: 0x00309E5C
	public static FilterItemData[] GetPinballRoleBdData(int[] bdIdList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in bdIdList)
		{
			PinballBdConfig? pinballBdConfigById = ConfigBase<PinballConfig>.Instance.GetPinballBdConfigById(num);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(pinballBdConfigById.Value.BdName);
			FilterItemData item = new FilterItemData(num, multiTextByKey, (pinballBdConfigById != null) ? pinballBdConfigById.GetValueOrDefault().Icon : null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B715 RID: 46869 RVA: 0x0030BCE0 File Offset: 0x00309EE0
	public static FilterItemData[] GetPinballRoleClassData(int[] classIdList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in classIdList)
		{
			PinballClassConfig? pinballClassConfigById = ConfigBase<PinballConfig>.Instance.GetPinballClassConfigById(num);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(pinballClassConfigById.Value.PinballClassName);
			FilterItemData item = new FilterItemData(num, multiTextByKey, (pinballClassConfigById != null) ? pinballClassConfigById.GetValueOrDefault().Icon : null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B716 RID: 46870 RVA: 0x0030BD64 File Offset: 0x00309F64
	public static FilterItemData[] GetPinballWeaponTypeData(int[] typeIdList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in typeIdList)
		{
			PinballWeaponType? pinballWeaponTypeConfigById = ConfigBase<PinballConfig>.Instance.GetPinballWeaponTypeConfigById(num);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(pinballWeaponTypeConfigById.Value.Name);
			FilterItemData item = new FilterItemData(num, multiTextByKey, (pinballWeaponTypeConfigById != null) ? pinballWeaponTypeConfigById.GetValueOrDefault().Icon3 : null);
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B717 RID: 46871 RVA: 0x0030BDE8 File Offset: 0x00309FE8
	public static FilterItemData[] GetPinballWeaponQualityData(int[] qualityIdList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in qualityIdList)
		{
			PinballWeaponQuality? pinballWeaponQualityConfigById = ConfigBase<PinballConfig>.Instance.GetPinballWeaponQualityConfigById(num);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(pinballWeaponQualityConfigById.Value.Name);
			list.Add(new FilterItemData(num, multiTextByKey, null)
			{
				ChangeColor = pinballWeaponQualityConfigById.Value.Color
			});
		}
		return list.ToArray();
	}

	// Token: 0x0600B718 RID: 46872 RVA: 0x0030BE68 File Offset: 0x0030A068
	public static FilterItemData[] GetRoleLangCustomData(int[] idList)
	{
		List<FilterItemData> list = new List<FilterItemData>();
		foreach (int num in idList)
		{
			RoleVoiceLanguage? roleLangCustomConfigById = ConfigBase<MenuBaseConfig>.Instance.GetRoleLangCustomConfigById(num);
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(roleLangCustomConfigById.Value.Text);
			list.Add(new FilterItemData(num, configTextByKey, null));
		}
		return list.ToArray();
	}
}
