using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckDetail
{
	// Token: 0x020054E4 RID: 21732
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaDeckDetailViewData : IPhantomArenaDeckDetailViewData
	{
		// Token: 0x17008EAA RID: 36522
		// (get) Token: 0x06037607 RID: 226823 RVA: 0x00E0D786 File Offset: 0x00E0B986
		// (set) Token: 0x06037608 RID: 226824 RVA: 0x00E0D78E File Offset: 0x00E0B98E
		public DeckInfo DeckInfo { get; set; }

		// Token: 0x17008EAB RID: 36523
		// (get) Token: 0x06037609 RID: 226825 RVA: 0x00E0D797 File Offset: 0x00E0B997
		// (set) Token: 0x0603760A RID: 226826 RVA: 0x00E0D79F File Offset: 0x00E0B99F
		public bool ShowLocked { get; set; }

		// Token: 0x17008EAC RID: 36524
		// (get) Token: 0x0603760B RID: 226827 RVA: 0x00E0D7A8 File Offset: 0x00E0B9A8
		// (set) Token: 0x0603760C RID: 226828 RVA: 0x00E0D7B0 File Offset: 0x00E0B9B0
		public int ActivityId { get; set; }

		// Token: 0x17008EAD RID: 36525
		// (get) Token: 0x0603760D RID: 226829 RVA: 0x00E0D7B9 File Offset: 0x00E0B9B9
		// (set) Token: 0x0603760E RID: 226830 RVA: 0x00E0D7C1 File Offset: 0x00E0B9C1
		public int? CurrencyId { get; set; }

		// Token: 0x17008EAE RID: 36526
		// (get) Token: 0x0603760F RID: 226831 RVA: 0x00E0D7CA File Offset: 0x00E0B9CA
		// (set) Token: 0x06037610 RID: 226832 RVA: 0x00E0D7D2 File Offset: 0x00E0B9D2
		public int? CurCardId { get; set; }

		// Token: 0x17008EAF RID: 36527
		// (get) Token: 0x06037611 RID: 226833 RVA: 0x00E0D7DB File Offset: 0x00E0B9DB
		// (set) Token: 0x06037612 RID: 226834 RVA: 0x00E0D7E3 File Offset: 0x00E0B9E3
		public DetailViewCardItemData CardItemData { get; set; }

		// Token: 0x17008EB0 RID: 36528
		// (get) Token: 0x06037613 RID: 226835 RVA: 0x00E0D7EC File Offset: 0x00E0B9EC
		// (set) Token: 0x06037614 RID: 226836 RVA: 0x00E0D7F4 File Offset: 0x00E0B9F4
		public CardDetailItemData DetailItemData { get; set; }

		// Token: 0x17008EB1 RID: 36529
		// (get) Token: 0x06037615 RID: 226837 RVA: 0x00E0D7FD File Offset: 0x00E0B9FD
		// (set) Token: 0x06037616 RID: 226838 RVA: 0x00E0D805 File Offset: 0x00E0BA05
		public List<int> EntryList { get; set; }

		// Token: 0x17008EB2 RID: 36530
		// (get) Token: 0x06037617 RID: 226839 RVA: 0x00E0D80E File Offset: 0x00E0BA0E
		// (set) Token: 0x06037618 RID: 226840 RVA: 0x00E0D816 File Offset: 0x00E0BA16
		public bool? IsUnlock { get; set; }

		// Token: 0x17008EB3 RID: 36531
		// (get) Token: 0x06037619 RID: 226841 RVA: 0x00E0D81F File Offset: 0x00E0BA1F
		// (set) Token: 0x0603761A RID: 226842 RVA: 0x00E0D827 File Offset: 0x00E0BA27
		public bool? IsRecommend { get; set; }

		// Token: 0x17008EB4 RID: 36532
		// (get) Token: 0x0603761B RID: 226843 RVA: 0x00E0D830 File Offset: 0x00E0BA30
		// (set) Token: 0x0603761C RID: 226844 RVA: 0x00E0D838 File Offset: 0x00E0BA38
		public Action<DeckInfo> SaveRecommendDeckCallback { get; set; }
	}
}
