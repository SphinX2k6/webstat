using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B4D RID: 6989
internal class DangoItemData
{
	// Token: 0x040060B0 RID: 24752
	public int RoleConfigId;

	// Token: 0x040060B1 RID: 24753
	public int DangoId;

	// Token: 0x040060B2 RID: 24754
	public int Level;

	// Token: 0x040060B3 RID: 24755
	public bool IfSelf = true;

	// Token: 0x040060B4 RID: 24756
	public int Index;

	// Token: 0x040060B5 RID: 24757
	[Nullable(1)]
	public int[] DangoEquipIds = new int[0];
}
