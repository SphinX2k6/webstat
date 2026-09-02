using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation
{
	// Token: 0x02006633 RID: 26163
	public class PinballFormationViewData : IPinballFormationViewData
	{
		// Token: 0x17009F6D RID: 40813
		// (get) Token: 0x0604159D RID: 267677 RVA: 0x010C2D1A File Offset: 0x010C0F1A
		// (set) Token: 0x0604159E RID: 267678 RVA: 0x010C2D22 File Offset: 0x010C0F22
		public int LevelId { get; set; }

		// Token: 0x17009F6E RID: 40814
		// (get) Token: 0x0604159F RID: 267679 RVA: 0x010C2D2B File Offset: 0x010C0F2B
		// (set) Token: 0x060415A0 RID: 267680 RVA: 0x010C2D33 File Offset: 0x010C0F33
		public bool? IsRestart { get; set; }

		// Token: 0x17009F6F RID: 40815
		// (get) Token: 0x060415A1 RID: 267681 RVA: 0x010C2D3C File Offset: 0x010C0F3C
		// (set) Token: 0x060415A2 RID: 267682 RVA: 0x010C2D44 File Offset: 0x010C0F44
		public bool? IfReturnToPinballMainView { get; set; }
	}
}
