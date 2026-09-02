using System;
using System.Runtime.CompilerServices;

// Token: 0x0200322B RID: 12843
[NullableContext(2)]
public interface IUeMovementComp
{
	// Token: 0x1700243C RID: 9276
	// (get) Token: 0x0601AB74 RID: 109428
	// (set) Token: 0x0601AB75 RID: 109429
	UeSkeletalTickManageComponent SkelTickMgr { get; set; }

	// Token: 0x0601AB76 RID: 109430
	bool CanTickDefault();

	// Token: 0x0601AB77 RID: 109431
	bool CanTickWithDistance();

	// Token: 0x0601AB78 RID: 109432
	void PreProxyTick(float delta);

	// Token: 0x0601AB79 RID: 109433
	void ProxyTick();
}
