using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DA1 RID: 23969
	[NullableContext(1)]
	[Nullable(0)]
	public class DreamLinkRewardGridData : IDreamLinkRewardGridData
	{
		// Token: 0x170098B4 RID: 39092
		// (get) Token: 0x0603C597 RID: 247191 RVA: 0x00F50766 File Offset: 0x00F4E966
		// (set) Token: 0x0603C598 RID: 247192 RVA: 0x00F5076E File Offset: 0x00F4E96E
		public int RewardId { get; set; }

		// Token: 0x170098B5 RID: 39093
		// (get) Token: 0x0603C599 RID: 247193 RVA: 0x00F50777 File Offset: 0x00F4E977
		// (set) Token: 0x0603C59A RID: 247194 RVA: 0x00F5077F File Offset: 0x00F4E97F
		public TItem Item { get; set; }

		// Token: 0x170098B6 RID: 39094
		// (get) Token: 0x0603C59B RID: 247195 RVA: 0x00F50788 File Offset: 0x00F4E988
		// (set) Token: 0x0603C59C RID: 247196 RVA: 0x00F50790 File Offset: 0x00F4E990
		public EActivityTaskState Status { get; set; }

		// Token: 0x170098B7 RID: 39095
		// (get) Token: 0x0603C59D RID: 247197 RVA: 0x00F50799 File Offset: 0x00F4E999
		// (set) Token: 0x0603C59E RID: 247198 RVA: 0x00F507A1 File Offset: 0x00F4E9A1
		public Action ReceiveDelegate { get; set; }
	}
}
