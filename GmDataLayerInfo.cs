using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020017A8 RID: 6056
[NullableContext(1)]
[Nullable(0)]
public class GmDataLayerInfo
{
	// Token: 0x0600AAD8 RID: 43736 RVA: 0x002DA368 File Offset: 0x002D8568
	public GmDataLayerInfo(HashSet<string> loadDataLayers, HashSet<string> unloadDataLayers)
	{
	}

	// Token: 0x17000DEA RID: 3562
	// (get) Token: 0x0600AAD9 RID: 43737 RVA: 0x002DA37E File Offset: 0x002D857E
	// (set) Token: 0x0600AADA RID: 43738 RVA: 0x002DA386 File Offset: 0x002D8586
	public HashSet<string> LoadDataLayers { get; set; } = loadDataLayers;

	// Token: 0x17000DEB RID: 3563
	// (get) Token: 0x0600AADB RID: 43739 RVA: 0x002DA38F File Offset: 0x002D858F
	// (set) Token: 0x0600AADC RID: 43740 RVA: 0x002DA397 File Offset: 0x002D8597
	public HashSet<string> UnloadDataLayers { get; set; } = unloadDataLayers;
}
