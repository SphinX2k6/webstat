using System;
using System.Runtime.CompilerServices;

// Token: 0x020014D3 RID: 5331
[NullableContext(2)]
[Nullable(0)]
internal class PinballBattleTipsParam : IPinballBattleTipsBaseParam
{
	// Token: 0x17000CA6 RID: 3238
	// (get) Token: 0x060094F5 RID: 38133 RVA: 0x0027059A File Offset: 0x0026E79A
	// (set) Token: 0x060094F6 RID: 38134 RVA: 0x002705A2 File Offset: 0x0026E7A2
	public Action CloseCallback { get; set; }

	// Token: 0x17000CA7 RID: 3239
	// (get) Token: 0x060094F7 RID: 38135 RVA: 0x002705AB File Offset: 0x0026E7AB
	// (set) Token: 0x060094F8 RID: 38136 RVA: 0x002705B3 File Offset: 0x0026E7B3
	public bool? AddMask { get; set; }

	// Token: 0x17000CA8 RID: 3240
	// (get) Token: 0x060094F9 RID: 38137 RVA: 0x002705BC File Offset: 0x0026E7BC
	// (set) Token: 0x060094FA RID: 38138 RVA: 0x002705C4 File Offset: 0x0026E7C4
	public int? CloseTime { get; set; }

	// Token: 0x17000CA9 RID: 3241
	// (get) Token: 0x060094FB RID: 38139 RVA: 0x002705CD File Offset: 0x0026E7CD
	// (set) Token: 0x060094FC RID: 38140 RVA: 0x002705D5 File Offset: 0x0026E7D5
	public bool? MoveToBehind { get; set; }
}
