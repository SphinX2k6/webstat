using System;
using System.Runtime.CompilerServices;

// Token: 0x02002033 RID: 8243
public class ItemRewardSelectViewOpenParam
{
	// Token: 0x04007898 RID: 30872
	public int GiftPackageId;

	// Token: 0x04007899 RID: 30873
	public int ShowType;

	// Token: 0x0400789A RID: 30874
	public int AccumulateSourceId;

	// Token: 0x0400789B RID: 30875
	[Nullable(2)]
	public Action<int, int> OnSelectItemCallBack;
}
