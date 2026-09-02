using System;
using System.Runtime.CompilerServices;

// Token: 0x020022B4 RID: 8884
[NullableContext(2)]
public interface IMotorTechLevelPoint
{
	// Token: 0x170014CC RID: 5324
	// (get) Token: 0x06010C92 RID: 68754
	// (set) Token: 0x06010C93 RID: 68755
	string Title { get; set; }

	// Token: 0x170014CD RID: 5325
	// (get) Token: 0x06010C94 RID: 68756
	// (set) Token: 0x06010C95 RID: 68757
	string Desc { get; set; }

	// Token: 0x170014CE RID: 5326
	// (get) Token: 0x06010C96 RID: 68758
	// (set) Token: 0x06010C97 RID: 68759
	int TargetLevel { get; set; }

	// Token: 0x170014CF RID: 5327
	// (get) Token: 0x06010C98 RID: 68760
	// (set) Token: 0x06010C99 RID: 68761
	int CurLevel { get; set; }
}
