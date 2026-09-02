using System;
using System.Runtime.CompilerServices;

// Token: 0x0200161A RID: 5658
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatQuestDetailPersistentData
{
	// Token: 0x06009FB7 RID: 40887 RVA: 0x0029B810 File Offset: 0x00299A10
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatQuestDetailPersistentData()
	{
	}

	// Token: 0x0400493D RID: 18749
	public int Index;

	// Token: 0x0400493E RID: 18750
	[RequiredMember]
	public string QuestPhotoPath;

	// Token: 0x0400493F RID: 18751
	[RequiredMember]
	public string QuestTitleTextId;

	// Token: 0x04004940 RID: 18752
	[RequiredMember]
	public string QuestContentTextId;

	// Token: 0x04004941 RID: 18753
	public int QuestCrestIndex;

	// Token: 0x04004942 RID: 18754
	[RequiredMember]
	public string QuestSharePhotoPath;

	// Token: 0x04004943 RID: 18755
	public bool CanShare;
}
