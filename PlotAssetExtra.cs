using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020032BD RID: 12989
[NullableContext(1)]
[Nullable(0)]
public class PlotAssetExtra
{
	// Token: 0x0601B396 RID: 111510 RVA: 0x0082DEDD File Offset: 0x0082C0DD
	public PlotAssetExtra(string plotId)
	{
	}

	// Token: 0x0400DDE8 RID: 56808
	public readonly string PlotId = plotId;

	// Token: 0x0400DDE9 RID: 56809
	[Nullable(2)]
	public string VideoPath;

	// Token: 0x0400DDEA RID: 56810
	public List<int> QteIds = new List<int>();
}
