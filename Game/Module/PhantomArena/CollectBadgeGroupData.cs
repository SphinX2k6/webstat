using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200548F RID: 21647
	[RequiredMember]
	public class CollectBadgeGroupData
	{
		// Token: 0x060371AB RID: 225707 RVA: 0x00DFD91A File Offset: 0x00DFBB1A
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CollectBadgeGroupData()
		{
		}

		// Token: 0x0401FB8D RID: 129933
		[RequiredMember]
		public int GroupId;

		// Token: 0x0401FB8E RID: 129934
		[Nullable(1)]
		[RequiredMember]
		public List<int> BadgeIdList;
	}
}
