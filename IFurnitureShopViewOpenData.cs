using System;
using System.Runtime.CompilerServices;

// Token: 0x02001046 RID: 4166
[NullableContext(1)]
public interface IFurnitureShopViewOpenData
{
	// Token: 0x1700087A RID: 2170
	// (get) Token: 0x06006C8E RID: 27790
	int ShopId { get; }

	// Token: 0x1700087B RID: 2171
	// (get) Token: 0x06006C8F RID: 27791
	int NpcEntityId { get; }

	// Token: 0x1700087C RID: 2172
	// (get) Token: 0x06006C90 RID: 27792
	string NpcName { get; }

	// Token: 0x1700087D RID: 2173
	// (get) Token: 0x06006C91 RID: 27793
	string NpcDesc { get; }

	// Token: 0x1700087E RID: 2174
	// (get) Token: 0x06006C92 RID: 27794
	string NpcStartMontagePath { get; }

	// Token: 0x1700087F RID: 2175
	// (get) Token: 0x06006C93 RID: 27795
	int GoodsId { get; }

	// Token: 0x17000880 RID: 2176
	// (get) Token: 0x06006C94 RID: 27796
	bool UseSpareShopNpc { get; }
}
