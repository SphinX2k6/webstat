using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BD7 RID: 7127
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchToyData : IFloroRanchCardOrToyData
{
	// Token: 0x0600CF61 RID: 53089 RVA: 0x00371DB3 File Offset: 0x0036FFB3
	public FloroRanchToyData(FloroRanchToy config)
	{
		this.Config = config;
		this.TagData.SetTagId(this.Config.Tag);
	}

	// Token: 0x170010F0 RID: 4336
	// (get) Token: 0x0600CF62 RID: 53090 RVA: 0x00371DE3 File Offset: 0x0036FFE3
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x0600CF63 RID: 53091 RVA: 0x00371DF0 File Offset: 0x0036FFF0
	public int GetToyType()
	{
		return this.Config.Type;
	}

	// Token: 0x0600CF64 RID: 53092 RVA: 0x00371DFD File Offset: 0x0036FFFD
	public string GetName()
	{
		return this.Config.Name;
	}

	// Token: 0x170010F1 RID: 4337
	// (get) Token: 0x0600CF65 RID: 53093 RVA: 0x00371E0A File Offset: 0x0037000A
	public string Name
	{
		get
		{
			return ConfigMultiTextLang.GetLocalTextNew(this.Config.Name, null);
		}
	}

	// Token: 0x0600CF66 RID: 53094 RVA: 0x00371E20 File Offset: 0x00370020
	public FloroRanchRarityData GetToyQualityData()
	{
		int rarityId = this.Config.RarityId;
		return ModelBase<FloroRanchModel>.Instance.GetFloroRanchRarity(rarityId);
	}

	// Token: 0x0600CF67 RID: 53095 RVA: 0x00371E44 File Offset: 0x00370044
	public int GetDeleteEarn()
	{
		return this.Config.Remove;
	}

	// Token: 0x0600CF68 RID: 53096 RVA: 0x00371E51 File Offset: 0x00370051
	public string GetIcon()
	{
		return this.Config.Icon;
	}

	// Token: 0x0600CF69 RID: 53097 RVA: 0x00371E5E File Offset: 0x0037005E
	public bool GetIsUnique()
	{
		return this.Config.Unique;
	}

	// Token: 0x170010F2 RID: 4338
	// (get) Token: 0x0600CF6A RID: 53098 RVA: 0x00371E6B File Offset: 0x0037006B
	public string Desc
	{
		get
		{
			return this.TagData.Desc;
		}
	}

	// Token: 0x0600CF6B RID: 53099 RVA: 0x00371E78 File Offset: 0x00370078
	public int GetRarity()
	{
		return this.Config.RarityId;
	}

	// Token: 0x170010F3 RID: 4339
	// (get) Token: 0x0600CF6C RID: 53100 RVA: 0x00371E85 File Offset: 0x00370085
	public bool IsAdaptAllRace
	{
		get
		{
			return this.Config.RaceLength == 0;
		}
	}

	// Token: 0x0600CF6D RID: 53101 RVA: 0x00371E98 File Offset: 0x00370098
	public unsafe int GetRace()
	{
		if (this.Config.RaceLength == 0)
		{
			return -1;
		}
		return *this.Config.GetRaceBytes()[0];
	}

	// Token: 0x0600CF6E RID: 53102 RVA: 0x00371ECC File Offset: 0x003700CC
	[NullableContext(2)]
	public FloroRanchRaceData GetToyRaceData()
	{
		int race = this.GetRace();
		if (race == -1)
		{
			return null;
		}
		return ModelBase<FloroRanchModel>.Instance.GetFloroRanchRaceData(race);
	}

	// Token: 0x170010F4 RID: 4340
	// (get) Token: 0x0600CF6F RID: 53103 RVA: 0x00371EF1 File Offset: 0x003700F1
	public int InitLevel
	{
		get
		{
			return this.Config.Level;
		}
	}

	// Token: 0x0600CF70 RID: 53104 RVA: 0x00371EFE File Offset: 0x003700FE
	public bool CheckCanSell()
	{
		return this.GetDeleteEarn() != -1;
	}

	// Token: 0x040062CB RID: 25291
	private FloroRanchToy Config;

	// Token: 0x040062CC RID: 25292
	public FloroRanchTagData TagData = new FloroRanchTagData();
}
