using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.QuestNew.Controller
{
	// Token: 0x02005311 RID: 21265
	[NullableContext(2)]
	[Nullable(0)]
	public class QuestStateUpdateData
	{
		// Token: 0x17008D17 RID: 36119
		// (get) Token: 0x06036493 RID: 222355 RVA: 0x00DAF18B File Offset: 0x00DAD38B
		// (set) Token: 0x06036494 RID: 222356 RVA: 0x00DAF193 File Offset: 0x00DAD393
		public int QuestId { get; set; }

		// Token: 0x17008D18 RID: 36120
		// (get) Token: 0x06036495 RID: 222357 RVA: 0x00DAF19C File Offset: 0x00DAD39C
		// (set) Token: 0x06036496 RID: 222358 RVA: 0x00DAF1A4 File Offset: 0x00DAD3A4
		public QuestState State { get; set; }

		// Token: 0x17008D19 RID: 36121
		// (get) Token: 0x06036497 RID: 222359 RVA: 0x00DAF1AD File Offset: 0x00DAD3AD
		// (set) Token: 0x06036498 RID: 222360 RVA: 0x00DAF1B5 File Offset: 0x00DAD3B5
		public EQuestStatusUpdateReason UpdateReason { get; set; }

		// Token: 0x17008D1A RID: 36122
		// (get) Token: 0x06036499 RID: 222361 RVA: 0x00DAF1BE File Offset: 0x00DAD3BE
		// (set) Token: 0x0603649A RID: 222362 RVA: 0x00DAF1C6 File Offset: 0x00DAD3C6
		public Action OnAfterUpdate { get; set; }
	}
}
