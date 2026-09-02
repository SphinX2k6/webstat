using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020015CA RID: 5578
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class Spring25InfoContentData
{
	// Token: 0x06009D19 RID: 40217 RVA: 0x002922AB File Offset: 0x002904AB
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public Spring25InfoContentData()
	{
	}

	// Token: 0x0400484D RID: 18509
	[RequiredMember]
	public int TaskId;

	// Token: 0x0400484E RID: 18510
	[RequiredMember]
	public ActivityTaskState State;

	// Token: 0x0400484F RID: 18511
	[RequiredMember]
	public string NameTextId;

	// Token: 0x04004850 RID: 18512
	[RequiredMember]
	public string SubtitleTextId;

	// Token: 0x04004851 RID: 18513
	[RequiredMember]
	public List<string> SubtitleTextArgs;

	// Token: 0x04004852 RID: 18514
	[RequiredMember]
	public List<TItem> ItemList;

	// Token: 0x04004853 RID: 18515
	[RequiredMember]
	public bool IsDone;

	// Token: 0x04004854 RID: 18516
	[RequiredMember]
	public bool CanReward;

	// Token: 0x04004855 RID: 18517
	[Nullable(2)]
	public string RightTextId;
}
