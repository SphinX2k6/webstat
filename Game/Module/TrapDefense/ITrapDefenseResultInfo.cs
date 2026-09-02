using System;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DD8 RID: 19928
	public interface ITrapDefenseResultInfo
	{
		// Token: 0x1700885A RID: 34906
		// (get) Token: 0x06033919 RID: 211225
		// (set) Token: 0x0603391A RID: 211226
		int Value { get; set; }

		// Token: 0x1700885B RID: 34907
		// (get) Token: 0x0603391B RID: 211227
		// (set) Token: 0x0603391C RID: 211228
		ETrapDefenseResultType Type { get; set; }

		// Token: 0x1700885C RID: 34908
		// (get) Token: 0x0603391D RID: 211229
		// (set) Token: 0x0603391E RID: 211230
		int? Total { get; set; }

		// Token: 0x1700885D RID: 34909
		// (get) Token: 0x0603391F RID: 211231
		// (set) Token: 0x06033920 RID: 211232
		int? History { get; set; }
	}
}
