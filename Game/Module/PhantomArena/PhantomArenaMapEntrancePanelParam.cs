using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200549C RID: 21660
	[RequiredMember]
	public class PhantomArenaMapEntrancePanelParam
	{
		// Token: 0x060371B8 RID: 225720 RVA: 0x00DFD994 File Offset: 0x00DFBB94
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public PhantomArenaMapEntrancePanelParam()
		{
		}

		// Token: 0x0401FBB4 RID: 129972
		[RequiredMember]
		public int ChallengeId;

		// Token: 0x0401FBB5 RID: 129973
		public bool? IsNeedSelect;
	}
}
