using System;
using System.Runtime.CompilerServices;

// Token: 0x0200006D RID: 109
[NullableContext(1)]
internal interface IRevocableObject<[Nullable(2)] TK, TV> : IRevocable<TV> where TV : class
{
	// Token: 0x1700004F RID: 79
	// (get) Token: 0x0600027D RID: 637
	// (set) Token: 0x0600027E RID: 638
	TK Key { get; set; }

	// Token: 0x17000050 RID: 80
	// (get) Token: 0x0600027F RID: 639
	// (set) Token: 0x06000280 RID: 640
	TV Value { get; set; }
}
