using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x02007088 RID: 28808
	[NullableContext(2)]
	[Nullable(0)]
	public class SeqCameraThings
	{
		// Token: 0x04027151 RID: 160081
		public FVectorDouble CameraLocation = Vector.Create().ToUeVector(false);

		// Token: 0x04027152 RID: 160082
		public FRotator CameraRotation = Rotator.Create().ToUeRotator();

		// Token: 0x04027153 RID: 160083
		public FVectorDouble CameraScale = Vector.Create().ToUeVector(false);

		// Token: 0x04027154 RID: 160084
		public FTransformDouble? OriginRootTransform;

		// Token: 0x04027155 RID: 160085
		public bool ConstrainAspectRatio;

		// Token: 0x04027156 RID: 160086
		public float CurrentAperture;

		// Token: 0x04027157 RID: 160087
		public float CurrentFocalLength;

		// Token: 0x04027158 RID: 160088
		public FCameraFocusSettings FocusSettings;

		// Token: 0x04027159 RID: 160089
		public FCameraLensSettings LensSettings;

		// Token: 0x0402715A RID: 160090
		public float FieldOfView;
	}
}
