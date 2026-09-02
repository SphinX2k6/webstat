using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005497 RID: 21655
	[RequiredMember]
	public class MasterLevelDescData
	{
		// Token: 0x060371B3 RID: 225715 RVA: 0x00DFD95A File Offset: 0x00DFBB5A
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MasterLevelDescData()
		{
		}

		// Token: 0x0401FBA1 RID: 129953
		[RequiredMember]
		public int Level;

		// Token: 0x0401FBA2 RID: 129954
		[Nullable(1)]
		[RequiredMember]
		public string StringId;

		// Token: 0x0401FBA3 RID: 129955
		[RequiredMember]
		public bool IsDone;
	}
}
