using System;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C49 RID: 19529
	public interface IMoveCheckResultAndDistance
	{
		// Token: 0x17008765 RID: 34661
		// (get) Token: 0x06032E2A RID: 208426
		// (set) Token: 0x06032E2B RID: 208427
		EMoveCheckResult Result { get; set; }

		// Token: 0x17008766 RID: 34662
		// (get) Token: 0x06032E2C RID: 208428
		// (set) Token: 0x06032E2D RID: 208429
		float AfterAdjustDistance { get; set; }
	}
}
