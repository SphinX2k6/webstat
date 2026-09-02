using System;

namespace CSharpScript.Game.Camera
{
	// Token: 0x02007093 RID: 28819
	public abstract class CameraBaseNearClipConfig
	{
		// Token: 0x06045DAA RID: 286122 RVA: 0x0124AFFE File Offset: 0x012491FE
		protected CameraBaseNearClipConfig(ECameraNearClipType nearClipType)
		{
		}

		// Token: 0x040271F0 RID: 160240
		public readonly ECameraNearClipType NearClipType = nearClipType;
	}
}
