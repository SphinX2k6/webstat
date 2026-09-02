using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.MingSu
{
	// Token: 0x02005735 RID: 22325
	[NullableContext(2)]
	[Nullable(0)]
	public class RewardItemData : IRewardItemData
	{
		// Token: 0x1700912B RID: 37163
		// (get) Token: 0x06038D09 RID: 232713 RVA: 0x00E645C3 File Offset: 0x00E627C3
		// (set) Token: 0x06038D0A RID: 232714 RVA: 0x00E645CB File Offset: 0x00E627CB
		public ItemConfig ItemInfo { get; set; }

		// Token: 0x1700912C RID: 37164
		// (get) Token: 0x06038D0B RID: 232715 RVA: 0x00E645D4 File Offset: 0x00E627D4
		// (set) Token: 0x06038D0C RID: 232716 RVA: 0x00E645DC File Offset: 0x00E627DC
		public int Count { get; set; }
	}
}
