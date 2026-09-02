using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x0200553C RID: 21820
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class DeckBuilderCardItemData : CardInfoBase
	{
		// Token: 0x06037A34 RID: 227892 RVA: 0x00E1D928 File Offset: 0x00E1BB28
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DeckBuilderCardItemData()
		{
		}

		// Token: 0x0401FE45 RID: 130629
		[RequiredMember]
		public DeckInfo DeckInfo;

		// Token: 0x0401FE46 RID: 130630
		[RequiredMember]
		public bool Disabled;

		// Token: 0x0401FE47 RID: 130631
		[RequiredMember]
		public bool IsAllInDeck;

		// Token: 0x0401FE48 RID: 130632
		[RequiredMember]
		public int LeftCount;

		// Token: 0x0401FE49 RID: 130633
		[RequiredMember]
		public int MaxCount;

		// Token: 0x0401FE4A RID: 130634
		[RequiredMember]
		public Action<int, int> AddCardToDeck;

		// Token: 0x0401FE4B RID: 130635
		[RequiredMember]
		public Action<int> OpenCardInfoView;
	}
}
