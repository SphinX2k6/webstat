using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005025 RID: 20517
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopConfigData : IRoleDevelopConfigData
	{
		// Token: 0x17008AD8 RID: 35544
		// (get) Token: 0x06034DE4 RID: 216548 RVA: 0x00D46549 File Offset: 0x00D44749
		// (set) Token: 0x06034DE5 RID: 216549 RVA: 0x00D46551 File Offset: 0x00D44751
		public List<IRoleDevPropsConfig> DevPropsList { get; set; }
	}
}
