using System;
using System.Runtime.CompilerServices;

// Token: 0x02002B1F RID: 11039
[NullableContext(1)]
[Nullable(0)]
public readonly struct ESurvivorsLevelInfoSeqName
{
	// Token: 0x060160B9 RID: 90297 RVA: 0x0061E069 File Offset: 0x0061C269
	private ESurvivorsLevelInfoSeqName(string value)
	{
		this._Value = value;
	}

	// Token: 0x060160BA RID: 90298 RVA: 0x0061E072 File Offset: 0x0061C272
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x0400A985 RID: 43397
	private readonly string _Value;

	// Token: 0x0400A986 RID: 43398
	public static readonly ESurvivorsLevelInfoSeqName EndlessOpen = new ESurvivorsLevelInfoSeqName("EndlessOpen");

	// Token: 0x0400A987 RID: 43399
	public static readonly ESurvivorsLevelInfoSeqName Unlock = new ESurvivorsLevelInfoSeqName("Unlock");

	// Token: 0x0400A988 RID: 43400
	public static readonly ESurvivorsLevelInfoSeqName Complete = new ESurvivorsLevelInfoSeqName("Complete");
}
