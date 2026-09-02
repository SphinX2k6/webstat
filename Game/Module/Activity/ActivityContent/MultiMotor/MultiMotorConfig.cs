using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006653 RID: 26195
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class MultiMotorConfig : ConfigBase<MultiMotorConfig>
	{
		// Token: 0x06041693 RID: 267923 RVA: 0x010C88D2 File Offset: 0x010C6AD2
		public IReadOnlyList<OnlineMotorLevel> GetAllMotorMultiParkourLevel()
		{
			return ConfigOnlineMotorLevelAll.GetConfigList(true);
		}

		// Token: 0x06041694 RID: 267924 RVA: 0x010C88DA File Offset: 0x010C6ADA
		public OnlineMotorLevel? GetMotorMultiParkourLevelById(int levelId)
		{
			return ConfigOnlineMotorLevelById.GetConfig(levelId, true);
		}

		// Token: 0x06041695 RID: 267925 RVA: 0x010C88E3 File Offset: 0x010C6AE3
		public OnlineMotorLevel? GetMotorMultiParkourLevelByInstId(int instId)
		{
			return ConfigOnlineMotorLevelByInstId.GetConfig(instId, true);
		}

		// Token: 0x06041696 RID: 267926 RVA: 0x010C88EC File Offset: 0x010C6AEC
		public OnlineMotorLevelTask? GetMotorLevelTaskByTaskId(int taskId)
		{
			return ConfigOnlineMotorLevelTaskById.GetConfig(taskId, true);
		}

		// Token: 0x06041697 RID: 267927 RVA: 0x010C88F5 File Offset: 0x010C6AF5
		public OnlineMotorGlobalTask? GetMotorGlobalTaskByTaskId(int taskId)
		{
			return ConfigOnlineMotorGlobalTaskById.GetConfig(taskId, true);
		}

		// Token: 0x06041698 RID: 267928 RVA: 0x010C88FE File Offset: 0x010C6AFE
		public OnlineMotorBroadcast? GetMotorBroadcastById(int id)
		{
			return ConfigOnlineMotorBroadcastById.GetConfig(id, true);
		}

		// Token: 0x06041699 RID: 267929 RVA: 0x010C8907 File Offset: 0x010C6B07
		public IReadOnlyList<OnlineMotorBroadcast> GetMotorBroadcastByGroup(int group)
		{
			return ConfigOnlineMotorBroadcastByBroadcastGroup.GetConfigList(group, true);
		}

		// Token: 0x0604169A RID: 267930 RVA: 0x010C8910 File Offset: 0x010C6B10
		public MotorOnlineBuff? GetMotorBuffById(int id)
		{
			return ConfigMotorOnlineBuffById.GetConfig(id, true);
		}

		// Token: 0x0604169B RID: 267931 RVA: 0x010C8919 File Offset: 0x010C6B19
		public MotorOnlineRoleSkin? GetMotorOnlineRoleSkinBySkinId(int skinId)
		{
			return ConfigMotorOnlineRoleSkinByRoleSkinId.GetConfig(skinId, true);
		}

		// Token: 0x0604169C RID: 267932 RVA: 0x010C8924 File Offset: 0x010C6B24
		public int GetHostExitProtectTime()
		{
			return ConfigCommonParamById.GetIntConfig("MultiMotorHostExitProtectTime").GetValueOrDefault(300);
		}

		// Token: 0x04024932 RID: 149810
		private const int DefaultExitHandleTime = 300;
	}
}
