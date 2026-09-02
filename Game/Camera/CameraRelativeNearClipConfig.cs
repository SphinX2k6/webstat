using System;

namespace CSharpScript.Game.Camera
{
	// Token: 0x02007095 RID: 28821
	public class CameraRelativeNearClipConfig : CameraBaseNearClipConfig
	{
		// Token: 0x06045DAB RID: 286123 RVA: 0x0124B00D File Offset: 0x0124920D
		public CameraRelativeNearClipConfig(ECameraRelativeNearClipTargetType targetType, float distance) : base(ECameraNearClipType.Relative)
		{
		}

		// Token: 0x040271F3 RID: 160243
		public readonly ECameraRelativeNearClipTargetType TargetType = targetType;

		// Token: 0x040271F4 RID: 160244
		public readonly float Distance = distance;
	}
}
