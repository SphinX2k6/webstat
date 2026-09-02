using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005481 RID: 21633
	[RequiredMember]
	public class CardFilterContext
	{
		// Token: 0x0603719D RID: 225693 RVA: 0x00DFD8AA File Offset: 0x00DFBAAA
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CardFilterContext()
		{
		}

		// Token: 0x0401FB63 RID: 129891
		[RequiredMember]
		public ECardCostFilter CostFilter;

		// Token: 0x0401FB64 RID: 129892
		[RequiredMember]
		public ECardTabType ElementFilter;

		// Token: 0x0401FB65 RID: 129893
		[RequiredMember]
		public bool IncludeLocked;
	}
}
