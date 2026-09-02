using System;

namespace CSharpScript.Game.Module.FilterSort.Sort.SortEntrance
{
	// Token: 0x02005E34 RID: 24116
	public class SortData : ISortData
	{
		// Token: 0x1700992C RID: 39212
		// (get) Token: 0x0603CAFA RID: 248570 RVA: 0x00F69BB3 File Offset: 0x00F67DB3
		// (set) Token: 0x0603CAFB RID: 248571 RVA: 0x00F69BBB File Offset: 0x00F67DBB
		public int RuleId { get; set; }

		// Token: 0x1700992D RID: 39213
		// (get) Token: 0x0603CAFC RID: 248572 RVA: 0x00F69BC4 File Offset: 0x00F67DC4
		// (set) Token: 0x0603CAFD RID: 248573 RVA: 0x00F69BCC File Offset: 0x00F67DCC
		public ESortDataType DataType { get; set; }

		// Token: 0x1700992E RID: 39214
		// (get) Token: 0x0603CAFE RID: 248574 RVA: 0x00F69BD5 File Offset: 0x00F67DD5
		// (set) Token: 0x0603CAFF RID: 248575 RVA: 0x00F69BDD File Offset: 0x00F67DDD
		public int SelectedRule { get; set; }
	}
}
