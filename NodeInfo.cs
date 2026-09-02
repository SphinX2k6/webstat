using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001DD4 RID: 7636
[RequiredMember]
public class NodeInfo
{
	// Token: 0x0600E216 RID: 57878 RVA: 0x003CE525 File Offset: 0x003CC725
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public NodeInfo()
	{
	}

	// Token: 0x04006C4E RID: 27726
	[Nullable(1)]
	[RequiredMember]
	public Aki.Protocol.NodeInfo Info;

	// Token: 0x04006C4F RID: 27727
	[RequiredMember]
	public int NodeId;
}
