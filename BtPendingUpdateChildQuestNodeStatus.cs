using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001DDA RID: 7642
[RequiredMember]
public class BtPendingUpdateChildQuestNodeStatus : BehaviorTreePendingProcess
{
	// Token: 0x0600E21A RID: 57882 RVA: 0x003CE545 File Offset: 0x003CC745
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public BtPendingUpdateChildQuestNodeStatus()
	{
	}

	// Token: 0x04006C65 RID: 27749
	[RequiredMember]
	public int NodeId;

	// Token: 0x04006C66 RID: 27750
	[RequiredMember]
	public ChildQuestNodeStatus NodeStatus;

	// Token: 0x04006C67 RID: 27751
	[RequiredMember]
	public ENodeStatusUpdateReason Reason;
}
