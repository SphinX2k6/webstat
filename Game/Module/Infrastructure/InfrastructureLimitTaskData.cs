using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C49 RID: 23625
	public class InfrastructureLimitTaskData
	{
		// Token: 0x0603BABA RID: 244410 RVA: 0x00F1DDAA File Offset: 0x00F1BFAA
		public InfrastructureLimitTaskData(int configId)
		{
			this.ConfigId = configId;
		}

		// Token: 0x170097D5 RID: 38869
		// (get) Token: 0x0603BABB RID: 244411 RVA: 0x00F1DDC0 File Offset: 0x00F1BFC0
		private InfrActivityTask Config
		{
			get
			{
				return ConfigBase<InfrastructureConfig>.Instance.GetInfrActivityTaskConfig(this.ConfigId).Value;
			}
		}

		// Token: 0x170097D6 RID: 38870
		// (get) Token: 0x0603BABC RID: 244412 RVA: 0x00F1DDE8 File Offset: 0x00F1BFE8
		public int TaskReward
		{
			get
			{
				return this.Config.TaskReward;
			}
		}

		// Token: 0x170097D7 RID: 38871
		// (get) Token: 0x0603BABD RID: 244413 RVA: 0x00F1DE04 File Offset: 0x00F1C004
		public int JumpId
		{
			get
			{
				return this.Config.JumpId;
			}
		}

		// Token: 0x0603BABE RID: 244414 RVA: 0x00F1DE1F File Offset: 0x00F1C01F
		[NullableContext(1)]
		public void UpdateData(ActivityTask data)
		{
			this.Current = data.Current;
			this.Target = data.Target;
			this.Status = data.Status;
		}

		// Token: 0x040218F7 RID: 137463
		public int ConfigId;

		// Token: 0x040218F8 RID: 137464
		public int Current;

		// Token: 0x040218F9 RID: 137465
		public int Target = 1;

		// Token: 0x040218FA RID: 137466
		public int Index;

		// Token: 0x040218FB RID: 137467
		public ActivityTaskState Status;
	}
}
