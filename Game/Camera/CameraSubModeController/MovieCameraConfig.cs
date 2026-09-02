using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;

namespace CSharpScript.Game.Camera.CameraSubModeController
{
	// Token: 0x020070CA RID: 28874
	public class MovieCameraConfig
	{
		// Token: 0x06045FEB RID: 286699 RVA: 0x0125E3EB File Offset: 0x0125C5EB
		[NullableContext(1)]
		public void Init(BP_MovieCameraConfig_C asset)
		{
			this.SmoothFactor = asset.ZSmoothFactor;
			this.SmoothDelta = asset.ZSmoothDelta;
		}

		// Token: 0x04027407 RID: 160775
		public float SmoothFactor = 10f;

		// Token: 0x04027408 RID: 160776
		public float SmoothDelta;
	}
}
