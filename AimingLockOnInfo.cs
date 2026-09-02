using System;
using System.Runtime.CompilerServices;

// Token: 0x02003140 RID: 12608
public class AimingLockOnInfo
{
	// Token: 0x0601A195 RID: 106901 RVA: 0x007A842B File Offset: 0x007A662B
	public void Reset()
	{
		this.Target = null;
		this.SocketName = "";
	}

	// Token: 0x0400D174 RID: 53620
	[Nullable(2)]
	public EntityHandle Target;

	// Token: 0x0400D175 RID: 53621
	[Nullable(1)]
	public string SocketName = "";
}
