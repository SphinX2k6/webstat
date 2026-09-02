using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020023F4 RID: 9204
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class WeekCardConfig : ConfigBase<WeekCardConfig>
{
	// Token: 0x06011D07 RID: 72967 RVA: 0x004E6E84 File Offset: 0x004E5084
	public WeekCard? GetConfig(int key)
	{
		WeekCard? config = ConfigWeekCardById.GetConfig(key, true);
		if (config == null)
		{
			return null;
		}
		return new WeekCard?(config.Value);
	}

	// Token: 0x06011D08 RID: 72968 RVA: 0x004E6EB8 File Offset: 0x004E50B8
	public WeekCard? GetWeekConfigByPayGiftId(int giftId)
	{
		WeekCard? config = ConfigWeekCardByPayGiftId.GetConfig(giftId, true);
		if (config == null)
		{
			return null;
		}
		return new WeekCard?(config.Value);
	}

	// Token: 0x06011D09 RID: 72969 RVA: 0x004E6EEC File Offset: 0x004E50EC
	public WeekCardContent? GetContentConfig(int contentId)
	{
		WeekCardContent? config = ConfigWeekCardContentById.GetConfig(contentId, true);
		if (config == null)
		{
			return null;
		}
		return new WeekCardContent?(config.Value);
	}

	// Token: 0x06011D0A RID: 72970 RVA: 0x004E6F20 File Offset: 0x004E5120
	public List<WeekCard> GetConfigListByKind(EWeekCardKind kind)
	{
		EWeekCardShowType showType = (kind == EWeekCardKind.NewPlayer) ? EWeekCardShowType.NewPlayer : EWeekCardShowType.Recommend;
		IReadOnlyList<WeekCard> configList = ConfigWeekCardAll.GetConfigList(true);
		if (configList == null)
		{
			return new List<WeekCard>();
		}
		return (from config in configList
		where config.ShowType == (int)showType
		select config).ToList<WeekCard>();
	}
}
