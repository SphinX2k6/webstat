using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200605E RID: 24670
	[NullableContext(1)]
	[Nullable(0)]
	public class LackResourceQuestTextInfo : MissionViewStepTextInfoBase
	{
		// Token: 0x0603E36D RID: 254829 RVA: 0x00FE2A50 File Offset: 0x00FE0C50
		public LackResourceQuestTextInfo(string tidTitle) : base(tidTitle, null, null)
		{
		}

		// Token: 0x17009A90 RID: 39568
		// (get) Token: 0x0603E36E RID: 254830 RVA: 0x00FE2A5B File Offset: 0x00FE0C5B
		public override EMissionItemViewDataSource ShowSource
		{
			get
			{
				return EMissionItemViewDataSource.LackResourceQuest;
			}
		}

		// Token: 0x17009A91 RID: 39569
		// (get) Token: 0x0603E36F RID: 254831 RVA: 0x00FE2A5E File Offset: 0x00FE0C5E
		public override string TidTitle
		{
			get
			{
				return this.InnerTidTitle;
			}
		}

		// Token: 0x17009A92 RID: 39570
		// (get) Token: 0x0603E370 RID: 254832 RVA: 0x00FE2A66 File Offset: 0x00FE0C66
		public string QuestScheduleType
		{
			get
			{
				return "FishingEntrust";
			}
		}
	}
}
