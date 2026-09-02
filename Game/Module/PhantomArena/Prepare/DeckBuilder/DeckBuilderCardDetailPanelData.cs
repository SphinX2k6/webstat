using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054F4 RID: 21748
	[NullableContext(1)]
	[Nullable(0)]
	public class DeckBuilderCardDetailPanelData : IDeckBuilderCardDetailPanelData
	{
		// Token: 0x17008EC9 RID: 36553
		// (get) Token: 0x060376A2 RID: 226978 RVA: 0x00E0F5F2 File Offset: 0x00E0D7F2
		// (set) Token: 0x060376A3 RID: 226979 RVA: 0x00E0F5FA File Offset: 0x00E0D7FA
		[Nullable(2)]
		public DeckInfo DeckInfo { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008ECA RID: 36554
		// (get) Token: 0x060376A4 RID: 226980 RVA: 0x00E0F603 File Offset: 0x00E0D803
		// (set) Token: 0x060376A5 RID: 226981 RVA: 0x00E0F60B File Offset: 0x00E0D80B
		[Nullable(2)]
		public Action AddCardToDeck { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008ECB RID: 36555
		// (get) Token: 0x060376A6 RID: 226982 RVA: 0x00E0F614 File Offset: 0x00E0D814
		// (set) Token: 0x060376A7 RID: 226983 RVA: 0x00E0F61C File Offset: 0x00E0D81C
		[Nullable(2)]
		public Action RemoveCardFromDeck { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008ECC RID: 36556
		// (get) Token: 0x060376A8 RID: 226984 RVA: 0x00E0F625 File Offset: 0x00E0D825
		// (set) Token: 0x060376A9 RID: 226985 RVA: 0x00E0F62D File Offset: 0x00E0D82D
		public DetailViewCardItemData CardItemData { get; set; }

		// Token: 0x17008ECD RID: 36557
		// (get) Token: 0x060376AA RID: 226986 RVA: 0x00E0F636 File Offset: 0x00E0D836
		// (set) Token: 0x060376AB RID: 226987 RVA: 0x00E0F63E File Offset: 0x00E0D83E
		public int[] EntryIdList { get; set; }

		// Token: 0x17008ECE RID: 36558
		// (get) Token: 0x060376AC RID: 226988 RVA: 0x00E0F647 File Offset: 0x00E0D847
		// (set) Token: 0x060376AD RID: 226989 RVA: 0x00E0F64F File Offset: 0x00E0D84F
		public CardDetailItemData DetailItemData { get; set; }

		// Token: 0x17008ECF RID: 36559
		// (get) Token: 0x060376AE RID: 226990 RVA: 0x00E0F658 File Offset: 0x00E0D858
		// (set) Token: 0x060376AF RID: 226991 RVA: 0x00E0F660 File Offset: 0x00E0D860
		public bool IsCardUnlocked { get; set; }

		// Token: 0x17008ED0 RID: 36560
		// (get) Token: 0x060376B0 RID: 226992 RVA: 0x00E0F669 File Offset: 0x00E0D869
		// (set) Token: 0x060376B1 RID: 226993 RVA: 0x00E0F671 File Offset: 0x00E0D871
		public int? CurrencyId { get; set; }

		// Token: 0x17008ED1 RID: 36561
		// (get) Token: 0x060376B2 RID: 226994 RVA: 0x00E0F67A File Offset: 0x00E0D87A
		// (set) Token: 0x060376B3 RID: 226995 RVA: 0x00E0F682 File Offset: 0x00E0D882
		public int? UnlockCost { get; set; }

		// Token: 0x17008ED2 RID: 36562
		// (get) Token: 0x060376B4 RID: 226996 RVA: 0x00E0F68B File Offset: 0x00E0D88B
		// (set) Token: 0x060376B5 RID: 226997 RVA: 0x00E0F693 File Offset: 0x00E0D893
		public int? CardLimit { get; set; }
	}
}
