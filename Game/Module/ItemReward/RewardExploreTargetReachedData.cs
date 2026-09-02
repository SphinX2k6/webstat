using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B1D RID: 23325
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreTargetReachedData : IRewardExploreTargetReached
	{
		// Token: 0x170096C8 RID: 38600
		// (get) Token: 0x0603B053 RID: 241747 RVA: 0x00EF26E0 File Offset: 0x00EF08E0
		// (set) Token: 0x0603B054 RID: 241748 RVA: 0x00EF26E8 File Offset: 0x00EF08E8
		public List<string> Target { get; set; }

		// Token: 0x170096C9 RID: 38601
		// (get) Token: 0x0603B055 RID: 241749 RVA: 0x00EF26F1 File Offset: 0x00EF08F1
		// (set) Token: 0x0603B056 RID: 241750 RVA: 0x00EF26F9 File Offset: 0x00EF08F9
		public string DescriptionTextId { get; set; }

		// Token: 0x170096CA RID: 38602
		// (get) Token: 0x0603B057 RID: 241751 RVA: 0x00EF2702 File Offset: 0x00EF0902
		// (set) Token: 0x0603B058 RID: 241752 RVA: 0x00EF270A File Offset: 0x00EF090A
		public bool IsReached { get; set; }
	}
}
