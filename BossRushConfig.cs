using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001272 RID: 4722
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class BossRushConfig : ConfigBase<BossRushConfig>
{
	// Token: 0x06007E0F RID: 32271 RVA: 0x002148EF File Offset: 0x00212AEF
	public BossRushActivity? GetBossRushActivityConfigById(int id)
	{
		return ConfigBossRushActivityById.GetConfig(id, true);
	}

	// Token: 0x06007E10 RID: 32272 RVA: 0x002148F8 File Offset: 0x00212AF8
	public BossRushActivity? GetBossRushByActivityIdAndInstanceId(int id, int instanceId)
	{
		IReadOnlyList<BossRushActivity> configList = ConfigBossRushActivityByActivityIdAndInstanceId.GetConfigList(id, instanceId, true);
		if (configList == null || configList.Count == 0)
		{
			return null;
		}
		return new BossRushActivity?(configList[0]);
	}

	// Token: 0x06007E11 RID: 32273 RVA: 0x0021492F File Offset: 0x00212B2F
	public BossRushBuff? GetBossRushBuffConfigById(int id)
	{
		return ConfigBossRushBuffById.GetConfig(id, true);
	}

	// Token: 0x06007E12 RID: 32274 RVA: 0x00214938 File Offset: 0x00212B38
	public BossRushScore? GetBossRushScoreConfigById(int id)
	{
		return ConfigBossRushScoreById.GetConfig(id, true);
	}

	// Token: 0x06007E13 RID: 32275 RVA: 0x00214941 File Offset: 0x00212B41
	public int GetBossRushMarkTypeByActivityId(int id)
	{
		return 0;
	}

	// Token: 0x06007E14 RID: 32276 RVA: 0x00214944 File Offset: 0x00212B44
	public int GetBossRushMarkByActivityId(int id)
	{
		BossRushMapMark? config = ConfigBossRushMapMarkByActivityId.GetConfig(id, true);
		if (config == null)
		{
			return 0;
		}
		return config.Value.MarkId;
	}

	// Token: 0x06007E15 RID: 32277 RVA: 0x00214974 File Offset: 0x00212B74
	public BossRushTaskConfig GetBossRushTaskConfig(int id)
	{
		BossRushTaskConfig? config = ConfigBossRushTaskConfigByTaskId.GetConfig(id, true);
		if (config == null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 1);
			defaultInterpolatedStringHandler.AppendLiteral("BossRushTaskConfig not found for id: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(id);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		return config.Value;
	}

	// Token: 0x06007E16 RID: 32278 RVA: 0x002149C4 File Offset: 0x00212BC4
	public IReadOnlyList<BossRushTaskTab> GetBossRushTabListByActivityId(int id)
	{
		IReadOnlyList<BossRushTaskTab> configList = ConfigBossRushTaskTabAll.GetConfigList(true);
		IReadOnlyList<BossRushTaskConfig> configList2 = ConfigBossRushTaskConfigAll.GetConfigList(true);
		if (configList == null || configList2 == null)
		{
			return new List<BossRushTaskTab>();
		}
		List<BossRushTaskTab> list = new List<BossRushTaskTab>();
		foreach (BossRushTaskTab item in configList)
		{
			if (item.ActivityId == id)
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06007E17 RID: 32279 RVA: 0x00214A3C File Offset: 0x00212C3C
	public BossRushTaskTab? GetBossRushTabByTabId(int id)
	{
		return ConfigBossRushTaskTabByTabId.GetConfig(id, true);
	}

	// Token: 0x06007E18 RID: 32280 RVA: 0x00214A48 File Offset: 0x00212C48
	public BossRushBuffDesc? GetBossRushBuffDescByClassLevel(int buffId, int classLevel)
	{
		BossRushBuff? bossRushBuffConfigById = this.GetBossRushBuffConfigById(buffId);
		if (bossRushBuffConfigById == null)
		{
			return null;
		}
		int[] array = bossRushBuffConfigById.Value.PopDescIdList();
		if (array.Length > classLevel)
		{
			return ConfigBossRushBuffDescById.GetConfig(array[classLevel], true);
		}
		return null;
	}
}
