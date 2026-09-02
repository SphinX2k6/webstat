using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001617 RID: 5655
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatActivityRewardData
{
	// Token: 0x06009FB4 RID: 40884 RVA: 0x0029B7F8 File Offset: 0x002999F8
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatActivityRewardData()
	{
	}

	// Token: 0x04004935 RID: 18741
	[RequiredMember]
	public string TitleId;

	// Token: 0x04004936 RID: 18742
	[RequiredMember]
	public List<TItem> RewardList;
}
