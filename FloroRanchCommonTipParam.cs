using System;
using System.Runtime.CompilerServices;

// Token: 0x02001C4F RID: 7247
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchCommonTipParam : IFloroRanchCommonTipParam
{
	// Token: 0x17001118 RID: 4376
	// (get) Token: 0x0600D36F RID: 54127 RVA: 0x003856E2 File Offset: 0x003838E2
	// (set) Token: 0x0600D370 RID: 54128 RVA: 0x003856EA File Offset: 0x003838EA
	public EFloroRanchCommonTipType TipType { get; set; }

	// Token: 0x17001119 RID: 4377
	// (get) Token: 0x0600D371 RID: 54129 RVA: 0x003856F3 File Offset: 0x003838F3
	// (set) Token: 0x0600D372 RID: 54130 RVA: 0x003856FB File Offset: 0x003838FB
	public FloroRanchEntityBase EntityData { get; set; }

	// Token: 0x1700111A RID: 4378
	// (get) Token: 0x0600D373 RID: 54131 RVA: 0x00385704 File Offset: 0x00383904
	// (set) Token: 0x0600D374 RID: 54132 RVA: 0x0038570C File Offset: 0x0038390C
	public Action<FloroRanchEntityBase> RemoveCallback { get; set; }

	// Token: 0x1700111B RID: 4379
	// (get) Token: 0x0600D375 RID: 54133 RVA: 0x00385715 File Offset: 0x00383915
	// (set) Token: 0x0600D376 RID: 54134 RVA: 0x0038571D File Offset: 0x0038391D
	public FloroRanchCurrencyData CurrencyData { get; set; }

	// Token: 0x1700111C RID: 4380
	// (get) Token: 0x0600D377 RID: 54135 RVA: 0x00385726 File Offset: 0x00383926
	// (set) Token: 0x0600D378 RID: 54136 RVA: 0x0038572E File Offset: 0x0038392E
	public FloroRanchToyData ToyData { get; set; }

	// Token: 0x1700111D RID: 4381
	// (get) Token: 0x0600D379 RID: 54137 RVA: 0x00385737 File Offset: 0x00383937
	// (set) Token: 0x0600D37A RID: 54138 RVA: 0x0038573F File Offset: 0x0038393F
	public FloroRanchCardData CardData { get; set; }
}
