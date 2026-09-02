using System;
using System.Runtime.CompilerServices;

// Token: 0x0200006C RID: 108
[NullableContext(1)]
internal interface IRevocable<T> where T : class
{
	// Token: 0x1700004E RID: 78
	// (get) Token: 0x0600027B RID: 635
	T proxy { get; }

	// Token: 0x0600027C RID: 636
	void Revoke();
}
