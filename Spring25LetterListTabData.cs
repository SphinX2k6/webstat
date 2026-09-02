using System;
using System.Runtime.CompilerServices;

// Token: 0x020015C8 RID: 5576
[NullableContext(2)]
[Nullable(0)]
[RequiredMember]
public class Spring25LetterListTabData
{
	// Token: 0x06009D17 RID: 40215 RVA: 0x0029229B File Offset: 0x0029049B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public Spring25LetterListTabData()
	{
	}

	// Token: 0x04004845 RID: 18501
	[RequiredMember]
	public int SignId;

	// Token: 0x04004846 RID: 18502
	[RequiredMember]
	public bool IsChosen;

	// Token: 0x04004847 RID: 18503
	[RequiredMember]
	public bool IsNew;

	// Token: 0x04004848 RID: 18504
	public string TexturePath;

	// Token: 0x04004849 RID: 18505
	public string DescriptionTextId;
}
