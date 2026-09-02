using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage
{
	// Token: 0x02006709 RID: 26377
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ActivityMotorLinkageConfig : ConfigBase<ActivityMotorLinkageConfig>
	{
		// Token: 0x06041D13 RID: 269587 RVA: 0x010E3384 File Offset: 0x010E1584
		public MotorLinkageIp GetIpConfig(int id)
		{
			return ConfigMotorLinkageIpById.GetConfig(id, true).Value;
		}

		// Token: 0x06041D14 RID: 269588 RVA: 0x010E33A0 File Offset: 0x010E15A0
		public IReadOnlyList<MotorLinkageIp> GetIpConfigAll()
		{
			return ConfigMotorLinkageIpAll.GetConfigList(true);
		}

		// Token: 0x06041D15 RID: 269589 RVA: 0x010E33A8 File Offset: 0x010E15A8
		public MotorLinkageQuest GetQuestConfig(int id)
		{
			return ConfigMotorLinkageQuestByQuestId.GetConfig(id, true).Value;
		}

		// Token: 0x06041D16 RID: 269590 RVA: 0x010E33C4 File Offset: 0x010E15C4
		public IReadOnlyList<MotorLinkageQuest> GetQuestConfigListByIpId(int ipId)
		{
			return ConfigMotorLinkageQuestByIp.GetConfigList(ipId, true);
		}

		// Token: 0x06041D17 RID: 269591 RVA: 0x010E33CD File Offset: 0x010E15CD
		public IReadOnlyList<MotorLinkageQuest> GetQuestConfigAll()
		{
			return ConfigMotorLinkageQuestAll.GetConfigList(true);
		}
	}
}
