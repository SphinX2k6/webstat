using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200680D RID: 26637
	[NullableContext(1)]
	public interface IFishingDockQuestChildItemData
	{
		// Token: 0x1700A17B RID: 41339
		// (get) Token: 0x06042654 RID: 271956
		// (set) Token: 0x06042655 RID: 271957
		string DesText { get; set; }

		// Token: 0x1700A17C RID: 41340
		// (get) Token: 0x06042656 RID: 271958
		// (set) Token: 0x06042657 RID: 271959
		int MaxCount { get; set; }

		// Token: 0x1700A17D RID: 41341
		// (get) Token: 0x06042658 RID: 271960
		// (set) Token: 0x06042659 RID: 271961
		int CurrentCount { get; set; }
	}
}
