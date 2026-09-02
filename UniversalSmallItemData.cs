using System;
using System.Runtime.CompilerServices;

// Token: 0x020027EF RID: 10223
[NullableContext(1)]
[Nullable(0)]
public class UniversalSmallItemData<[Nullable(0)] T> : IUniversalSmallItemData<T> where T : Enum
{
	// Token: 0x170019CE RID: 6606
	// (get) Token: 0x060142FB RID: 82683 RVA: 0x005A0BA4 File Offset: 0x0059EDA4
	// (set) Token: 0x060142FC RID: 82684 RVA: 0x005A0BAC File Offset: 0x0059EDAC
	public T Type { get; set; }
}
