using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200535C RID: 21340
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotFlow
	{
		// Token: 0x060366FC RID: 222972 RVA: 0x00DBBA08 File Offset: 0x00DB9C08
		public PlotFlow(string flowListName, int? flowId, int? stateId)
		{
			this.FlowListName = flowListName;
			this.FlowId = flowId;
			this.StateId = stateId;
		}

		// Token: 0x0401F4E8 RID: 128232
		public string FlowListName;

		// Token: 0x0401F4E9 RID: 128233
		public int? FlowId;

		// Token: 0x0401F4EA RID: 128234
		public int? StateId;
	}
}
