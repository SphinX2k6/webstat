using System;
using System.Runtime.CompilerServices;

// Token: 0x02001DD8 RID: 7640
[RequiredMember]
public class BtPendingCreateNode : BehaviorTreePendingProcess
{
	// Token: 0x0600E218 RID: 57880 RVA: 0x003CE535 File Offset: 0x003CC735
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public BtPendingCreateNode()
	{
	}

	// Token: 0x04006C60 RID: 27744
	[RequiredMember]
	public ENodeStatusUpdateReason Reason;

	// Token: 0x04006C61 RID: 27745
	[Nullable(2)]
	[RequiredMember]
	public NodeInfo NodeInfo;
}
