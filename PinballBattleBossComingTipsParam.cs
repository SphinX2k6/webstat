using System;
using System.Runtime.CompilerServices;

// Token: 0x020014D4 RID: 5332
[NullableContext(2)]
[Nullable(0)]
internal class PinballBattleBossComingTipsParam : IPinballBattleBossComingTipsParam, IPinballBattleTipsBaseParam
{
	// Token: 0x17000CAA RID: 3242
	// (get) Token: 0x060094FE RID: 38142 RVA: 0x002705E6 File Offset: 0x0026E7E6
	// (set) Token: 0x060094FF RID: 38143 RVA: 0x002705EE File Offset: 0x0026E7EE
	public int BossTypeId { get; set; }

	// Token: 0x17000CAB RID: 3243
	// (get) Token: 0x06009500 RID: 38144 RVA: 0x002705F7 File Offset: 0x0026E7F7
	// (set) Token: 0x06009501 RID: 38145 RVA: 0x002705FF File Offset: 0x0026E7FF
	public Action CloseCallback { get; set; }

	// Token: 0x17000CAC RID: 3244
	// (get) Token: 0x06009502 RID: 38146 RVA: 0x00270608 File Offset: 0x0026E808
	// (set) Token: 0x06009503 RID: 38147 RVA: 0x00270610 File Offset: 0x0026E810
	public bool? AddMask { get; set; }

	// Token: 0x17000CAD RID: 3245
	// (get) Token: 0x06009504 RID: 38148 RVA: 0x00270619 File Offset: 0x0026E819
	// (set) Token: 0x06009505 RID: 38149 RVA: 0x00270621 File Offset: 0x0026E821
	public int? CloseTime { get; set; }

	// Token: 0x17000CAE RID: 3246
	// (get) Token: 0x06009506 RID: 38150 RVA: 0x0027062A File Offset: 0x0026E82A
	// (set) Token: 0x06009507 RID: 38151 RVA: 0x00270632 File Offset: 0x0026E832
	public bool? MoveToBehind { get; set; }
}
