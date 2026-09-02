using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x020066A1 RID: 26273
	[NullableContext(1)]
	[Nullable(0)]
	public class BuffNodeTweenData
	{
		// Token: 0x1700A02D RID: 41005
		// (get) Token: 0x060419C0 RID: 268736 RVA: 0x010D2A2F File Offset: 0x010D0C2F
		// (set) Token: 0x060419C1 RID: 268737 RVA: 0x010D2A37 File Offset: 0x010D0C37
		public float Percentage { get; set; }

		// Token: 0x1700A02E RID: 41006
		// (get) Token: 0x060419C2 RID: 268738 RVA: 0x010D2A40 File Offset: 0x010D0C40
		// (set) Token: 0x060419C3 RID: 268739 RVA: 0x010D2A48 File Offset: 0x010D0C48
		public MowingBuffUnit BuffNodeItem { get; set; }

		// Token: 0x060419C4 RID: 268740 RVA: 0x010D2A51 File Offset: 0x010D0C51
		public BuffNodeTweenData(float percentage, MowingBuffUnit buffNodeItem)
		{
			this.Percentage = percentage;
			this.BuffNodeItem = buffNodeItem;
		}
	}
}
