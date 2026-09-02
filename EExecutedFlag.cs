using System;

// Token: 0x02000089 RID: 137
[Flags]
public enum EExecutedFlag
{
	// Token: 0x0400033C RID: 828
	None = 0,
	// Token: 0x0400033D RID: 829
	Create = 1,
	// Token: 0x0400033E RID: 830
	InitData = 2,
	// Token: 0x0400033F RID: 831
	Init = 4,
	// Token: 0x04000340 RID: 832
	Start = 8,
	// Token: 0x04000341 RID: 833
	Activate = 16,
	// Token: 0x04000342 RID: 834
	PostActivate = 32,
	// Token: 0x04000343 RID: 835
	End = 64,
	// Token: 0x04000344 RID: 836
	Clear = 128
}
