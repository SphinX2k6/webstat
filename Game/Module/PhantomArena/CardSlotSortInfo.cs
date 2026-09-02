using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200547C RID: 21628
	[RequiredMember]
	public class CardSlotSortInfo
	{
		// Token: 0x0603718F RID: 225679 RVA: 0x00DFD89A File Offset: 0x00DFBA9A
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CardSlotSortInfo()
		{
		}

		// Token: 0x0401FB5D RID: 129885
		[RequiredMember]
		public int CardId;

		// Token: 0x0401FB5E RID: 129886
		[RequiredMember]
		public int Cost;

		// Token: 0x0401FB5F RID: 129887
		[RequiredMember]
		public int Element;

		// Token: 0x0401FB60 RID: 129888
		[RequiredMember]
		public ECardType CardType;
	}
}
