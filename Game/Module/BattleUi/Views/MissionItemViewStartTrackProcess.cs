using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006067 RID: 24679
	[NullableContext(1)]
	[Nullable(0)]
	public class MissionItemViewStartTrackProcess : TPendingProcess
	{
		// Token: 0x0603E3EA RID: 254954 RVA: 0x00FE3FDE File Offset: 0x00FE21DE
		public MissionItemViewStartTrackProcess(IMissionItemViewShowData showData, ETreeTextExpressReason reason, bool isSkipAnim)
		{
		}

		// Token: 0x17009AC0 RID: 39616
		// (get) Token: 0x0603E3EB RID: 254955 RVA: 0x00FE3FFB File Offset: 0x00FE21FB
		public override EMissionProcessType ProcessType
		{
			get
			{
				return EMissionProcessType.MissionItemViewStartTrack;
			}
		}

		// Token: 0x17009AC1 RID: 39617
		// (get) Token: 0x0603E3EC RID: 254956 RVA: 0x00FE3FFE File Offset: 0x00FE21FE
		public override bool IsSkipAnim { get; } = isSkipAnim;

		// Token: 0x04022E3F RID: 142911
		public readonly IMissionItemViewShowData ShowData = showData;

		// Token: 0x04022E40 RID: 142912
		public readonly ETreeTextExpressReason Reason = reason;
	}
}
