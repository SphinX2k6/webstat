using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006068 RID: 24680
	public class MissionItemViewEndTrackProcess : TPendingProcess
	{
		// Token: 0x0603E3ED RID: 254957 RVA: 0x00FE4006 File Offset: 0x00FE2206
		public MissionItemViewEndTrackProcess(long id, int reason, bool isSkipAnim)
		{
		}

		// Token: 0x17009AC2 RID: 39618
		// (get) Token: 0x0603E3EE RID: 254958 RVA: 0x00FE4023 File Offset: 0x00FE2223
		public override EMissionProcessType ProcessType
		{
			get
			{
				return EMissionProcessType.MissionItemViewEndTrack;
			}
		}

		// Token: 0x17009AC3 RID: 39619
		// (get) Token: 0x0603E3EF RID: 254959 RVA: 0x00FE4026 File Offset: 0x00FE2226
		public override bool IsSkipAnim { get; } = isSkipAnim;

		// Token: 0x04022E42 RID: 142914
		public readonly long Id = id;

		// Token: 0x04022E43 RID: 142915
		public readonly int Reason = reason;
	}
}
