using System;
using System.Runtime.CompilerServices;

// Token: 0x020027B1 RID: 10161
[NullableContext(1)]
[Nullable(0)]
public class RoleBreachSuccessViewData
{
	// Token: 0x06014127 RID: 82215 RVA: 0x0059A80F File Offset: 0x00598A0F
	public RoleBreachSuccessViewData(int roleDataId, Action onMaskClick)
	{
		this.RoleDataId = roleDataId;
		this.OnMaskClick = onMaskClick;
	}

	// Token: 0x04009C56 RID: 40022
	public int RoleDataId;

	// Token: 0x04009C57 RID: 40023
	public Action OnMaskClick;
}
