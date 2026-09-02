using System;
using System.Runtime.CompilerServices;

// Token: 0x02000F8D RID: 3981
public class TowerDefenseFollowerProxy
{
	// Token: 0x0600653F RID: 25919 RVA: 0x00195623 File Offset: 0x00193823
	public TowerDefenseFollowerProxy(int? proxyId = null)
	{
		this.ProxyId = proxyId;
	}

	// Token: 0x04003039 RID: 12345
	public int? ProxyId;

	// Token: 0x0400303A RID: 12346
	[Nullable(2)]
	public int[] SkillIds;

	// Token: 0x0400303B RID: 12347
	public int? PropertyId;
}
