using System;
using System.Runtime.CompilerServices;

// Token: 0x02001E5C RID: 7772
[NullableContext(1)]
[Nullable(0)]
public class HandBookQuestNode
{
	// Token: 0x0600E623 RID: 58915 RVA: 0x003E1EE7 File Offset: 0x003E00E7
	public HandBookQuestNode(string tidText = "", [Nullable(2)] string flowListName = null, int flowId = 0, int stateId = 0)
	{
		this.TidText = tidText;
		this.FlowListName = flowListName;
		this.FlowId = flowId;
		this.StateId = stateId;
	}

	// Token: 0x04006EE0 RID: 28384
	public string TidText;

	// Token: 0x04006EE1 RID: 28385
	[Nullable(2)]
	public string FlowListName;

	// Token: 0x04006EE2 RID: 28386
	public int FlowId;

	// Token: 0x04006EE3 RID: 28387
	public int StateId;
}
