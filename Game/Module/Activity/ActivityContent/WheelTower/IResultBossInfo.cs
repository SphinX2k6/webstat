using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x020061FC RID: 25084
	[NullableContext(1)]
	public interface IResultBossInfo
	{
		// Token: 0x17009B67 RID: 39783
		// (get) Token: 0x0603F4C4 RID: 259268
		// (set) Token: 0x0603F4C5 RID: 259269
		IBossItemData BossInfo { get; set; }

		// Token: 0x17009B68 RID: 39784
		// (get) Token: 0x0603F4C6 RID: 259270
		// (set) Token: 0x0603F4C7 RID: 259271
		bool IsDead { get; set; }
	}
}
