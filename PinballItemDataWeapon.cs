using System;

// Token: 0x020014D9 RID: 5337
public class PinballItemDataWeapon : IPinballItemDataWeapon
{
	// Token: 0x17000CC4 RID: 3268
	// (get) Token: 0x06009537 RID: 38199 RVA: 0x002707D3 File Offset: 0x0026E9D3
	// (set) Token: 0x06009538 RID: 38200 RVA: 0x002707DB File Offset: 0x0026E9DB
	public EPinballItemType Type { get; set; }

	// Token: 0x17000CC5 RID: 3269
	// (get) Token: 0x06009539 RID: 38201 RVA: 0x002707E4 File Offset: 0x0026E9E4
	// (set) Token: 0x0600953A RID: 38202 RVA: 0x002707EC File Offset: 0x0026E9EC
	public int Id { get; set; }

	// Token: 0x17000CC6 RID: 3270
	// (get) Token: 0x0600953B RID: 38203 RVA: 0x002707F5 File Offset: 0x0026E9F5
	// (set) Token: 0x0600953C RID: 38204 RVA: 0x002707FD File Offset: 0x0026E9FD
	public int IncId { get; set; }

	// Token: 0x17000CC7 RID: 3271
	// (get) Token: 0x0600953D RID: 38205 RVA: 0x00270806 File Offset: 0x0026EA06
	// (set) Token: 0x0600953E RID: 38206 RVA: 0x0027080E File Offset: 0x0026EA0E
	public bool? IsUnavailable { get; set; }

	// Token: 0x17000CC8 RID: 3272
	// (get) Token: 0x0600953F RID: 38207 RVA: 0x00270817 File Offset: 0x0026EA17
	// (set) Token: 0x06009540 RID: 38208 RVA: 0x0027081F File Offset: 0x0026EA1F
	public int? RoleId { get; set; }

	// Token: 0x17000CC9 RID: 3273
	// (get) Token: 0x06009541 RID: 38209 RVA: 0x00270828 File Offset: 0x0026EA28
	// (set) Token: 0x06009542 RID: 38210 RVA: 0x00270830 File Offset: 0x0026EA30
	public bool? IsLocked { get; set; }

	// Token: 0x17000CCA RID: 3274
	// (get) Token: 0x06009543 RID: 38211 RVA: 0x00270839 File Offset: 0x0026EA39
	// (set) Token: 0x06009544 RID: 38212 RVA: 0x00270841 File Offset: 0x0026EA41
	public bool? NeedReduceBtn { get; set; }

	// Token: 0x17000CCB RID: 3275
	// (get) Token: 0x06009545 RID: 38213 RVA: 0x0027084A File Offset: 0x0026EA4A
	// (set) Token: 0x06009546 RID: 38214 RVA: 0x00270852 File Offset: 0x0026EA52
	public bool? IsRecommendedWeapon { get; set; }
}
