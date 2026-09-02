using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x0200660A RID: 26122
	[NullableContext(1)]
	public interface IPinballItemSyncMonsterGridViewData
	{
		// Token: 0x17009F3B RID: 40763
		// (get) Token: 0x0604145F RID: 267359
		// (set) Token: 0x06041460 RID: 267360
		IPinballItemDataMonster ItemData { get; set; }

		// Token: 0x17009F3C RID: 40764
		// (get) Token: 0x06041461 RID: 267361
		// (set) Token: 0x06041462 RID: 267362
		bool IsSelected { get; set; }

		// Token: 0x17009F3D RID: 40765
		// (get) Token: 0x06041463 RID: 267363
		// (set) Token: 0x06041464 RID: 267364
		Action<IPinballItemToggleCallback> OnStateChangeDelegate { get; set; }
	}
}
