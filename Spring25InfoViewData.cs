using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020015CC RID: 5580
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class Spring25InfoViewData
{
	// Token: 0x06009D1B RID: 40219 RVA: 0x002922BB File Offset: 0x002904BB
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public Spring25InfoViewData()
	{
	}

	// Token: 0x04004858 RID: 18520
	[RequiredMember]
	public string TitleTextId;

	// Token: 0x04004859 RID: 18521
	[RequiredMember]
	public string CurrentNum;

	// Token: 0x0400485A RID: 18522
	[RequiredMember]
	public string TotalNumTextId;

	// Token: 0x0400485B RID: 18523
	[RequiredMember]
	public string TotalNumTextArg;

	// Token: 0x0400485C RID: 18524
	[RequiredMember]
	public ESpring25InfoBottomState BottomState;

	// Token: 0x0400485D RID: 18525
	[RequiredMember]
	public List<Spring25InfoContentData> ContentList;

	// Token: 0x0400485E RID: 18526
	[RequiredMember]
	public List<Spring25InfoProgressData> ProgressList;
}
