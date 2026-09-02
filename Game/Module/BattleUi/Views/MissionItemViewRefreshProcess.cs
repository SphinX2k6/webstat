using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006069 RID: 24681
	[NullableContext(1)]
	[Nullable(0)]
	public class MissionItemViewRefreshProcess : TPendingProcess
	{
		// Token: 0x0603E3F0 RID: 254960 RVA: 0x00FE402E File Offset: 0x00FE222E
		public MissionItemViewRefreshProcess(IMissionItemViewShowData showData, bool isSkipAnim)
		{
		}

		// Token: 0x17009AC4 RID: 39620
		// (get) Token: 0x0603E3F1 RID: 254961 RVA: 0x00FE4044 File Offset: 0x00FE2244
		public override EMissionProcessType ProcessType
		{
			get
			{
				return EMissionProcessType.MissionItemViewRefresh;
			}
		}

		// Token: 0x17009AC5 RID: 39621
		// (get) Token: 0x0603E3F2 RID: 254962 RVA: 0x00FE4047 File Offset: 0x00FE2247
		public override bool IsSkipAnim { get; } = isSkipAnim;

		// Token: 0x04022E45 RID: 142917
		public readonly IMissionItemViewShowData ShowData = showData;
	}
}
