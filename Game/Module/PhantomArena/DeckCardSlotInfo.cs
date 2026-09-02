using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005486 RID: 21638
	[RequiredMember]
	public class DeckCardSlotInfo : CardSlotSortInfo
	{
		// Token: 0x060371A2 RID: 225698 RVA: 0x00DFD8D2 File Offset: 0x00DFBAD2
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DeckCardSlotInfo()
		{
		}

		// Token: 0x0401FB78 RID: 129912
		[RequiredMember]
		public int Count;
	}
}
