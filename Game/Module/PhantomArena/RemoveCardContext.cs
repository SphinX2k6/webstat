using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005488 RID: 21640
	[RequiredMember]
	public class RemoveCardContext
	{
		// Token: 0x060371A4 RID: 225700 RVA: 0x00DFD8E2 File Offset: 0x00DFBAE2
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public RemoveCardContext()
		{
		}

		// Token: 0x0401FB7F RID: 129919
		[RequiredMember]
		public int CardId;

		// Token: 0x0401FB80 RID: 129920
		[RequiredMember]
		public int RemoveCount;
	}
}
