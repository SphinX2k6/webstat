using System;
using System.Runtime.CompilerServices;

// Token: 0x02000C01 RID: 3073
[NullableContext(1)]
[Nullable(0)]
public abstract class ICurvePoint<[Nullable(2)] T> where T : new()
{
	// Token: 0x0400058D RID: 1421
	public float InVal;

	// Token: 0x0400058E RID: 1422
	public T OutVal = Activator.CreateInstance<T>();

	// Token: 0x0400058F RID: 1423
	public T ArriveTangent = Activator.CreateInstance<T>();

	// Token: 0x04000590 RID: 1424
	public T LeaveTangent = Activator.CreateInstance<T>();
}
