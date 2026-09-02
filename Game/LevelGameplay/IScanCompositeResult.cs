using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A35 RID: 27189
	[NullableContext(1)]
	public interface IScanCompositeResult
	{
		// Token: 0x1700A23D RID: 41533
		// (get) Token: 0x06043498 RID: 275608
		// (set) Token: 0x06043499 RID: 275609
		List<GamePlayScan> ScanInfos { get; set; }

		// Token: 0x1700A23E RID: 41534
		// (get) Token: 0x0604349A RID: 275610
		// (set) Token: 0x0604349B RID: 275611
		float Interval { get; set; }

		// Token: 0x1700A23F RID: 41535
		// (get) Token: 0x0604349C RID: 275612
		// (set) Token: 0x0604349D RID: 275613
		GamePlayScanComposite ScanCompositeConfig { get; set; }
	}
}
