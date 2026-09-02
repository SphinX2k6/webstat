using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005024 RID: 20516
	[NullableContext(1)]
	public interface IRoleDevelopConfigData
	{
		// Token: 0x17008AD7 RID: 35543
		// (get) Token: 0x06034DE2 RID: 216546
		// (set) Token: 0x06034DE3 RID: 216547
		List<IRoleDevPropsConfig> DevPropsList { get; set; }
	}
}
