using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200161F RID: 5663
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatVoteData
{
	// Token: 0x06009FBC RID: 40892 RVA: 0x0029B838 File Offset: 0x00299A38
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatVoteData()
	{
	}

	// Token: 0x04004958 RID: 18776
	[RequiredMember]
	public string TitleTextId;

	// Token: 0x04004959 RID: 18777
	[RequiredMember]
	public string ContentTextId;

	// Token: 0x0400495A RID: 18778
	public int CrestIndex;

	// Token: 0x0400495B RID: 18779
	[RequiredMember]
	public VersionPreheatVoteToggleData LeftToggleData;

	// Token: 0x0400495C RID: 18780
	[RequiredMember]
	public VersionPreheatVoteToggleData RightToggleData;

	// Token: 0x0400495D RID: 18781
	[RequiredMember]
	public List<TItem> ItemListData;

	// Token: 0x0400495E RID: 18782
	public bool? IsLeftChosen;
}
