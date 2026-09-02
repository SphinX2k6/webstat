using System;
using System.Runtime.CompilerServices;

// Token: 0x02001620 RID: 5664
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatVoteToggleData
{
	// Token: 0x06009FBD RID: 40893 RVA: 0x0029B840 File Offset: 0x00299A40
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatVoteToggleData()
	{
	}

	// Token: 0x0400495F RID: 18783
	public int Id;

	// Token: 0x04004960 RID: 18784
	[RequiredMember]
	public string ContentTextId;

	// Token: 0x04004961 RID: 18785
	[RequiredMember]
	public TVersionPreheatVoteClickFunc ClickFunc;

	// Token: 0x04004962 RID: 18786
	public bool ClickPassData;
}
