using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E5C RID: 11868
[NullableContext(2)]
[Nullable(0)]
public class DamageTransfer
{
	// Token: 0x170020AB RID: 8363
	// (get) Token: 0x060185F6 RID: 99830 RVA: 0x006D2D06 File Offset: 0x006D0F06
	// (set) Token: 0x060185F7 RID: 99831 RVA: 0x006D2D0E File Offset: 0x006D0F0E
	public BaseDamageComponent TransferTarget { get; set; }

	// Token: 0x170020AC RID: 8364
	// (get) Token: 0x060185F8 RID: 99832 RVA: 0x006D2D17 File Offset: 0x006D0F17
	// (set) Token: 0x060185F9 RID: 99833 RVA: 0x006D2D1F File Offset: 0x006D0F1F
	public float ToughRecoverDelayTime { get; set; }

	// Token: 0x170020AD RID: 8365
	// (get) Token: 0x060185FA RID: 99834 RVA: 0x006D2D28 File Offset: 0x006D0F28
	// (set) Token: 0x060185FB RID: 99835 RVA: 0x006D2D30 File Offset: 0x006D0F30
	public float WeakTime { get; set; }
}
