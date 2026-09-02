using System;
using System.Runtime.CompilerServices;

// Token: 0x020019B1 RID: 6577
[NullableContext(2)]
public interface IMediumItemGridCheckTickComponentParams
{
	// Token: 0x17000F65 RID: 3941
	// (get) Token: 0x0600BCF5 RID: 48373
	// (set) Token: 0x0600BCF6 RID: 48374
	bool? IsCheckTick { get; set; }

	// Token: 0x17000F66 RID: 3942
	// (get) Token: 0x0600BCF7 RID: 48375
	// (set) Token: 0x0600BCF8 RID: 48376
	string HexColor { get; set; }

	// Token: 0x17000F67 RID: 3943
	// (get) Token: 0x0600BCF9 RID: 48377
	// (set) Token: 0x0600BCFA RID: 48378
	float? Alpha { get; set; }

	// Token: 0x17000F68 RID: 3944
	// (get) Token: 0x0600BCFB RID: 48379
	// (set) Token: 0x0600BCFC RID: 48380
	string TickHexColor { get; set; }
}
