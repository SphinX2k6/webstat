using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001E43 RID: 7747
[NullableContext(1)]
public interface IGeographyHandBookItemData
{
	// Token: 0x170011CC RID: 4556
	// (get) Token: 0x0600E556 RID: 58710
	// (set) Token: 0x0600E557 RID: 58711
	GeographyTabType TabType { get; set; }

	// Token: 0x170011CD RID: 4557
	// (get) Token: 0x0600E558 RID: 58712
	// (set) Token: 0x0600E559 RID: 58713
	GeographyType Type { get; set; }

	// Token: 0x170011CE RID: 4558
	// (get) Token: 0x0600E55A RID: 58714
	// (set) Token: 0x0600E55B RID: 58715
	List<GeographyHandBook> HandBookList { get; set; }
}
