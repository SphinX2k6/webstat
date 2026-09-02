using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.FloroRanch;

// Token: 0x02001C0D RID: 7181
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class FloroRanchModel : ModelBase<FloroRanchModel>
{
	// Token: 0x0600D0F2 RID: 53490 RVA: 0x00377A9C File Offset: 0x00375C9C
	public void SetActivityData(EFloroRanchActivityDataType activityType, FloroRanchActivityData activityData)
	{
		if (this.ActivityDataMap.ContainsKey(activityType))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "ActivityData already exists";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityType", activityType);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.ActivityDataMap[activityType] = activityData;
	}

	// Token: 0x0600D0F3 RID: 53491 RVA: 0x00377AF4 File Offset: 0x00375CF4
	[NullableContext(2)]
	public FloroRanchActivityData GetActivityData(EFloroRanchActivityDataType activityType = EFloroRanchActivityDataType.Normal, bool bShowLog = true)
	{
		FloroRanchActivityData floroRanchActivityData;
		this.ActivityDataMap.TryGetValue(activityType, out floroRanchActivityData);
		if (floroRanchActivityData == null && bShowLog)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanch, ELogAuthor.BB, "FloroRanchActivityData is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return floroRanchActivityData;
	}

	// Token: 0x0600D0F4 RID: 53492 RVA: 0x00377B3C File Offset: 0x00375D3C
	private void InitFloroRanchRarity()
	{
		this.FloroRanchRarityMap.Clear();
		foreach (FloroRanchRarity config in ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchRarityConfigList())
		{
			FloroRanchRarityData value = new FloroRanchRarityData(config);
			this.FloroRanchRarityMap[config.Id] = value;
		}
	}

	// Token: 0x0600D0F5 RID: 53493 RVA: 0x00377BAC File Offset: 0x00375DAC
	[NullableContext(2)]
	public FloroRanchRarityData GetFloroRanchRarity(int id)
	{
		if (this.FloroRanchRarityMap.Count <= 0)
		{
			this.InitFloroRanchRarity();
		}
		FloroRanchRarityData result;
		if (this.FloroRanchRarityMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanch;
		ELogAuthor author = ELogAuthor.BB;
		string message = "Invalid FloroRanchRarity";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600D0F6 RID: 53494 RVA: 0x00377C10 File Offset: 0x00375E10
	private void InitFloroRanchTerrain()
	{
		this.FloroRanchTerrainMap.Clear();
		foreach (FloroRanchTerrain config in ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchTerrainConfigList())
		{
			FloroRanchTerrainData value = new FloroRanchTerrainData(config);
			this.FloroRanchTerrainMap[config.Id] = value;
		}
	}

	// Token: 0x0600D0F7 RID: 53495 RVA: 0x00377C80 File Offset: 0x00375E80
	[NullableContext(2)]
	public FloroRanchTerrainData GetFloroRanchTerrain(int id)
	{
		if (this.FloroRanchTerrainMap.Count <= 0)
		{
			this.InitFloroRanchTerrain();
		}
		FloroRanchTerrainData result;
		if (this.FloroRanchTerrainMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanch;
		ELogAuthor author = ELogAuthor.BB;
		string message = "Invalid FloroRanchTerrain";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600D0F8 RID: 53496 RVA: 0x00377CE4 File Offset: 0x00375EE4
	private void InitFloroRanchAudio()
	{
		this.FloroRanchAudioMap.Clear();
		foreach (FloroRanchAudio config in ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchAudioConfigList())
		{
			FloroRanchAudioData item = new FloroRanchAudioData(config);
			Dictionary<EFloroRanchAudioType, List<FloroRanchAudioData>> dictionary;
			if (!this.FloroRanchAudioMap.TryGetValue((EFloroRanchCharacterType)config.CharacterType, out dictionary))
			{
				dictionary = new Dictionary<EFloroRanchAudioType, List<FloroRanchAudioData>>();
				this.FloroRanchAudioMap[(EFloroRanchCharacterType)config.CharacterType] = dictionary;
			}
			List<FloroRanchAudioData> list;
			if (!dictionary.TryGetValue((EFloroRanchAudioType)config.Type, out list))
			{
				list = new List<FloroRanchAudioData>();
			}
			list.Add(item);
			dictionary[(EFloroRanchAudioType)config.Type] = list;
		}
	}

	// Token: 0x0600D0F9 RID: 53497 RVA: 0x00377DA0 File Offset: 0x00375FA0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<FloroRanchAudioData> GetFloroRanchAudioListForCharacterAndType(EFloroRanchCharacterType characterType, EFloroRanchAudioType type)
	{
		if (this.FloroRanchAudioMap.Count <= 0)
		{
			this.InitFloroRanchAudio();
		}
		Dictionary<EFloroRanchAudioType, List<FloroRanchAudioData>> dictionary;
		List<FloroRanchAudioData> result;
		if (this.FloroRanchAudioMap.TryGetValue(characterType, out dictionary) && dictionary.TryGetValue(type, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600D0FA RID: 53498 RVA: 0x00377DE0 File Offset: 0x00375FE0
	[NullableContext(2)]
	public unsafe FloroRanchAudioData GetFloroRanchRandomAudioDataByType(EFloroRanchAudioType type, EFloroRanchCharacterType characterType = EFloroRanchCharacterType.Floro)
	{
		List<FloroRanchAudioData> floroRanchAudioListForCharacterAndType = this.GetFloroRanchAudioListForCharacterAndType(characterType, type);
		if ((floroRanchAudioListForCharacterAndType == null || floroRanchAudioListForCharacterAndType.Count <= 0) && characterType != EFloroRanchCharacterType.Floro)
		{
			floroRanchAudioListForCharacterAndType = this.GetFloroRanchAudioListForCharacterAndType(EFloroRanchCharacterType.Floro, type);
		}
		if (floroRanchAudioListForCharacterAndType == null || floroRanchAudioListForCharacterAndType.Count <= 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "Invalid FloroRanchAudio";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("type", type);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("characterType", characterType);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return ObjectUtils.GetRandomArrayItem<FloroRanchAudioData>(floroRanchAudioListForCharacterAndType);
	}

	// Token: 0x0600D0FB RID: 53499 RVA: 0x00377E84 File Offset: 0x00376084
	private void InitFloroRanchCardGroup()
	{
		this.FloroRanchCardGroupMap.Clear();
		foreach (FloroRanchCardGroup config in ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchCardGroupConfigList())
		{
			FloroRanchCardGroupData value = new FloroRanchCardGroupData(config);
			this.FloroRanchCardGroupMap[config.Id] = value;
		}
	}

	// Token: 0x0600D0FC RID: 53500 RVA: 0x00377EF4 File Offset: 0x003760F4
	[NullableContext(2)]
	public FloroRanchCardGroupData GetFloroRanchCardGroup(int id)
	{
		if (this.FloroRanchCardGroupMap.Count <= 0)
		{
			this.InitFloroRanchCardGroup();
		}
		FloroRanchCardGroupData result;
		if (this.FloroRanchCardGroupMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanch;
		ELogAuthor author = ELogAuthor.BB;
		string message = "Invalid FloroRanchCardGroup";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600D0FD RID: 53501 RVA: 0x00377F58 File Offset: 0x00376158
	private void InitFloroRanchCurrency()
	{
		this.FloroRanchCurrencyMap.Clear();
		foreach (FloroRanchCurrency config in ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchCurrencyConfigList())
		{
			FloroRanchCurrencyConfigData value = new FloroRanchCurrencyConfigData(config);
			this.FloroRanchCurrencyMap[config.Id] = value;
		}
	}

	// Token: 0x0600D0FE RID: 53502 RVA: 0x00377FC8 File Offset: 0x003761C8
	[NullableContext(2)]
	public FloroRanchCurrencyConfigData GetFloroRanchCurrencyConfig(ECurrencyType currencyType)
	{
		if (this.FloroRanchCurrencyMap.Count <= 0)
		{
			this.InitFloroRanchCurrency();
		}
		FloroRanchCurrencyConfigData result;
		if (this.FloroRanchCurrencyMap.TryGetValue((int)currencyType, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanch;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "Invalid FloroRanchCurrency";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("currencyType", currencyType);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600D0FF RID: 53503 RVA: 0x0037802C File Offset: 0x0037622C
	private void InitFloroRanchCardData()
	{
		this.FloroRanchCardDataMap.Clear();
		this.FloroRanchRaceToCardDataMap.Clear();
		foreach (FloroRanchCard config in ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchCardConfigList())
		{
			FloroRanchCardData floroRanchCardData = new FloroRanchCardData(config);
			this.FloroRanchCardDataMap[config.Id] = floroRanchCardData;
			if (floroRanchCardData.IsShowInHandBook)
			{
				int race = config.Race;
				if (!this.FloroRanchRaceToCardDataMap.ContainsKey(race))
				{
					this.FloroRanchRaceToCardDataMap[race] = new List<FloroRanchCardData>();
				}
				this.FloroRanchRaceToCardDataMap[race].Add(floroRanchCardData);
			}
		}
	}

	// Token: 0x0600D100 RID: 53504 RVA: 0x003780E8 File Offset: 0x003762E8
	[NullableContext(2)]
	public FloroRanchCardData GetFloroRanchCardData(int id)
	{
		if (this.FloroRanchCardDataMap.Count <= 0)
		{
			this.InitFloroRanchCardData();
		}
		FloroRanchCardData result;
		if (this.FloroRanchCardDataMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanch;
		ELogAuthor author = ELogAuthor.BB;
		string message = "Invalid FloroRanchCardData";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600D101 RID: 53505 RVA: 0x0037814C File Offset: 0x0037634C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<FloroRanchCardData> GetFloroRanchCardDataListByRace(int race)
	{
		if (this.FloroRanchCardDataMap.Count <= 0)
		{
			this.InitFloroRanchCardData();
		}
		List<FloroRanchCardData> result;
		this.FloroRanchRaceToCardDataMap.TryGetValue(race, out result);
		return result;
	}

	// Token: 0x0600D102 RID: 53506 RVA: 0x0037817D File Offset: 0x0037637D
	public Dictionary<int, FloroRanchCardData> GetFloroRanchCardDataMap()
	{
		if (this.FloroRanchCardDataMap.Count <= 0)
		{
			this.InitFloroRanchCardData();
		}
		return this.FloroRanchCardDataMap;
	}

	// Token: 0x0600D103 RID: 53507 RVA: 0x0037819C File Offset: 0x0037639C
	private void InitFloroRanchToyData()
	{
		this.FloroRanchToyDataMap.Clear();
		foreach (FloroRanchToy config in ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchToyConfigList())
		{
			FloroRanchToyData value = new FloroRanchToyData(config);
			this.FloroRanchToyDataMap[config.Id] = value;
		}
	}

	// Token: 0x0600D104 RID: 53508 RVA: 0x0037820C File Offset: 0x0037640C
	[NullableContext(2)]
	public FloroRanchToyData GetFloroRanchToyData(int id)
	{
		if (this.FloroRanchToyDataMap.Count <= 0)
		{
			this.InitFloroRanchToyData();
		}
		FloroRanchToyData result;
		if (this.FloroRanchToyDataMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanch;
		ELogAuthor author = ELogAuthor.BB;
		string message = "Invalid FloroRanchToyData";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600D105 RID: 53509 RVA: 0x0037826F File Offset: 0x0037646F
	public Dictionary<int, FloroRanchToyData> GetFloroRanchToyDataMap()
	{
		if (this.FloroRanchToyDataMap.Count <= 0)
		{
			this.InitFloroRanchToyData();
		}
		return this.FloroRanchToyDataMap;
	}

	// Token: 0x0600D106 RID: 53510 RVA: 0x0037828C File Offset: 0x0037648C
	private void InitFloroRanchSkillData()
	{
		this.FloroRanchSkillDataMap.Clear();
		foreach (FloroRanchSkill config in ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchSkillConfigList())
		{
			FloroRanchSkillData value = new FloroRanchSkillData(config);
			this.FloroRanchSkillDataMap[config.Id] = value;
		}
	}

	// Token: 0x0600D107 RID: 53511 RVA: 0x003782FC File Offset: 0x003764FC
	[NullableContext(2)]
	public FloroRanchSkillData GetFloroRanchSkillData(int id)
	{
		if (this.FloroRanchSkillDataMap.Count <= 0)
		{
			this.InitFloroRanchSkillData();
		}
		FloroRanchSkillData result;
		if (this.FloroRanchSkillDataMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanch;
		ELogAuthor author = ELogAuthor.BB;
		string message = "Invalid FloroRanchSkillData";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600D108 RID: 53512 RVA: 0x00378360 File Offset: 0x00376560
	public List<FloroRanchSkillData> GetFloroRanchSkillDataList()
	{
		if (this.FloroRanchSkillDataMap.Count <= 0)
		{
			this.InitFloroRanchSkillData();
		}
		List<FloroRanchSkillData> list = new List<FloroRanchSkillData>(this.FloroRanchSkillDataMap.Values);
		list.Sort((FloroRanchSkillData a, FloroRanchSkillData b) => a.Id - b.Id);
		return list;
	}

	// Token: 0x0600D109 RID: 53513 RVA: 0x003783B8 File Offset: 0x003765B8
	private void InitFloroRanchRaceData()
	{
		this.FloroRanchRaceDataMap.Clear();
		this.FloroRanchRaceDataList = null;
		this.FloroRanchRaceDataListIncludeCommon = null;
		foreach (FloroRanchRace config in ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchRaceConfigList())
		{
			FloroRanchRaceData value = new FloroRanchRaceData(config);
			this.FloroRanchRaceDataMap[config.Id] = value;
		}
	}

	// Token: 0x0600D10A RID: 53514 RVA: 0x00378438 File Offset: 0x00376638
	[NullableContext(2)]
	public FloroRanchRaceData GetFloroRanchRaceData(int id)
	{
		if (this.FloroRanchRaceDataMap.Count <= 0)
		{
			this.InitFloroRanchRaceData();
		}
		FloroRanchRaceData result;
		if (this.FloroRanchRaceDataMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanch;
		ELogAuthor author = ELogAuthor.CXJ;
		string message = "Invalid FloroRanchRaceData";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600D10B RID: 53515 RVA: 0x0037849C File Offset: 0x0037669C
	public List<FloroRanchRaceData> GetFloroRanchRaceDataList(bool isIncludeCommonRace = false)
	{
		if (this.FloroRanchRaceDataMap.Count <= 0)
		{
			this.InitFloroRanchRaceData();
		}
		if (this.FloroRanchRaceDataList == null || this.FloroRanchRaceDataListIncludeCommon == null)
		{
			this.FloroRanchRaceDataList = new List<FloroRanchRaceData>();
			this.FloroRanchRaceDataListIncludeCommon = new List<FloroRanchRaceData>();
			foreach (FloroRanchRaceData floroRanchRaceData in this.FloroRanchRaceDataMap.Values)
			{
				if (!floroRanchRaceData.IsCommon)
				{
					this.FloroRanchRaceDataList.Add(floroRanchRaceData);
				}
				this.FloroRanchRaceDataListIncludeCommon.Add(floroRanchRaceData);
			}
			this.FloroRanchRaceDataList.Sort((FloroRanchRaceData a, FloroRanchRaceData b) => a.Id - b.Id);
			this.FloroRanchRaceDataListIncludeCommon.Sort((FloroRanchRaceData a, FloroRanchRaceData b) => a.Id - b.Id);
		}
		if (!isIncludeCommonRace)
		{
			return this.FloroRanchRaceDataList;
		}
		return this.FloroRanchRaceDataListIncludeCommon;
	}

	// Token: 0x0600D10C RID: 53516 RVA: 0x003785B0 File Offset: 0x003767B0
	public Dictionary<int, FloroRanchRaceData> GetFloroRanchRaceDataMap()
	{
		if (this.FloroRanchRaceDataMap.Count <= 0)
		{
			this.InitFloroRanchRaceData();
		}
		return this.FloroRanchRaceDataMap;
	}

	// Token: 0x0600D10D RID: 53517 RVA: 0x003785CC File Offset: 0x003767CC
	public List<FloroRanchTaskTab> GetTaskTabList()
	{
		List<FloroRanchTaskTab> list = new List<FloroRanchTaskTab>(ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchTaskTabConfigList());
		list.Sort((FloroRanchTaskTab a, FloroRanchTaskTab b) => b.Sort - a.Sort);
		return list;
	}

	// Token: 0x0600D10E RID: 53518 RVA: 0x00378602 File Offset: 0x00376802
	public string GetCoinText(int coinNum)
	{
		if (coinNum <= this.MaxCoinNum)
		{
			return coinNum.ToString();
		}
		return coinNum.ToString("0.00e+0");
	}

	// Token: 0x0600D10F RID: 53519 RVA: 0x00378624 File Offset: 0x00376824
	public EFloroRanchActivityDataType GetActivityDataType(int activityId)
	{
		if (activityId == 0)
		{
			return EFloroRanchActivityDataType.Normal;
		}
		FloroRanchActivity? floroRanchActivityConfig = ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchActivityConfig(activityId);
		if (floroRanchActivityConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "Invalid FloroRanchActivity";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return EFloroRanchActivityDataType.Normal;
		}
		return (EFloroRanchActivityDataType)floroRanchActivityConfig.Value.ActivityType;
	}

	// Token: 0x0600D110 RID: 53520 RVA: 0x0037868B File Offset: 0x0037688B
	public ELocalStoragePlayerKey GetSkillStorageKeyByActivityType(EFloroRanchActivityDataType activityType)
	{
		if (activityType == EFloroRanchActivityDataType.Weekly)
		{
			return ELocalStoragePlayerKey.FloroRanchSkillIdWeekly;
		}
		return ELocalStoragePlayerKey.FloroRanchSkillId;
	}

	// Token: 0x040063C9 RID: 25545
	private readonly Dictionary<EFloroRanchActivityDataType, FloroRanchActivityData> ActivityDataMap = new Dictionary<EFloroRanchActivityDataType, FloroRanchActivityData>();

	// Token: 0x040063CA RID: 25546
	private readonly Dictionary<int, FloroRanchRarityData> FloroRanchRarityMap = new Dictionary<int, FloroRanchRarityData>();

	// Token: 0x040063CB RID: 25547
	private readonly Dictionary<int, FloroRanchTerrainData> FloroRanchTerrainMap = new Dictionary<int, FloroRanchTerrainData>();

	// Token: 0x040063CC RID: 25548
	private readonly Dictionary<EFloroRanchCharacterType, Dictionary<EFloroRanchAudioType, List<FloroRanchAudioData>>> FloroRanchAudioMap = new Dictionary<EFloroRanchCharacterType, Dictionary<EFloroRanchAudioType, List<FloroRanchAudioData>>>();

	// Token: 0x040063CD RID: 25549
	private readonly Dictionary<int, FloroRanchCardGroupData> FloroRanchCardGroupMap = new Dictionary<int, FloroRanchCardGroupData>();

	// Token: 0x040063CE RID: 25550
	private readonly Dictionary<int, FloroRanchCurrencyConfigData> FloroRanchCurrencyMap = new Dictionary<int, FloroRanchCurrencyConfigData>();

	// Token: 0x040063CF RID: 25551
	private readonly Dictionary<int, FloroRanchCardData> FloroRanchCardDataMap = new Dictionary<int, FloroRanchCardData>();

	// Token: 0x040063D0 RID: 25552
	private readonly Dictionary<int, List<FloroRanchCardData>> FloroRanchRaceToCardDataMap = new Dictionary<int, List<FloroRanchCardData>>();

	// Token: 0x040063D1 RID: 25553
	private readonly Dictionary<int, FloroRanchToyData> FloroRanchToyDataMap = new Dictionary<int, FloroRanchToyData>();

	// Token: 0x040063D2 RID: 25554
	private readonly Dictionary<int, FloroRanchSkillData> FloroRanchSkillDataMap = new Dictionary<int, FloroRanchSkillData>();

	// Token: 0x040063D3 RID: 25555
	private readonly Dictionary<int, FloroRanchRaceData> FloroRanchRaceDataMap = new Dictionary<int, FloroRanchRaceData>();

	// Token: 0x040063D4 RID: 25556
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<FloroRanchRaceData> FloroRanchRaceDataList;

	// Token: 0x040063D5 RID: 25557
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<FloroRanchRaceData> FloroRanchRaceDataListIncludeCommon;

	// Token: 0x040063D6 RID: 25558
	private readonly int MaxCoinNum = 100000;
}
