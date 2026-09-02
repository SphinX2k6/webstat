using System;
using System.Runtime.CompilerServices;

// Token: 0x02001612 RID: 5650
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatQuestData
{
	// Token: 0x06009FAF RID: 40879 RVA: 0x0029B7D0 File Offset: 0x002999D0
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatQuestData()
	{
	}

	// Token: 0x04004925 RID: 18725
	public int Id;

	// Token: 0x04004926 RID: 18726
	public EVersionPreheatQuestState State;

	// Token: 0x04004927 RID: 18727
	[RequiredMember]
	public string NumberTextId;

	// Token: 0x04004928 RID: 18728
	[RequiredMember]
	public string NumberTextArg;

	// Token: 0x04004929 RID: 18729
	[RequiredMember]
	public string TitleTextId;

	// Token: 0x0400492A RID: 18730
	public long UnlockTimestamp;
}
