using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002B4C RID: 11084
[NullableContext(1)]
public interface ISurvivorsRogueParallaxItem
{
	// Token: 0x17001CC0 RID: 7360
	// (get) Token: 0x0601618E RID: 90510
	// (set) Token: 0x0601618F RID: 90511
	UUIItem Item { get; set; }

	// Token: 0x17001CC1 RID: 7361
	// (get) Token: 0x06016190 RID: 90512
	// (set) Token: 0x06016191 RID: 90513
	float InitPosY { get; set; }

	// Token: 0x17001CC2 RID: 7362
	// (get) Token: 0x06016192 RID: 90514
	// (set) Token: 0x06016193 RID: 90515
	float ParallaxFactor { get; set; }
}
