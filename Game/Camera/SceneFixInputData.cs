using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070B1 RID: 28849
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneFixInputData
	{
		// Token: 0x06045EF1 RID: 286449 RVA: 0x012537AC File Offset: 0x012519AC
		public SceneFixInputData Set(float pitchLimitMin, float pitchLimitMax, float yawLimitMin, float yawLimitMax, float pitchInputSpeed, float yawInputSpeed)
		{
			this.PitchLimitMin = pitchLimitMin;
			this.PitchLimitMax = pitchLimitMax;
			this.YawLimitMin = yawLimitMin;
			this.YawLimitMax = yawLimitMax;
			this.PitchInputSpeed = pitchInputSpeed;
			this.YawInputSpeed = yawInputSpeed;
			return this;
		}

		// Token: 0x06045EF2 RID: 286450 RVA: 0x012537DC File Offset: 0x012519DC
		public void DeepCopy(SceneFixInputData source)
		{
			this.PitchLimitMin = source.PitchLimitMin;
			this.PitchLimitMax = source.PitchLimitMax;
			this.YawLimitMin = source.YawLimitMin;
			this.YawLimitMax = source.YawLimitMax;
			this.PitchInputSpeed = source.PitchInputSpeed;
			this.YawInputSpeed = source.YawInputSpeed;
		}

		// Token: 0x06045EF3 RID: 286451 RVA: 0x01253834 File Offset: 0x01251A34
		public void Reset()
		{
			this.PitchLimitMin = 0f;
			this.PitchLimitMax = 0f;
			this.YawLimitMin = 0f;
			this.YawLimitMax = 0f;
			this.PitchInputSpeed = 0f;
			this.YawInputSpeed = 0f;
		}

		// Token: 0x040272D1 RID: 160465
		public float PitchLimitMin;

		// Token: 0x040272D2 RID: 160466
		public float PitchLimitMax;

		// Token: 0x040272D3 RID: 160467
		public float YawLimitMin;

		// Token: 0x040272D4 RID: 160468
		public float YawLimitMax;

		// Token: 0x040272D5 RID: 160469
		public float PitchInputSpeed;

		// Token: 0x040272D6 RID: 160470
		public float YawInputSpeed;
	}
}
