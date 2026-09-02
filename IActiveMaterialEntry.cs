using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002CB0 RID: 11440
[NullableContext(1)]
public interface IActiveMaterialEntry
{
	// Token: 0x17001E35 RID: 7733
	// (get) Token: 0x06016F3A RID: 94010
	// (set) Token: 0x06016F3B RID: 94011
	UObject Data { get; set; }

	// Token: 0x17001E36 RID: 7734
	// (get) Token: 0x06016F3C RID: 94012
	// (set) Token: 0x06016F3D RID: 94013
	bool IsGroup { get; set; }

	// Token: 0x17001E37 RID: 7735
	// (get) Token: 0x06016F3E RID: 94014
	// (set) Token: 0x06016F3F RID: 94015
	bool WithAnimObject { get; set; }
}
