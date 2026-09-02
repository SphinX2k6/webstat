using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x020061FB RID: 25083
	[NullableContext(1)]
	[Nullable(0)]
	public class BossItemData : IBossItemData
	{
		// Token: 0x17009B64 RID: 39780
		// (get) Token: 0x0603F4BD RID: 259261 RVA: 0x0103E681 File Offset: 0x0103C881
		// (set) Token: 0x0603F4BE RID: 259262 RVA: 0x0103E689 File Offset: 0x0103C889
		public IBossInfo BossInfo { get; set; } = new BossInfo();

		// Token: 0x17009B65 RID: 39781
		// (get) Token: 0x0603F4BF RID: 259263 RVA: 0x0103E692 File Offset: 0x0103C892
		// (set) Token: 0x0603F4C0 RID: 259264 RVA: 0x0103E69A File Offset: 0x0103C89A
		public float? StartPercent { get; set; }

		// Token: 0x17009B66 RID: 39782
		// (get) Token: 0x0603F4C1 RID: 259265 RVA: 0x0103E6A3 File Offset: 0x0103C8A3
		// (set) Token: 0x0603F4C2 RID: 259266 RVA: 0x0103E6AB File Offset: 0x0103C8AB
		public bool? ShowBossRound { get; set; }
	}
}
