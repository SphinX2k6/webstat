using System;

// Token: 0x0200231F RID: 8991
public class MusicUiData : IMusicUiData
{
	// Token: 0x1700152C RID: 5420
	// (get) Token: 0x060111B4 RID: 70068 RVA: 0x004B35A4 File Offset: 0x004B17A4
	// (set) Token: 0x060111B5 RID: 70069 RVA: 0x004B35AC File Offset: 0x004B17AC
	public int Id { get; set; }

	// Token: 0x1700152D RID: 5421
	// (get) Token: 0x060111B6 RID: 70070 RVA: 0x004B35B5 File Offset: 0x004B17B5
	// (set) Token: 0x060111B7 RID: 70071 RVA: 0x004B35BD File Offset: 0x004B17BD
	public bool? IsFavorite { get; set; }
}
