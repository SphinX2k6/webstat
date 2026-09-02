using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047AC RID: 18348
	[NullableContext(1)]
	public interface ITraceWaterResult
	{
		// Token: 0x170081BA RID: 33210
		// (get) Token: 0x0602F9F2 RID: 195058
		// (set) Token: 0x0602F9F3 RID: 195059
		bool FoundWater { get; set; }

		// Token: 0x170081BB RID: 33211
		// (get) Token: 0x0602F9F4 RID: 195060
		// (set) Token: 0x0602F9F5 RID: 195061
		float MinWaterHeight { get; set; }

		// Token: 0x170081BC RID: 33212
		// (get) Token: 0x0602F9F6 RID: 195062
		// (set) Token: 0x0602F9F7 RID: 195063
		Vector ImpactPoint { get; set; }

		// Token: 0x170081BD RID: 33213
		// (get) Token: 0x0602F9F8 RID: 195064
		// (set) Token: 0x0602F9F9 RID: 195065
		Vector ImpactNormal { get; set; }
	}
}
