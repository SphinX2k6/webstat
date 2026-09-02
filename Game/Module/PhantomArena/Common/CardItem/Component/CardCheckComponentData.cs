using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005545 RID: 21829
	[NullableContext(1)]
	[Nullable(0)]
	public class CardCheckComponentData : ICardCheckComponentData
	{
		// Token: 0x17008F3D RID: 36669
		// (get) Token: 0x06037A5E RID: 227934 RVA: 0x00E1E10F File Offset: 0x00E1C30F
		// (set) Token: 0x06037A5F RID: 227935 RVA: 0x00E1E117 File Offset: 0x00E1C317
		public int LeftCount { get; set; }

		// Token: 0x17008F3E RID: 36670
		// (get) Token: 0x06037A60 RID: 227936 RVA: 0x00E1E120 File Offset: 0x00E1C320
		// (set) Token: 0x06037A61 RID: 227937 RVA: 0x00E1E128 File Offset: 0x00E1C328
		public int MaxCount { get; set; }

		// Token: 0x17008F3F RID: 36671
		// (get) Token: 0x06037A62 RID: 227938 RVA: 0x00E1E131 File Offset: 0x00E1C331
		// (set) Token: 0x06037A63 RID: 227939 RVA: 0x00E1E139 File Offset: 0x00E1C339
		public Action OnCheckBtnClick { get; set; }
	}
}
