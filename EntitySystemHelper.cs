using System;
using System.Runtime.CompilerServices;

// Token: 0x02000099 RID: 153
[Nullable(new byte[]
{
	0,
	1
})]
public class EntitySystemHelper : Singleton<EntitySystemHelper>
{
	// Token: 0x040003B3 RID: 947
	public bool IsSortDirty;

	// Token: 0x040003B4 RID: 948
	public bool IsFilterDirty;

	// Token: 0x040003B5 RID: 949
	public int SortedFrame = -1;
}
