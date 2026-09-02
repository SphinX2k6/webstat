using System;

// Token: 0x020019C9 RID: 6601
public class MediumLevelAndLock : IMediumLevelAndLock
{
	// Token: 0x17000F7F RID: 3967
	// (get) Token: 0x0600BD80 RID: 48512 RVA: 0x003240B0 File Offset: 0x003222B0
	// (set) Token: 0x0600BD81 RID: 48513 RVA: 0x003240B8 File Offset: 0x003222B8
	public int? Level { get; set; }

	// Token: 0x17000F80 RID: 3968
	// (get) Token: 0x0600BD82 RID: 48514 RVA: 0x003240C1 File Offset: 0x003222C1
	// (set) Token: 0x0600BD83 RID: 48515 RVA: 0x003240C9 File Offset: 0x003222C9
	public bool? IsLevelInfinite { get; set; }

	// Token: 0x17000F81 RID: 3969
	// (get) Token: 0x0600BD84 RID: 48516 RVA: 0x003240D2 File Offset: 0x003222D2
	// (set) Token: 0x0600BD85 RID: 48517 RVA: 0x003240DA File Offset: 0x003222DA
	public bool? IsLockVisible { get; set; }

	// Token: 0x17000F82 RID: 3970
	// (get) Token: 0x0600BD86 RID: 48518 RVA: 0x003240E3 File Offset: 0x003222E3
	// (set) Token: 0x0600BD87 RID: 48519 RVA: 0x003240EB File Offset: 0x003222EB
	public bool? IsLevelUseChangeColor { get; set; }

	// Token: 0x17000F83 RID: 3971
	// (get) Token: 0x0600BD88 RID: 48520 RVA: 0x003240F4 File Offset: 0x003222F4
	// (set) Token: 0x0600BD89 RID: 48521 RVA: 0x003240FC File Offset: 0x003222FC
	public bool? IsUseVision { get; set; }

	// Token: 0x17000F84 RID: 3972
	// (get) Token: 0x0600BD8A RID: 48522 RVA: 0x00324105 File Offset: 0x00322305
	// (set) Token: 0x0600BD8B RID: 48523 RVA: 0x0032410D File Offset: 0x0032230D
	public bool? IsDeprecate { get; set; }
}
