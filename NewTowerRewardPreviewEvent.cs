using System;
using System.Runtime.CompilerServices;

// Token: 0x02002173 RID: 8563
[NullableContext(1)]
[Nullable(0)]
public class NewTowerRewardPreviewEvent : PlayerCommonLogData
{
	// Token: 0x170013CB RID: 5067
	// (get) Token: 0x06010456 RID: 66646 RVA: 0x00476180 File Offset: 0x00474380
	// (set) Token: 0x06010457 RID: 66647 RVA: 0x00476188 File Offset: 0x00474388
	public override string event_id { get; set; } = "1073";

	// Token: 0x04007EE2 RID: 32482
	public int i_goods_id;

	// Token: 0x04007EE3 RID: 32483
	public int i_item_id;

	// Token: 0x04007EE4 RID: 32484
	public int i_skin_id;
}
