using System;
using System.Runtime.CompilerServices;

// Token: 0x02001615 RID: 5653
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatActivityTitleData
{
	// Token: 0x06009FB2 RID: 40882 RVA: 0x0029B7E8 File Offset: 0x002999E8
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatActivityTitleData()
	{
	}

	// Token: 0x04004932 RID: 18738
	[RequiredMember]
	public string TitleTextId;

	// Token: 0x04004933 RID: 18739
	[RequiredMember]
	public string SubTitleTextId;
}
