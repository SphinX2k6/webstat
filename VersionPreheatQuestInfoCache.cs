using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001611 RID: 5649
[RequiredMember]
public class VersionPreheatQuestInfoCache
{
	// Token: 0x06009FAE RID: 40878 RVA: 0x0029B7C8 File Offset: 0x002999C8
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatQuestInfoCache()
	{
	}

	// Token: 0x04004921 RID: 18721
	[Nullable(1)]
	[RequiredMember]
	public PreheatSignNodeInfo Meta;

	// Token: 0x04004922 RID: 18722
	public int Id;

	// Token: 0x04004923 RID: 18723
	public long UnlockTimestamp;

	// Token: 0x04004924 RID: 18724
	public bool Rewarded;
}
