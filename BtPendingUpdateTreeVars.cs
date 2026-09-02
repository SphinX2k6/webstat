using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001DE0 RID: 7648
[RequiredMember]
public class BtPendingUpdateTreeVars : BehaviorTreePendingProcess
{
	// Token: 0x0600E220 RID: 57888 RVA: 0x003CE575 File Offset: 0x003CC775
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public BtPendingUpdateTreeVars()
	{
	}

	// Token: 0x04006C76 RID: 27766
	[Nullable(1)]
	[RequiredMember]
	public BtVarUpdateNotify Notify;
}
