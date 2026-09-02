using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020029E9 RID: 10729
[NullableContext(1)]
[Nullable(0)]
public class ParallaxItem : IParallaxItem
{
	// Token: 0x17001BE7 RID: 7143
	// (get) Token: 0x0601562B RID: 87595 RVA: 0x005ECA86 File Offset: 0x005EAC86
	// (set) Token: 0x0601562C RID: 87596 RVA: 0x005ECA8E File Offset: 0x005EAC8E
	public UUIItem Item { get; set; }

	// Token: 0x17001BE8 RID: 7144
	// (get) Token: 0x0601562D RID: 87597 RVA: 0x005ECA97 File Offset: 0x005EAC97
	// (set) Token: 0x0601562E RID: 87598 RVA: 0x005ECA9F File Offset: 0x005EAC9F
	public float InitPosY { get; set; }

	// Token: 0x17001BE9 RID: 7145
	// (get) Token: 0x0601562F RID: 87599 RVA: 0x005ECAA8 File Offset: 0x005EACA8
	// (set) Token: 0x06015630 RID: 87600 RVA: 0x005ECAB0 File Offset: 0x005EACB0
	public float ParallaxSub { get; set; }
}
