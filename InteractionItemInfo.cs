using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020017A2 RID: 6050
[NullableContext(1)]
[Nullable(0)]
public class InteractionItemInfo
{
	// Token: 0x17000DE5 RID: 3557
	// (get) Token: 0x0600AAB8 RID: 43704 RVA: 0x002D9688 File Offset: 0x002D7888
	// (set) Token: 0x0600AAB9 RID: 43705 RVA: 0x002D9690 File Offset: 0x002D7890
	public IReadOnlySet<string> Foliages { get; set; }

	// Token: 0x17000DE6 RID: 3558
	// (get) Token: 0x0600AABA RID: 43706 RVA: 0x002D9699 File Offset: 0x002D7899
	// (set) Token: 0x0600AABB RID: 43707 RVA: 0x002D96A1 File Offset: 0x002D78A1
	public IReadOnlySet<string> StaticMeshes { get; set; }

	// Token: 0x17000DE7 RID: 3559
	// (get) Token: 0x0600AABC RID: 43708 RVA: 0x002D96AA File Offset: 0x002D78AA
	// (set) Token: 0x0600AABD RID: 43709 RVA: 0x002D96B2 File Offset: 0x002D78B2
	public string AudioKey { get; set; }

	// Token: 0x0600AABE RID: 43710 RVA: 0x002D96BB File Offset: 0x002D78BB
	public InteractionItemInfo(IReadOnlySet<string> foliages, IReadOnlySet<string> staticMeshes, string audioKey)
	{
		this.Foliages = foliages;
		this.StaticMeshes = staticMeshes;
		this.AudioKey = audioKey;
	}
}
