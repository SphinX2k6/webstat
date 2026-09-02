using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200547D RID: 21629
	[RequiredMember]
	public class CardSlotSortContext
	{
		// Token: 0x06037190 RID: 225680 RVA: 0x00DFD8A2 File Offset: 0x00DFBAA2
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CardSlotSortContext()
		{
		}

		// Token: 0x0401FB61 RID: 129889
		[RequiredMember]
		public ECardSlotSortType SortType;

		// Token: 0x0401FB62 RID: 129890
		[RequiredMember]
		public bool IsAscending;
	}
}
