using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E0D RID: 11789
[NullableContext(1)]
[Nullable(0)]
public class BulletRayInfo
{
	// Token: 0x0400B8E9 RID: 47337
	public double Length;

	// Token: 0x0400B8EA RID: 47338
	public Vector StartPoint = Vector.Create();

	// Token: 0x0400B8EB RID: 47339
	public Vector EndPoint = Vector.Create();

	// Token: 0x0400B8EC RID: 47340
	public bool IsBlock;

	// Token: 0x0400B8ED RID: 47341
	public bool BlockByCharacter;

	// Token: 0x0400B8EE RID: 47342
	public double Speed;
}
