using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004688 RID: 18056
	public class IUdpRegion
	{
		// Token: 0x0401ACC0 RID: 109760
		[Nullable(1)]
		public List<IUdpProbe> Probe;

		// Token: 0x0401ACC1 RID: 109761
		public int ProbeInterval;

		// Token: 0x0401ACC2 RID: 109762
		public bool ProbeOpen;
	}
}
