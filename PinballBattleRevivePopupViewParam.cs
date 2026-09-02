using System;
using System.Runtime.CompilerServices;

// Token: 0x020014D2 RID: 5330
[NullableContext(2)]
[Nullable(0)]
public class PinballBattleRevivePopupViewParam : IPinballBattleRevivePopupViewParam
{
	// Token: 0x17000CA4 RID: 3236
	// (get) Token: 0x060094F0 RID: 38128 RVA: 0x00270570 File Offset: 0x0026E770
	// (set) Token: 0x060094F1 RID: 38129 RVA: 0x00270578 File Offset: 0x0026E778
	public Action ConfirmCallback { get; set; }

	// Token: 0x17000CA5 RID: 3237
	// (get) Token: 0x060094F2 RID: 38130 RVA: 0x00270581 File Offset: 0x0026E781
	// (set) Token: 0x060094F3 RID: 38131 RVA: 0x00270589 File Offset: 0x0026E789
	public Action CancelCallback { get; set; }
}
