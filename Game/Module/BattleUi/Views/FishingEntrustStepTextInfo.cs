using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200605D RID: 24669
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingEntrustStepTextInfo : MissionViewStepTextInfoBase
	{
		// Token: 0x0603E368 RID: 254824 RVA: 0x00FE2A24 File Offset: 0x00FE0C24
		public FishingEntrustStepTextInfo(string tidTitle, int progressTargetId) : base(tidTitle, null, null)
		{
		}

		// Token: 0x17009A8C RID: 39564
		// (get) Token: 0x0603E369 RID: 254825 RVA: 0x00FE2A36 File Offset: 0x00FE0C36
		public override EMissionItemViewDataSource ShowSource
		{
			get
			{
				return EMissionItemViewDataSource.FishingEntrust;
			}
		}

		// Token: 0x17009A8D RID: 39565
		// (get) Token: 0x0603E36A RID: 254826 RVA: 0x00FE2A39 File Offset: 0x00FE0C39
		public int ProgressTargetId { get; } = progressTargetId;

		// Token: 0x17009A8E RID: 39566
		// (get) Token: 0x0603E36B RID: 254827 RVA: 0x00FE2A41 File Offset: 0x00FE0C41
		public override string TidTitle
		{
			get
			{
				return this.InnerTidTitle;
			}
		}

		// Token: 0x17009A8F RID: 39567
		// (get) Token: 0x0603E36C RID: 254828 RVA: 0x00FE2A49 File Offset: 0x00FE0C49
		public string QuestScheduleType
		{
			get
			{
				return "FishingEntrust";
			}
		}
	}
}
