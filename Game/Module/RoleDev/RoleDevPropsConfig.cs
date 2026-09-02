using System;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005023 RID: 20515
	public class RoleDevPropsConfig : IRoleDevPropsConfig
	{
		// Token: 0x17008AD4 RID: 35540
		// (get) Token: 0x06034DDB RID: 216539 RVA: 0x00D4650E File Offset: 0x00D4470E
		// (set) Token: 0x06034DDC RID: 216540 RVA: 0x00D46516 File Offset: 0x00D44716
		public int Id { get; set; }

		// Token: 0x17008AD5 RID: 35541
		// (get) Token: 0x06034DDD RID: 216541 RVA: 0x00D4651F File Offset: 0x00D4471F
		// (set) Token: 0x06034DDE RID: 216542 RVA: 0x00D46527 File Offset: 0x00D44727
		public long ProspectBeginTime { get; set; }

		// Token: 0x17008AD6 RID: 35542
		// (get) Token: 0x06034DDF RID: 216543 RVA: 0x00D46530 File Offset: 0x00D44730
		// (set) Token: 0x06034DE0 RID: 216544 RVA: 0x00D46538 File Offset: 0x00D44738
		public long ProspectEndTime { get; set; }
	}
}
