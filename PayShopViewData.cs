using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020023B4 RID: 9140
public class PayShopViewData : UiViewData
{
	// Token: 0x04008A20 RID: 35360
	public PayShopDefine.EPayShopTabType PayShopId = PayShopDefine.EPayShopTabType.Recommend;

	// Token: 0x04008A21 RID: 35361
	public int? SwitchId;

	// Token: 0x04008A22 RID: 35362
	public int? RecommendId;

	// Token: 0x04008A23 RID: 35363
	[Nullable(1)]
	public List<int> ShowShopIdList = new List<int>();

	// Token: 0x04008A24 RID: 35364
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<PayShopJumpParam> JumpTabResolver;
}
