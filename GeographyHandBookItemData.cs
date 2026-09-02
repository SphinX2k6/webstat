using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001E44 RID: 7748
[NullableContext(1)]
[Nullable(0)]
public class GeographyHandBookItemData : IGeographyHandBookItemData
{
	// Token: 0x170011CF RID: 4559
	// (get) Token: 0x0600E55C RID: 58716 RVA: 0x003DF6C5 File Offset: 0x003DD8C5
	// (set) Token: 0x0600E55D RID: 58717 RVA: 0x003DF6CD File Offset: 0x003DD8CD
	public GeographyTabType TabType { get; set; }

	// Token: 0x170011D0 RID: 4560
	// (get) Token: 0x0600E55E RID: 58718 RVA: 0x003DF6D6 File Offset: 0x003DD8D6
	// (set) Token: 0x0600E55F RID: 58719 RVA: 0x003DF6DE File Offset: 0x003DD8DE
	public GeographyType Type { get; set; }

	// Token: 0x170011D1 RID: 4561
	// (get) Token: 0x0600E560 RID: 58720 RVA: 0x003DF6E7 File Offset: 0x003DD8E7
	// (set) Token: 0x0600E561 RID: 58721 RVA: 0x003DF6EF File Offset: 0x003DD8EF
	public List<GeographyHandBook> HandBookList { get; set; }
}
