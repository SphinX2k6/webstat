using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006800 RID: 26624
	public class FishingReward : IFishingReward
	{
		// Token: 0x1700A152 RID: 41298
		// (get) Token: 0x060425EE RID: 271854 RVA: 0x01104690 File Offset: 0x01102890
		// (set) Token: 0x060425EF RID: 271855 RVA: 0x01104698 File Offset: 0x01102898
		public int Id { get; set; }

		// Token: 0x1700A153 RID: 41299
		// (get) Token: 0x060425F0 RID: 271856 RVA: 0x011046A1 File Offset: 0x011028A1
		// (set) Token: 0x060425F1 RID: 271857 RVA: 0x011046A9 File Offset: 0x011028A9
		public int Current { get; set; }

		// Token: 0x1700A154 RID: 41300
		// (get) Token: 0x060425F2 RID: 271858 RVA: 0x011046B2 File Offset: 0x011028B2
		// (set) Token: 0x060425F3 RID: 271859 RVA: 0x011046BA File Offset: 0x011028BA
		public int Target { get; set; }

		// Token: 0x1700A155 RID: 41301
		// (get) Token: 0x060425F4 RID: 271860 RVA: 0x011046C3 File Offset: 0x011028C3
		// (set) Token: 0x060425F5 RID: 271861 RVA: 0x011046CB File Offset: 0x011028CB
		public bool IsFinished { get; set; }

		// Token: 0x1700A156 RID: 41302
		// (get) Token: 0x060425F6 RID: 271862 RVA: 0x011046D4 File Offset: 0x011028D4
		// (set) Token: 0x060425F7 RID: 271863 RVA: 0x011046DC File Offset: 0x011028DC
		public bool IsTaken { get; set; }
	}
}
