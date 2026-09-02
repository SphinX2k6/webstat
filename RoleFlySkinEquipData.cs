using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002A50 RID: 10832
[NullableContext(1)]
[Nullable(0)]
public class RoleFlySkinEquipData
{
	// Token: 0x0400A68C RID: 42636
	public int RoleDataId;

	// Token: 0x0400A68D RID: 42637
	public Dictionary<EFlySkinType, int> SkinEquipMap = new Dictionary<EFlySkinType, int>();

	// Token: 0x0400A68E RID: 42638
	public HashSet<int> SkinEquipSet = new HashSet<int>();
}
