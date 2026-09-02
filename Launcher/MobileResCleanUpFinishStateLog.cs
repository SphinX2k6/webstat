using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher
{
	// Token: 0x0200448C RID: 17548
	[NullableContext(1)]
	[Nullable(0)]
	public class MobileResCleanUpFinishStateLog : HotPatchLogData
	{
		// Token: 0x0602E4F2 RID: 189682 RVA: 0x00ADE327 File Offset: 0x00ADC527
		public MobileResCleanUpFinishStateLog(string uniqueId, string traceId, [Nullable(2)] string playerId = null) : base("1714", uniqueId, playerId)
		{
			this.s_trace_id = traceId;
		}

		// Token: 0x0401A49F RID: 107679
		public string s_trace_id = "";
	}
}
