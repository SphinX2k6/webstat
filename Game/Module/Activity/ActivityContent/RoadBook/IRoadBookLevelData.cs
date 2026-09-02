using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x02006489 RID: 25737
	public interface IRoadBookLevelData
	{
		// Token: 0x17009E54 RID: 40532
		// (get) Token: 0x0604090C RID: 264460
		// (set) Token: 0x0604090D RID: 264461
		int Id { get; set; }

		// Token: 0x17009E55 RID: 40533
		// (get) Token: 0x0604090E RID: 264462
		// (set) Token: 0x0604090F RID: 264463
		int Level { get; set; }

		// Token: 0x17009E56 RID: 40534
		// (get) Token: 0x06040910 RID: 264464
		// (set) Token: 0x06040911 RID: 264465
		int AccumulateExp { get; set; }

		// Token: 0x17009E57 RID: 40535
		// (get) Token: 0x06040912 RID: 264466
		// (set) Token: 0x06040913 RID: 264467
		int TargetExp { get; set; }
	}
}
