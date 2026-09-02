using System;
using System.Runtime.CompilerServices;

// Token: 0x020017A7 RID: 6055
[NullableContext(1)]
[Nullable(0)]
public class TeleportInfo
{
	// Token: 0x0600AAD3 RID: 43731 RVA: 0x002DA330 File Offset: 0x002D8530
	public TeleportInfo(Vector location, [Nullable(2)] Rotator rotator)
	{
	}

	// Token: 0x17000DE8 RID: 3560
	// (get) Token: 0x0600AAD4 RID: 43732 RVA: 0x002DA346 File Offset: 0x002D8546
	// (set) Token: 0x0600AAD5 RID: 43733 RVA: 0x002DA34E File Offset: 0x002D854E
	public Vector Location { get; set; } = location;

	// Token: 0x17000DE9 RID: 3561
	// (get) Token: 0x0600AAD6 RID: 43734 RVA: 0x002DA357 File Offset: 0x002D8557
	// (set) Token: 0x0600AAD7 RID: 43735 RVA: 0x002DA35F File Offset: 0x002D855F
	[Nullable(2)]
	public Rotator Rotator { [NullableContext(2)] get; [NullableContext(2)] set; } = rotator;
}
