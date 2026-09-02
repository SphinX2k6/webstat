using System;
using System.Runtime.CompilerServices;

// Token: 0x02002860 RID: 10336
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorLockItemData
{
	// Token: 0x060147CC RID: 83916 RVA: 0x005AF781 File Offset: 0x005AD981
	public RoleFavorLockItemData(bool isLock, string desc)
	{
		this.IsLock = isLock;
		this.Desc = desc;
	}

	// Token: 0x04009E63 RID: 40547
	public bool IsLock;

	// Token: 0x04009E64 RID: 40548
	public string Desc = "";
}
