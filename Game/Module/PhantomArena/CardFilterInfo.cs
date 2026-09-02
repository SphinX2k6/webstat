using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005482 RID: 21634
	[RequiredMember]
	public class CardFilterInfo
	{
		// Token: 0x0603719E RID: 225694 RVA: 0x00DFD8B2 File Offset: 0x00DFBAB2
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CardFilterInfo()
		{
		}

		// Token: 0x0401FB66 RID: 129894
		[RequiredMember]
		public int CardId;

		// Token: 0x0401FB67 RID: 129895
		[RequiredMember]
		public int Cost;

		// Token: 0x0401FB68 RID: 129896
		[RequiredMember]
		public int Element;

		// Token: 0x0401FB69 RID: 129897
		public bool IsLocked;
	}
}
