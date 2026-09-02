using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001DD9 RID: 7641
[RequiredMember]
public class BtPendingUpdateNodeStatus : BehaviorTreePendingProcess
{
	// Token: 0x0600E219 RID: 57881 RVA: 0x003CE53D File Offset: 0x003CC73D
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public BtPendingUpdateNodeStatus()
	{
	}

	// Token: 0x04006C62 RID: 27746
	[RequiredMember]
	public ENodeStatusUpdateReason Reason;

	// Token: 0x04006C63 RID: 27747
	[RequiredMember]
	public int NodeId;

	// Token: 0x04006C64 RID: 27748
	[RequiredMember]
	public NodeStatus NodeStatus;
}
