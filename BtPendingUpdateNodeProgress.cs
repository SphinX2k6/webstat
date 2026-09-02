using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001DDB RID: 7643
[RequiredMember]
public class BtPendingUpdateNodeProgress : BehaviorTreePendingProcess
{
	// Token: 0x0600E21B RID: 57883 RVA: 0x003CE54D File Offset: 0x003CC74D
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public BtPendingUpdateNodeProgress()
	{
	}

	// Token: 0x04006C68 RID: 27752
	[RequiredMember]
	public int NodeId;

	// Token: 0x04006C69 RID: 27753
	[Nullable(2)]
	[RequiredMember]
	public ChildQuestNodeProgress NodeInfo;
}
