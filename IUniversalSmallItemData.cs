using System;
using System.Runtime.CompilerServices;

// Token: 0x020027EE RID: 10222
[NullableContext(1)]
public interface IUniversalSmallItemData<[Nullable(0)] T> where T : Enum
{
	// Token: 0x170019CD RID: 6605
	// (get) Token: 0x060142F9 RID: 82681
	// (set) Token: 0x060142FA RID: 82682
	T Type { get; set; }
}
