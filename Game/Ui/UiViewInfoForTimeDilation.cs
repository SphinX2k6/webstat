using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049B6 RID: 18870
	[NullableContext(1)]
	[Nullable(0)]
	public class UiViewInfoForTimeDilation : IUiViewInfoForTimeDilation
	{
		// Token: 0x1700840E RID: 33806
		// (get) Token: 0x0603151A RID: 202010 RVA: 0x00C46328 File Offset: 0x00C44528
		// (set) Token: 0x0603151B RID: 202011 RVA: 0x00C46330 File Offset: 0x00C44530
		public float TimeDilation { get; set; }

		// Token: 0x1700840F RID: 33807
		// (get) Token: 0x0603151C RID: 202012 RVA: 0x00C46339 File Offset: 0x00C44539
		// (set) Token: 0x0603151D RID: 202013 RVA: 0x00C46341 File Offset: 0x00C44541
		public int ViewId { get; set; }

		// Token: 0x17008410 RID: 33808
		// (get) Token: 0x0603151E RID: 202014 RVA: 0x00C4634A File Offset: 0x00C4454A
		// (set) Token: 0x0603151F RID: 202015 RVA: 0x00C46352 File Offset: 0x00C44552
		public EUiViewName? DebugName { get; set; }

		// Token: 0x17008411 RID: 33809
		// (get) Token: 0x06031520 RID: 202016 RVA: 0x00C4635B File Offset: 0x00C4455B
		// (set) Token: 0x06031521 RID: 202017 RVA: 0x00C46363 File Offset: 0x00C44563
		public string Reason { get; set; }
	}
}
