using System;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x02005097 RID: 20631
	public class DropRewardItemData : IDropRewardItemData
	{
		// Token: 0x17008BD2 RID: 35794
		// (get) Token: 0x0603529A RID: 217754 RVA: 0x00D52FC6 File Offset: 0x00D511C6
		// (set) Token: 0x0603529B RID: 217755 RVA: 0x00D52FCE File Offset: 0x00D511CE
		public int ItemId { get; set; }

		// Token: 0x17008BD3 RID: 35795
		// (get) Token: 0x0603529C RID: 217756 RVA: 0x00D52FD7 File Offset: 0x00D511D7
		// (set) Token: 0x0603529D RID: 217757 RVA: 0x00D52FDF File Offset: 0x00D511DF
		public int Count { get; set; }

		// Token: 0x17008BD4 RID: 35796
		// (get) Token: 0x0603529E RID: 217758 RVA: 0x00D52FE8 File Offset: 0x00D511E8
		// (set) Token: 0x0603529F RID: 217759 RVA: 0x00D52FF0 File Offset: 0x00D511F0
		public bool HaveFinish { get; set; }
	}
}
