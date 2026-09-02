using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001DDF RID: 7647
[RequiredMember]
public class BtPendingUpdateOccupations : BehaviorTreePendingProcess
{
	// Token: 0x0600E21F RID: 57887 RVA: 0x003CE56D File Offset: 0x003CC76D
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public BtPendingUpdateOccupations()
	{
	}

	// Token: 0x04006C73 RID: 27763
	[RequiredMember]
	public int SuspendNodeId;

	// Token: 0x04006C74 RID: 27764
	[RequiredMember]
	public int SuspendType;

	// Token: 0x04006C75 RID: 27765
	[Nullable(1)]
	[RequiredMember]
	public IReadOnlyList<OccupationPbInfo> OccupationInfo;
}
