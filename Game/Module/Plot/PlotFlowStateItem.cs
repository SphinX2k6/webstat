using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200535A RID: 21338
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotFlowStateItem
	{
		// Token: 0x060366F9 RID: 222969 RVA: 0x00DBB94C File Offset: 0x00DB9B4C
		public PlotFlowStateItem(int pbDataId, string flowListName, int flowId, int stateId)
		{
			this.PbDataId = pbDataId;
			this.FlowListName = flowListName;
			this.FlowId = flowId;
			this.StateId = stateId;
		}

		// Token: 0x0401F4DC RID: 128220
		public int PbDataId;

		// Token: 0x0401F4DD RID: 128221
		public string FlowListName;

		// Token: 0x0401F4DE RID: 128222
		public int FlowId;

		// Token: 0x0401F4DF RID: 128223
		public int StateId;
	}
}
