using System;

namespace CSharpScript.Game.NewWorld.Character.Common.Controller
{
	// Token: 0x020048F1 RID: 18673
	public interface IProjectileJumpConfig
	{
		// Token: 0x17008304 RID: 33540
		// (get) Token: 0x06030BFF RID: 199679
		// (set) Token: 0x06030C00 RID: 199680
		float BaseJumpHeight { get; set; }

		// Token: 0x17008305 RID: 33541
		// (get) Token: 0x06030C01 RID: 199681
		// (set) Token: 0x06030C02 RID: 199682
		float BaseJumpDistanceRate { get; set; }

		// Token: 0x17008306 RID: 33542
		// (get) Token: 0x06030C03 RID: 199683
		// (set) Token: 0x06030C04 RID: 199684
		float MaxJumpDistance { get; set; }

		// Token: 0x17008307 RID: 33543
		// (get) Token: 0x06030C05 RID: 199685
		// (set) Token: 0x06030C06 RID: 199686
		float MaxJumpHeight { get; set; }

		// Token: 0x17008308 RID: 33544
		// (get) Token: 0x06030C07 RID: 199687
		// (set) Token: 0x06030C08 RID: 199688
		float JumpAcceleration { get; set; }

		// Token: 0x17008309 RID: 33545
		// (get) Token: 0x06030C09 RID: 199689
		// (set) Token: 0x06030C0A RID: 199690
		float TargetSpeedForJump { get; set; }

		// Token: 0x1700830A RID: 33546
		// (get) Token: 0x06030C0B RID: 199691
		// (set) Token: 0x06030C0C RID: 199692
		float AllTimeForJump { get; set; }

		// Token: 0x1700830B RID: 33547
		// (get) Token: 0x06030C0D RID: 199693
		// (set) Token: 0x06030C0E RID: 199694
		float JumpBlendTime { get; set; }
	}
}
