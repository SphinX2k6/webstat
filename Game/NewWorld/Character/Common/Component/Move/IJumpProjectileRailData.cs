using System;
using CSharpScript.Game.NewWorld.Character.Common.Controller;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x0200492F RID: 18735
	public interface IJumpProjectileRailData : IRailParam, IConnectionRailData, IJumpProjectileParams
	{
		// Token: 0x17008372 RID: 33650
		// (get) Token: 0x06030FC3 RID: 200643
		// (set) Token: 0x06030FC4 RID: 200644
		float LastRate { get; set; }

		// Token: 0x17008373 RID: 33651
		// (get) Token: 0x06030FC5 RID: 200645
		// (set) Token: 0x06030FC6 RID: 200646
		float JumpTime { get; set; }
	}
}
