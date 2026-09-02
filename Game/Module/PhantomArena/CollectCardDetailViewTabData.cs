using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200548C RID: 21644
	[RequiredMember]
	public class CollectCardDetailViewTabData
	{
		// Token: 0x060371A8 RID: 225704 RVA: 0x00DFD902 File Offset: 0x00DFBB02
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CollectCardDetailViewTabData()
		{
		}

		// Token: 0x0401FB85 RID: 129925
		[RequiredMember]
		public ECollectCardDetailViewTab Index;

		// Token: 0x0401FB86 RID: 129926
		[Nullable(1)]
		[RequiredMember]
		public string NameId;
	}
}
