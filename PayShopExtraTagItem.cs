using System;
using System.Runtime.CompilerServices;

// Token: 0x020023D7 RID: 9175
public abstract class PayShopExtraTagItem : PayShopTagItem
{
	// Token: 0x06011BE8 RID: 72680
	[NullableContext(1)]
	public abstract void Refresh(IPayShopUnionData data);
}
