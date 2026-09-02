using System;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x0200503D RID: 20541
	public class DropRewardItemData : IDropRewardItemData
	{
		// Token: 0x17008AFC RID: 35580
		// (get) Token: 0x06034E3A RID: 216634 RVA: 0x00D4674D File Offset: 0x00D4494D
		// (set) Token: 0x06034E3B RID: 216635 RVA: 0x00D46755 File Offset: 0x00D44955
		public int ItemId { get; set; }

		// Token: 0x17008AFD RID: 35581
		// (get) Token: 0x06034E3C RID: 216636 RVA: 0x00D4675E File Offset: 0x00D4495E
		// (set) Token: 0x06034E3D RID: 216637 RVA: 0x00D46766 File Offset: 0x00D44966
		public int Count { get; set; }

		// Token: 0x17008AFE RID: 35582
		// (get) Token: 0x06034E3E RID: 216638 RVA: 0x00D4676F File Offset: 0x00D4496F
		// (set) Token: 0x06034E3F RID: 216639 RVA: 0x00D46777 File Offset: 0x00D44977
		public bool HaveFinish { get; set; }
	}
}
