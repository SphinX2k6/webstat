using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001EEF RID: 7919
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class HonamiStoryConfig : ConfigBase<HonamiStoryConfig>
{
	// Token: 0x0600EAB6 RID: 60086 RVA: 0x003FA684 File Offset: 0x003F8884
	public HonamiStoryBackPack? GetHonamiStoryBackPack(int id)
	{
		HonamiStoryBackPack? config = ConfigHonamiStoryBackPackById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			string message = "HonamiStoryBackPack表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryBackPack?(config.Value);
	}

	// Token: 0x0600EAB7 RID: 60087 RVA: 0x003FA6E8 File Offset: 0x003F88E8
	public HonamiStoryItem? GetHonamiStoryItem(int itemId)
	{
		HonamiStoryItem? config = ConfigHonamiStoryItemById.GetConfig(itemId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			string message = "HonamiStoryItem表无效itemId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryItem?(config.Value);
	}

	// Token: 0x0600EAB8 RID: 60088 RVA: 0x003FA74C File Offset: 0x003F894C
	public HonamiStoryEquip? GetHonamiStoryEquip(int itemId)
	{
		HonamiStoryEquip? config = ConfigHonamiStoryEquipById.GetConfig(itemId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			string message = "HonamiStoryEquip表无效itemId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryEquip?(config.Value);
	}

	// Token: 0x0600EAB9 RID: 60089 RVA: 0x003FA7B0 File Offset: 0x003F89B0
	public int[] GetHonamiStoryPropLibrary(int id)
	{
		HonamiStoryPropLibrary? config = ConfigHonamiStoryPropLibraryById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			string message = "HonamiStoryPropLibrary表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new int[0];
		}
		int honamiStoryPropIdLength = config.Value.HonamiStoryPropIdLength;
		int[] array = new int[honamiStoryPropIdLength];
		for (int i = 0; i < honamiStoryPropIdLength; i++)
		{
			array[i] = config.Value.HonamiStoryPropId(i);
		}
		return array;
	}

	// Token: 0x0600EABA RID: 60090 RVA: 0x003FA844 File Offset: 0x003F8A44
	public HonamiStoryProp? GetHonamiStoryProp(int id)
	{
		HonamiStoryProp? config = ConfigHonamiStoryPropById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			string message = "HonamiStoryProp表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryProp?(config.Value);
	}

	// Token: 0x0600EABB RID: 60091 RVA: 0x003FA8A8 File Offset: 0x003F8AA8
	public int? GetHonamiStoryBuffTempLibrary(int id)
	{
		HonamiStoryBuffTempLibrary? config = ConfigHonamiStoryBuffTempLibraryById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			string message = "HonamiStoryBuffTempLibrary表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new int?(config.Value.BuffTermpId);
	}

	// Token: 0x0600EABC RID: 60092 RVA: 0x003FA914 File Offset: 0x003F8B14
	[NullableContext(2)]
	public string GetHonamiStoryBuffTempDescFromLibrary(int libraryId)
	{
		int? honamiStoryBuffTempLibrary = this.GetHonamiStoryBuffTempLibrary(libraryId);
		if (honamiStoryBuffTempLibrary == null)
		{
			return null;
		}
		HonamiStoryBuffTemp? config = ConfigHonamiStoryBuffTempById.GetConfig(honamiStoryBuffTempLibrary.Value, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			string message = "HonamiStoryBuffTemp表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", honamiStoryBuffTempLibrary);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config.Value.Desc;
	}

	// Token: 0x0600EABD RID: 60093 RVA: 0x003FA98C File Offset: 0x003F8B8C
	public HonamiStoryBuffTemp? GetHonamiStoryBuffTemp(int id)
	{
		HonamiStoryBuffTemp? config = ConfigHonamiStoryBuffTempById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryBuffTemp表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryBuffTemp?(config.Value);
	}

	// Token: 0x0600EABE RID: 60094 RVA: 0x003FA9F0 File Offset: 0x003F8BF0
	public HonamiStoryItemQuality? GetHonamiStoryQuality(int quality)
	{
		HonamiStoryItemQuality? config = ConfigHonamiStoryItemQualityById.GetConfig(quality, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			string message = "HonamiStoryItemQuality表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", quality);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryItemQuality?(config.Value);
	}

	// Token: 0x0600EABF RID: 60095 RVA: 0x003FAA54 File Offset: 0x003F8C54
	public HonamiStoryActivity? GetHonamiStoryActivityConfig(int activityId)
	{
		HonamiStoryActivity? config = ConfigHonamiStoryActivityByActivityId.GetConfig(activityId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryActivity表无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryActivity?(config.Value);
	}

	// Token: 0x0600EAC0 RID: 60096 RVA: 0x003FAAB8 File Offset: 0x003F8CB8
	public IReadOnlyList<HonamiStoryActivity> GetAllActivityConfig()
	{
		IReadOnlyList<HonamiStoryActivity> configList = ConfigHonamiStoryActivityAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.WHJ, "HonamiStoryActivity表无效All", default(ReadOnlySpan<ValueTuple<string, object>>));
			return Array.Empty<HonamiStoryActivity>();
		}
		return configList;
	}

	// Token: 0x0600EAC1 RID: 60097 RVA: 0x003FAAF8 File Offset: 0x003F8CF8
	public HonamiStoryMascot? GetHonamiStoryMascotConfig(int id)
	{
		HonamiStoryMascot? config = ConfigHonamiStoryMascotById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryMascot表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryMascot?(config.Value);
	}

	// Token: 0x0600EAC2 RID: 60098 RVA: 0x003FAB5C File Offset: 0x003F8D5C
	public IReadOnlyList<HonamiStoryMascot> GetHonamiStoryMascotConfigList(int activityId)
	{
		IReadOnlyList<HonamiStoryMascot> configList = ConfigHonamiStoryMascotByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryMascot表无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<HonamiStoryMascot>();
		}
		return configList;
	}

	// Token: 0x0600EAC3 RID: 60099 RVA: 0x003FABAC File Offset: 0x003F8DAC
	public HonamiStoryArea? GetHonamiStoryAreaConfig(int areaId)
	{
		if (areaId == 0)
		{
			return null;
		}
		HonamiStoryArea? config = ConfigHonamiStoryAreaById.GetConfig(areaId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryArea表无效areaId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("areaId", areaId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryArea?(config.Value);
	}

	// Token: 0x0600EAC4 RID: 60100 RVA: 0x003FAC1C File Offset: 0x003F8E1C
	public IReadOnlyList<HonamiStoryArea> GetHonamiStoryAreaConfigList(int activityId)
	{
		IReadOnlyList<HonamiStoryArea> configList = ConfigHonamiStoryAreaByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryArea表无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<HonamiStoryArea>();
		}
		return configList;
	}

	// Token: 0x0600EAC5 RID: 60101 RVA: 0x003FAC6C File Offset: 0x003F8E6C
	public IReadOnlyList<HonamiStoryLimitTask> GetHonamiStoryLimitTaskConfigList(int activityId)
	{
		IReadOnlyList<HonamiStoryLimitTask> configList = ConfigHonamiStoryLimitTaskByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryLimitTask表无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<HonamiStoryLimitTask>();
		}
		return configList;
	}

	// Token: 0x0600EAC6 RID: 60102 RVA: 0x003FACBC File Offset: 0x003F8EBC
	public IReadOnlyList<HonamiStoryResidentTask> GetHonamiStoryPermanentTaskConfigList(int activityId)
	{
		IReadOnlyList<HonamiStoryResidentTask> configList = ConfigHonamiStoryResidentTaskByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryResidentTask表无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<HonamiStoryResidentTask>();
		}
		return configList;
	}

	// Token: 0x0600EAC7 RID: 60103 RVA: 0x003FAD0C File Offset: 0x003F8F0C
	public IReadOnlyList<HonamiStoryScoreReward> GetHonamiStoryScoreRewardConfigList(int activityId)
	{
		IReadOnlyList<HonamiStoryScoreReward> configList = ConfigHonamiStoryScoreRewardByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryScoreReward表无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<HonamiStoryScoreReward>();
		}
		return configList;
	}

	// Token: 0x0600EAC8 RID: 60104 RVA: 0x003FAD5C File Offset: 0x003F8F5C
	public IReadOnlyList<HonamiStoryTalent> GetHonamiStoryTalentConfigList(int activityId)
	{
		IReadOnlyList<HonamiStoryTalent> configList = ConfigHonamiStoryTalentByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryTalent表无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<HonamiStoryTalent>();
		}
		return configList;
	}

	// Token: 0x0600EAC9 RID: 60105 RVA: 0x003FADAC File Offset: 0x003F8FAC
	public IReadOnlyList<HonamiStoryItemCollection> GetHonamiStoryItemCollectionConfigList(int activityId)
	{
		IReadOnlyList<HonamiStoryItemCollection> configList = ConfigHonamiStoryItemCollectionByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryItemCollection表无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<HonamiStoryItemCollection>();
		}
		return configList;
	}

	// Token: 0x0600EACA RID: 60106 RVA: 0x003FADFC File Offset: 0x003F8FFC
	public HonamiStoryAreaTask? GetHonamiStoryAreaTaskById(int id)
	{
		HonamiStoryAreaTask? config = ConfigHonamiStoryAreaTaskById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryAreaTask表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryAreaTask?(config.Value);
	}

	// Token: 0x0600EACB RID: 60107 RVA: 0x003FAE60 File Offset: 0x003F9060
	public HonamiStoryLimitTask? GetHonamiStoryLimitTaskConfig(int configId)
	{
		HonamiStoryLimitTask? config = ConfigHonamiStoryLimitTaskById.GetConfig(configId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryLimitTask表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", configId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryLimitTask?(config.Value);
	}

	// Token: 0x0600EACC RID: 60108 RVA: 0x003FAEC4 File Offset: 0x003F90C4
	public HonamiStoryResidentTask? GetHonamiStoryPermanentTaskConfig(int configId)
	{
		HonamiStoryResidentTask? config = ConfigHonamiStoryResidentTaskById.GetConfig(configId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryResidentTask表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", configId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryResidentTask?(config.Value);
	}

	// Token: 0x0600EACD RID: 60109 RVA: 0x003FAF28 File Offset: 0x003F9128
	public HonamiStoryScoreReward? GetHonamiStoryScoreRewardConfig(int configId)
	{
		HonamiStoryScoreReward? config = ConfigHonamiStoryScoreRewardById.GetConfig(configId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryScoreReward表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", configId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryScoreReward?(config.Value);
	}

	// Token: 0x0600EACE RID: 60110 RVA: 0x003FAF8C File Offset: 0x003F918C
	public HonamiStoryWeaponSuit? GetWeaponSuit(int id)
	{
		HonamiStoryWeaponSuit? config = ConfigHonamiStoryWeaponSuitById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryWeaponSuit表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryWeaponSuit?(config.Value);
	}

	// Token: 0x0600EACF RID: 60111 RVA: 0x003FAFF0 File Offset: 0x003F91F0
	public HonamiStoryPluginSubType? GetPluginSubType(int id)
	{
		HonamiStoryPluginSubType? config = ConfigHonamiStoryPluginSubTypeById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryPluginSubType表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryPluginSubType?(config.Value);
	}

	// Token: 0x0600EAD0 RID: 60112 RVA: 0x003FB054 File Offset: 0x003F9254
	public HonamiStoryPluginTag? GetPluginTag(int id)
	{
		HonamiStoryPluginTag? config = ConfigHonamiStoryPluginTagById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryPluginTag表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryPluginTag?(config.Value);
	}

	// Token: 0x0600EAD1 RID: 60113 RVA: 0x003FB0B8 File Offset: 0x003F92B8
	public HonamiStoryLifeSupport? GetLifeSupport(int id)
	{
		HonamiStoryLifeSupport? config = ConfigHonamiStoryLifeSupportById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryLifeSupport表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryLifeSupport?(config.Value);
	}

	// Token: 0x0600EAD2 RID: 60114 RVA: 0x003FB11C File Offset: 0x003F931C
	public IReadOnlyList<HonamiStoryLifeSupport> GetLifeSupportList(int activityId)
	{
		IReadOnlyList<HonamiStoryLifeSupport> configList = ConfigHonamiStoryLifeSupportByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryLifeSupport表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<HonamiStoryLifeSupport>();
		}
		return configList;
	}

	// Token: 0x0600EAD3 RID: 60115 RVA: 0x003FB16C File Offset: 0x003F936C
	public HonamiStoryWeapon? GetWeaponConfig(int id)
	{
		if (id == 0)
		{
			return null;
		}
		HonamiStoryWeapon? config = ConfigHonamiStoryWeaponById.GetConfig(id, true);
		if (id > 0 && config == null)
		{
			return null;
		}
		if (config == null)
		{
			return null;
		}
		return new HonamiStoryWeapon?(config.Value);
	}

	// Token: 0x0600EAD4 RID: 60116 RVA: 0x003FB1C4 File Offset: 0x003F93C4
	public IReadOnlyList<HonamiStoryWeapon> GetHonamiStoryWeaponConfigList(int activityId)
	{
		IReadOnlyList<HonamiStoryWeapon> configList = ConfigHonamiStoryWeaponByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryWeapon表无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<HonamiStoryWeapon>();
		}
		return configList;
	}

	// Token: 0x0600EAD5 RID: 60117 RVA: 0x003FB214 File Offset: 0x003F9414
	public IReadOnlyList<HonamiStoryOutDialog> GetHonamiStoryOutDialogList(int activityId)
	{
		IReadOnlyList<HonamiStoryOutDialog> configList = ConfigHonamiStoryOutDialogByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryOutDialog表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<HonamiStoryOutDialog>();
		}
		return configList;
	}

	// Token: 0x0600EAD6 RID: 60118 RVA: 0x003FB264 File Offset: 0x003F9464
	public HonamiStoryEffect? GetEffectConfig(int id)
	{
		HonamiStoryEffect? config = ConfigHonamiStoryEffectById.GetConfig(id, true);
		if (id > 0 && config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryEffect表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (config == null)
		{
			return null;
		}
		return new HonamiStoryEffect?(config.Value);
	}

	// Token: 0x0600EAD7 RID: 60119 RVA: 0x003FB2E0 File Offset: 0x003F94E0
	public int GetDoubleClickDelay()
	{
		return ConfigCommonParamById.GetIntConfig("HonamiStoryBackpackClickInterval").GetValueOrDefault(300);
	}

	// Token: 0x0600EAD8 RID: 60120 RVA: 0x003FB304 File Offset: 0x003F9504
	public HonamiStoryPluginSlot? GetSlotUnlockConfig(int id)
	{
		HonamiStoryPluginSlot? config = ConfigHonamiStoryPluginSlotById.GetConfig(id, true);
		if (id > 0 && config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryPluginSlot表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (config == null)
		{
			return null;
		}
		return new HonamiStoryPluginSlot?(config.Value);
	}

	// Token: 0x0600EAD9 RID: 60121 RVA: 0x003FB380 File Offset: 0x003F9580
	public HonamiStoryDangerLevel? GetDangerLevelConfig(int id)
	{
		HonamiStoryDangerLevel? config = ConfigHonamiStoryDangerLevelById.GetConfig(id, true);
		if (id > 0 && config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryEffect表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (config == null)
		{
			return null;
		}
		return new HonamiStoryDangerLevel?(config.Value);
	}

	// Token: 0x0600EADA RID: 60122 RVA: 0x003FB3FC File Offset: 0x003F95FC
	public HonamiStoryLoadingPerform? GetLoadingPerformConfigById(int id)
	{
		HonamiStoryLoadingPerform? config = ConfigHonamiStoryLoadingPerformById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryLoadingPerform表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryLoadingPerform?(config.Value);
	}

	// Token: 0x0600EADB RID: 60123 RVA: 0x003FB460 File Offset: 0x003F9660
	public unsafe HonamiStoryLoadingPerform? GetLoadingPerformConfigByBtAndTime(int mainBtId, int timing)
	{
		HonamiStoryLoadingPerform? config = ConfigHonamiStoryLoadingPerformByBTIdAndTiming.GetConfig(mainBtId, timing, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryLoadingPerform表无效BtId/timing";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BtId", mainBtId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Timing", timing);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return new HonamiStoryLoadingPerform?(config.Value);
	}

	// Token: 0x0600EADC RID: 60124 RVA: 0x003FB4F8 File Offset: 0x003F96F8
	public IReadOnlyList<HonamiStoryLoadingPerform> GetLoadingPerformConfigListByTiming(int timing)
	{
		IReadOnlyList<HonamiStoryLoadingPerform> configList = ConfigHonamiStoryLoadingPerformByTiming.GetConfigList(timing, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryLoadingPerform表无效timing";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("timing", timing);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<HonamiStoryLoadingPerform>();
		}
		return configList;
	}

	// Token: 0x0600EADD RID: 60125 RVA: 0x003FB548 File Offset: 0x003F9748
	public IReadOnlyList<HonamiStoryMapMark> GetHonamiMapMarkList()
	{
		IReadOnlyList<HonamiStoryMapMark> configList = ConfigHonamiStoryMapMarkAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.LYX, "HonamiStoryMapMark表无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<HonamiStoryMapMark>();
		}
		return configList;
	}

	// Token: 0x0600EADE RID: 60126 RVA: 0x003FB588 File Offset: 0x003F9788
	public HonamiStoryMapMark? GetHonamiMapMarkById(int id)
	{
		HonamiStoryMapMark? config = ConfigHonamiStoryMapMarkById.GetConfig(id, true);
		if (id > 0 && config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LYX;
			string message = "HonamiStoryMapMark表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (config == null)
		{
			return null;
		}
		return new HonamiStoryMapMark?(config.Value);
	}

	// Token: 0x0600EADF RID: 60127 RVA: 0x003FB604 File Offset: 0x003F9804
	public HonamiStoryMarkWhiteList? GetHonamiScanItemWhiteListConfigByEntityConfigId(int entityConfigId)
	{
		HonamiStoryMarkWhiteList? config = ConfigHonamiStoryMarkWhiteListById.GetConfig(entityConfigId, true);
		if (config == null)
		{
			return null;
		}
		return new HonamiStoryMarkWhiteList?(config.Value);
	}

	// Token: 0x0600EAE0 RID: 60128 RVA: 0x003FB638 File Offset: 0x003F9838
	public IReadOnlyList<int> GetHonamiScanItemWhileListIds()
	{
		IReadOnlyList<HonamiStoryMarkWhiteList> configList = ConfigHonamiStoryMarkWhiteListAll.GetConfigList(true);
		if (configList == null)
		{
			return new List<int>();
		}
		List<int> list = new List<int>();
		foreach (HonamiStoryMarkWhiteList honamiStoryMarkWhiteList in configList)
		{
			list.Add(honamiStoryMarkWhiteList.Id);
		}
		return list;
	}

	// Token: 0x0600EAE1 RID: 60129 RVA: 0x003FB6A0 File Offset: 0x003F98A0
	public HonamiStoryPluginBoxItem? GetHonamiStoryPluginBoxItemById(int id)
	{
		HonamiStoryPluginBoxItem? config = ConfigHonamiStoryPluginBoxItemById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			string message = "HonamiStoryPluginBoxItem表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryPluginBoxItem?(config.Value);
	}

	// Token: 0x0600EAE2 RID: 60130 RVA: 0x003FB704 File Offset: 0x003F9904
	public IReadOnlyList<HonamiStoryPluginBoxItem> GetHonamiStoryPluginBoxItemList(int activityId)
	{
		IReadOnlyList<HonamiStoryPluginBoxItem> configList = ConfigHonamiStoryPluginBoxItemByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			string message = "HonamiStoryPluginBoxItem表无效ActivityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<HonamiStoryPluginBoxItem>();
		}
		return configList;
	}

	// Token: 0x0600EAE3 RID: 60131 RVA: 0x003FB754 File Offset: 0x003F9954
	public int GetScrollingSpeed()
	{
		return ConfigCommonParamById.GetIntConfig("HonamiStoryScrollMoveSpeed").GetValueOrDefault(10);
	}

	// Token: 0x0600EAE4 RID: 60132 RVA: 0x003FB778 File Offset: 0x003F9978
	public int GetDragThresholdSpeed()
	{
		return ConfigCommonParamById.GetIntConfig("HonamiStoryDragBeginDistanceThreshold").GetValueOrDefault(9);
	}

	// Token: 0x0600EAE5 RID: 60133 RVA: 0x003FB79C File Offset: 0x003F999C
	[NullableContext(0)]
	public ValueTuple<int, int> GetDragOffset()
	{
		if (!HonamiStoryUtil.IsMobileView())
		{
			return new ValueTuple<int, int>(0, 0);
		}
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("HonamiStoryMobileDragOffsetX").GetValueOrDefault();
		int valueOrDefault2 = ConfigCommonParamById.GetIntConfig("HonamiStoryMobileDragOffsetY").GetValueOrDefault(140);
		return new ValueTuple<int, int>(valueOrDefault, valueOrDefault2);
	}

	// Token: 0x0600EAE6 RID: 60134 RVA: 0x003FB7E8 File Offset: 0x003F99E8
	public int GetPickUpRange()
	{
		return ConfigCommonParamById.GetIntConfig("HonamiStoryMobilePickUpRange").GetValueOrDefault(1000);
	}

	// Token: 0x0600EAE7 RID: 60135 RVA: 0x003FB80C File Offset: 0x003F9A0C
	public HonamiStoryScanMachine? GetScanMachineById(int id)
	{
		HonamiStoryScanMachine? config = ConfigHonamiStoryScanMachineById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LYX;
			string message = "HonamiStoryScanMachine表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new HonamiStoryScanMachine?(config.Value);
	}
}
