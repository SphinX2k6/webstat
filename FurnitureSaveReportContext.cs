using System;
using System.Runtime.CompilerServices;

// Token: 0x02001068 RID: 4200
[NullableContext(1)]
[Nullable(0)]
public class FurnitureSaveReportContext : IFurnitureSaveReportContext
{
	// Token: 0x170008CA RID: 2250
	// (get) Token: 0x06006D12 RID: 27922 RVA: 0x001C5F96 File Offset: 0x001C4196
	// (set) Token: 0x06006D13 RID: 27923 RVA: 0x001C5F9E File Offset: 0x001C419E
	public int AreaId { get; set; }

	// Token: 0x170008CB RID: 2251
	// (get) Token: 0x06006D14 RID: 27924 RVA: 0x001C5FA7 File Offset: 0x001C41A7
	// (set) Token: 0x06006D15 RID: 27925 RVA: 0x001C5FAF File Offset: 0x001C41AF
	public FurnitureAreaData OldAreaData { get; set; }

	// Token: 0x170008CC RID: 2252
	// (get) Token: 0x06006D16 RID: 27926 RVA: 0x001C5FB8 File Offset: 0x001C41B8
	// (set) Token: 0x06006D17 RID: 27927 RVA: 0x001C5FC0 File Offset: 0x001C41C0
	public FurnitureAreaData NewAreaData { get; set; }

	// Token: 0x170008CD RID: 2253
	// (get) Token: 0x06006D18 RID: 27928 RVA: 0x001C5FC9 File Offset: 0x001C41C9
	// (set) Token: 0x06006D19 RID: 27929 RVA: 0x001C5FD1 File Offset: 0x001C41D1
	public bool IsSave { get; set; }
}
