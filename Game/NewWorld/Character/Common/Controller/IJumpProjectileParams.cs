using System;

namespace CSharpScript.Game.NewWorld.Character.Common.Controller
{
	// Token: 0x020048EF RID: 18671
	public interface IJumpProjectileParams
	{
		// Token: 0x170082FA RID: 33530
		// (get) Token: 0x06030BEA RID: 199658
		// (set) Token: 0x06030BEB RID: 199659
		float Length { get; set; }

		// Token: 0x170082FB RID: 33531
		// (get) Token: 0x06030BEC RID: 199660
		// (set) Token: 0x06030BED RID: 199661
		float AllTime { get; set; }

		// Token: 0x170082FC RID: 33532
		// (get) Token: 0x06030BEE RID: 199662
		// (set) Token: 0x06030BEF RID: 199663
		float Height0 { get; set; }

		// Token: 0x170082FD RID: 33533
		// (get) Token: 0x06030BF0 RID: 199664
		// (set) Token: 0x06030BF1 RID: 199665
		float ProjectileA { get; set; }

		// Token: 0x170082FE RID: 33534
		// (get) Token: 0x06030BF2 RID: 199666
		// (set) Token: 0x06030BF3 RID: 199667
		float ProjectileB { get; set; }
	}
}
