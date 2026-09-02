using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A55 RID: 6741
[NullableContext(1)]
[Nullable(0)]
public class SpineAnimationQueueParam : ISpineAnimationQueueParam
{
	// Token: 0x17000FD1 RID: 4049
	// (get) Token: 0x0600C0B1 RID: 49329 RVA: 0x0032D6B3 File Offset: 0x0032B8B3
	// (set) Token: 0x0600C0B2 RID: 49330 RVA: 0x0032D6BB File Offset: 0x0032B8BB
	public int LayerIndex { get; set; }

	// Token: 0x17000FD2 RID: 4050
	// (get) Token: 0x0600C0B3 RID: 49331 RVA: 0x0032D6C4 File Offset: 0x0032B8C4
	// (set) Token: 0x0600C0B4 RID: 49332 RVA: 0x0032D6CC File Offset: 0x0032B8CC
	public string AnimationName { get; set; } = "";

	// Token: 0x17000FD3 RID: 4051
	// (get) Token: 0x0600C0B5 RID: 49333 RVA: 0x0032D6D5 File Offset: 0x0032B8D5
	// (set) Token: 0x0600C0B6 RID: 49334 RVA: 0x0032D6DD File Offset: 0x0032B8DD
	public bool Loop { get; set; }
}
