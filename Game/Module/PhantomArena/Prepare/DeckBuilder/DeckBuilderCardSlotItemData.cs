using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054F9 RID: 21753
	[NullableContext(1)]
	[Nullable(0)]
	public class DeckBuilderCardSlotItemData : IDeckBuilderCardSlotItemData
	{
		// Token: 0x17008EDA RID: 36570
		// (get) Token: 0x060376CD RID: 227021 RVA: 0x00E0F953 File Offset: 0x00E0DB53
		// (set) Token: 0x060376CE RID: 227022 RVA: 0x00E0F95B File Offset: 0x00E0DB5B
		public DeckCardSlotInfo SlotInfo { get; set; }

		// Token: 0x17008EDB RID: 36571
		// (get) Token: 0x060376CF RID: 227023 RVA: 0x00E0F964 File Offset: 0x00E0DB64
		// (set) Token: 0x060376D0 RID: 227024 RVA: 0x00E0F96C File Offset: 0x00E0DB6C
		public bool Locked { get; set; }

		// Token: 0x17008EDC RID: 36572
		// (get) Token: 0x060376D1 RID: 227025 RVA: 0x00E0F975 File Offset: 0x00E0DB75
		// (set) Token: 0x060376D2 RID: 227026 RVA: 0x00E0F97D File Offset: 0x00E0DB7D
		public bool RedDotState { get; set; }

		// Token: 0x17008EDD RID: 36573
		// (get) Token: 0x060376D3 RID: 227027 RVA: 0x00E0F986 File Offset: 0x00E0DB86
		// (set) Token: 0x060376D4 RID: 227028 RVA: 0x00E0F98E File Offset: 0x00E0DB8E
		public bool OutlookUnlocked { get; set; }

		// Token: 0x17008EDE RID: 36574
		// (get) Token: 0x060376D5 RID: 227029 RVA: 0x00E0F997 File Offset: 0x00E0DB97
		// (set) Token: 0x060376D6 RID: 227030 RVA: 0x00E0F99F File Offset: 0x00E0DB9F
		public bool NeedPlayAddAnim { get; set; }
	}
}
