using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054EC RID: 21740
	[NullableContext(1)]
	public interface IDeckBuilderCardDetailPanelData
	{
		// Token: 0x17008EBF RID: 36543
		// (get) Token: 0x0603765F RID: 226911
		[Nullable(2)]
		DeckInfo DeckInfo { [NullableContext(2)] get; }

		// Token: 0x17008EC0 RID: 36544
		// (get) Token: 0x06037660 RID: 226912
		[Nullable(2)]
		Action AddCardToDeck { [NullableContext(2)] get; }

		// Token: 0x17008EC1 RID: 36545
		// (get) Token: 0x06037661 RID: 226913
		[Nullable(2)]
		Action RemoveCardFromDeck { [NullableContext(2)] get; }

		// Token: 0x17008EC2 RID: 36546
		// (get) Token: 0x06037662 RID: 226914
		DetailViewCardItemData CardItemData { get; }

		// Token: 0x17008EC3 RID: 36547
		// (get) Token: 0x06037663 RID: 226915
		int[] EntryIdList { get; }

		// Token: 0x17008EC4 RID: 36548
		// (get) Token: 0x06037664 RID: 226916
		CardDetailItemData DetailItemData { get; }

		// Token: 0x17008EC5 RID: 36549
		// (get) Token: 0x06037665 RID: 226917
		bool IsCardUnlocked { get; }

		// Token: 0x17008EC6 RID: 36550
		// (get) Token: 0x06037666 RID: 226918
		int? CurrencyId { get; }

		// Token: 0x17008EC7 RID: 36551
		// (get) Token: 0x06037667 RID: 226919
		int? UnlockCost { get; }

		// Token: 0x17008EC8 RID: 36552
		// (get) Token: 0x06037668 RID: 226920
		int? CardLimit { get; }
	}
}
