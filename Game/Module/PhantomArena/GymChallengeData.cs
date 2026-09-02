using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200548A RID: 21642
	[RequiredMember]
	public class GymChallengeData
	{
		// Token: 0x060371A6 RID: 225702 RVA: 0x00DFD8F2 File Offset: 0x00DFBAF2
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public GymChallengeData()
		{
		}

		// Token: 0x0401FB82 RID: 129922
		[RequiredMember]
		public int Id;

		// Token: 0x0401FB83 RID: 129923
		[RequiredMember]
		public EChallengeState State;

		// Token: 0x0401FB84 RID: 129924
		[RequiredMember]
		public bool IsLast;
	}
}
