using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200507C RID: 20604
	[NullableContext(1)]
	public interface IRoleDevProsConfig
	{
		// Token: 0x17008B91 RID: 35729
		// (get) Token: 0x0603520F RID: 217615
		// (set) Token: 0x06035210 RID: 217616
		int Id { get; set; }

		// Token: 0x17008B92 RID: 35730
		// (get) Token: 0x06035211 RID: 217617
		// (set) Token: 0x06035212 RID: 217618
		long ProspectBeginTime { get; set; }

		// Token: 0x17008B93 RID: 35731
		// (get) Token: 0x06035213 RID: 217619
		// (set) Token: 0x06035214 RID: 217620
		long ProspectEndTime { get; set; }

		// Token: 0x17008B94 RID: 35732
		// (get) Token: 0x06035215 RID: 217621
		// (set) Token: 0x06035216 RID: 217622
		int TypeId { get; set; }

		// Token: 0x17008B95 RID: 35733
		// (get) Token: 0x06035217 RID: 217623
		// (set) Token: 0x06035218 RID: 217624
		int GachaId { get; set; }

		// Token: 0x17008B96 RID: 35734
		// (get) Token: 0x06035219 RID: 217625
		// (set) Token: 0x0603521A RID: 217626
		List<IRoleDevProsSpecialGachaConfig> SpecialGachaId { get; set; }

		// Token: 0x17008B97 RID: 35735
		// (get) Token: 0x0603521B RID: 217627
		// (set) Token: 0x0603521C RID: 217628
		int SortId { get; set; }
	}
}
