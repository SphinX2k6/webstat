using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002ABD RID: 10941
[NullableContext(2)]
[Nullable(0)]
public class TipsSplineActorData
{
	// Token: 0x06015E37 RID: 89655 RVA: 0x006143E4 File Offset: 0x006125E4
	public TipsSplineActorData(int id, int pbDataId)
	{
	}

	// Token: 0x0400A81F RID: 43039
	public int Id = id;

	// Token: 0x0400A820 RID: 43040
	public int PbDataId = pbDataId;

	// Token: 0x0400A821 RID: 43041
	public TsGameSplineActor Actor;

	// Token: 0x0400A822 RID: 43042
	public USplineComponent SplineComp;
}
