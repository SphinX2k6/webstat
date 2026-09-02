using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.GameMainView.TrapDefense
{
	// Token: 0x02005D0E RID: 23822
	[NullableContext(2)]
	[Nullable(0)]
	public class TrapDefenseBossComingTipsData : ITrapDefenseBossComingTipsData
	{
		// Token: 0x1700985D RID: 39005
		// (get) Token: 0x0603C0BB RID: 245947 RVA: 0x00F3B62C File Offset: 0x00F3982C
		// (set) Token: 0x0603C0BC RID: 245948 RVA: 0x00F3B634 File Offset: 0x00F39834
		public Action Callback { get; set; }
	}
}
