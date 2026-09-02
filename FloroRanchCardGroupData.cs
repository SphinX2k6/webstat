using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BBE RID: 7102
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchCardGroupData
{
	// Token: 0x0600CEAC RID: 52908 RVA: 0x00370E4F File Offset: 0x0036F04F
	public FloroRanchCardGroupData(FloroRanchCardGroup config)
	{
		this.Config = config;
	}

	// Token: 0x0600CEAD RID: 52909 RVA: 0x00370E60 File Offset: 0x0036F060
	public string GetName()
	{
		return this.Config.Name;
	}

	// Token: 0x170010A6 RID: 4262
	// (get) Token: 0x0600CEAE RID: 52910 RVA: 0x00370E7C File Offset: 0x0036F07C
	public string Desc
	{
		get
		{
			return ConfigMultiTextLang.GetLocalTextNew(this.Config.Desc, null);
		}
	}

	// Token: 0x0600CEAF RID: 52911 RVA: 0x00370EA0 File Offset: 0x0036F0A0
	public string GetIcon()
	{
		return this.Config.Icon;
	}

	// Token: 0x0600CEB0 RID: 52912 RVA: 0x00370EBC File Offset: 0x0036F0BC
	public FloroRanchRarityData GetQualityData()
	{
		int rarityId = this.Config.RarityId;
		return ModelBase<FloroRanchModel>.Instance.GetFloroRanchRarity(rarityId);
	}

	// Token: 0x0600CEB1 RID: 52913 RVA: 0x00370EE4 File Offset: 0x0036F0E4
	public int GetRaceId()
	{
		return this.Config.Race;
	}

	// Token: 0x04006286 RID: 25222
	private readonly FloroRanchCardGroup Config;
}
