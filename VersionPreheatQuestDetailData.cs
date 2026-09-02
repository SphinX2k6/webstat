using System;
using System.Runtime.CompilerServices;

// Token: 0x02001619 RID: 5657
[NullableContext(2)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatQuestDetailData
{
	// Token: 0x06009FB6 RID: 40886 RVA: 0x0029B808 File Offset: 0x00299A08
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatQuestDetailData()
	{
	}

	// Token: 0x04004938 RID: 18744
	[Nullable(1)]
	[RequiredMember]
	public VersionPreheatQuestDetailPersistentData PersistentData;

	// Token: 0x04004939 RID: 18745
	public VersionPreheatQuestDetailVoteData VoteData;

	// Token: 0x0400493A RID: 18746
	public VersionPreheatQuestDetailChatData ChatData;

	// Token: 0x0400493B RID: 18747
	public VersionPreheatQuestDetailRewardData RewardData;

	// Token: 0x0400493C RID: 18748
	public string BonusTextId;
}
