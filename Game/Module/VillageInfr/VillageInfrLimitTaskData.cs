using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C03 RID: 19459
	public class VillageInfrLimitTaskData
	{
		// Token: 0x06032C7F RID: 207999 RVA: 0x00CB8BD4 File Offset: 0x00CB6DD4
		public VillageInfrLimitTaskData(int configId)
		{
			this.ConfigId = configId;
		}

		// Token: 0x1700872C RID: 34604
		// (get) Token: 0x06032C80 RID: 208000 RVA: 0x00CB8BEC File Offset: 0x00CB6DEC
		private InfrV2Reward Config
		{
			get
			{
				return ConfigBase<VillageInfrConfig>.Instance.GetInfrActivityTaskConfig(this.ConfigId).Value;
			}
		}

		// Token: 0x1700872D RID: 34605
		// (get) Token: 0x06032C81 RID: 208001 RVA: 0x00CB8C14 File Offset: 0x00CB6E14
		public int TaskReward
		{
			get
			{
				return this.Config.DropId;
			}
		}

		// Token: 0x06032C82 RID: 208002 RVA: 0x00CB8C2F File Offset: 0x00CB6E2F
		[NullableContext(1)]
		public void UpdateData(ConditionTask data)
		{
			this.Current = data.Current;
			this.Target = data.Target;
			this.Status = data.Status;
		}

		// Token: 0x06032C83 RID: 208003 RVA: 0x00CB8C55 File Offset: 0x00CB6E55
		public bool CanReceive()
		{
			return this.Status == ConditionTaskState.ConditionTaskFinish;
		}

		// Token: 0x0401D8BB RID: 121019
		public int ConfigId;

		// Token: 0x0401D8BC RID: 121020
		public int Current;

		// Token: 0x0401D8BD RID: 121021
		public int Target = 1;

		// Token: 0x0401D8BE RID: 121022
		public int Index;

		// Token: 0x0401D8BF RID: 121023
		public ConditionTaskState Status;
	}
}
