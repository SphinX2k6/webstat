using System;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DD3 RID: 19923
	public interface ITrapDefensePauseInfo
	{
		// Token: 0x17008850 RID: 34896
		// (get) Token: 0x06033903 RID: 211203
		// (set) Token: 0x06033904 RID: 211204
		ETrapDefensePauseInfoType Type { get; set; }

		// Token: 0x17008851 RID: 34897
		// (get) Token: 0x06033905 RID: 211205
		// (set) Token: 0x06033906 RID: 211206
		int? Value { get; set; }

		// Token: 0x17008852 RID: 34898
		// (get) Token: 0x06033907 RID: 211207
		// (set) Token: 0x06033908 RID: 211208
		int? MaxBatch { get; set; }
	}
}
