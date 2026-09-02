using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.GameMainView.TrapDefense
{
	// Token: 0x02005D12 RID: 23826
	[NullableContext(2)]
	[Nullable(0)]
	public class TrapDefenseRoundTipsData : ITrapDefenseRoundTipsData
	{
		// Token: 0x17009864 RID: 39012
		// (get) Token: 0x0603C0CB RID: 245963 RVA: 0x00F3B66F File Offset: 0x00F3986F
		// (set) Token: 0x0603C0CC RID: 245964 RVA: 0x00F3B677 File Offset: 0x00F39877
		public int Round { get; set; }

		// Token: 0x17009865 RID: 39013
		// (get) Token: 0x0603C0CD RID: 245965 RVA: 0x00F3B680 File Offset: 0x00F39880
		// (set) Token: 0x0603C0CE RID: 245966 RVA: 0x00F3B688 File Offset: 0x00F39888
		public Action Callback { get; set; }
	}
}
