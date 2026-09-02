using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.GameMainView.TrapDefense
{
	// Token: 0x02005D0F RID: 23823
	[NullableContext(2)]
	public interface ITrapDefenseCountDownTipsData
	{
		// Token: 0x1700985E RID: 39006
		// (get) Token: 0x0603C0BE RID: 245950
		// (set) Token: 0x0603C0BF RID: 245951
		float CountDownTime { get; set; }

		// Token: 0x1700985F RID: 39007
		// (get) Token: 0x0603C0C0 RID: 245952
		// (set) Token: 0x0603C0C1 RID: 245953
		Action Callback { get; set; }
	}
}
