using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DE7 RID: 19943
	[NullableContext(1)]
	public interface ITrapDefenseLevelTargetItemData
	{
		// Token: 0x1700888E RID: 34958
		// (get) Token: 0x06033978 RID: 211320
		ITrapDefenseLevelTargetInfo Info { get; }

		// Token: 0x1700888F RID: 34959
		// (get) Token: 0x06033979 RID: 211321
		int TargetValue { get; }

		// Token: 0x17008890 RID: 34960
		// (get) Token: 0x0603397A RID: 211322
		int TargetStar { get; }

		// Token: 0x17008891 RID: 34961
		// (get) Token: 0x0603397B RID: 211323
		bool IsFinish { get; }
	}
}
