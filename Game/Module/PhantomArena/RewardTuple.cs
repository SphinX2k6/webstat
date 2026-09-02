using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200548D RID: 21645
	[RequiredMember]
	public class RewardTuple
	{
		// Token: 0x060371A9 RID: 225705 RVA: 0x00DFD90A File Offset: 0x00DFBB0A
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public RewardTuple()
		{
		}

		// Token: 0x0401FB87 RID: 129927
		[RequiredMember]
		public int Id;

		// Token: 0x0401FB88 RID: 129928
		[RequiredMember]
		public int Num;

		// Token: 0x0401FB89 RID: 129929
		[RequiredMember]
		public bool Taken;
	}
}
