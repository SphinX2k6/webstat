using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005494 RID: 21652
	[RequiredMember]
	public class BattleMatchViewOpenParam
	{
		// Token: 0x060371B0 RID: 225712 RVA: 0x00DFD942 File Offset: 0x00DFBB42
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public BattleMatchViewOpenParam()
		{
		}

		// Token: 0x0401FB98 RID: 129944
		[RequiredMember]
		public int Level;

		// Token: 0x0401FB99 RID: 129945
		[RequiredMember]
		public int ActivityId;
	}
}
