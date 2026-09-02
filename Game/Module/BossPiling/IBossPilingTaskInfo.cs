using System;
using Aki.Protocol;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EE1 RID: 24289
	public interface IBossPilingTaskInfo
	{
		// Token: 0x170099F2 RID: 39410
		// (get) Token: 0x0603D08C RID: 249996
		// (set) Token: 0x0603D08D RID: 249997
		int Id { get; set; }

		// Token: 0x170099F3 RID: 39411
		// (get) Token: 0x0603D08E RID: 249998
		// (set) Token: 0x0603D08F RID: 249999
		int Current { get; set; }

		// Token: 0x170099F4 RID: 39412
		// (get) Token: 0x0603D090 RID: 250000
		// (set) Token: 0x0603D091 RID: 250001
		int Target { get; set; }

		// Token: 0x170099F5 RID: 39413
		// (get) Token: 0x0603D092 RID: 250002
		// (set) Token: 0x0603D093 RID: 250003
		ConditionTaskState Status { get; set; }
	}
}
