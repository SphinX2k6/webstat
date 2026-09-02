using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink
{
	// Token: 0x020066F6 RID: 26358
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class MotorDecalLinkConfig : ConfigBase<MotorDecalLinkConfig>
	{
		// Token: 0x06041CAF RID: 269487 RVA: 0x010E0FC6 File Offset: 0x010DF1C6
		public IReadOnlyList<MotorDecalIp> GetIpConfigListByActivityId(int activityId)
		{
			return ConfigMotorDecalIpByActivityId.GetConfigList(activityId, true) ?? new List<MotorDecalIp>();
		}

		// Token: 0x06041CB0 RID: 269488 RVA: 0x010E0FD8 File Offset: 0x010DF1D8
		public IReadOnlyList<MotorDecalQuest> GetTaskConfigListByIpId(int ipId)
		{
			return ConfigMotorDecalQuestByIp.GetConfigList(ipId, true) ?? new List<MotorDecalQuest>();
		}

		// Token: 0x06041CB1 RID: 269489 RVA: 0x010E0FEA File Offset: 0x010DF1EA
		public MotorDecalQuest? GetTaskConfig(int taskId)
		{
			return ConfigMotorDecalQuestByTaskId.GetConfig(taskId, true);
		}

		// Token: 0x06041CB2 RID: 269490 RVA: 0x010E0FF3 File Offset: 0x010DF1F3
		public MotorDecalPreview? GetStickerPreviewConfig(int stickerId)
		{
			return ConfigMotorDecalPreviewByStickerId.GetConfig(stickerId, true);
		}
	}
}
