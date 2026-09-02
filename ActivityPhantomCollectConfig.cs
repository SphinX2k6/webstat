using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200148D RID: 5261
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityPhantomCollectConfig : ConfigBase<ActivityPhantomCollectConfig>
{
	// Token: 0x06009340 RID: 37696 RVA: 0x0026DC56 File Offset: 0x0026BE56
	public PhantomCollectActivity? GetPhantomCollectConfig(int activityId)
	{
		return ConfigPhantomCollectActivityById.GetConfig(activityId, true);
	}

	// Token: 0x06009341 RID: 37697 RVA: 0x0026DC5F File Offset: 0x0026BE5F
	public PhantomCollectTaskDesc? GetPhantomCollectTaskDesc(int taskType)
	{
		return ConfigPhantomCollectTaskDescById.GetConfig(taskType, true);
	}
}
