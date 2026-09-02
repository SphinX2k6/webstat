using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052DC RID: 21212
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class QuickHackHighlightPreProcessResult : IQuickHackHighlightPreProcessResult
	{
		// Token: 0x17008D03 RID: 36099
		// (get) Token: 0x060362D7 RID: 221911 RVA: 0x00DA57D6 File Offset: 0x00DA39D6
		// (set) Token: 0x060362D8 RID: 221912 RVA: 0x00DA57DE File Offset: 0x00DA39DE
		[RequiredMember]
		public HashSet<EntityHandle> NewOnScreenTargetSet { get; set; }

		// Token: 0x17008D04 RID: 36100
		// (get) Token: 0x060362D9 RID: 221913 RVA: 0x00DA57E7 File Offset: 0x00DA39E7
		// (set) Token: 0x060362DA RID: 221914 RVA: 0x00DA57EF File Offset: 0x00DA39EF
		[RequiredMember]
		public HashSet<EntityHandle> NewLockTargetSet { get; set; }

		// Token: 0x060362DB RID: 221915 RVA: 0x00DA57F8 File Offset: 0x00DA39F8
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public QuickHackHighlightPreProcessResult()
		{
		}
	}
}
