using System;
using System.Runtime.CompilerServices;

// Token: 0x02001DEA RID: 7658
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class IOccupationInfo
{
	// Token: 0x0600E222 RID: 57890 RVA: 0x003CE593 File Offset: 0x003CC793
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public IOccupationInfo()
	{
	}

	// Token: 0x04006CB7 RID: 27831
	[RequiredMember]
	public string ResourceName;

	// Token: 0x04006CB8 RID: 27832
	[RequiredMember]
	public string QuestName;

	// Token: 0x04006CB9 RID: 27833
	[RequiredMember]
	public long TreeIncId;
}
