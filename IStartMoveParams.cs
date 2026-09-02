using System;
using System.Runtime.CompilerServices;

// Token: 0x020030F4 RID: 12532
[NullableContext(1)]
[Nullable(0)]
public class IStartMoveParams : PatrolParamsImpl, IActionParamMap
{
	// Token: 0x17002326 RID: 8998
	// (get) Token: 0x06019EBD RID: 106173 RVA: 0x0079460E File Offset: 0x0079280E
	// (set) Token: 0x06019EBE RID: 106174 RVA: 0x00794616 File Offset: 0x00792816
	public int SplineId { get; set; }

	// Token: 0x17002327 RID: 8999
	// (get) Token: 0x06019EBF RID: 106175 RVA: 0x0079461F File Offset: 0x0079281F
	// (set) Token: 0x06019EC0 RID: 106176 RVA: 0x00794627 File Offset: 0x00792827
	public string Context { get; set; }
}
