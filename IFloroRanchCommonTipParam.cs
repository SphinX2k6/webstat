using System;
using System.Runtime.CompilerServices;

// Token: 0x02001C4E RID: 7246
[NullableContext(1)]
public interface IFloroRanchCommonTipParam
{
	// Token: 0x17001112 RID: 4370
	// (get) Token: 0x0600D363 RID: 54115
	// (set) Token: 0x0600D364 RID: 54116
	EFloroRanchCommonTipType TipType { get; set; }

	// Token: 0x17001113 RID: 4371
	// (get) Token: 0x0600D365 RID: 54117
	// (set) Token: 0x0600D366 RID: 54118
	FloroRanchEntityBase EntityData { get; set; }

	// Token: 0x17001114 RID: 4372
	// (get) Token: 0x0600D367 RID: 54119
	// (set) Token: 0x0600D368 RID: 54120
	Action<FloroRanchEntityBase> RemoveCallback { get; set; }

	// Token: 0x17001115 RID: 4373
	// (get) Token: 0x0600D369 RID: 54121
	// (set) Token: 0x0600D36A RID: 54122
	FloroRanchCurrencyData CurrencyData { get; set; }

	// Token: 0x17001116 RID: 4374
	// (get) Token: 0x0600D36B RID: 54123
	// (set) Token: 0x0600D36C RID: 54124
	FloroRanchToyData ToyData { get; set; }

	// Token: 0x17001117 RID: 4375
	// (get) Token: 0x0600D36D RID: 54125
	// (set) Token: 0x0600D36E RID: 54126
	FloroRanchCardData CardData { get; set; }
}
