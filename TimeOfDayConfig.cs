using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02002BB3 RID: 11187
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class TimeOfDayConfig : ConfigBase<TimeOfDayConfig>
{
	// Token: 0x06016467 RID: 91239 RVA: 0x0062B7BD File Offset: 0x006299BD
	public TimeOfDay? GetConfig()
	{
		return ConfigTimeOfDayById.GetConfig(1, true);
	}

	// Token: 0x06016468 RID: 91240 RVA: 0x0062B7C8 File Offset: 0x006299C8
	public double GetInitTimeSecond()
	{
		TimeOfDay? timeOfDay;
		return (double)(((this.GetConfig() != null) ? timeOfDay.GetValueOrDefault().InitTime : 0) * 60);
	}

	// Token: 0x06016469 RID: 91241 RVA: 0x0062B7FC File Offset: 0x006299FC
	public double GetMaxV()
	{
		TimeOfDay? timeOfDay;
		return (double)(60 * ((this.GetConfig() != null) ? timeOfDay.GetValueOrDefault().V : 0));
	}

	// Token: 0x0601646A RID: 91242 RVA: 0x0062B830 File Offset: 0x00629A30
	public double GetA()
	{
		TimeOfDay? timeOfDay;
		return (double)(60 * ((this.GetConfig() != null) ? timeOfDay.GetValueOrDefault().A : 0));
	}

	// Token: 0x0601646B RID: 91243 RVA: 0x0062B864 File Offset: 0x00629A64
	public double GetRate()
	{
		if (this.GetConfig() == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.TimeOfDay, ELogAuthor.TL, "时间流速比未配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0.0;
		}
		return (double)this.GetConfig().Value.Rate;
	}

	// Token: 0x0601646C RID: 91244 RVA: 0x0062B8C0 File Offset: 0x00629AC0
	public bool InitDayStateTimeSpanList()
	{
		if (this.GetConfig() == null)
		{
			return false;
		}
		TimeOfDay? config = this.GetConfig();
		if (config == null || config.Value.StateSpanLength <= 0)
		{
			return false;
		}
		this.DayStateMinuteSpanList.Clear();
		int stateSpanLength = config.Value.StateSpanLength;
		for (int i = 0; i < stateSpanLength; i++)
		{
			DicIntInt? dicIntInt = config.Value.StateSpan(i);
			TTodTimeSpan item = new TTodTimeSpan(dicIntInt.Value.Key, dicIntInt.Value.Value);
			this.DayStateMinuteSpanList.Add(item);
		}
		this.DayStateMinuteSpanList.Sort((TTodTimeSpan a, TTodTimeSpan b) => (a.StartTime < b.StartTime) ? 1 : 0);
		return true;
	}

	// Token: 0x0601646D RID: 91245 RVA: 0x0062B9A0 File Offset: 0x00629BA0
	public ETodDayState GetDayStateByGameTimeMinute(double minute)
	{
		if (this.DayStateMinuteSpanList.Count == 0 && !this.InitDayStateTimeSpanList())
		{
			Singleton<Log>.Instance.Error(ELogModule.TimeOfDay, ELogAuthor.TL, "时间区间配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			return ETodDayState.One;
		}
		ETodDayState etodDayState = ETodDayState.One;
		foreach (TTodTimeSpan ttodTimeSpan in this.DayStateMinuteSpanList)
		{
			if (TodDayTime.CheckInMinuteSpan(minute, ttodTimeSpan))
			{
				etodDayState = (ETodDayState)this.DayStateMinuteSpanList.IndexOf(ttodTimeSpan);
				break;
			}
		}
		if (etodDayState >= ETodDayState.Count)
		{
			Singleton<Log>.Instance.Error(ELogModule.TimeOfDay, ELogAuthor.TL, "时间区间配置超出范围", default(ReadOnlySpan<ValueTuple<string, object>>));
			return ETodDayState.One;
		}
		return etodDayState;
	}

	// Token: 0x0601646E RID: 91246 RVA: 0x0062BA5C File Offset: 0x00629C5C
	public List<FGameplayTag> GetBanGameplayTags()
	{
		if (this.BanGameplayTagList.Count > 0)
		{
			return this.BanGameplayTagList;
		}
		TimeOfDay? config = this.GetConfig();
		if (config == null)
		{
			return this.BanGameplayTagList;
		}
		int banTagLength = config.Value.BanTagLength;
		for (int i = 0; i < banTagLength; i++)
		{
			FGameplayTag? gameplayTagByName = GameplayTagUtils.GetGameplayTagByName(config.Value.BanTag(i));
			if (gameplayTagByName != null)
			{
				this.BanGameplayTagList.Add(gameplayTagByName.Value);
			}
		}
		return this.BanGameplayTagList;
	}

	// Token: 0x0601646F RID: 91247 RVA: 0x0062BAE9 File Offset: 0x00629CE9
	[NullableContext(2)]
	public IReadOnlyList<DaySelectPreset> GetDayTimeChangePresets()
	{
		return ConfigDaySelectPresetAll.GetConfigList(true);
	}

	// Token: 0x06016470 RID: 91248 RVA: 0x0062BAF4 File Offset: 0x00629CF4
	public DaySelectPreset? GetDayTimeChangeConfig(int id)
	{
		DaySelectPreset? config = ConfigDaySelectPresetById.GetConfig(id, true);
		if (config != null)
		{
			return config;
		}
		return null;
	}

	// Token: 0x06016471 RID: 91249 RVA: 0x0062BB20 File Offset: 0x00629D20
	public string GetTimeChangeText(int id)
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.GetDayTimeChangeConfig(id).Value.Title, null) ?? "";
	}

	// Token: 0x0400AC61 RID: 44129
	private List<TTodTimeSpan> DayStateMinuteSpanList = new List<TTodTimeSpan>();

	// Token: 0x0400AC62 RID: 44130
	private readonly List<FGameplayTag> BanGameplayTagList = new List<FGameplayTag>();
}
