using System;
using System.Runtime.CompilerServices;

// Token: 0x02000018 RID: 24
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class GetPutRecord
{
	// Token: 0x06000045 RID: 69 RVA: 0x00003895 File Offset: 0x00001A95
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public GetPutRecord()
	{
	}

	// Token: 0x0400002D RID: 45
	[RequiredMember]
	public string ClassName;

	// Token: 0x0400002E RID: 46
	[RequiredMember]
	public string GetOrPut;

	// Token: 0x0400002F RID: 47
	public bool Hit;

	// Token: 0x04000030 RID: 48
	public long TimeStamp;

	// Token: 0x04000031 RID: 49
	public int ThisTypeTotal;

	// Token: 0x04000032 RID: 50
	public float HitRate;

	// Token: 0x04000033 RID: 51
	public int CurrentTotal;

	// Token: 0x04000034 RID: 52
	public int PendingKillNum;
}
