using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.GameMainView.TrapDefense
{
	// Token: 0x02005D10 RID: 23824
	[NullableContext(2)]
	[Nullable(0)]
	public class TrapDefenseCountDownTipsData : ITrapDefenseCountDownTipsData
	{
		// Token: 0x17009860 RID: 39008
		// (get) Token: 0x0603C0C2 RID: 245954 RVA: 0x00F3B645 File Offset: 0x00F39845
		// (set) Token: 0x0603C0C3 RID: 245955 RVA: 0x00F3B64D File Offset: 0x00F3984D
		public float CountDownTime { get; set; }

		// Token: 0x17009861 RID: 39009
		// (get) Token: 0x0603C0C4 RID: 245956 RVA: 0x00F3B656 File Offset: 0x00F39856
		// (set) Token: 0x0603C0C5 RID: 245957 RVA: 0x00F3B65E File Offset: 0x00F3985E
		public Action Callback { get; set; }
	}
}
