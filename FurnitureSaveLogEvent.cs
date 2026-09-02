using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020021B2 RID: 8626
[NullableContext(1)]
[Nullable(0)]
public class FurnitureSaveLogEvent : PlayerCommonLogData
{
	// Token: 0x17001407 RID: 5127
	// (get) Token: 0x0601050D RID: 66829 RVA: 0x00476CAA File Offset: 0x00474EAA
	// (set) Token: 0x0601050E RID: 66830 RVA: 0x00476CB2 File Offset: 0x00474EB2
	public override string event_id { get; set; } = "1836";

	// Token: 0x04008025 RID: 32805
	public int i_area_id;

	// Token: 0x04008026 RID: 32806
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<FurniturePlaceLogData> o_old_place;

	// Token: 0x04008027 RID: 32807
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<FurniturePlaceLogData> o_new_place;

	// Token: 0x04008028 RID: 32808
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<FurniturePlaceDiffLogData> o_diff;

	// Token: 0x04008029 RID: 32809
	public int i_old_atmosphere;

	// Token: 0x0400802A RID: 32810
	public int i_new_atmosphere;

	// Token: 0x0400802B RID: 32811
	public int i_is_save;

	// Token: 0x0400802C RID: 32812
	public string s_trace_id = "";
}
