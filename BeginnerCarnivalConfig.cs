using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001252 RID: 4690
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class BeginnerCarnivalConfig : ConfigBase<BeginnerCarnivalConfig>
{
	// Token: 0x06007CFD RID: 31997 RVA: 0x0020EDB1 File Offset: 0x0020CFB1
	public NewbieCarnivalTask? GetNewbieCarnivalTask(int taskId)
	{
		return ConfigNewbieCarnivalTaskByTaskId.GetConfig(taskId, true);
	}

	// Token: 0x06007CFE RID: 31998 RVA: 0x0020EDBA File Offset: 0x0020CFBA
	public NewbieCarnivalTaskType? GetNewbieCarnivalTaskType(int typeId)
	{
		return ConfigNewbieCarnivalTaskTypeById.GetConfig(typeId, true);
	}

	// Token: 0x06007CFF RID: 31999 RVA: 0x0020EDC3 File Offset: 0x0020CFC3
	public NewbieCarnivalParam? GetNewbieCarnivalParam(int activityId)
	{
		return ConfigNewbieCarnivalParamByActivityId.GetConfig(activityId, true);
	}

	// Token: 0x06007D00 RID: 32000 RVA: 0x0020EDCC File Offset: 0x0020CFCC
	public NewbieCarnivalRole? GetNewbieCarnivalRole(int roleId)
	{
		return ConfigNewbieCarnivalRoleByRoleId.GetConfig(roleId, true);
	}

	// Token: 0x06007D01 RID: 32001 RVA: 0x0020EDD8 File Offset: 0x0020CFD8
	public NewbieCarnivalTask? GetNewbieCarnivalTaskByTaskType(int taskType)
	{
		IReadOnlyList<NewbieCarnivalTask> configList = ConfigNewbieCarnivalTaskByTaskType.GetConfigList(taskType, true);
		if (configList == null || configList.Count == 0)
		{
			return null;
		}
		return new NewbieCarnivalTask?(configList[0]);
	}
}
