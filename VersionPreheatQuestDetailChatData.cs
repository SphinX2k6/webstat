using System;
using System.Runtime.CompilerServices;

// Token: 0x0200161C RID: 5660
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatQuestDetailChatData
{
	// Token: 0x06009FB9 RID: 40889 RVA: 0x0029B820 File Offset: 0x00299A20
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatQuestDetailChatData()
	{
	}

	// Token: 0x0400494B RID: 18763
	[RequiredMember]
	public string NpcIconPath;

	// Token: 0x0400494C RID: 18764
	[RequiredMember]
	public string NpcContentTextId;

	// Token: 0x0400494D RID: 18765
	[Nullable(2)]
	public VersionPreheatQuestDetailChatData SelfChatData;
}
