using System;
using System.Runtime.CompilerServices;

// Token: 0x02000FBE RID: 4030
[NullableContext(1)]
[Nullable(0)]
public class ThresholdListenerInfo : IThresholdListenerInfo
{
	// Token: 0x17000810 RID: 2064
	// (get) Token: 0x06006727 RID: 26407 RVA: 0x001AEC39 File Offset: 0x001ACE39
	// (set) Token: 0x06006728 RID: 26408 RVA: 0x001AEC41 File Offset: 0x001ACE41
	public TThresholdListener Func { get; set; }

	// Token: 0x17000811 RID: 2065
	// (get) Token: 0x06006729 RID: 26409 RVA: 0x001AEC4A File Offset: 0x001ACE4A
	// (set) Token: 0x0600672A RID: 26410 RVA: 0x001AEC52 File Offset: 0x001ACE52
	public float Max { get; set; }

	// Token: 0x17000812 RID: 2066
	// (get) Token: 0x0600672B RID: 26411 RVA: 0x001AEC5B File Offset: 0x001ACE5B
	// (set) Token: 0x0600672C RID: 26412 RVA: 0x001AEC63 File Offset: 0x001ACE63
	public float Min { get; set; }

	// Token: 0x17000813 RID: 2067
	// (get) Token: 0x0600672D RID: 26413 RVA: 0x001AEC6C File Offset: 0x001ACE6C
	// (set) Token: 0x0600672E RID: 26414 RVA: 0x001AEC74 File Offset: 0x001ACE74
	public bool InInterval { get; set; }
}
