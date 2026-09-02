using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006968 RID: 26984
	[NullableContext(1)]
	[Nullable(0)]
	public class AdamSmasherStageItemData : IAdamSmasherStageItemData
	{
		// Token: 0x1700A1D4 RID: 41428
		// (get) Token: 0x06042F4E RID: 274254 RVA: 0x01130C28 File Offset: 0x0112EE28
		// (set) Token: 0x06042F4F RID: 274255 RVA: 0x01130C30 File Offset: 0x0112EE30
		public int StageId { get; set; }

		// Token: 0x1700A1D5 RID: 41429
		// (get) Token: 0x06042F50 RID: 274256 RVA: 0x01130C39 File Offset: 0x0112EE39
		// (set) Token: 0x06042F51 RID: 274257 RVA: 0x01130C41 File Offset: 0x0112EE41
		public string IndexText { get; set; } = "";

		// Token: 0x1700A1D6 RID: 41430
		// (get) Token: 0x06042F52 RID: 274258 RVA: 0x01130C4A File Offset: 0x0112EE4A
		// (set) Token: 0x06042F53 RID: 274259 RVA: 0x01130C52 File Offset: 0x0112EE52
		public string Name { get; set; } = "";

		// Token: 0x1700A1D7 RID: 41431
		// (get) Token: 0x06042F54 RID: 274260 RVA: 0x01130C5B File Offset: 0x0112EE5B
		// (set) Token: 0x06042F55 RID: 274261 RVA: 0x01130C63 File Offset: 0x0112EE63
		public bool IsUnlocked { get; set; }

		// Token: 0x1700A1D8 RID: 41432
		// (get) Token: 0x06042F56 RID: 274262 RVA: 0x01130C6C File Offset: 0x0112EE6C
		// (set) Token: 0x06042F57 RID: 274263 RVA: 0x01130C74 File Offset: 0x0112EE74
		public bool IsHard { get; set; }
	}
}
