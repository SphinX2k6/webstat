using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001466 RID: 5222
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityNewPlayerSupportConfig : ConfigBase<ActivityNewPlayerSupportConfig>
{
	// Token: 0x060091EC RID: 37356 RVA: 0x00268074 File Offset: 0x00266274
	public NewPlayerSupportTask GetTaskConfig(int id)
	{
		return ConfigNewPlayerSupportTaskById.GetConfig(id, true).Value;
	}

	// Token: 0x060091ED RID: 37357 RVA: 0x00268090 File Offset: 0x00266290
	[NullableContext(2)]
	public IReadOnlyList<NewPlayerSupportTask> GetAllTaskConfigs()
	{
		return ConfigNewPlayerSupportTaskAll.GetConfigList(true);
	}

	// Token: 0x060091EE RID: 37358 RVA: 0x00268098 File Offset: 0x00266298
	public Dictionary<int, string> GetTrialRoleUnlockDesc()
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		foreach (NewPlayerSupportTask newPlayerSupportTask in (this.GetAllTaskConfigs() ?? Array.Empty<NewPlayerSupportTask>()))
		{
			ConditionGroup? conditionGroup;
			string value = ((ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(newPlayerSupportTask.ConditionGroup) != null) ? conditionGroup.GetValueOrDefault().HintText : null) ?? "";
			dictionary[newPlayerSupportTask.TrialRoleGroupId] = value;
		}
		return dictionary;
	}

	// Token: 0x060091EF RID: 37359 RVA: 0x00268138 File Offset: 0x00266338
	public ConditionGroup? GetConditionGroup(int conditionId)
	{
		return ConfigConditionGroupById.GetConfig(conditionId, true);
	}
}
