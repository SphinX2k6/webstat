using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020011A2 RID: 4514
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ArtemisActivityConfig : ConfigBase<ArtemisActivityConfig>
{
	// Token: 0x060076B8 RID: 30392 RVA: 0x001F1440 File Offset: 0x001EF640
	public Artemis? GetArtemisByActivityIdAndDay(int id, int day)
	{
		return ConfigArtemisByDay.GetConfig(id, day, true);
	}

	// Token: 0x060076B9 RID: 30393 RVA: 0x001F144A File Offset: 0x001EF64A
	public IReadOnlyList<Artemis> GetArtemisGroupByActivityId(int activityId)
	{
		return ConfigArtemisByActivityId.GetConfigList(activityId, true);
	}

	// Token: 0x060076BA RID: 30394 RVA: 0x001F1453 File Offset: 0x001EF653
	public ArtemisChat? GetArtemisChatConfigById(int id)
	{
		return ConfigArtemisChatById.GetConfig(id, true);
	}

	// Token: 0x060076BB RID: 30395 RVA: 0x001F145C File Offset: 0x001EF65C
	public ArtemisQte? GetArtemisQteConfigById(int id)
	{
		return ConfigArtemisQteById.GetConfig(id, true);
	}
}
