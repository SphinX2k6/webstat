using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000C17 RID: 3095
[NullableContext(1)]
public interface IPlane : IVector, IVector2D
{
	// Token: 0x170000DA RID: 218
	// (get) Token: 0x06003412 RID: 13330
	// (set) Token: 0x06003413 RID: 13331
	double W { get; set; }

	// Token: 0x06003414 RID: 13332
	IPlane MultiplyEqual(double inB);

	// Token: 0x06003415 RID: 13333
	IPlane MultiplyEqual(IPlane inB);

	// Token: 0x06003416 RID: 13334
	IPlane MultiplyEqual(Vector inB, Vector outV);

	// Token: 0x06003417 RID: 13335
	Vector Multiply(Vector inB, Vector outV);

	// Token: 0x06003418 RID: 13336
	Vector Multiply(double inB, Vector outV);

	// Token: 0x170000DB RID: 219
	// (get) Token: 0x06003419 RID: 13337
	// (set) Token: 0x0600341A RID: 13338
	double[] Tuple { get; set; }
}
