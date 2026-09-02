using System;
using System.Runtime.CompilerServices;

// Token: 0x020015C5 RID: 5573
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class Spring25DialogueChatData
{
	// Token: 0x06009D14 RID: 40212 RVA: 0x00292283 File Offset: 0x00290483
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public Spring25DialogueChatData()
	{
	}

	// Token: 0x0400483C RID: 18492
	[RequiredMember]
	public string ContentTextId;

	// Token: 0x0400483D RID: 18493
	[RequiredMember]
	public ESpring25DialogType Position;

	// Token: 0x0400483E RID: 18494
	[RequiredMember]
	public string SpineAnimName;
}
