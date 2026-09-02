using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x02005094 RID: 20628
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopPhantomSuitData : IRoleDevelopPhantomSuitData
	{
		// Token: 0x17008BCA RID: 35786
		// (get) Token: 0x06035289 RID: 217737 RVA: 0x00D52F69 File Offset: 0x00D51169
		// (set) Token: 0x0603528A RID: 217738 RVA: 0x00D52F71 File Offset: 0x00D51171
		public int DevelopRoleId { get; set; }

		// Token: 0x17008BCB RID: 35787
		// (get) Token: 0x0603528B RID: 217739 RVA: 0x00D52F7A File Offset: 0x00D5117A
		// (set) Token: 0x0603528C RID: 217740 RVA: 0x00D52F82 File Offset: 0x00D51182
		public int FetterGroupId { get; set; }

		// Token: 0x17008BCC RID: 35788
		// (get) Token: 0x0603528D RID: 217741 RVA: 0x00D52F8B File Offset: 0x00D5118B
		// (set) Token: 0x0603528E RID: 217742 RVA: 0x00D52F93 File Offset: 0x00D51193
		public VisionFetterRecommendInfo VisionFetterRecommendInfo { get; set; }

		// Token: 0x17008BCD RID: 35789
		// (get) Token: 0x0603528F RID: 217743 RVA: 0x00D52F9C File Offset: 0x00D5119C
		// (set) Token: 0x06035290 RID: 217744 RVA: 0x00D52FA4 File Offset: 0x00D511A4
		public int? FirstVisionMonsterId { get; set; }

		// Token: 0x17008BCE RID: 35790
		// (get) Token: 0x06035291 RID: 217745 RVA: 0x00D52FAD File Offset: 0x00D511AD
		// (set) Token: 0x06035292 RID: 217746 RVA: 0x00D52FB5 File Offset: 0x00D511B5
		public bool? IsNeedFetterButton { get; set; }
	}
}
