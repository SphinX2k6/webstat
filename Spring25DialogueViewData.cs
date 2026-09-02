using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020015C6 RID: 5574
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class Spring25DialogueViewData
{
	// Token: 0x06009D15 RID: 40213 RVA: 0x0029228B File Offset: 0x0029048B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public Spring25DialogueViewData()
	{
	}

	// Token: 0x0400483F RID: 18495
	[RequiredMember]
	public bool IsOpening;

	// Token: 0x04004840 RID: 18496
	[RequiredMember]
	public Spring25DialogueSpineData LeftSpineData;

	// Token: 0x04004841 RID: 18497
	[RequiredMember]
	public Spring25DialogueSpineData RightSpineData;

	// Token: 0x04004842 RID: 18498
	[RequiredMember]
	public List<Spring25DialogueChatData> ChatDataList;
}
