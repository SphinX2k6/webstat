using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Npc.Controller
{
	// Token: 0x020048D6 RID: 18646
	[NullableContext(1)]
	[Nullable(0)]
	public class TimetableConfigData
	{
		// Token: 0x06030A6A RID: 199274 RVA: 0x00BFCFA8 File Offset: 0x00BFB1A8
		public bool IsMatchTime(TodDayTime time)
		{
			TTodTimeSpan minuteSpan = new TTodTimeSpan(this.StartTime * 60, this.EndTime * 60);
			return TodDayTime.CheckInMinuteSpan(time.Minute, minuteSpan);
		}

		// Token: 0x0401BF73 RID: 114547
		public string BehaviorTreePath = "";

		// Token: 0x0401BF74 RID: 114548
		public int StartTime;

		// Token: 0x0401BF75 RID: 114549
		public int EndTime;

		// Token: 0x0401BF76 RID: 114550
		public int SplineId;
	}
}
