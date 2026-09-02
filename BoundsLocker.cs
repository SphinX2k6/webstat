using System;

// Token: 0x02002E97 RID: 11927
public class BoundsLocker : IBoundsLocker
{
	// Token: 0x1700210F RID: 8463
	// (get) Token: 0x060187BC RID: 100284 RVA: 0x006DB48C File Offset: 0x006D968C
	// (set) Token: 0x060187BD RID: 100285 RVA: 0x006DB494 File Offset: 0x006D9694
	public bool LockUpperBounds { get; set; }

	// Token: 0x17002110 RID: 8464
	// (get) Token: 0x060187BE RID: 100286 RVA: 0x006DB49D File Offset: 0x006D969D
	// (set) Token: 0x060187BF RID: 100287 RVA: 0x006DB4A5 File Offset: 0x006D96A5
	public bool LockLowerBounds { get; set; }

	// Token: 0x17002111 RID: 8465
	// (get) Token: 0x060187C0 RID: 100288 RVA: 0x006DB4AE File Offset: 0x006D96AE
	// (set) Token: 0x060187C1 RID: 100289 RVA: 0x006DB4B6 File Offset: 0x006D96B6
	public float UpperPercent { get; set; }

	// Token: 0x17002112 RID: 8466
	// (get) Token: 0x060187C2 RID: 100290 RVA: 0x006DB4BF File Offset: 0x006D96BF
	// (set) Token: 0x060187C3 RID: 100291 RVA: 0x006DB4C7 File Offset: 0x006D96C7
	public float UpperOffset { get; set; }

	// Token: 0x17002113 RID: 8467
	// (get) Token: 0x060187C4 RID: 100292 RVA: 0x006DB4D0 File Offset: 0x006D96D0
	// (set) Token: 0x060187C5 RID: 100293 RVA: 0x006DB4D8 File Offset: 0x006D96D8
	public float LowerPercent { get; set; }

	// Token: 0x17002114 RID: 8468
	// (get) Token: 0x060187C6 RID: 100294 RVA: 0x006DB4E1 File Offset: 0x006D96E1
	// (set) Token: 0x060187C7 RID: 100295 RVA: 0x006DB4E9 File Offset: 0x006D96E9
	public float LowerOffset { get; set; }
}
