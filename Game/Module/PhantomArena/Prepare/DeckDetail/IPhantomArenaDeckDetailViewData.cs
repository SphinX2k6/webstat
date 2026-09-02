using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckDetail
{
	// Token: 0x020054E3 RID: 21731
	[NullableContext(1)]
	public interface IPhantomArenaDeckDetailViewData
	{
		// Token: 0x17008E9F RID: 36511
		// (get) Token: 0x060375F1 RID: 226801
		// (set) Token: 0x060375F2 RID: 226802
		DeckInfo DeckInfo { get; set; }

		// Token: 0x17008EA0 RID: 36512
		// (get) Token: 0x060375F3 RID: 226803
		// (set) Token: 0x060375F4 RID: 226804
		bool ShowLocked { get; set; }

		// Token: 0x17008EA1 RID: 36513
		// (get) Token: 0x060375F5 RID: 226805
		// (set) Token: 0x060375F6 RID: 226806
		int ActivityId { get; set; }

		// Token: 0x17008EA2 RID: 36514
		// (get) Token: 0x060375F7 RID: 226807
		// (set) Token: 0x060375F8 RID: 226808
		int? CurrencyId { get; set; }

		// Token: 0x17008EA3 RID: 36515
		// (get) Token: 0x060375F9 RID: 226809
		// (set) Token: 0x060375FA RID: 226810
		int? CurCardId { get; set; }

		// Token: 0x17008EA4 RID: 36516
		// (get) Token: 0x060375FB RID: 226811
		// (set) Token: 0x060375FC RID: 226812
		DetailViewCardItemData CardItemData { get; set; }

		// Token: 0x17008EA5 RID: 36517
		// (get) Token: 0x060375FD RID: 226813
		// (set) Token: 0x060375FE RID: 226814
		CardDetailItemData DetailItemData { get; set; }

		// Token: 0x17008EA6 RID: 36518
		// (get) Token: 0x060375FF RID: 226815
		// (set) Token: 0x06037600 RID: 226816
		List<int> EntryList { get; set; }

		// Token: 0x17008EA7 RID: 36519
		// (get) Token: 0x06037601 RID: 226817
		// (set) Token: 0x06037602 RID: 226818
		bool? IsUnlock { get; set; }

		// Token: 0x17008EA8 RID: 36520
		// (get) Token: 0x06037603 RID: 226819
		// (set) Token: 0x06037604 RID: 226820
		bool? IsRecommend { get; set; }

		// Token: 0x17008EA9 RID: 36521
		// (get) Token: 0x06037605 RID: 226821
		// (set) Token: 0x06037606 RID: 226822
		Action<DeckInfo> SaveRecommendDeckCallback { get; set; }
	}
}
