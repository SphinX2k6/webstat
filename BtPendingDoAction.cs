using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001DDE RID: 7646
[RequiredMember]
public class BtPendingDoAction : BehaviorTreePendingProcess
{
	// Token: 0x0600E21E RID: 57886 RVA: 0x003CE565 File Offset: 0x003CC765
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public BtPendingDoAction()
	{
	}

	// Token: 0x04006C6C RID: 27756
	[Nullable(1)]
	[RequiredMember]
	public GameCtxPb Context;

	// Token: 0x04006C6D RID: 27757
	[RequiredMember]
	public int NodeId;

	// Token: 0x04006C6E RID: 27758
	[RequiredMember]
	public int PlayerId;

	// Token: 0x04006C6F RID: 27759
	[RequiredMember]
	public int SessionId;

	// Token: 0x04006C70 RID: 27760
	[RequiredMember]
	public int StartIndex;

	// Token: 0x04006C71 RID: 27761
	[RequiredMember]
	public int EndIndex;

	// Token: 0x04006C72 RID: 27762
	[RequiredMember]
	public bool NeedFinishReq;
}
