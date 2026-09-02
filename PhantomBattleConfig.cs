using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;

// Token: 0x0200245A RID: 9306
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class PhantomBattleConfig : ConfigBase<PhantomBattleConfig>
{
	// Token: 0x0601203C RID: 73788 RVA: 0x004F555B File Offset: 0x004F375B
	public PhantomBattleConfig()
	{
		this.TrialPhantomPropMap = new Dictionary<int, TrailPhantomProp>();
	}

	// Token: 0x0601203D RID: 73789 RVA: 0x004F5570 File Offset: 0x004F3770
	public IReadOnlyList<PhantomItem> GetPhantomItemList()
	{
		IReadOnlyList<PhantomItem> configList = ConfigPhantomItemAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.YZY, "获取幻象道具配置列表失败, 请检查配置表", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return configList;
	}

	// Token: 0x0601203E RID: 73790 RVA: 0x004F55A4 File Offset: 0x004F37A4
	public PhantomItem? GetPhantomItemById(int id)
	{
		PhantomItem? config = ConfigPhantomItemByItemId.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取幻象道具配置失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return new PhantomItem?(config.Value);
	}

	// Token: 0x0601203F RID: 73791 RVA: 0x004F55FA File Offset: 0x004F37FA
	[NullableContext(2)]
	public IReadOnlyList<PhantomItem> GetPhantomItemByMonsterId(int monsterId)
	{
		return ConfigPhantomItemByMonsterId.GetConfigList(monsterId, true);
	}

	// Token: 0x06012040 RID: 73792 RVA: 0x004F5603 File Offset: 0x004F3803
	[NullableContext(2)]
	public IReadOnlyList<PhantomItem> GetPhantomItemByParentMonsterId(int parentMonsterId)
	{
		return ConfigPhantomItemByParentMonsterId.GetConfigList(parentMonsterId, true);
	}

	// Token: 0x06012041 RID: 73793 RVA: 0x004F560C File Offset: 0x004F380C
	public IReadOnlyList<PhantomSkill> GetPhantomSkillList(int skillId)
	{
		IReadOnlyList<PhantomSkill> configList = ConfigPhantomSkillByPhantomSkillId.GetConfigList(skillId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取幻象技能配置列表失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillId", skillId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return configList;
	}

	// Token: 0x06012042 RID: 73794 RVA: 0x004F5650 File Offset: 0x004F3850
	public string[] GetPhantomSkillDescExByPhantomSkillIdAndQuality(int phantomSkillId, int quality = 2)
	{
		PhantomSkill phantomSkill = ConfigPhantomSkillByPhantomSkillId.GetConfigList(phantomSkillId, true)[0];
		int levelDescStrArrayLength = phantomSkill.LevelDescStrArrayLength;
		int j;
		if (quality > levelDescStrArrayLength)
		{
			j = levelDescStrArrayLength - 1;
		}
		else
		{
			j = quality - 1;
		}
		StringArray? stringArray = phantomSkill.LevelDescStrArray(j);
		if (stringArray != null)
		{
			StringArray value = stringArray.Value;
			int arrayStringLength = value.ArrayStringLength;
			string[] array = new string[arrayStringLength];
			for (int i = 0; i < arrayStringLength; i++)
			{
				array[i] = value.ArrayString(i);
			}
			return array;
		}
		return new string[0];
	}

	// Token: 0x06012043 RID: 73795 RVA: 0x004F56D8 File Offset: 0x004F38D8
	public string[] GetPhantomSkillDescExBySkillIdAndQuality(int skillId, int quality = 2)
	{
		PhantomSkill value = ConfigPhantomSkillById.GetConfig(skillId, true).Value;
		int levelDescStrArrayLength = value.LevelDescStrArrayLength;
		int j;
		if (quality > levelDescStrArrayLength)
		{
			j = levelDescStrArrayLength - 1;
		}
		else
		{
			j = quality - 1;
		}
		StringArray? stringArray = value.LevelDescStrArray(j);
		if (stringArray != null)
		{
			StringArray value2 = stringArray.Value;
			int arrayStringLength = value2.ArrayStringLength;
			string[] array = new string[arrayStringLength];
			for (int i = 0; i < arrayStringLength; i++)
			{
				array[i] = value2.ArrayString(i);
			}
			return array;
		}
		return new string[0];
	}

	// Token: 0x06012044 RID: 73796 RVA: 0x004F5764 File Offset: 0x004F3964
	public string GetPhantomSkillDescStringBySkillIdAndQuality(int skillId, int quality = 2)
	{
		string[] phantomSkillDescExBySkillIdAndQuality = this.GetPhantomSkillDescExBySkillIdAndQuality(skillId, quality);
		return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(ConfigPhantomSkillById.GetConfig(skillId, true).Value.DescriptionEx, null), phantomSkillDescExBySkillIdAndQuality);
	}

	// Token: 0x06012045 RID: 73797 RVA: 0x004F57A0 File Offset: 0x004F39A0
	public PhantomSkill? GetPhantomSkillBySkillId(int skillId)
	{
		IReadOnlyList<PhantomSkill> configList = ConfigPhantomSkillByPhantomSkillId.GetConfigList(skillId, true);
		if (configList == null || configList.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取幻象技能配置失败, 请检查配置表, 也可能是探索技能";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillId", skillId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new PhantomSkill?(configList[0]);
	}

	// Token: 0x06012046 RID: 73798 RVA: 0x004F5802 File Offset: 0x004F3A02
	public PhantomRarity? GetPhantomRareConfig(int rareId)
	{
		return ConfigPhantomRarityByRare.GetConfig(rareId, true);
	}

	// Token: 0x06012047 RID: 73799 RVA: 0x004F580C File Offset: 0x004F3A0C
	[NullableContext(2)]
	public IReadOnlyList<PhantomRarity> GetPhantomRareConfigAll()
	{
		IReadOnlyList<PhantomRarity> configList = ConfigPhantomRarityAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.WDX, "获取幻象洗炼材料配置失败, 请检查配置表", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return configList;
	}

	// Token: 0x06012048 RID: 73800 RVA: 0x004F5840 File Offset: 0x004F3A40
	[NullableContext(2)]
	public IReadOnlyList<PhantomVicePolishConfig> GetPhantomVicePolishConfigAll()
	{
		IReadOnlyList<PhantomVicePolishConfig> configList = ConfigPhantomVicePolishConfigAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.WDX, "获取幻象辅音洗炼材料配置失败, 请检查配置表", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return configList;
	}

	// Token: 0x06012049 RID: 73801 RVA: 0x004F5874 File Offset: 0x004F3A74
	public PhantomQuality? GetPhantomQualityByItemQuality(int itemQuality)
	{
		PhantomQuality? config = ConfigPhantomQualityByQuality.GetConfig(itemQuality, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取幻象品质配置失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", itemQuality);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x0601204A RID: 73802 RVA: 0x004F58C0 File Offset: 0x004F3AC0
	public PhantomMainProperty? GetPhantomMainPropertyById(int id)
	{
		PhantomMainProperty? config = ConfigPhantomMainPropertyById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取幻象主属性配置失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x0601204B RID: 73803 RVA: 0x004F590C File Offset: 0x004F3B0C
	[NullableContext(2)]
	public IReadOnlyList<PhantomMainProperty> GetPhantomMainPropertyByRandGroupId(int randGroupId)
	{
		IReadOnlyList<PhantomMainProperty> configList = ConfigPhantomMainPropertyByRandGroupId.GetConfigList(randGroupId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.WDX;
			string message = "获取幻象主属性方案组失败, 请检查配表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", randGroupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return configList;
	}

	// Token: 0x0601204C RID: 73804 RVA: 0x004F5954 File Offset: 0x004F3B54
	public PhantomMainPropItem GetPhantomMainPropertyItemId(int id)
	{
		PhantomMainPropItem? config = ConfigPhantomMainPropItemById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取幻象主属性配置失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value;
	}

	// Token: 0x0601204D RID: 73805 RVA: 0x004F59A8 File Offset: 0x004F3BA8
	public PhantomSubProperty GetPhantomSubPropertyById(int id)
	{
		PhantomSubProperty? config = ConfigPhantomSubPropertyById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取幻象属性配置失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value;
	}

	// Token: 0x0601204E RID: 73806 RVA: 0x004F59FC File Offset: 0x004F3BFC
	public IReadOnlyList<PhantomFetter> GetPhantomFetterList()
	{
		IReadOnlyList<PhantomFetter> configList = ConfigPhantomFetterAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.YZY, "获取幻象羁绊配置列表失败, 请检查配置表", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return configList;
	}

	// Token: 0x0601204F RID: 73807 RVA: 0x004F5A30 File Offset: 0x004F3C30
	public IReadOnlyList<PhantomFetterGroup> GetPhantomFetterGroupList()
	{
		IReadOnlyList<PhantomFetterGroup> configList = ConfigPhantomFetterGroupAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.YZY, "获取幻象羁绊配置列表失败, 请检查配置表", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return configList;
	}

	// Token: 0x06012050 RID: 73808 RVA: 0x004F5A64 File Offset: 0x004F3C64
	public PhantomFetter GetPhantomFetterById(int id)
	{
		PhantomFetter? config = ConfigPhantomFetterById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取幻象羁绊配置失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value;
	}

	// Token: 0x06012051 RID: 73809 RVA: 0x004F5AB8 File Offset: 0x004F3CB8
	public unsafe int GetPhantomLevelExpByGroupIdAndLevel(int groupId, int level)
	{
		PhantomLevel? config = ConfigPhantomLevelByGroupIdAndLevel.GetConfig(groupId, level, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取幻象升级消耗配置失败, 请检查配置表";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("groupId", groupId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("level", level);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return config.Value.Exp;
	}

	// Token: 0x06012052 RID: 73810 RVA: 0x004F5B44 File Offset: 0x004F3D44
	public IReadOnlyList<PhantomLevel> GetPhantomLevelListByGroupId(int groupId)
	{
		IReadOnlyList<PhantomLevel> configList = ConfigPhantomLevelByGroupId.GetConfigList(groupId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取幻象升级消耗配置列表失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("groupId", groupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return configList;
	}

	// Token: 0x06012053 RID: 73811 RVA: 0x004F5B88 File Offset: 0x004F3D88
	public ItemInfo GetItemInfoById(int itemId)
	{
		ItemInfo? config = ConfigItemInfoById.GetConfig(itemId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取道具配置失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value;
	}

	// Token: 0x06012054 RID: 73812 RVA: 0x004F5BDC File Offset: 0x004F3DDC
	public PhantomExpItem GetPhantomExpItemById(int itemId)
	{
		PhantomExpItem? config = ConfigPhantomExpItemByItemId.GetConfig(itemId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取幻象经验道具配置失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value;
	}

	// Token: 0x06012055 RID: 73813 RVA: 0x004F5C2D File Offset: 0x004F3E2D
	[NullableContext(2)]
	public IReadOnlyList<PhantomExpItem> GetPhantomExpItemList()
	{
		return ConfigPhantomExpItemAll.GetConfigList(true);
	}

	// Token: 0x06012056 RID: 73814 RVA: 0x004F5C35 File Offset: 0x004F3E35
	[NullableContext(2)]
	public IReadOnlyList<PhantomWildItem> GetPhantomWildItem()
	{
		return ConfigPhantomWildItemAll.GetConfigList(true);
	}

	// Token: 0x06012057 RID: 73815 RVA: 0x004F5C40 File Offset: 0x004F3E40
	public unsafe int GetPhantomGrowthValueByGrowthIdAndLevel(int growthId, int level)
	{
		PhantomGrowth? config = ConfigPhantomGrowthByGrowthIdAndLevel.GetConfig(growthId, level, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取幻象成长曲线值配置失败, 请检查配置表";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("growthId", growthId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("level", level);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return config.Value.Value;
	}

	// Token: 0x06012058 RID: 73816 RVA: 0x004F5CCB File Offset: 0x004F3ECB
	[NullableContext(2)]
	public IReadOnlyList<PhantomSubProperty> GetPhantomSubPropertyByPropId(int propId)
	{
		return ConfigPhantomSubPropertyByPropId.GetConfigList(propId, true);
	}

	// Token: 0x06012059 RID: 73817 RVA: 0x004F5CD4 File Offset: 0x004F3ED4
	public float GetPhantomLevelUpCostRatio()
	{
		return (float)ConfigCommonParamById.GetIntConfig("PhantomLevelUpCoinCost").Value / 1000f;
	}

	// Token: 0x0601205A RID: 73818 RVA: 0x004F5CFC File Offset: 0x004F3EFC
	public ConfigPropValue GetTrailPhantomPropItemById(int id)
	{
		TrialPhantomPropItem? config = ConfigTrialPhantomPropItemById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "获取configTrialPhantomPropItemById, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value.Prop.Value;
	}

	// Token: 0x0601205B RID: 73819 RVA: 0x004F5D60 File Offset: 0x004F3F60
	public int GetQualityIdentifyCost(int quality)
	{
		return this.GetPhantomQualityByItemQuality(quality).Value.IdentifyCoin;
	}

	// Token: 0x0601205C RID: 73820 RVA: 0x004F5D84 File Offset: 0x004F3F84
	public PhantomFetterGroup GetFetterGroupById(int groupId)
	{
		return ConfigPhantomFetterGroupById.GetConfig(groupId, true).Value;
	}

	// Token: 0x0601205D RID: 73821 RVA: 0x004F5DA0 File Offset: 0x004F3FA0
	public int GetFetterGroupMaxCountById(int groupId)
	{
		PhantomFetterGroup fetterGroupById = this.GetFetterGroupById(groupId);
		int fetterMapLength = fetterGroupById.FetterMapLength;
		int num = 0;
		for (int i = 0; i < fetterMapLength; i++)
		{
			int key = fetterGroupById.FetterMap(i).Value.Key;
			if (key > num)
			{
				num = key;
			}
		}
		return num;
	}

	// Token: 0x0601205E RID: 73822 RVA: 0x004F5DF0 File Offset: 0x004F3FF0
	public Dictionary<int, int> GetFetterGroupFetterDataById(int groupId)
	{
		return ConfigPhantomFetterGroupById.GetConfig(groupId, true).Value.FetterMap();
	}

	// Token: 0x0601205F RID: 73823 RVA: 0x004F5E14 File Offset: 0x004F4014
	[NullableContext(2)]
	public IReadOnlyList<PhantomFetterGroup> GetFetterGroupArray()
	{
		return ConfigPhantomFetterGroupAll.GetConfigList(true);
	}

	// Token: 0x06012060 RID: 73824 RVA: 0x004F5E1C File Offset: 0x004F401C
	public int[] GetFetterGroupSourceMonster(int groupId)
	{
		IEnumerable<PhantomItem> phantomItemList = this.GetPhantomItemList();
		List<int> list = new List<int>();
		foreach (PhantomItem phantomItem in phantomItemList)
		{
			if (phantomItem.PhantomType == 1 && phantomItem.ParentMonsterId == 0 && phantomItem.FetterGroup().Contains(groupId))
			{
				list.Add(phantomItem.MonsterId);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06012061 RID: 73825 RVA: 0x004F5EA0 File Offset: 0x004F40A0
	public Dictionary<int, Dictionary<int, int>> GetFetterMapResultBySuitMap(Dictionary<int, int> suitMap)
	{
		Dictionary<int, Dictionary<int, int>> dictionary = new Dictionary<int, Dictionary<int, int>>();
		foreach (KeyValuePair<int, int> keyValuePair in suitMap)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			PhantomFetterGroup? config = ConfigPhantomFetterGroupById.GetConfig(key, true);
			int fetterMapLength = config.Value.FetterMapLength;
			int num = 0;
			int value2 = 0;
			Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
			for (int i = 0; i < fetterMapLength; i++)
			{
				DicIntInt? dicIntInt = config.Value.FetterMap(i);
				int key2 = dicIntInt.Value.Key;
				int value3 = dicIntInt.Value.Value;
				if (value >= key2)
				{
					num = value3;
					value2 = key2;
				}
				if (num > 0)
				{
					dictionary2[num] = value2;
				}
			}
			if (dictionary2.Count > 0)
			{
				dictionary[key] = dictionary2;
			}
		}
		return dictionary;
	}

	// Token: 0x06012062 RID: 73826 RVA: 0x004F5FA8 File Offset: 0x004F41A8
	public List<int> GetFetterResultBySuitMap(Dictionary<int, int> suitMap)
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, int> keyValuePair in suitMap)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			PhantomFetterGroup? config = ConfigPhantomFetterGroupById.GetConfig(key, true);
			int fetterMapLength = config.Value.FetterMapLength;
			int num = 0;
			for (int i = 0; i < fetterMapLength; i++)
			{
				DicIntInt? dicIntInt = config.Value.FetterMap(i);
				int key2 = dicIntInt.Value.Key;
				int value2 = dicIntInt.Value.Value;
				if (value >= key2)
				{
					num = value2;
				}
			}
			if (num > 0)
			{
				list.Add(num);
			}
		}
		return list;
	}

	// Token: 0x06012063 RID: 73827 RVA: 0x004F6088 File Offset: 0x004F4288
	public string GetPhantomQualityBgSprite(int quality)
	{
		if (quality == 0)
		{
			return ConfigCommonParamById.GetStringConfig("VisionQualityDefaultSprite");
		}
		return this.GetPhantomQualityByItemQuality(quality).Value.QualitySprite;
	}

	// Token: 0x06012064 RID: 73828 RVA: 0x004F60BC File Offset: 0x004F42BC
	public int[] GetPhantomSlotUnlockLevel(int quality)
	{
		return this.GetPhantomQualityByItemQuality(quality).Value.GetSlotUnlockLevelBytes().ToArray();
	}

	// Token: 0x06012065 RID: 73829 RVA: 0x004F60E8 File Offset: 0x004F42E8
	public Dictionary<int, int> GetPhantomIdentifyCost(int quality)
	{
		return this.GetPhantomQualityByItemQuality(quality).Value.IdentifyCost();
	}

	// Token: 0x06012066 RID: 73830 RVA: 0x004F610C File Offset: 0x004F430C
	public string GetMonsterIdName(int monsterId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.GetPhantomItemByMonsterId(monsterId)[0].MonsterName, null);
	}

	// Token: 0x06012067 RID: 73831 RVA: 0x004F6134 File Offset: 0x004F4334
	public string GetFetterNameByFetterNameId(string fetterNameId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(fetterNameId, null);
	}

	// Token: 0x06012068 RID: 73832 RVA: 0x004F613D File Offset: 0x004F433D
	public IReadOnlyList<PhantomManagePlanV2> GetPhantomManagerPlanByFetterId(int fetterId)
	{
		return ConfigPhantomManagePlanV2ByFetterId.GetConfigList(fetterId, true) ?? Array.Empty<PhantomManagePlanV2>();
	}

	// Token: 0x06012069 RID: 73833 RVA: 0x004F614F File Offset: 0x004F434F
	public IReadOnlyList<PhantomManagePlanV2> GetPhantomManagerPlanAll()
	{
		return ConfigPhantomManagePlanV2All.GetConfigList(true) ?? Array.Empty<PhantomManagePlanV2>();
	}

	// Token: 0x0601206A RID: 73834 RVA: 0x004F6160 File Offset: 0x004F4360
	public int GetPhantomManagerShareCodeMax()
	{
		return ConfigCommonParamById.GetIntConfig("PhBaPlanCodeMaxCount").GetValueOrDefault(30);
	}

	// Token: 0x0601206B RID: 73835 RVA: 0x004F6184 File Offset: 0x004F4384
	public int GetPhantomManagerShareCodeMin()
	{
		return ConfigCommonParamById.GetIntConfig("PhBaPlanCodeMinCount").GetValueOrDefault(20);
	}

	// Token: 0x0601206C RID: 73836 RVA: 0x004F61A5 File Offset: 0x004F43A5
	public TrailPhantomProp? GetTrialPhantomPropConfig(int id)
	{
		return ConfigTrailPhantomPropById.GetConfig(id, true);
	}

	// Token: 0x0601206D RID: 73837 RVA: 0x004F61B0 File Offset: 0x004F43B0
	public int GetVisionLevelUpQualityLimit()
	{
		return ConfigCommonParamById.GetIntConfig("VisionHighQuality").Value;
	}

	// Token: 0x0601206E RID: 73838 RVA: 0x004F61D0 File Offset: 0x004F43D0
	public int GetVisionLevelUpRareLimit()
	{
		return ConfigCommonParamById.GetIntConfig("VisionHighRare").Value;
	}

	// Token: 0x0601206F RID: 73839 RVA: 0x004F61F0 File Offset: 0x004F43F0
	public int GetVisionLevelUpLevelLimit()
	{
		return ConfigCommonParamById.GetIntConfig("VisionHighLevel").Value;
	}

	// Token: 0x06012070 RID: 73840 RVA: 0x004F6210 File Offset: 0x004F4410
	public int GetVisionScrollerMoveDistance()
	{
		return ConfigCommonParamById.GetIntConfig("VisionScrollerMoveDistance").Value;
	}

	// Token: 0x06012071 RID: 73841 RVA: 0x004F6230 File Offset: 0x004F4430
	public int GetVisionScrollerPressTime()
	{
		return ConfigCommonParamById.GetIntConfig("VisionScrollerLongPressTime").Value;
	}

	// Token: 0x06012072 RID: 73842 RVA: 0x004F6250 File Offset: 0x004F4450
	public int GetVisionBeforeScrollerLongPressTime()
	{
		return ConfigCommonParamById.GetIntConfig("VisionBeforeScrollerLongPressTime").Value;
	}

	// Token: 0x06012073 RID: 73843 RVA: 0x004F6270 File Offset: 0x004F4470
	public float GetVisionScrollerOffsetX()
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			return 0f;
		}
		return ConfigCommonParamById.GetFloatConfig("VisionScrollerOffsetX").Value;
	}

	// Token: 0x06012074 RID: 73844 RVA: 0x004F62A4 File Offset: 0x004F44A4
	public float GetVisionScrollerOffsetY()
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			return 0f;
		}
		return ConfigCommonParamById.GetFloatConfig("VisionScrollerOffsetY").Value;
	}

	// Token: 0x06012075 RID: 73845 RVA: 0x004F62D8 File Offset: 0x004F44D8
	public int GetVisionScrollerOffsetXDir()
	{
		return ConfigCommonParamById.GetIntConfig("VisionScrollerOffsetXDir").Value;
	}

	// Token: 0x06012076 RID: 73846 RVA: 0x004F62F8 File Offset: 0x004F44F8
	public int GetVisionScrollerOffsetYDir()
	{
		return ConfigCommonParamById.GetIntConfig("VisionScrollerOffsetYDir").Value;
	}

	// Token: 0x06012077 RID: 73847 RVA: 0x004F6317 File Offset: 0x004F4517
	public string GetVisionDragCurve()
	{
		return ConfigCommonParamById.GetStringConfig("VisionDragCurve");
	}

	// Token: 0x06012078 RID: 73848 RVA: 0x004F6324 File Offset: 0x004F4524
	public int GetVisionDragCurveTime()
	{
		return ConfigCommonParamById.GetIntConfig("VisionDragAnimationTime").Value;
	}

	// Token: 0x06012079 RID: 73849 RVA: 0x004F6343 File Offset: 0x004F4543
	public string GetFilterOwnTexture()
	{
		return ConfigCommonParamById.GetStringConfig("VisionFilterSpriteOwn");
	}

	// Token: 0x0601207A RID: 73850 RVA: 0x004F634F File Offset: 0x004F454F
	public string GetFilterNotOwnTexture()
	{
		return ConfigCommonParamById.GetStringConfig("VisionFilterSpriteNotOwn");
	}

	// Token: 0x0601207B RID: 73851 RVA: 0x004F635B File Offset: 0x004F455B
	public string GetFilterEquipTexture()
	{
		return ConfigCommonParamById.GetStringConfig("VisionFilterSpriteEquipped");
	}

	// Token: 0x0601207C RID: 73852 RVA: 0x004F6367 File Offset: 0x004F4567
	public string GetFilterNoEquipTexture()
	{
		return ConfigCommonParamById.GetStringConfig("VisionFilterSpriteNotEquipped");
	}

	// Token: 0x0601207D RID: 73853 RVA: 0x004F6373 File Offset: 0x004F4573
	public string GetVisionLevelUpTexture()
	{
		return ConfigCommonParamById.GetStringConfig("VisionLevelUpUnlockTexture");
	}

	// Token: 0x0601207E RID: 73854 RVA: 0x004F637F File Offset: 0x004F457F
	public string GetVisionHeadSprBgB()
	{
		return ConfigCommonParamById.GetStringConfig("VisionHeadSprBgB");
	}

	// Token: 0x0601207F RID: 73855 RVA: 0x004F638B File Offset: 0x004F458B
	public string GetVisionHeadSprBgA()
	{
		return ConfigCommonParamById.GetStringConfig("VisionHeadSprBgA");
	}

	// Token: 0x06012080 RID: 73856 RVA: 0x004F6397 File Offset: 0x004F4597
	public string GetVisionHeadLightBgA()
	{
		return ConfigCommonParamById.GetStringConfig("VisionHeadLightBgA");
	}

	// Token: 0x06012081 RID: 73857 RVA: 0x004F63A3 File Offset: 0x004F45A3
	public string GetVisionHeadLightBgB()
	{
		return ConfigCommonParamById.GetStringConfig("VisionHeadLightBgB");
	}

	// Token: 0x06012082 RID: 73858 RVA: 0x004F63B0 File Offset: 0x004F45B0
	public int GetVisionReachableCostMax()
	{
		return ConfigCommonParamById.GetIntConfig("PhantomTotalCost").Value;
	}

	// Token: 0x06012083 RID: 73859 RVA: 0x004F63CF File Offset: 0x004F45CF
	public string GetVisionFetterDefaultColor()
	{
		return ConfigCommonParamById.GetStringConfig("VisionFetterDefaultColor");
	}

	// Token: 0x06012084 RID: 73860 RVA: 0x004F63DB File Offset: 0x004F45DB
	public string GetVisionFetterDefaultTexture()
	{
		return ConfigCommonParamById.GetStringConfig("VisionFetterDefaultTexture");
	}

	// Token: 0x06012085 RID: 73861 RVA: 0x004F63E8 File Offset: 0x004F45E8
	public int GetVisionLevelUpDelay()
	{
		return ConfigCommonParamById.GetIntConfig("VisionLevelUpDelay").Value;
	}

	// Token: 0x06012086 RID: 73862 RVA: 0x004F6408 File Offset: 0x004F4608
	public int GetVisionIdentifyDelay()
	{
		return ConfigCommonParamById.GetIntConfig("VisionIdentifyDelay").Value;
	}

	// Token: 0x06012087 RID: 73863 RVA: 0x004F6427 File Offset: 0x004F4627
	public string GetVisionCostColorBase()
	{
		return ConfigCommonParamById.GetStringConfig("VisionCostColorBase");
	}

	// Token: 0x06012088 RID: 73864 RVA: 0x004F6433 File Offset: 0x004F4633
	public string GetVisionCostColorFull()
	{
		return ConfigCommonParamById.GetStringConfig("VisionCostColorFull");
	}

	// Token: 0x06012089 RID: 73865 RVA: 0x004F643F File Offset: 0x004F463F
	public string GetVisionCostColorAlert()
	{
		return ConfigCommonParamById.GetStringConfig("VisionCostColorAlert");
	}

	// Token: 0x0601208A RID: 73866 RVA: 0x004F644C File Offset: 0x004F464C
	public int GetVisionIdentifyAnimationTime()
	{
		return ConfigCommonParamById.GetIntConfig("VisionIdentifyAnimationTime").Value;
	}

	// Token: 0x0601208B RID: 73867 RVA: 0x004F646B File Offset: 0x004F466B
	public int[] GetVisionMainAttributeSortArray()
	{
		return ConfigCommonParamById.GetIntArrayConfig("VisionMainAttributeSortArray").ToArray<int>();
	}

	// Token: 0x0601208C RID: 73868 RVA: 0x004F647C File Offset: 0x004F467C
	public int[] GetVisionMainPercentageAttributeSortArray()
	{
		return ConfigCommonParamById.GetIntArrayConfig("VisionMainPercentageAttributeSortArray").ToArray<int>();
	}

	// Token: 0x0601208D RID: 73869 RVA: 0x004F648D File Offset: 0x004F468D
	public int[] GetVisionSubAttributeSortArray()
	{
		return ConfigCommonParamById.GetIntArrayConfig("VisionSubAttributeSortArray").ToArray<int>();
	}

	// Token: 0x0601208E RID: 73870 RVA: 0x004F649E File Offset: 0x004F469E
	public int[] GetVisionSubPercentageAttributeSortArray()
	{
		return ConfigCommonParamById.GetIntArrayConfig("VisionSubPercentageAttributeSortArray").ToArray<int>();
	}

	// Token: 0x0601208F RID: 73871 RVA: 0x004F64AF File Offset: 0x004F46AF
	public string GetVisionDestroyCostSpriteByCost(int cost)
	{
		if (cost == 1)
		{
			return this.GetVisionDestroyCost1();
		}
		if (cost == 3)
		{
			return this.GetVisionDestroyCost3();
		}
		return this.GetVisionDestroyCost4();
	}

	// Token: 0x06012090 RID: 73872 RVA: 0x004F64CD File Offset: 0x004F46CD
	public string GetVisionDestroyCost1()
	{
		return ConfigCommonParamById.GetStringConfig("VisionFilterSpriteCost1");
	}

	// Token: 0x06012091 RID: 73873 RVA: 0x004F64D9 File Offset: 0x004F46D9
	public string GetVisionDestroyCost3()
	{
		return ConfigCommonParamById.GetStringConfig("VisionFilterSpriteCost3");
	}

	// Token: 0x06012092 RID: 73874 RVA: 0x004F64E5 File Offset: 0x004F46E5
	public string GetVisionDestroyCost4()
	{
		return ConfigCommonParamById.GetStringConfig("VisionFilterSpriteCost4");
	}

	// Token: 0x06012093 RID: 73875 RVA: 0x004F64F1 File Offset: 0x004F46F1
	public string GetVisionRecoveryUnDesperateIcon()
	{
		return ConfigCommonParamById.GetStringConfig("VisionRecoveryUnDesperate");
	}

	// Token: 0x06012094 RID: 73876 RVA: 0x004F64FD File Offset: 0x004F46FD
	public string GetVisionRecoveryDesperateIcon()
	{
		return ConfigCommonParamById.GetStringConfig("VisionRecoveryDesperate");
	}

	// Token: 0x06012095 RID: 73877 RVA: 0x004F650C File Offset: 0x004F470C
	public int GetVisionRecommendRuleLevel()
	{
		return ConfigCommonParamById.GetIntConfig("VisionRecommendRuleLevel").Value;
	}

	// Token: 0x06012096 RID: 73878 RVA: 0x004F652C File Offset: 0x004F472C
	public int GetPhantomEquipGroupCountMax()
	{
		return ConfigCommonParamById.GetIntConfig("PhantomEquipGroupCount").Value;
	}

	// Token: 0x06012097 RID: 73879 RVA: 0x004F654C File Offset: 0x004F474C
	public int GetPhantomEquipHelpGroupId()
	{
		return ConfigCommonParamById.GetIntConfig("VisionEquipHelpGroupId").Value;
	}

	// Token: 0x06012098 RID: 73880 RVA: 0x004F656C File Offset: 0x004F476C
	public int GetPhantomRecommendHelpGroupId()
	{
		return ConfigCommonParamById.GetIntConfig("VisionRecommendHelpId").Value;
	}

	// Token: 0x06012099 RID: 73881 RVA: 0x004F658B File Offset: 0x004F478B
	public int[] GetVisionAttrSortArray()
	{
		return ConfigCommonParamById.GetIntArrayConfig("VisionMainViewExtraAttributeForPreset").ToArray<int>();
	}

	// Token: 0x0601209A RID: 73882 RVA: 0x004F659C File Offset: 0x004F479C
	public PhantomVicePolishConfig? GetPhantomVicePolishCostByLockCount(int count)
	{
		return ConfigPhantomVicePolishConfigByPropCount.GetConfig(count, true);
	}

	// Token: 0x0601209B RID: 73883 RVA: 0x004F65A8 File Offset: 0x004F47A8
	public int GetPhantomSharedCodeCd()
	{
		return ConfigCommonParamById.GetIntConfig("PhBaPlanCodeShareCheckCD").GetValueOrDefault(30);
	}

	// Token: 0x0601209C RID: 73884 RVA: 0x004F65C9 File Offset: 0x004F47C9
	protected override bool OnClear()
	{
		this.TrialPhantomPropMap.Clear();
		return true;
	}

	// Token: 0x04008D02 RID: 36098
	private readonly Dictionary<int, TrailPhantomProp> TrialPhantomPropMap;
}
