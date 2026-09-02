using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020011DC RID: 4572
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class BabelTowerConfig : ConfigBase<BabelTowerConfig>
{
	// Token: 0x060078B7 RID: 30903 RVA: 0x001FA100 File Offset: 0x001F8300
	public BabelTowerLevel GetBabelTowerLevelConfig(int id)
	{
		return ConfigBabelTowerLevelById.GetConfig(id, true).Value;
	}

	// Token: 0x060078B8 RID: 30904 RVA: 0x001FA11C File Offset: 0x001F831C
	public BabelTowerTask GetBabelTowerNormalQuest(int id)
	{
		return ConfigBabelTowerTaskByTaskId.GetConfig(id, true).Value;
	}

	// Token: 0x060078B9 RID: 30905 RVA: 0x001FA138 File Offset: 0x001F8338
	public BabelTowerDailyTask GetBabelTowerDailyQuest(int id)
	{
		return ConfigBabelTowerDailyTaskByTaskId.GetConfig(id, true).Value;
	}

	// Token: 0x060078BA RID: 30906 RVA: 0x001FA154 File Offset: 0x001F8354
	public IReadOnlyList<BabelTowerDailyTask> GetBabelTowerAllDailyQuest()
	{
		return ConfigBabelTowerDailyTaskAll.GetConfigList(true);
	}

	// Token: 0x060078BB RID: 30907 RVA: 0x001FA15C File Offset: 0x001F835C
	public BabelTowerBuff GetBabelTowerBuff(int id)
	{
		return ConfigBabelTowerBuffById.GetConfig(id, true).Value;
	}

	// Token: 0x060078BC RID: 30908 RVA: 0x001FA178 File Offset: 0x001F8378
	public BabelTowerDeTerm GetBabelTowerDeTerm(int id)
	{
		return ConfigBabelTowerDeTermById.GetConfig(id, true).Value;
	}

	// Token: 0x060078BD RID: 30909 RVA: 0x001FA194 File Offset: 0x001F8394
	public IReadOnlyList<BabelTowerDeTerm> GetBabelTowerDeTermByGroupId(int id)
	{
		return ConfigBabelTowerDeTermByGroupId.GetConfigList(id, true);
	}

	// Token: 0x060078BE RID: 30910 RVA: 0x001FA1A0 File Offset: 0x001F83A0
	public BabelTowerDeTermMutex GetBabelTowerDeTermMutual(int id)
	{
		return ConfigBabelTowerDeTermMutexById.GetConfig(id, true).Value;
	}

	// Token: 0x060078BF RID: 30911 RVA: 0x001FA1BC File Offset: 0x001F83BC
	public IReadOnlyList<BabelTowerQuick> GetBabelTowerQuickByInstId(int instId)
	{
		return ConfigBabelTowerQuickByInstId.GetConfigList(instId, true);
	}

	// Token: 0x060078C0 RID: 30912 RVA: 0x001FA1C8 File Offset: 0x001F83C8
	public IReadOnlyList<BabelTowerLevel> GetAllBabelTowerDifficultLevel(int activityId)
	{
		return (from level in ConfigBabelTowerLevelAll.GetConfigList(true)
		where level.IsDifficult && level.ActivityId == activityId
		select level).ToList<BabelTowerLevel>();
	}
}
