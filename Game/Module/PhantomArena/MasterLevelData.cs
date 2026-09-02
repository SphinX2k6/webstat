using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005496 RID: 21654
	[RequiredMember]
	public class MasterLevelData
	{
		// Token: 0x060371B2 RID: 225714 RVA: 0x00DFD952 File Offset: 0x00DFBB52
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MasterLevelData()
		{
		}

		// Token: 0x0401FB9D RID: 129949
		[RequiredMember]
		public int Level;

		// Token: 0x0401FB9E RID: 129950
		[RequiredMember]
		public int ExpLevel;

		// Token: 0x0401FB9F RID: 129951
		[RequiredMember]
		public int ExpNext;

		// Token: 0x0401FBA0 RID: 129952
		[RequiredMember]
		public bool IsMax;
	}
}
