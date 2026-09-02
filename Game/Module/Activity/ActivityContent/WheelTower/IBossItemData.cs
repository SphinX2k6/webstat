using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x020061FA RID: 25082
	[NullableContext(1)]
	public interface IBossItemData
	{
		// Token: 0x17009B61 RID: 39777
		// (get) Token: 0x0603F4B7 RID: 259255
		// (set) Token: 0x0603F4B8 RID: 259256
		IBossInfo BossInfo { get; set; }

		// Token: 0x17009B62 RID: 39778
		// (get) Token: 0x0603F4B9 RID: 259257
		// (set) Token: 0x0603F4BA RID: 259258
		float? StartPercent { get; set; }

		// Token: 0x17009B63 RID: 39779
		// (get) Token: 0x0603F4BB RID: 259259
		// (set) Token: 0x0603F4BC RID: 259260
		bool? ShowBossRound { get; set; }
	}
}
