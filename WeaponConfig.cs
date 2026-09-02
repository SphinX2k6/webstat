using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002CFC RID: 11516
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class WeaponConfig : ConfigBase<WeaponConfig>
{
	// Token: 0x060173EE RID: 95214 RVA: 0x006722D9 File Offset: 0x006704D9
	public WeaponConf? GetWeaponConfigByItemId(int itemId)
	{
		return ConfigWeaponConfByItemId.GetConfig(itemId, true);
	}

	// Token: 0x060173EF RID: 95215 RVA: 0x006722E2 File Offset: 0x006704E2
	[return: Nullable(2)]
	public string GetWeaponName(string weaponNameId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(weaponNameId, null);
	}

	// Token: 0x060173F0 RID: 95216 RVA: 0x006722EC File Offset: 0x006704EC
	public unsafe WeaponPropertyGrowth? GetWeaponPropertyGrowthConfig(int curveId, int level, int breach)
	{
		WeaponPropertyGrowth? config = ConfigWeaponPropertyGrowthByCurveIdLevelAndBreachLevel.GetConfig(curveId, level, breach, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "武器基础配置表格查找武器成长数值失败 WeaponPropertyGrowth";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("曲线id", curveId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("等级", level);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("突破等级", breach);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		return config;
	}

	// Token: 0x060173F1 RID: 95217 RVA: 0x00672388 File Offset: 0x00670588
	public unsafe WeaponReson? GetWeaponResonanceConfig(int resonanceId, int level)
	{
		WeaponReson? config = ConfigWeaponResonByResonIdAndLevel.GetConfig(resonanceId, level, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "武器基础配置表格查找武器共鸣配置[WeaponReson]失败,请查看对应表格";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("共鸣组id", resonanceId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("共鸣等级", level);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return config;
	}

	// Token: 0x060173F2 RID: 95218 RVA: 0x00672405 File Offset: 0x00670605
	[return: Nullable(2)]
	public string GetWeaponResonanceDesc(string descId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(descId, null);
	}

	// Token: 0x060173F3 RID: 95219 RVA: 0x0067240E File Offset: 0x0067060E
	[return: Nullable(2)]
	public string GetWeaponResonanceName(string resonanceNameId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(resonanceNameId, null);
	}

	// Token: 0x060173F4 RID: 95220 RVA: 0x00672418 File Offset: 0x00670618
	[NullableContext(2)]
	public string GetWeaponTypeName(int typeId)
	{
		Mapping? config = ConfigMappingBySheetNameFieldNameAndValue.GetConfig("WeaponConf", "WeaponType", typeId, true);
		if (config != null)
		{
			return ConfigMultiTextLang.GetLocalTextNew(config.Value.Comment, null);
		}
		return null;
	}

	// Token: 0x060173F5 RID: 95221 RVA: 0x00672458 File Offset: 0x00670658
	[NullableContext(2)]
	public string GetWeaponIconPath(int typeId)
	{
		IReadOnlyList<Mapping> configList = ConfigMappingBySheetNameAndFieldName.GetConfigList("WeaponConf", "WeaponType", true);
		if (configList != null)
		{
			foreach (Mapping mapping in configList)
			{
				if (typeId == mapping.Value)
				{
					return mapping.Icon;
				}
			}
		}
		return null;
	}

	// Token: 0x060173F6 RID: 95222 RVA: 0x006724C4 File Offset: 0x006706C4
	[NullableContext(2)]
	public IReadOnlyList<WeaponBreach> GetWeaponBreachList(int breachId)
	{
		return ConfigWeaponBreachByBreachId.GetConfigList(breachId, true);
	}

	// Token: 0x060173F7 RID: 95223 RVA: 0x006724CD File Offset: 0x006706CD
	[NullableContext(2)]
	public IReadOnlyList<WeaponLevel> GetWeaponLevelList(int levelId)
	{
		return ConfigWeaponLevelByLevelId.GetConfigList(levelId, true);
	}

	// Token: 0x060173F8 RID: 95224 RVA: 0x006724D6 File Offset: 0x006706D6
	public WeaponLevel? GetWeaponLevelConfig(int levelId, int level)
	{
		return ConfigWeaponLevelByLevelIdAndLevel.GetConfig(levelId, level, true);
	}

	// Token: 0x060173F9 RID: 95225 RVA: 0x006724E0 File Offset: 0x006706E0
	public WeaponBreach? GetWeaponBreach(int breachId, int breachLevel)
	{
		return ConfigWeaponBreachByBreachIdAndLevel.GetConfig(breachId, breachLevel, true);
	}

	// Token: 0x060173FA RID: 95226 RVA: 0x006724EC File Offset: 0x006706EC
	public int GetWeaponLevelLimit(int qualityId)
	{
		WeaponQualityInfo? config = ConfigWeaponQualityInfoById.GetConfig(qualityId, true);
		if (config == null)
		{
			return 0;
		}
		return config.GetValueOrDefault().LevelLimit;
	}

	// Token: 0x060173FB RID: 95227 RVA: 0x0067251B File Offset: 0x0067071B
	public WeaponExpItem? GetWeaponExpItemConfig(int itemId)
	{
		return ConfigWeaponExpItemById.GetConfig(itemId, true);
	}

	// Token: 0x060173FC RID: 95228 RVA: 0x00672524 File Offset: 0x00670724
	public WeaponQualityInfo? GetWeaponQualityInfo(int qualityId)
	{
		return ConfigWeaponQualityInfoById.GetConfig(qualityId, true);
	}

	// Token: 0x060173FD RID: 95229 RVA: 0x00672530 File Offset: 0x00670730
	public float GetWeaponLevelUpCostRatio()
	{
		return (float)ConfigCommonParamById.GetIntConfig("WeaponLevelUpCoinCost").GetValueOrDefault() / 1000f;
	}

	// Token: 0x060173FE RID: 95230 RVA: 0x00672558 File Offset: 0x00670758
	public float GetWeaponExpCoefficient()
	{
		return (float)ConfigCommonParamById.GetIntConfig("WeaponStrengthenExpCost").GetValueOrDefault() / 1000f;
	}

	// Token: 0x060173FF RID: 95231 RVA: 0x00672580 File Offset: 0x00670780
	public int GetWeaponQualityCheck()
	{
		return ConfigCommonParamById.GetIntConfig("weapon_strengthen_panel_restrain1").GetValueOrDefault();
	}

	// Token: 0x06017400 RID: 95232 RVA: 0x006725A0 File Offset: 0x006707A0
	public int GetWeaponLevelCheck()
	{
		return ConfigCommonParamById.GetIntConfig("weapon_strengthen_panel_restrain2").GetValueOrDefault();
	}

	// Token: 0x06017401 RID: 95233 RVA: 0x006725C0 File Offset: 0x006707C0
	public int GetWeaponResonanceCheck()
	{
		return ConfigCommonParamById.GetIntConfig("weapon_quick_strengthen_restrain_num").GetValueOrDefault();
	}

	// Token: 0x06017402 RID: 95234 RVA: 0x006725E0 File Offset: 0x006707E0
	public int GetMaterialItemMaxCount()
	{
		return ConfigCommonParamById.GetIntConfig("weapon_strengthen_num_limit").GetValueOrDefault();
	}

	// Token: 0x06017403 RID: 95235 RVA: 0x006725FF File Offset: 0x006707FF
	public QualityInfo? GetItemQuality(int qualityId)
	{
		return ConfigQualityInfoById.GetConfig(qualityId, true);
	}

	// Token: 0x06017404 RID: 95236 RVA: 0x00672608 File Offset: 0x00670808
	public WeaponModelTransform? GetWeaponModelTransformData(int transformId)
	{
		return ConfigWeaponModelTransformById.GetConfig(transformId, true);
	}

	// Token: 0x06017405 RID: 95237 RVA: 0x00672611 File Offset: 0x00670811
	public TrialWeaponInfo? GetTrialWeaponConfig(int id)
	{
		return ConfigTrialWeaponInfoById.GetConfig(id, true);
	}

	// Token: 0x06017406 RID: 95238 RVA: 0x0067261A File Offset: 0x0067081A
	[NullableContext(2)]
	public List<WeaponConf> GetWeaponForHandBook()
	{
		IReadOnlyList<WeaponConf> configList = ConfigWeaponConfByIsShow.GetConfigList(true, true);
		if (configList == null)
		{
			return null;
		}
		return configList.ToList<WeaponConf>();
	}

	// Token: 0x06017407 RID: 95239 RVA: 0x0067262E File Offset: 0x0067082E
	[NullableContext(2)]
	public List<WeaponSkin> GetWeaponSkinForHandBook()
	{
		IReadOnlyList<WeaponSkin> configList = ConfigWeaponSkinByIsShow.GetConfigList(true, true);
		if (configList == null)
		{
			return null;
		}
		return configList.ToList<WeaponSkin>();
	}

	// Token: 0x06017408 RID: 95240 RVA: 0x00672644 File Offset: 0x00670844
	public WeaponSkin GetWeaponSkinConfig(int id)
	{
		return ConfigWeaponSkinById.GetConfig(id, true).Value;
	}

	// Token: 0x06017409 RID: 95241 RVA: 0x00672660 File Offset: 0x00670860
	[NullableContext(2)]
	public List<WeaponExpItem> GetWeaponExpItemList()
	{
		IReadOnlyList<WeaponExpItem> configList = ConfigWeaponExpItemAll.GetConfigList(true);
		if (configList == null)
		{
			return null;
		}
		return configList.ToList<WeaponExpItem>();
	}

	// Token: 0x0601740A RID: 95242 RVA: 0x00672673 File Offset: 0x00670873
	protected override bool OnClear()
	{
		this.WeaponConfigMap.Clear();
		this.WeaponExpItemMap.Clear();
		this.WeaponQualityInfoMap.Clear();
		this.TrialWeaponInfoMap.Clear();
		return true;
	}

	// Token: 0x0400B2B7 RID: 45751
	private readonly Dictionary<int, WeaponConf> WeaponConfigMap = new Dictionary<int, WeaponConf>();

	// Token: 0x0400B2B8 RID: 45752
	private readonly Dictionary<int, WeaponExpItem> WeaponExpItemMap = new Dictionary<int, WeaponExpItem>();

	// Token: 0x0400B2B9 RID: 45753
	private readonly Dictionary<int, WeaponQualityInfo> WeaponQualityInfoMap = new Dictionary<int, WeaponQualityInfo>();

	// Token: 0x0400B2BA RID: 45754
	private readonly Dictionary<int, TrialWeaponInfo> TrialWeaponInfoMap = new Dictionary<int, TrialWeaponInfo>();
}
