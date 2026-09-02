using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B1F RID: 23327
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreToggleData : IRewardExploreToggle
	{
		// Token: 0x170096CD RID: 38605
		// (get) Token: 0x0603B05E RID: 241758 RVA: 0x00EF271B File Offset: 0x00EF091B
		// (set) Token: 0x0603B05F RID: 241759 RVA: 0x00EF2723 File Offset: 0x00EF0923
		public string DescriptionTextId { get; set; }

		// Token: 0x170096CE RID: 38606
		// (get) Token: 0x0603B060 RID: 241760 RVA: 0x00EF272C File Offset: 0x00EF092C
		// (set) Token: 0x0603B061 RID: 241761 RVA: 0x00EF2734 File Offset: 0x00EF0934
		[Nullable(2)]
		public Action<EToggleState> OnToggleClick { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
