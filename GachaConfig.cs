using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02001CDC RID: 7388
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class GachaConfig : ConfigBase<GachaConfig>
{
	// Token: 0x0600D8B0 RID: 55472 RVA: 0x003A0667 File Offset: 0x0039E867
	public int? PrimaryCurrency()
	{
		return ConfigCommonParamById.GetIntConfig("PrimaryCurrency");
	}

	// Token: 0x0600D8B1 RID: 55473 RVA: 0x003A0673 File Offset: 0x0039E873
	public int? SecondCurrency()
	{
		return ConfigCommonParamById.GetIntConfig("SecondCurrency");
	}

	// Token: 0x0600D8B2 RID: 55474 RVA: 0x003A067F File Offset: 0x0039E87F
	public float? GachaRecordActiveAlpha()
	{
		return ConfigCommonParamById.GetFloatConfig("GachaRecordActiveAlpha");
	}

	// Token: 0x0600D8B3 RID: 55475 RVA: 0x003A068B File Offset: 0x0039E88B
	public float? GachaRecordNoActiveAlpha()
	{
		return ConfigCommonParamById.GetFloatConfig("GachaRecordNoActiveAlpha");
	}

	// Token: 0x0600D8B4 RID: 55476 RVA: 0x003A0697 File Offset: 0x0039E897
	public int? GetGachaResultDelay()
	{
		return ConfigCommonParamById.GetIntConfig("GachaResultDelay");
	}

	// Token: 0x0600D8B5 RID: 55477 RVA: 0x003A06A3 File Offset: 0x0039E8A3
	public Gacha? GetGachaConfig(int gachaId)
	{
		return ConfigGachaById.GetConfig(gachaId, true);
	}

	// Token: 0x0600D8B6 RID: 55478 RVA: 0x003A06AC File Offset: 0x0039E8AC
	public IReadOnlyList<Gacha> GetGachaList()
	{
		return ConfigGachaAll.GetConfigList(true);
	}

	// Token: 0x0600D8B7 RID: 55479 RVA: 0x003A06B4 File Offset: 0x0039E8B4
	public GachaPool? GetGachaPoolConfig(int gachaPoolId)
	{
		return ConfigGachaPoolById.GetConfig(gachaPoolId, true);
	}

	// Token: 0x0600D8B8 RID: 55480 RVA: 0x003A06BD File Offset: 0x0039E8BD
	public InventoryDefine.EItemDataType GetItemIdType(int itemId)
	{
		return ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemId));
	}

	// Token: 0x0600D8B9 RID: 55481 RVA: 0x003A06CF File Offset: 0x0039E8CF
	public GachaEffectConfig? GetGachaEffectConfigByTimesAndQuality(int times, int quality)
	{
		return ConfigGachaEffectConfigByTimesAndQuality.GetConfig(times, quality, true);
	}

	// Token: 0x0600D8BA RID: 55482 RVA: 0x003A06DC File Offset: 0x0039E8DC
	public string GetTextIdByType(GachaDefine.EAwardType awardType)
	{
		string p0Id;
		if (!GachaDefine.textKeyMap.TryGetValue(awardType, out p0Id))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Gacha;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "无法找到此奖品的文本Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("awardType", awardType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (ConfigTextById.GetConfig(p0Id, true) == null)
		{
			return null;
		}
		Text? text;
		return text.GetValueOrDefault().TextContent;
	}

	// Token: 0x0600D8BB RID: 55483 RVA: 0x003A074A File Offset: 0x0039E94A
	public RoleQualityInfo? GetRoleQualityConfig(int qualityId)
	{
		return ConfigRoleQualityInfoById.GetConfig(qualityId, true);
	}

	// Token: 0x0600D8BC RID: 55484 RVA: 0x003A0754 File Offset: 0x0039E954
	public RoleInfo? GetRoleInfoById(int itemId)
	{
		InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
		if (instance.GetItemDataTypeByConfigId(new int?(itemId)) == InventoryDefine.EItemDataType.RoleItem)
		{
			return ConfigBase<RoleConfig>.Instance.GetRoleConfig(itemId);
		}
		ItemConfig itemConfigData = instance.GetItemConfigData(itemId);
		if (itemConfigData == null)
		{
			return null;
		}
		int id;
		if (!itemConfigData.Parameters.TryGetValue(5, out id))
		{
			return null;
		}
		return ConfigBase<RoleConfig>.Instance.GetRoleConfig(id);
	}

	// Token: 0x0600D8BD RID: 55485 RVA: 0x003A07BC File Offset: 0x0039E9BC
	public string GetGachaPoolNameId(int gachaPoolId)
	{
		GachaViewInfo? gachaViewInfo = this.GetGachaViewInfo(gachaPoolId);
		if (gachaViewInfo == null)
		{
			return null;
		}
		return gachaViewInfo.GetValueOrDefault().SummaryTitle;
	}

	// Token: 0x0600D8BE RID: 55486 RVA: 0x003A07EC File Offset: 0x0039E9EC
	public GachaDefine.EGachaViewType? GetGachaViewType(int gachaPoolId)
	{
		GachaViewInfo? gachaViewInfo = this.GetGachaViewInfo(gachaPoolId);
		if (gachaViewInfo == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Gacha;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "奖池界面信息配置为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("gachaPoolId", gachaPoolId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new GachaDefine.EGachaViewType?((GachaDefine.EGachaViewType)gachaViewInfo.Value.Type);
	}

	// Token: 0x0600D8BF RID: 55487 RVA: 0x003A0858 File Offset: 0x0039EA58
	public GachaViewInfo? GetGachaViewInfo(int gachaPoolId)
	{
		GachaViewInfo? config = ConfigGachaViewInfoById.GetConfig(gachaPoolId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Gacha;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "奖池界面信息配置为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("gachaPoolId", gachaPoolId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x0600D8C0 RID: 55488 RVA: 0x003A08A8 File Offset: 0x0039EAA8
	public GachaTextureInfo? GetGachaTextureInfo(int itemId)
	{
		GachaTextureInfo? config = ConfigGachaTextureInfoById.GetConfig(itemId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Gacha;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "抽卡贴图信息表没有配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x0600D8C1 RID: 55489 RVA: 0x003A08F8 File Offset: 0x0039EAF8
	public string GetGachaElementTexturePath(int elementId)
	{
		ElementInfo? config = ConfigElementInfoById.GetConfig(elementId, true);
		if (config == null)
		{
			return null;
		}
		return config.GetValueOrDefault().Icon2;
	}

	// Token: 0x0600D8C2 RID: 55490 RVA: 0x003A0928 File Offset: 0x0039EB28
	public string GetGachaElementSpritePath(int elementId)
	{
		ElementInfo? config = ConfigElementInfoById.GetConfig(elementId, true);
		if (config == null)
		{
			return null;
		}
		return config.GetValueOrDefault().GachaSpritePath;
	}

	// Token: 0x0600D8C3 RID: 55491 RVA: 0x003A0957 File Offset: 0x0039EB57
	public GachaSequenceConfig? GetGachaSequenceConfigById(int id)
	{
		return ConfigGachaSequenceConfigById.GetConfig(id, true);
	}

	// Token: 0x0600D8C4 RID: 55492 RVA: 0x003A0960 File Offset: 0x0039EB60
	public GachaWeaponSeqConfig? GetGachaWeaponSeqConfigById(int id)
	{
		return ConfigGachaWeaponSeqConfigById.GetConfig(id, true);
	}

	// Token: 0x0600D8C5 RID: 55493 RVA: 0x003A0969 File Offset: 0x0039EB69
	public GachaWeaponTransform? GetGachaWeaponTransformConfig(int id)
	{
		return ConfigGachaWeaponTransformById.GetConfig(id, true);
	}

	// Token: 0x0600D8C6 RID: 55494 RVA: 0x003A0972 File Offset: 0x0039EB72
	public GachaViewTypeInfo? GetGachaViewTypeConfig(int type)
	{
		return ConfigGachaViewTypeInfoByType.GetConfig(type, true);
	}

	// Token: 0x0600D8C7 RID: 55495 RVA: 0x003A097C File Offset: 0x0039EB7C
	public int GetShopIdByGachaItemId(int gachaItemId)
	{
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("GachaItemIdToShopId");
		if (intArrayConfig == null || intArrayConfig.Count == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Gacha, ELogAuthor.LZK, "GachaItemIdToShopId配置为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0;
		}
		for (int i = 0; i < intArrayConfig.Count; i += 2)
		{
			if (intArrayConfig[i] == gachaItemId)
			{
				return intArrayConfig[i + 1];
			}
		}
		return 0;
	}

	// Token: 0x0600D8C8 RID: 55496 RVA: 0x003A09E8 File Offset: 0x0039EBE8
	[NullableContext(1)]
	public IReadOnlyList<int> GetGachaRolePreviewTypeList()
	{
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("GachaRolePreviewTypeList");
		return intArrayConfig ?? new List<int>();
	}

	// Token: 0x0600D8C9 RID: 55497 RVA: 0x003A0A0C File Offset: 0x0039EC0C
	[NullableContext(1)]
	public IReadOnlyList<int> GetGachaWeaponPreviewTypeList()
	{
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("GachaWeaponPreviewTypeList");
		return intArrayConfig ?? new List<int>();
	}
}
