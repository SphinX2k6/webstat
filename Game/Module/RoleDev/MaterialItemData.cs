using System;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x0200503B RID: 20539
	public class MaterialItemData : IMaterialItemData
	{
		// Token: 0x17008AF7 RID: 35575
		// (get) Token: 0x06034E2F RID: 216623 RVA: 0x00D46723 File Offset: 0x00D44923
		// (set) Token: 0x06034E30 RID: 216624 RVA: 0x00D4672B File Offset: 0x00D4492B
		public int ItemId { get; set; }

		// Token: 0x17008AF8 RID: 35576
		// (get) Token: 0x06034E31 RID: 216625 RVA: 0x00D46734 File Offset: 0x00D44934
		// (set) Token: 0x06034E32 RID: 216626 RVA: 0x00D4673C File Offset: 0x00D4493C
		public int RequiredCount { get; set; }
	}
}
