using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005491 RID: 21649
	[RequiredMember]
	public class BadgeGroupCollectCountData
	{
		// Token: 0x060371AD RID: 225709 RVA: 0x00DFD92A File Offset: 0x00DFBB2A
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public BadgeGroupCollectCountData()
		{
		}

		// Token: 0x0401FB91 RID: 129937
		[RequiredMember]
		public int Now;

		// Token: 0x0401FB92 RID: 129938
		[RequiredMember]
		public int Need;

		// Token: 0x0401FB93 RID: 129939
		[RequiredMember]
		public int All;
	}
}
