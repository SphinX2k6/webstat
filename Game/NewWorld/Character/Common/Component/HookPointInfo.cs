using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Custom.Components;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x020048FA RID: 18682
	[NullableContext(1)]
	[Nullable(0)]
	public class HookPointInfo
	{
		// Token: 0x06030C95 RID: 199829 RVA: 0x00C0F5E4 File Offset: 0x00C0D7E4
		public HookPointInfo(GrapplingHookPointComponent point, long portalPairId = 0L, bool portalA2B = true)
		{
			this.Point = point;
			this.PortalPairId = portalPairId;
			this.PortalA2B = portalA2B;
		}

		// Token: 0x0401C0A4 RID: 114852
		public GrapplingHookPointComponent Point;

		// Token: 0x0401C0A5 RID: 114853
		public long PortalPairId;

		// Token: 0x0401C0A6 RID: 114854
		public bool PortalA2B = true;
	}
}
