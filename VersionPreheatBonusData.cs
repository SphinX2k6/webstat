using System;
using System.Runtime.CompilerServices;

// Token: 0x02001613 RID: 5651
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatBonusData
{
	// Token: 0x06009FB0 RID: 40880 RVA: 0x0029B7D8 File Offset: 0x002999D8
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatBonusData()
	{
	}

	// Token: 0x0400492B RID: 18731
	[RequiredMember]
	public string NumberTextId;

	// Token: 0x0400492C RID: 18732
	[RequiredMember]
	public string NumberTextArg;

	// Token: 0x0400492D RID: 18733
	[RequiredMember]
	public string ContentTextId;
}
