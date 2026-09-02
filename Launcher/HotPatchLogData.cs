using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher
{
	// Token: 0x02004485 RID: 17541
	[NullableContext(1)]
	[Nullable(0)]
	public class HotPatchLogData
	{
		// Token: 0x0602E4EA RID: 189674 RVA: 0x00ADE15C File Offset: 0x00ADC35C
		[NullableContext(2)]
		public HotPatchLogData([Nullable(1)] string eventId, string uniqueId = null, string playerId = null)
		{
			this.event_id = eventId;
			this.unique_id = (uniqueId ?? "");
			this.player_id = (playerId ?? "");
		}

		// Token: 0x0602E4EB RID: 189675 RVA: 0x00ADE1B7 File Offset: 0x00ADC3B7
		public void Report()
		{
			Singleton<HotPatchLogReport>.Instance.ReportHotPatchLog(this);
		}

		// Token: 0x0401A485 RID: 107653
		public string event_id = "";

		// Token: 0x0401A486 RID: 107654
		public string unique_id = "";

		// Token: 0x0401A487 RID: 107655
		public string player_id = "";
	}
}
