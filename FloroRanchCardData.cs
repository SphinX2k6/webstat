using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BBD RID: 7101
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchCardData : IFloroRanchCardOrToyData
{
	// Token: 0x0600CE97 RID: 52887 RVA: 0x00370BDB File Offset: 0x0036EDDB
	public FloroRanchCardData(FloroRanchCard config)
	{
		this.Config = config;
		this.TagData.SetTagId(this.Config.Tag);
	}

	// Token: 0x170010A0 RID: 4256
	// (get) Token: 0x0600CE98 RID: 52888 RVA: 0x00370C0C File Offset: 0x0036EE0C
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x0600CE99 RID: 52889 RVA: 0x00370C28 File Offset: 0x0036EE28
	public string GetName()
	{
		return this.Config.Name;
	}

	// Token: 0x170010A1 RID: 4257
	// (get) Token: 0x0600CE9A RID: 52890 RVA: 0x00370C44 File Offset: 0x0036EE44
	public string Name
	{
		get
		{
			return ConfigMultiTextLang.GetLocalTextNew(this.Config.Name, null);
		}
	}

	// Token: 0x170010A2 RID: 4258
	// (get) Token: 0x0600CE9B RID: 52891 RVA: 0x00370C65 File Offset: 0x0036EE65
	public string Desc
	{
		get
		{
			return this.TagData.Desc;
		}
	}

	// Token: 0x0600CE9C RID: 52892 RVA: 0x00370C74 File Offset: 0x0036EE74
	public FloroRanchRarityData GetCardQualityData()
	{
		int rarityId = this.Config.RarityId;
		return ModelBase<FloroRanchModel>.Instance.GetFloroRanchRarity(rarityId);
	}

	// Token: 0x0600CE9D RID: 52893 RVA: 0x00370C9C File Offset: 0x0036EE9C
	public int GetDeleteCost()
	{
		return this.Config.Cost;
	}

	// Token: 0x0600CE9E RID: 52894 RVA: 0x00370CB8 File Offset: 0x0036EEB8
	public string GetIcon()
	{
		return this.Config.Icon;
	}

	// Token: 0x0600CE9F RID: 52895 RVA: 0x00370CD4 File Offset: 0x0036EED4
	public string GetRaceName()
	{
		int race = this.Config.Race;
		return ModelBase<FloroRanchModel>.Instance.GetFloroRanchRaceData(race).GetRaceName();
	}

	// Token: 0x0600CEA0 RID: 52896 RVA: 0x00370D00 File Offset: 0x0036EF00
	public int GetBasicSalary()
	{
		return this.Config.Salary;
	}

	// Token: 0x0600CEA1 RID: 52897 RVA: 0x00370D1C File Offset: 0x0036EF1C
	public int GetRace()
	{
		return this.Config.Race;
	}

	// Token: 0x0600CEA2 RID: 52898 RVA: 0x00370D38 File Offset: 0x0036EF38
	public int GetRarity()
	{
		return this.Config.RarityId;
	}

	// Token: 0x0600CEA3 RID: 52899 RVA: 0x00370D54 File Offset: 0x0036EF54
	public int GetCardSalary()
	{
		return this.Config.Salary;
	}

	// Token: 0x0600CEA4 RID: 52900 RVA: 0x00370D70 File Offset: 0x0036EF70
	public string GetSpineAtlas()
	{
		return this.Config.Spine;
	}

	// Token: 0x0600CEA5 RID: 52901 RVA: 0x00370D8C File Offset: 0x0036EF8C
	public string GetSpineData()
	{
		return this.Config.SpineSkeletonData;
	}

	// Token: 0x0600CEA6 RID: 52902 RVA: 0x00370DA8 File Offset: 0x0036EFA8
	public int GetEvolveItemOffsetY()
	{
		return this.Config.EvolveItemOffsetY;
	}

	// Token: 0x0600CEA7 RID: 52903 RVA: 0x00370DC4 File Offset: 0x0036EFC4
	public EFloroRanchCardDirection GetCardDefaultDirection()
	{
		return (EFloroRanchCardDirection)this.Config.Towards;
	}

	// Token: 0x0600CEA8 RID: 52904 RVA: 0x00370DE0 File Offset: 0x0036EFE0
	public EFloroRanchSpecialEffectType GetCardSpecialEffect()
	{
		return (EFloroRanchSpecialEffectType)this.Config.SpeicalEffectshow;
	}

	// Token: 0x170010A3 RID: 4259
	// (get) Token: 0x0600CEA9 RID: 52905 RVA: 0x00370DFC File Offset: 0x0036EFFC
	public bool IsShowInHandBook
	{
		get
		{
			return this.Config.Illustration;
		}
	}

	// Token: 0x170010A4 RID: 4260
	// (get) Token: 0x0600CEAA RID: 52906 RVA: 0x00370E18 File Offset: 0x0036F018
	public bool IsSpecialPhantom
	{
		get
		{
			return this.Config.IsSpecial;
		}
	}

	// Token: 0x170010A5 RID: 4261
	// (get) Token: 0x0600CEAB RID: 52907 RVA: 0x00370E34 File Offset: 0x0036F034
	public string Video
	{
		get
		{
			return this.Config.Video;
		}
	}

	// Token: 0x04006284 RID: 25220
	private readonly FloroRanchCard Config;

	// Token: 0x04006285 RID: 25221
	public FloroRanchTagData TagData = new FloroRanchTagData();
}
