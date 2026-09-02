using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x0200660B RID: 26123
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballItemSyncMonsterGridViewData : IPinballItemSyncMonsterGridViewData
	{
		// Token: 0x17009F3E RID: 40766
		// (get) Token: 0x06041465 RID: 267365 RVA: 0x010BF55D File Offset: 0x010BD75D
		// (set) Token: 0x06041466 RID: 267366 RVA: 0x010BF565 File Offset: 0x010BD765
		public IPinballItemDataMonster ItemData { get; set; }

		// Token: 0x17009F3F RID: 40767
		// (get) Token: 0x06041467 RID: 267367 RVA: 0x010BF56E File Offset: 0x010BD76E
		// (set) Token: 0x06041468 RID: 267368 RVA: 0x010BF576 File Offset: 0x010BD776
		public bool IsSelected { get; set; }

		// Token: 0x17009F40 RID: 40768
		// (get) Token: 0x06041469 RID: 267369 RVA: 0x010BF57F File Offset: 0x010BD77F
		// (set) Token: 0x0604146A RID: 267370 RVA: 0x010BF587 File Offset: 0x010BD787
		public Action<IPinballItemToggleCallback> OnStateChangeDelegate { get; set; }
	}
}
