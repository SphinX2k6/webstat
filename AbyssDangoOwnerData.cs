using System;
using System.Runtime.CompilerServices;

// Token: 0x02001AC4 RID: 6852
public class AbyssDangoOwnerData
{
	// Token: 0x04005E6E RID: 24174
	public int PlayerId;

	// Token: 0x04005E6F RID: 24175
	public int RoleCfgId;

	// Token: 0x04005E70 RID: 24176
	public int DangoId;

	// Token: 0x04005E71 RID: 24177
	public int DangoLevel;

	// Token: 0x04005E72 RID: 24178
	[Nullable(1)]
	public int[] DangoEquipIds = Array.Empty<int>();
}
