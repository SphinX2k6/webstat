using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ED4 RID: 28372
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabCameraConfig
	{
		// Token: 0x06044BFF RID: 281599 RVA: 0x011DE490 File Offset: 0x011DC690
		public DollGrabCameraConfig(Vector cameraLocation, Rotator cameraRotation, float fadeInTime, float fadeOutTime, bool isDisableCollision, bool isDisableDither, float fov)
		{
			this.CameraLocation.DeepCopy(cameraLocation);
			this.CameraRotation.DeepCopy(cameraRotation);
			this.FadeInTime = fadeInTime;
			this.FadeOutTime = fadeOutTime;
			this.IsDisableCollision = isDisableCollision;
			this.IsDisableDither = isDisableDither;
			this.Fov = fov;
		}

		// Token: 0x040264A3 RID: 156835
		public Vector CameraLocation = Vector.Create();

		// Token: 0x040264A4 RID: 156836
		public Rotator CameraRotation = Rotator.Create();

		// Token: 0x040264A5 RID: 156837
		public float FadeInTime;

		// Token: 0x040264A6 RID: 156838
		public float FadeOutTime;

		// Token: 0x040264A7 RID: 156839
		public bool IsDisableCollision;

		// Token: 0x040264A8 RID: 156840
		public bool IsDisableDither;

		// Token: 0x040264A9 RID: 156841
		public float Fov;
	}
}
