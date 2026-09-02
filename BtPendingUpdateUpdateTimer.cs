using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001DDD RID: 7645
[RequiredMember]
public class BtPendingUpdateUpdateTimer : BehaviorTreePendingProcess
{
	// Token: 0x0600E21D RID: 57885 RVA: 0x003CE55D File Offset: 0x003CC75D
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public BtPendingUpdateUpdateTimer()
	{
	}

	// Token: 0x04006C6B RID: 27755
	[Nullable(1)]
	[RequiredMember]
	public TimerInfoPb TimerInfo;
}
