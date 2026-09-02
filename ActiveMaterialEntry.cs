using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002CB1 RID: 11441
[NullableContext(1)]
[Nullable(0)]
public class ActiveMaterialEntry : IActiveMaterialEntry
{
	// Token: 0x17001E38 RID: 7736
	// (get) Token: 0x06016F40 RID: 94016 RVA: 0x0065C890 File Offset: 0x0065AA90
	// (set) Token: 0x06016F41 RID: 94017 RVA: 0x0065C898 File Offset: 0x0065AA98
	public UObject Data { get; set; }

	// Token: 0x17001E39 RID: 7737
	// (get) Token: 0x06016F42 RID: 94018 RVA: 0x0065C8A1 File Offset: 0x0065AAA1
	// (set) Token: 0x06016F43 RID: 94019 RVA: 0x0065C8A9 File Offset: 0x0065AAA9
	public bool IsGroup { get; set; }

	// Token: 0x17001E3A RID: 7738
	// (get) Token: 0x06016F44 RID: 94020 RVA: 0x0065C8B2 File Offset: 0x0065AAB2
	// (set) Token: 0x06016F45 RID: 94021 RVA: 0x0065C8BA File Offset: 0x0065AABA
	public bool WithAnimObject { get; set; }
}
