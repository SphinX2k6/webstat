using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000E4D RID: 3661
public class SetMovementModeInfo
{
	// Token: 0x04001DAA RID: 7594
	public EMovementMode Mode;

	// Token: 0x04001DAB RID: 7595
	public byte CustomMode;

	// Token: 0x04001DAC RID: 7596
	[Nullable(1)]
	public Action Callback;

	// Token: 0x04001DAD RID: 7597
	public long? Uid;

	// Token: 0x04001DAE RID: 7598
	[Nullable(2)]
	public string Context;
}
