using System;
using System.Runtime.CompilerServices;

// Token: 0x0200161B RID: 5659
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatQuestDetailVoteData
{
	// Token: 0x06009FB8 RID: 40888 RVA: 0x0029B818 File Offset: 0x00299A18
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatQuestDetailVoteData()
	{
	}

	// Token: 0x04004944 RID: 18756
	public float LeftNormalized;

	// Token: 0x04004945 RID: 18757
	public float RightNormalized;

	// Token: 0x04004946 RID: 18758
	[RequiredMember]
	public string LeftPercentageText;

	// Token: 0x04004947 RID: 18759
	[RequiredMember]
	public string RightPercentageText;

	// Token: 0x04004948 RID: 18760
	[RequiredMember]
	public string LeftThemeTextId;

	// Token: 0x04004949 RID: 18761
	[RequiredMember]
	public string RightThemeTextId;

	// Token: 0x0400494A RID: 18762
	public bool IsLeftChosen;
}
