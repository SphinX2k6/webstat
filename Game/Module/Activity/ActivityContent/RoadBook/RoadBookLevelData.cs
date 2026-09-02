using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x0200648A RID: 25738
	public class RoadBookLevelData : IRoadBookLevelData
	{
		// Token: 0x17009E58 RID: 40536
		// (get) Token: 0x06040914 RID: 264468 RVA: 0x0108CF8F File Offset: 0x0108B18F
		// (set) Token: 0x06040915 RID: 264469 RVA: 0x0108CF97 File Offset: 0x0108B197
		public int Id { get; set; }

		// Token: 0x17009E59 RID: 40537
		// (get) Token: 0x06040916 RID: 264470 RVA: 0x0108CFA0 File Offset: 0x0108B1A0
		// (set) Token: 0x06040917 RID: 264471 RVA: 0x0108CFA8 File Offset: 0x0108B1A8
		public int Level { get; set; }

		// Token: 0x17009E5A RID: 40538
		// (get) Token: 0x06040918 RID: 264472 RVA: 0x0108CFB1 File Offset: 0x0108B1B1
		// (set) Token: 0x06040919 RID: 264473 RVA: 0x0108CFB9 File Offset: 0x0108B1B9
		public int AccumulateExp { get; set; }

		// Token: 0x17009E5B RID: 40539
		// (get) Token: 0x0604091A RID: 264474 RVA: 0x0108CFC2 File Offset: 0x0108B1C2
		// (set) Token: 0x0604091B RID: 264475 RVA: 0x0108CFCA File Offset: 0x0108B1CA
		public int TargetExp { get; set; }
	}
}
