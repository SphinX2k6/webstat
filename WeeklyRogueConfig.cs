using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002D55 RID: 11605
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class WeeklyRogueConfig : ConfigBase<WeeklyRogueConfig>
{
	// Token: 0x060176B7 RID: 95927 RVA: 0x0067E958 File Offset: 0x0067CB58
	public RogueWeeklyParam? GetWeeklyRogueParam(int id)
	{
		return ConfigRogueWeeklyParamById.GetConfig(id, true);
	}

	// Token: 0x060176B8 RID: 95928 RVA: 0x0067E961 File Offset: 0x0067CB61
	public RogueWeeklyRoomType? GetRogueWeeklyRoomType(int id)
	{
		return ConfigRogueWeeklyRoomTypeById.GetConfig(id, true);
	}

	// Token: 0x060176B9 RID: 95929 RVA: 0x0067E96A File Offset: 0x0067CB6A
	public RogueWeeklyBuffPool? GetRogueWeeklyBuffPool(int id)
	{
		return ConfigRogueWeeklyBuffPoolById.GetConfig(id, true);
	}

	// Token: 0x060176BA RID: 95930 RVA: 0x0067E973 File Offset: 0x0067CB73
	[NullableContext(2)]
	public IReadOnlyList<RogueWeeklyBuffPool> GetRogueWeeklyBuffPoolByRelatedArtifactId(int artifactId)
	{
		return ConfigRogueWeeklyBuffPoolByRelatedArtifactId.GetConfigList(artifactId, true);
	}

	// Token: 0x060176BB RID: 95931 RVA: 0x0067E97C File Offset: 0x0067CB7C
	public RogueWeekQualityConfig? GetRogueWeeklyQualityConfig(int id)
	{
		return ConfigRogueWeekQualityConfigById.GetConfig(id, true);
	}

	// Token: 0x060176BC RID: 95932 RVA: 0x0067E985 File Offset: 0x0067CB85
	public RogueWeeklyReward? GetRogueWeeklyRewardConfig(int id)
	{
		return ConfigRogueWeeklyRewardById.GetConfig(id, true);
	}

	// Token: 0x060176BD RID: 95933 RVA: 0x0067E98E File Offset: 0x0067CB8E
	public RogueWeeklyCycle? GetRogueWeeklyCycleConfig(int id)
	{
		return ConfigRogueWeeklyCycleById.GetConfig(id, true);
	}

	// Token: 0x060176BE RID: 95934 RVA: 0x0067E997 File Offset: 0x0067CB97
	public RogueWeeklyRoomType? GetRoomTypeConfig(int id)
	{
		return ConfigRogueWeeklyRoomTypeById.GetConfig(id, true);
	}

	// Token: 0x060176BF RID: 95935 RVA: 0x0067E9A0 File Offset: 0x0067CBA0
	public RogueWeeklyRoomPool? GetRoomPoolConfig(int id)
	{
		return ConfigRogueWeeklyRoomPoolById.GetConfig(id, true);
	}

	// Token: 0x060176C0 RID: 95936 RVA: 0x0067E9A9 File Offset: 0x0067CBA9
	public RogueWeekTag? GetRogueWeekTagConfig(int id)
	{
		return ConfigRogueWeekTagById.GetConfig(id, true);
	}

	// Token: 0x060176C1 RID: 95937 RVA: 0x0067E9B2 File Offset: 0x0067CBB2
	public RogueWeeklyBF? GetBlackFlowerConfig(int id)
	{
		return ConfigRogueWeeklyBFById.GetConfig(id, true);
	}

	// Token: 0x060176C2 RID: 95938 RVA: 0x0067E9BC File Offset: 0x0067CBBC
	public IReadOnlyList<RogueWeeklyBF> GetBlackFlowerConfigAll()
	{
		IReadOnlyList<RogueWeeklyBF> configList = ConfigRogueWeeklyBFAll.GetConfigList(true);
		if (configList == null)
		{
			return new List<RogueWeeklyBF>();
		}
		return configList;
	}
}
