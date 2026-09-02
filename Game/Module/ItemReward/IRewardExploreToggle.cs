using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B1E RID: 23326
	[NullableContext(1)]
	public interface IRewardExploreToggle
	{
		// Token: 0x170096CB RID: 38603
		// (get) Token: 0x0603B05A RID: 241754
		// (set) Token: 0x0603B05B RID: 241755
		string DescriptionTextId { get; set; }

		// Token: 0x170096CC RID: 38604
		// (get) Token: 0x0603B05C RID: 241756
		// (set) Token: 0x0603B05D RID: 241757
		[Nullable(2)]
		Action<EToggleState> OnToggleClick { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
