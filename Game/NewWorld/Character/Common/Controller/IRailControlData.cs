using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Controller
{
	// Token: 0x020048F3 RID: 18675
	[NullableContext(1)]
	public interface IRailControlData
	{
		// Token: 0x17008314 RID: 33556
		// (get) Token: 0x06030C20 RID: 199712
		// (set) Token: 0x06030C21 RID: 199713
		float Rad { get; set; }

		// Token: 0x17008315 RID: 33557
		// (get) Token: 0x06030C22 RID: 199714
		// (set) Token: 0x06030C23 RID: 199715
		float AngularVelocity { get; set; }

		// Token: 0x17008316 RID: 33558
		// (get) Token: 0x06030C24 RID: 199716
		// (set) Token: 0x06030C25 RID: 199717
		float Damping { get; set; }

		// Token: 0x17008317 RID: 33559
		// (get) Token: 0x06030C26 RID: 199718
		// (set) Token: 0x06030C27 RID: 199719
		float MaxAngularVelocity { get; set; }

		// Token: 0x17008318 RID: 33560
		// (get) Token: 0x06030C28 RID: 199720
		// (set) Token: 0x06030C29 RID: 199721
		float MaxLinearVelocity { get; set; }

		// Token: 0x17008319 RID: 33561
		// (get) Token: 0x06030C2A RID: 199722
		// (set) Token: 0x06030C2B RID: 199723
		bool IgnoreMaxAngle { get; set; }

		// Token: 0x1700831A RID: 33562
		// (get) Token: 0x06030C2C RID: 199724
		// (set) Token: 0x06030C2D RID: 199725
		float RegressionSpeed { get; set; }

		// Token: 0x1700831B RID: 33563
		// (get) Token: 0x06030C2E RID: 199726
		// (set) Token: 0x06030C2F RID: 199727
		float InputCoefficient { get; set; }

		// Token: 0x1700831C RID: 33564
		// (get) Token: 0x06030C30 RID: 199728
		// (set) Token: 0x06030C31 RID: 199729
		float MaxAngle { get; set; }

		// Token: 0x1700831D RID: 33565
		// (get) Token: 0x06030C32 RID: 199730
		// (set) Token: 0x06030C33 RID: 199731
		float Radius { get; set; }

		// Token: 0x1700831E RID: 33566
		// (get) Token: 0x06030C34 RID: 199732
		// (set) Token: 0x06030C35 RID: 199733
		bool InnerArc { get; set; }

		// Token: 0x1700831F RID: 33567
		// (get) Token: 0x06030C36 RID: 199734
		// (set) Token: 0x06030C37 RID: 199735
		float HalfHeight { get; set; }

		// Token: 0x17008320 RID: 33568
		// (get) Token: 0x06030C38 RID: 199736
		Vector ToCenterVector { get; }

		// Token: 0x17008321 RID: 33569
		// (get) Token: 0x06030C39 RID: 199737
		Vector SplineForwardVector { get; }

		// Token: 0x17008322 RID: 33570
		// (get) Token: 0x06030C3A RID: 199738
		Vector CenterLocation { get; }

		// Token: 0x17008323 RID: 33571
		// (get) Token: 0x06030C3B RID: 199739
		Vector DefaultLocation { get; }

		// Token: 0x06030C3C RID: 199740
		float GetLimitLinearVelocity();
	}
}
