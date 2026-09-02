using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005498 RID: 21656
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class PhantomArenaTaskData
	{
		// Token: 0x060371B4 RID: 225716 RVA: 0x00DFD962 File Offset: 0x00DFBB62
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public PhantomArenaTaskData()
		{
		}

		// Token: 0x0401FBA4 RID: 129956
		[RequiredMember]
		public ActivityTask TaskConfig;

		// Token: 0x0401FBA5 RID: 129957
		[RequiredMember]
		public List<TItem> Reward;
	}
}
