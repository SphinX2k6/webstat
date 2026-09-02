using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020015C9 RID: 5577
[NullableContext(2)]
[Nullable(0)]
[RequiredMember]
public class Spring25LetterListViewData
{
	// Token: 0x06009D18 RID: 40216 RVA: 0x002922A3 File Offset: 0x002904A3
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public Spring25LetterListViewData()
	{
	}

	// Token: 0x0400484A RID: 18506
	[Nullable(1)]
	[RequiredMember]
	public List<Spring25LetterListTabData> TabDataList;

	// Token: 0x0400484B RID: 18507
	public string InfoTextId;

	// Token: 0x0400484C RID: 18508
	public string TitleTextId;
}
