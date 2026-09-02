using System;
using System.Runtime.CompilerServices;

// Token: 0x02001ACB RID: 6859
public class AbyssDangoItemData
{
	// Token: 0x04005EA5 RID: 24229
	public int DangoId;

	// Token: 0x04005EA6 RID: 24230
	public int PlayerId;

	// Token: 0x04005EA7 RID: 24231
	public int RoleId;

	// Token: 0x04005EA8 RID: 24232
	public bool SelectState;

	// Token: 0x04005EA9 RID: 24233
	[Nullable(1)]
	public Action<AbyssDangoItemData> OnSelectCallBack = delegate(AbyssDangoItemData _)
	{
	};
}
