using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066C9 RID: 26313
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightTaskData
	{
		// Token: 0x06041B77 RID: 269175 RVA: 0x010DA4BD File Offset: 0x010D86BD
		public MotorFightTaskData(MotorFightTask config)
		{
			this.Config = config;
			this.RewardList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(config.DropId);
		}

		// Token: 0x1700A08A RID: 41098
		// (get) Token: 0x06041B78 RID: 269176 RVA: 0x010DA4F5 File Offset: 0x010D86F5
		public bool IsFinished
		{
			get
			{
				return this.Status == EActivityTaskState.FinishedAndClaimed;
			}
		}

		// Token: 0x1700A08B RID: 41099
		// (get) Token: 0x06041B79 RID: 269177 RVA: 0x010DA500 File Offset: 0x010D8700
		public bool IsUnclaimed
		{
			get
			{
				return this.Status == EActivityTaskState.FinishedAndUnclaimed;
			}
		}

		// Token: 0x1700A08C RID: 41100
		// (get) Token: 0x06041B7A RID: 269178 RVA: 0x010DA50B File Offset: 0x010D870B
		public bool IsDoing
		{
			get
			{
				return this.Status == EActivityTaskState.Active;
			}
		}

		// Token: 0x1700A08D RID: 41101
		// (get) Token: 0x06041B7B RID: 269179 RVA: 0x010DA518 File Offset: 0x010D8718
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x1700A08E RID: 41102
		// (get) Token: 0x06041B7C RID: 269180 RVA: 0x010DA534 File Offset: 0x010D8734
		public string TaskName
		{
			get
			{
				return this.Config.TaskName;
			}
		}

		// Token: 0x04024ABD RID: 150205
		private readonly MotorFightTask Config;

		// Token: 0x04024ABE RID: 150206
		public int Current;

		// Token: 0x04024ABF RID: 150207
		public int Target;

		// Token: 0x04024AC0 RID: 150208
		public EActivityTaskState Status = EActivityTaskState.Active;

		// Token: 0x04024AC1 RID: 150209
		public List<TItem> RewardList = new List<TItem>();
	}
}
