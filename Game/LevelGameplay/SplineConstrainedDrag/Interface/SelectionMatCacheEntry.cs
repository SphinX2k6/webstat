using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface
{
	// Token: 0x02006AE8 RID: 27368
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class SelectionMatCacheEntry : ISelectionMatCacheEntry
	{
		// Token: 0x1700A2F3 RID: 41715
		// (get) Token: 0x06043AC6 RID: 277190 RVA: 0x01173BD5 File Offset: 0x01171DD5
		// (set) Token: 0x06043AC7 RID: 277191 RVA: 0x01173BDD File Offset: 0x01171DDD
		[Nullable(2)]
		public ItemMaterialControllerActorData Asset { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700A2F4 RID: 41716
		// (get) Token: 0x06043AC8 RID: 277192 RVA: 0x01173BE6 File Offset: 0x01171DE6
		// (set) Token: 0x06043AC9 RID: 277193 RVA: 0x01173BEE File Offset: 0x01171DEE
		[RequiredMember]
		public HashSet<int> RefHolders { get; set; }

		// Token: 0x06043ACA RID: 277194 RVA: 0x01173BF7 File Offset: 0x01171DF7
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public SelectionMatCacheEntry()
		{
		}
	}
}
