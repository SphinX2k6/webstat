using System;
using System.Runtime.CompilerServices;

// Token: 0x020011A6 RID: 4518
[RequiredMember]
public class ArtemisActivityRoleChatViewParams
{
	// Token: 0x060076D6 RID: 30422 RVA: 0x001F1712 File Offset: 0x001EF912
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ArtemisActivityRoleChatViewParams()
	{
	}

	// Token: 0x04003978 RID: 14712
	[Nullable(1)]
	[RequiredMember]
	public ArtemisActivityData Data;

	// Token: 0x04003979 RID: 14713
	[RequiredMember]
	public int DefaultIndex;
}
