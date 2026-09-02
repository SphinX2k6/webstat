using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher
{
	// Token: 0x02004489 RID: 17545
	[NullableContext(1)]
	[Nullable(0)]
	public class InitialMobileResCleanUpViewStateLog : HotPatchLogData
	{
		// Token: 0x0602E4EF RID: 189679 RVA: 0x00ADE29F File Offset: 0x00ADC49F
		public InitialMobileResCleanUpViewStateLog(int canCleanUpSpace, string uniqueId, string traceId, int chooseByUser, [Nullable(2)] string playerId = null) : base("1712", uniqueId, playerId)
		{
			this.i_remaining_space = canCleanUpSpace;
			this.s_trace_id = traceId;
			this.i_type = chooseByUser;
		}

		// Token: 0x0401A496 RID: 107670
		public int i_remaining_space;

		// Token: 0x0401A497 RID: 107671
		public int i_type;

		// Token: 0x0401A498 RID: 107672
		public string s_trace_id = "";
	}
}
