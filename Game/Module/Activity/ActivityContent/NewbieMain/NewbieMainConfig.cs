using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain
{
	// Token: 0x02006640 RID: 26176
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class NewbieMainConfig : ConfigBase<NewbieMainConfig>
	{
		// Token: 0x0604160B RID: 267787 RVA: 0x010C575A File Offset: 0x010C395A
		public IReadOnlyList<NewbieMainActTab> GetTabListByActivityId(int activityId)
		{
			return ConfigNewbieMainActTabByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x0604160C RID: 267788 RVA: 0x010C5763 File Offset: 0x010C3963
		public NewbieMainActTab? GetTabById(int tabId)
		{
			return ConfigNewbieMainActTabById.GetConfig(tabId, true);
		}

		// Token: 0x0604160D RID: 267789 RVA: 0x010C576C File Offset: 0x010C396C
		public NewbieMainActTask? GetTabTaskById(int taskId)
		{
			return ConfigNewbieMainActTaskById.GetConfig(taskId, true);
		}

		// Token: 0x0604160E RID: 267790 RVA: 0x010C5775 File Offset: 0x010C3975
		public IReadOnlyList<NewbieMainActTask> GetTabTaskListByTabId(int tabId)
		{
			return ConfigNewbieMainActTaskByTabId.GetConfigList(tabId, true);
		}

		// Token: 0x0604160F RID: 267791 RVA: 0x010C577E File Offset: 0x010C397E
		public IReadOnlyList<NewbieMainActReward> GetRewardListByActivityId(int activityId)
		{
			return ConfigNewbieMainActRewardByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x06041610 RID: 267792 RVA: 0x010C5787 File Offset: 0x010C3987
		public NewbieMainActReward? GetRewardById(int rewardId)
		{
			return ConfigNewbieMainActRewardById.GetConfig(rewardId, true);
		}
	}
}
