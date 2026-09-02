using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200549F RID: 21663
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class DeckBuilderCardInfoViewData
	{
		// Token: 0x060371BB RID: 225723 RVA: 0x00DFD9AC File Offset: 0x00DFBBAC
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DeckBuilderCardInfoViewData()
		{
		}

		// Token: 0x0401FBC3 RID: 129987
		[RequiredMember]
		public int CurCardId;

		// Token: 0x0401FBC4 RID: 129988
		[RequiredMember]
		public bool NeedOutlookTab;

		// Token: 0x0401FBC5 RID: 129989
		public int? CurCardIndex;

		// Token: 0x0401FBC6 RID: 129990
		public int? CurrencyId;

		// Token: 0x0401FBC7 RID: 129991
		public int? SelectedTabIndex;

		// Token: 0x0401FBC8 RID: 129992
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public DeckBuilderCardItemData[] CardList;

		// Token: 0x0401FBC9 RID: 129993
		public DeckInfo DeckInfo;

		// Token: 0x0401FBCA RID: 129994
		public Action<int, int> AddCardToDeck;

		// Token: 0x0401FBCB RID: 129995
		public Action<int, int> RemoveCardFromDeck;
	}
}
