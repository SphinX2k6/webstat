using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BF7 RID: 7159
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class FloroRanchConfig : ConfigBase<FloroRanchConfig>
{
	// Token: 0x0600D033 RID: 53299 RVA: 0x003749FC File Offset: 0x00372BFC
	public FloroRanchActivity? GetFloroRanchActivityConfig(int activityId)
	{
		FloroRanchActivity? config = ConfigFloroRanchActivityById.GetConfig(activityId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchActivity表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600D034 RID: 53300 RVA: 0x00374A54 File Offset: 0x00372C54
	public IReadOnlyList<FloroRanchIns> GetFloroRanchDungeonConfigList(int activityId)
	{
		IReadOnlyList<FloroRanchIns> configList = ConfigFloroRanchInsByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchIns表 无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<FloroRanchIns>();
		}
		return configList;
	}

	// Token: 0x0600D035 RID: 53301 RVA: 0x00374AA4 File Offset: 0x00372CA4
	public FloroRanchSubIns? GetFloroRanchSubDungeonConfig(int id)
	{
		FloroRanchSubIns? config = ConfigFloroRanchSubInsById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchSubIns表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600D036 RID: 53302 RVA: 0x00374AFC File Offset: 0x00372CFC
	public IReadOnlyList<FloroRanchRarity> GetFloroRanchRarityConfigList()
	{
		IReadOnlyList<FloroRanchRarity> configList = ConfigFloroRanchRarityAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.BB, "FloroRanchRarity表获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<FloroRanchRarity>();
		}
		return configList;
	}

	// Token: 0x0600D037 RID: 53303 RVA: 0x00374B3C File Offset: 0x00372D3C
	public FloroRanchRace? GetFloroRanchRaceConfig(int id)
	{
		FloroRanchRace? config = ConfigFloroRanchRaceById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanchRace表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600D038 RID: 53304 RVA: 0x00374B94 File Offset: 0x00372D94
	public IReadOnlyList<FloroRanchRace> GetFloroRanchRaceConfigList()
	{
		IReadOnlyList<FloroRanchRace> configList = ConfigFloroRanchRaceAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.BB, "FloroRanchRace表获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<FloroRanchRace>();
		}
		return configList;
	}

	// Token: 0x0600D039 RID: 53305 RVA: 0x00374BD4 File Offset: 0x00372DD4
	public FloroRanchCard? GetFloroRanchCardConfig(int id)
	{
		FloroRanchCard? config = ConfigFloroRanchCardById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanchCard表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600D03A RID: 53306 RVA: 0x00374C2C File Offset: 0x00372E2C
	public IReadOnlyList<FloroRanchCard> GetFloroRanchCardConfigList()
	{
		IReadOnlyList<FloroRanchCard> configList = ConfigFloroRanchCardAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.BB, "FloroRanchCard表获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<FloroRanchCard>();
		}
		return configList;
	}

	// Token: 0x0600D03B RID: 53307 RVA: 0x00374C6C File Offset: 0x00372E6C
	public FloroRanchToy? GetFloroRanchToyConfig(int id)
	{
		FloroRanchToy? config = ConfigFloroRanchToyById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanchToy表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600D03C RID: 53308 RVA: 0x00374CC4 File Offset: 0x00372EC4
	public IReadOnlyList<FloroRanchToy> GetFloroRanchToyConfigList()
	{
		IReadOnlyList<FloroRanchToy> configList = ConfigFloroRanchToyAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.BB, "FloroRanchToy表获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<FloroRanchToy>();
		}
		return configList;
	}

	// Token: 0x0600D03D RID: 53309 RVA: 0x00374D04 File Offset: 0x00372F04
	public IReadOnlyList<FloroRanchTerrain> GetFloroRanchTerrainConfigList()
	{
		IReadOnlyList<FloroRanchTerrain> configList = ConfigFloroRanchTerrainAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.BB, "FloroRanchTerrain表获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<FloroRanchTerrain>();
		}
		return configList;
	}

	// Token: 0x0600D03E RID: 53310 RVA: 0x00374D44 File Offset: 0x00372F44
	public FloroRanchSkill? GetFloroRanchSkillConfig(int id)
	{
		FloroRanchSkill? config = ConfigFloroRanchSkillById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanchSkill表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600D03F RID: 53311 RVA: 0x00374D9C File Offset: 0x00372F9C
	public IReadOnlyList<FloroRanchSkill> GetFloroRanchSkillConfigList()
	{
		IReadOnlyList<FloroRanchSkill> configList = ConfigFloroRanchSkillAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.BB, "FloroRanchSkill表获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<FloroRanchSkill>();
		}
		return configList;
	}

	// Token: 0x0600D040 RID: 53312 RVA: 0x00374DDC File Offset: 0x00372FDC
	public IReadOnlyList<FloroRanchTech> GetFloroRanchTechnologyConfigList(int activityId)
	{
		IReadOnlyList<FloroRanchTech> configList = ConfigFloroRanchTechByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchTech表无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<FloroRanchTech>();
		}
		return configList;
	}

	// Token: 0x0600D041 RID: 53313 RVA: 0x00374E2C File Offset: 0x0037302C
	public IReadOnlyList<FloroRanchTask> GetFloroRanchTaskConfigList(int activityId)
	{
		IReadOnlyList<FloroRanchTask> configList = ConfigFloroRanchTaskByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchTask表无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<FloroRanchTask>();
		}
		return configList;
	}

	// Token: 0x0600D042 RID: 53314 RVA: 0x00374E7C File Offset: 0x0037307C
	public IReadOnlyList<FloroRanchReward> GetFloroRanchRewardConfigList(int activityId)
	{
		IReadOnlyList<FloroRanchReward> configList = ConfigFloroRanchRewardByActivityId.GetConfigList(activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchReward表无效activityId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<FloroRanchReward>();
		}
		return configList;
	}

	// Token: 0x0600D043 RID: 53315 RVA: 0x00374ECC File Offset: 0x003730CC
	public IReadOnlyList<FloroRanchFilterType> GetFloroRanchFilterTypeConfigList()
	{
		IReadOnlyList<FloroRanchFilterType> configList = ConfigFloroRanchFilterTypeAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.LRC, "FloroRanchFilterType表获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<FloroRanchFilterType>();
		}
		return configList;
	}

	// Token: 0x0600D044 RID: 53316 RVA: 0x00374F0C File Offset: 0x0037310C
	public IReadOnlyList<FloroRanchCardGroup> GetFloroRanchCardGroupConfigList()
	{
		IReadOnlyList<FloroRanchCardGroup> configList = ConfigFloroRanchCardGroupAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.BB, "FloroRanchCardGroup表获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<FloroRanchCardGroup>();
		}
		return configList;
	}

	// Token: 0x0600D045 RID: 53317 RVA: 0x00374F4C File Offset: 0x0037314C
	public IReadOnlyList<FloroRanchCurrency> GetFloroRanchCurrencyConfigList()
	{
		IReadOnlyList<FloroRanchCurrency> configList = ConfigFloroRanchCurrencyAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.LRC, "FloroRanchCurrency表获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<FloroRanchCurrency>();
		}
		return configList;
	}

	// Token: 0x0600D046 RID: 53318 RVA: 0x00374F8C File Offset: 0x0037318C
	public FloroRanchBuff? GetFloroRanchBuffById(int id)
	{
		FloroRanchBuff? config = ConfigFloroRanchBuffById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanchBuff表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600D047 RID: 53319 RVA: 0x00374FE4 File Offset: 0x003731E4
	public FloroRanchWeeklyEvent? GetFloroRanchWeeklyEventById(int id)
	{
		FloroRanchWeeklyEvent? config = ConfigFloroRanchWeeklyEventById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanchWeeklyEvent表获取失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600D048 RID: 53320 RVA: 0x0037503C File Offset: 0x0037323C
	public FloroRanchWeeklyChoice? GetFloroRanchWeeklyChoiceById(int id)
	{
		FloroRanchWeeklyChoice? config = ConfigFloroRanchWeeklyChoiceById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanchWeeklyChoice表获取失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600D049 RID: 53321 RVA: 0x00375094 File Offset: 0x00373294
	public IReadOnlyList<FloroRanchAudio> GetFloroRanchAudioConfigList()
	{
		IReadOnlyList<FloroRanchAudio> configList = ConfigFloroRanchAudioAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.BB, "FloroRanchAudio表获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<FloroRanchAudio>();
		}
		return configList;
	}

	// Token: 0x0600D04A RID: 53322 RVA: 0x003750D4 File Offset: 0x003732D4
	public IReadOnlyList<FloroRanchTaskTab> GetFloroRanchTaskTabConfigList()
	{
		IReadOnlyList<FloroRanchTaskTab> configList = ConfigFloroRanchTaskTabAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.CXJ, "FloroRanchTaskTab表获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<FloroRanchTaskTab>();
		}
		return configList;
	}

	// Token: 0x0600D04B RID: 53323 RVA: 0x00375114 File Offset: 0x00373314
	public FloroRanchTag? GetFloroRanchTagConfig(int tagId)
	{
		FloroRanchTag? config = ConfigFloroRanchTagById.GetConfig(tagId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchTag表无效tagId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tagId", tagId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600D04C RID: 53324 RVA: 0x0037516C File Offset: 0x0037336C
	public FloroRanchAction? GetFloroRanchActionConfig(int actionId)
	{
		FloroRanchAction? config = ConfigFloroRanchActionById.GetConfig(actionId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchAction表无效actionId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionId", actionId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}
}
