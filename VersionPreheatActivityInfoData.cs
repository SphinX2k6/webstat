using System;
using System.Runtime.CompilerServices;

// Token: 0x02001614 RID: 5652
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatActivityInfoData
{
	// Token: 0x06009FB1 RID: 40881 RVA: 0x0029B7E0 File Offset: 0x002999E0
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatActivityInfoData()
	{
	}

	// Token: 0x0400492E RID: 18734
	[RequiredMember]
	public VersionPreheatActivityTitleData TitleData;

	// Token: 0x0400492F RID: 18735
	[RequiredMember]
	public VersionPreheatActivityDescriptionData DescriptionData;

	// Token: 0x04004930 RID: 18736
	[RequiredMember]
	public VersionPreheatActivityRewardData RewardData;

	// Token: 0x04004931 RID: 18737
	[RequiredMember]
	public VersionPreheatActivityBottomData BottomData;
}
