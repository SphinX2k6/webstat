using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.KeySetting;

// Token: 0x0200225F RID: 8799
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MenuBaseConfig : ConfigBase<MenuBaseConfig>
{
	// Token: 0x060109C6 RID: 68038 RVA: 0x0048B7D0 File Offset: 0x004899D0
	public IReadOnlyList<MenuConfig> GetMenuBaseConfig()
	{
		IReadOnlyList<MenuConfig> configList = ConfigMenuConfigAll.GetConfigList(true);
		if (configList != null && configList.Count > 0)
		{
			return configList;
		}
		Singleton<Log>.Instance.Error(ELogModule.Menu, ELogAuthor.WZ, "没有基础配置文件，请检查配置表是否缺失", default(ReadOnlySpan<ValueTuple<string, object>>));
		return null;
	}

	// Token: 0x060109C7 RID: 68039 RVA: 0x0048B810 File Offset: 0x00489A10
	public Dictionary<int, MainType> GetMainConfig()
	{
		IReadOnlyList<MainType> configList = ConfigMainTypeAll.GetConfigList(true);
		if (configList != null && configList.Count > 0)
		{
			Dictionary<int, MainType> dictionary = new Dictionary<int, MainType>();
			foreach (MainType value in configList)
			{
				dictionary[value.Id] = value;
			}
			return dictionary;
		}
		Singleton<Log>.Instance.Error(ELogModule.Menu, ELogAuthor.WZ, "没有对应的主类型基础配置，请检查配置表是否缺失", default(ReadOnlySpan<ValueTuple<string, object>>));
		return null;
	}

	// Token: 0x060109C8 RID: 68040 RVA: 0x0048B898 File Offset: 0x00489A98
	public MainType? GetMainTypeConfigById(int tabId)
	{
		return ConfigMainTypeById.GetConfig(tabId, true);
	}

	// Token: 0x060109C9 RID: 68041 RVA: 0x0048B8A1 File Offset: 0x00489AA1
	public MenuConfig? GetMenuConfigByFunctionId(int functionId)
	{
		return ConfigMenuConfigByFunctionId.GetConfig(functionId, true);
	}

	// Token: 0x060109CA RID: 68042 RVA: 0x0048B8AA File Offset: 0x00489AAA
	public IReadOnlyList<MenuConfig> GetMenuConfigListByFunctionId(int functionId)
	{
		return ConfigMenuConfigByFunctionId.GetConfigList(functionId, true);
	}

	// Token: 0x060109CB RID: 68043 RVA: 0x0048B8B3 File Offset: 0x00489AB3
	public IReadOnlyList<KeyType> GetAllKeyTypeConfig()
	{
		return ConfigKeyTypeAll.GetConfigList(true);
	}

	// Token: 0x060109CC RID: 68044 RVA: 0x0048B8BB File Offset: 0x00489ABB
	public IReadOnlyList<KeySetting> GetKeySettingConfigListByTypeIdAndInputControllerType(int typeId, int inputControllerTypeId)
	{
		return ConfigKeySettingByTypeIdAndInputControllerType.GetConfigList(typeId, inputControllerTypeId, true);
	}

	// Token: 0x060109CD RID: 68045 RVA: 0x0048B8C5 File Offset: 0x00489AC5
	public IReadOnlyList<AxisRevert> GetAxisRevertConfigListByRevertType(int revertType)
	{
		return ConfigAxisRevertByRevertType.GetConfigList(revertType, true);
	}

	// Token: 0x060109CE RID: 68046 RVA: 0x0048B8CE File Offset: 0x00489ACE
	public IReadOnlyList<KeySetting> GetExclusiveKeySettingConfigByTypeIdAndInputControllerType(int typeId, int inputControllerTypeId, EKeySettingExclusiveType exclusiveType)
	{
		return ConfigKeySettingByTypeIdAndInputControllerTypeExclusive.GetConfigList(typeId, inputControllerTypeId, (int)exclusiveType, true);
	}

	// Token: 0x060109CF RID: 68047 RVA: 0x0048B8D9 File Offset: 0x00489AD9
	public KeyExclusiveType? GetExclusiveTypeConfigById(int typeId)
	{
		return ConfigKeyExclusiveTypeById.GetConfig(typeId, true);
	}

	// Token: 0x060109D0 RID: 68048 RVA: 0x0048B8E2 File Offset: 0x00489AE2
	public MenuDetailPop? GetMenuDetailPopConfigById(int configId)
	{
		return ConfigMenuDetailPopById.GetConfig(configId, true);
	}

	// Token: 0x060109D1 RID: 68049 RVA: 0x0048B8EB File Offset: 0x00489AEB
	public MenuDetailPopItem? GetMenuDetailPopItemConfigById(int configId)
	{
		return ConfigMenuDetailPopItemById.GetConfig(configId, true);
	}

	// Token: 0x060109D2 RID: 68050 RVA: 0x0048B8F4 File Offset: 0x00489AF4
	public RoleVoiceLanguage? GetRoleLangCustomConfigById(int configId)
	{
		return ConfigRoleVoiceLanguageByLanguageId.GetConfig(configId, true);
	}
}
