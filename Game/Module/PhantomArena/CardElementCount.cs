using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005485 RID: 21637
	[RequiredMember]
	public class CardElementCount
	{
		// Token: 0x060371A1 RID: 225697 RVA: 0x00DFD8CA File Offset: 0x00DFBACA
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CardElementCount()
		{
		}

		// Token: 0x0401FB75 RID: 129909
		[RequiredMember]
		public int ElementId;

		// Token: 0x0401FB76 RID: 129910
		[RequiredMember]
		public int Count;

		// Token: 0x0401FB77 RID: 129911
		[RequiredMember]
		public int All;
	}
}
