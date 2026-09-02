using System;

namespace CSharpScript.Game.Camera
{
	// Token: 0x02007096 RID: 28822
	public class CameraAbsoluteNearClipConfig : CameraBaseNearClipConfig
	{
		// Token: 0x06045DAC RID: 286124 RVA: 0x0124B024 File Offset: 0x01249224
		public CameraAbsoluteNearClipConfig(float distance) : base(ECameraNearClipType.Absolute)
		{
		}

		// Token: 0x040271F5 RID: 160245
		public readonly float Distance = distance;
	}
}
