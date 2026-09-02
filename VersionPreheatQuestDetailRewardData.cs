using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200161D RID: 5661
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatQuestDetailRewardData
{
	// Token: 0x06009FBA RID: 40890 RVA: 0x0029B828 File Offset: 0x00299A28
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatQuestDetailRewardData()
	{
	}

	// Token: 0x0400494E RID: 18766
	[RequiredMember]
	public string QuestContentTextId;

	// Token: 0x0400494F RID: 18767
	[RequiredMember]
	public List<TItem> ItemListData;

	// Token: 0x04004950 RID: 18768
	public bool IsReceived;

	// Token: 0x04004951 RID: 18769
	[RequiredMember]
	public TVersionPreheatQuestDetailClickFunc ClickFunc;

	// Token: 0x04004952 RID: 18770
	public int ClickPassData;
}
