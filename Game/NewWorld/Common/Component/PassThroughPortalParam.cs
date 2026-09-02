using System;
using CSharpScript.Game.NewWorld.Character.Common.Component;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048BE RID: 18622
	public class PassThroughPortalParam
	{
		// Token: 0x060308C7 RID: 198855 RVA: 0x00BECF2C File Offset: 0x00BEB12C
		public PassThroughPortalParam()
		{
		}

		// Token: 0x060308C8 RID: 198856 RVA: 0x00BECF34 File Offset: 0x00BEB134
		public PassThroughPortalParam(CharacterManipulateComponent.EPassThroughPortalType type, long portalPairId, float distance)
		{
			this.Type = type;
			this.PortalPairId = portalPairId;
			this.Distance = distance;
		}

		// Token: 0x0401BE69 RID: 114281
		public CharacterManipulateComponent.EPassThroughPortalType Type;

		// Token: 0x0401BE6A RID: 114282
		public long PortalPairId;

		// Token: 0x0401BE6B RID: 114283
		public float Distance;
	}
}
