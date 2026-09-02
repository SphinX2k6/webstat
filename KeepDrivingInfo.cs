using System;
using System.Runtime.CompilerServices;

// Token: 0x02003293 RID: 12947
[NullableContext(1)]
[Nullable(0)]
public abstract class KeepDrivingInfo
{
	// Token: 0x0601B1DB RID: 111067
	public abstract bool UpdateDrivingInfo(float delta, VehicleMoveComponent moveComp);

	// Token: 0x0601B1DC RID: 111068
	public abstract override string ToString();

	// Token: 0x0400DCAC RID: 56492
	[Nullable(2)]
	public Func<bool> CheckCondition;

	// Token: 0x0400DCAD RID: 56493
	[Nullable(2)]
	public Action RunAction;
}
