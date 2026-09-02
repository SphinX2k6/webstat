using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher
{
	// Token: 0x0200448B RID: 17547
	[NullableContext(1)]
	[Nullable(0)]
	public class MobileResCleanUpStateLog : HotPatchLogData
	{
		// Token: 0x0602E4F1 RID: 189681 RVA: 0x00ADE2D8 File Offset: 0x00ADC4D8
		public MobileResCleanUpStateLog(int cleanUpSpace, string uniqueId, string traceId, List<MobileResCleanUpStateLogContentData> content, int type, [Nullable(2)] string playerId = null) : base("1713", uniqueId, playerId)
		{
			this.i_required_space = cleanUpSpace;
			this.s_trace_id = traceId;
			this.o_content = content;
			this.i_type = type;
		}

		// Token: 0x0401A49B RID: 107675
		public int i_required_space;

		// Token: 0x0401A49C RID: 107676
		public List<MobileResCleanUpStateLogContentData> o_content = new List<MobileResCleanUpStateLogContentData>();

		// Token: 0x0401A49D RID: 107677
		public int i_type;

		// Token: 0x0401A49E RID: 107678
		public string s_trace_id = "";
	}
}
