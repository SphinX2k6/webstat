using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002B4D RID: 11085
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueParallaxItem : ISurvivorsRogueParallaxItem
{
	// Token: 0x17001CC3 RID: 7363
	// (get) Token: 0x06016194 RID: 90516 RVA: 0x00621DED File Offset: 0x0061FFED
	// (set) Token: 0x06016195 RID: 90517 RVA: 0x00621DF5 File Offset: 0x0061FFF5
	public UUIItem Item { get; set; }

	// Token: 0x17001CC4 RID: 7364
	// (get) Token: 0x06016196 RID: 90518 RVA: 0x00621DFE File Offset: 0x0061FFFE
	// (set) Token: 0x06016197 RID: 90519 RVA: 0x00621E06 File Offset: 0x00620006
	public float InitPosY { get; set; }

	// Token: 0x17001CC5 RID: 7365
	// (get) Token: 0x06016198 RID: 90520 RVA: 0x00621E0F File Offset: 0x0062000F
	// (set) Token: 0x06016199 RID: 90521 RVA: 0x00621E17 File Offset: 0x00620017
	public float ParallaxFactor { get; set; }
}
