using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005487 RID: 21639
	[RequiredMember]
	public class AddCardContext
	{
		// Token: 0x060371A3 RID: 225699 RVA: 0x00DFD8DA File Offset: 0x00DFBADA
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public AddCardContext()
		{
		}

		// Token: 0x0401FB79 RID: 129913
		[RequiredMember]
		public int CardId;

		// Token: 0x0401FB7A RID: 129914
		[RequiredMember]
		public int Cost;

		// Token: 0x0401FB7B RID: 129915
		[RequiredMember]
		public int Element;

		// Token: 0x0401FB7C RID: 129916
		[RequiredMember]
		public int MaxCount;

		// Token: 0x0401FB7D RID: 129917
		[RequiredMember]
		public int AddCount;

		// Token: 0x0401FB7E RID: 129918
		[RequiredMember]
		public ECardType CardType;
	}
}
